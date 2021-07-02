using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Comeback.Api.Extensions;
using Comeback.Api.Core;
using Comeback.Api.Interfaces;
using Comeback.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Comeback.Api.Features
{
    public class GetGoalsPage
    {
        public class Request: IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response: ResponseBase
        {
            public int Length { get; set; }
            public List<GoalDto> Entities { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IComebackDbContext _context;
        
            public Handler(IComebackDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from goal in _context.Goals
                    select goal;
                
                var length = await _context.Goals.CountAsync();
                
                var goals = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();
                
                return new()
                {
                    Length = length,
                    Entities = goals
                };
            }
            
        }
    }
}
