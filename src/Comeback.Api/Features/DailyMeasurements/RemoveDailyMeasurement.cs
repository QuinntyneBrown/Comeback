using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Comeback.Api.Models;
using Comeback.Api.Core;
using Comeback.Api.Interfaces;

namespace Comeback.Api.Features
{
    public class RemoveDailyMeasurement
    {
        public class Request: IRequest<Response>
        {
            public Guid DailyMeasurementId { get; set; }
        }

        public class Response: ResponseBase
        {
            public DailyMeasurementDto DailyMeasurement { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IComebackDbContext _context;
        
            public Handler(IComebackDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var dailyMeasurement = await _context.DailyMeasurements.SingleAsync(x => x.DailyMeasurementId == request.DailyMeasurementId);
                
                _context.DailyMeasurements.Remove(dailyMeasurement);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    DailyMeasurement = dailyMeasurement.ToDto()
                };
            }
            
        }
    }
}
