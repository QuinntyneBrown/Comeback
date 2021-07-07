using Comeback.Api.Interfaces;
using Comeback.Api.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Comeback.Api.Features
{
    public class GetGoalsByType
    {
        public class Request : IRequest<Response>
        {
            public GoalType Type { get; set; }
        }

        public class Response
        {
            public List<GoalDto> Goals { get; set; }
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
                return new()
                {
                    Goals = _context.Goals
                    .Where(x => x.Type == request.Type)
                    .Select(x => x.ToDto()).ToList()
                };
            }
        }
    }
}
