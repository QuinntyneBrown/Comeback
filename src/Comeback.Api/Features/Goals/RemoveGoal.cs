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
    public class RemoveGoal
    {
        public class Request: IRequest<Response>
        {
            public Guid GoalId { get; set; }
        }

        public class Response: ResponseBase
        {
            public GoalDto Goal { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IComebackDbContext _context;
        
            public Handler(IComebackDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var goal = await _context.Goals.SingleAsync(x => x.GoalId == request.GoalId);
                
                _context.Goals.Remove(goal);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Goal = goal.ToDto()
                };
            }
            
        }
    }
}
