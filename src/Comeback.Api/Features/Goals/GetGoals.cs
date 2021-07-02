using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Comeback.Api.Core;
using Comeback.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Comeback.Api.Features
{
    public class GetGoals
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<GoalDto> Goals { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IComebackDbContext _context;
        
            public Handler(IComebackDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Goals = await _context.Goals.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
