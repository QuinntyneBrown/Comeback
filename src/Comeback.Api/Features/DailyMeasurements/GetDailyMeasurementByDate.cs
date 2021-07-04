using Comeback.Api.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Comeback.Api.Features
{
    public class GetDailyMeasurementByDate
    {
        public class Request : IRequest<Response> {
            public DateTime Date { get; set; } = DateTime.UtcNow.Date;
        }

        public class Response
        {
            public DailyMeasurementDto DailyMeasurement { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IComebackDbContext _context;

            public Handler(IComebackDbContext context){
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
			    return new () { 
                    DailyMeasurement = _context.DailyMeasurements
                    .Where(x => x.Date.Date == request.Date)
                    .Select(x => x.ToDto()).FirstOrDefault()
                };
            }
        }
    }
}
