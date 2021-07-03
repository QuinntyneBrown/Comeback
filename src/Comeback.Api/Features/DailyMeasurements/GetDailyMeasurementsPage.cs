using Comeback.Api.Core;
using Comeback.Api.Extensions;
using Comeback.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Comeback.Api.Features
{
    public class GetDailyMeasurementsPage
    {
        public class Request : IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response : ResponseBase
        {
            public int Length { get; set; }
            public List<DailyMeasurementDto> Entities { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IComebackDbContext _context;

            public Handler(IComebackDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from dailyMeasurement in _context.DailyMeasurements
                            select dailyMeasurement;

                var length = await _context.DailyMeasurements.CountAsync();

                var dailyMeasurements = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();

                return new()
                {
                    Length = length,
                    Entities = dailyMeasurements
                };
            }

        }
    }
}
