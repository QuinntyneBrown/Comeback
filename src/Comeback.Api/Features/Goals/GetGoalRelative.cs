using Comeback.Api.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.Decimal;

namespace Comeback.Api.Features
{
    public class GetGoalRelative
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public GoalDto Goal { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IComebackDbContext _context;

            public Handler(IComebackDbContext context){
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {

                var last = _context.DailyMeasurements
                    .OrderBy(x => x.Date)
                    .Last();

                var s = last.Date.Date == DateTime.UtcNow.AddDays(-1).Date;

                var measurement = _context.DailyMeasurements
                    .Where(x => x.Date.Date == DateTime.UtcNow.AddDays(-1).Date)
                    .Single();

			    return new () { 
                    Goal = new GoalDto
                    {
                        Name = "Relative",
                        Date = DateTime.UtcNow,
                        Weight = measurement.Weight - 0.5m
                    }
                };
            }
        }
    }
}
