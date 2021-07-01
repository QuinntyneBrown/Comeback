using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Comeback.Api.Core;
using Comeback.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Comeback.Api.Features
{
    public class GetDailyMeasurementById
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
                return new () {
                    DailyMeasurement = (await _context.DailyMeasurements.SingleOrDefaultAsync(x => x.DailyMeasurementId == request.DailyMeasurementId)).ToDto()
                };
            }
            
        }
    }
}
