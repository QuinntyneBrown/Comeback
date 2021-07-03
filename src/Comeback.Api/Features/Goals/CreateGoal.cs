using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Comeback.Api.Models;
using Comeback.Api.Core;
using Comeback.Api.Interfaces;

namespace Comeback.Api.Features
{
    public class CreateGoal
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Goal).NotNull();
                RuleFor(request => request.Goal).SetValidator(new GoalValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public GoalDto Goal { get; set; }
        }

        public class Response : ResponseBase
        {
            public GoalDto Goal { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IComebackDbContext _context;

            public Handler(IComebackDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var goal = new Goal(
                    request.Goal.Name,
                    request.Goal.Date,
                    request.Goal.Weight,
                    request.Goal.Description);

                _context.Goals.Add(goal);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Goal = goal.ToDto()
                };
            }

        }
    }
}
