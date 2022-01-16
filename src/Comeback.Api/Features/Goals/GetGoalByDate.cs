using Comeback.Api.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.Decimal;

namespace Comeback.Api.Features
{
    public class GetGoalByDate
    {
        public class Request : IRequest<Response>
        {
            public DateTime Date { get; set; } = DateTime.UtcNow.Date;
        }

        public class Response
        {
            public GoalDto Goal { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IComebackDbContext _context;

            public Handler(IComebackDbContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {

                var measurement = _context.DailyMeasurements.FirstOrDefault();

                var days = Truncate(Convert.ToDecimal((request.Date - measurement.Date).TotalDays + 1));

                return new()
                {
                    Goal = new GoalDto
                    {
                        Name = "Date",
                        Date = DateTime.UtcNow,
                        Weight = measurement.Weight - days * 0.4m
                    }
                };
            }
        }
    }
}
