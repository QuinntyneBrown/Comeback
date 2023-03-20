// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Comeback.Core.Kernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Comeback.Core.AggregateModel.GoalAggregate.Queries;

public class GetGoalsPageRequest : IRequest<GetGoalsPageResponse>
{
    public int PageSize { get; set; }
    public int Index { get; set; }
}

public class GetGoalsPageResponse : ResponseBase
{
    public int Length { get; set; }
    public List<GoalDto> Entities { get; set; }
}

public class GetGoalsPageHandler : IRequestHandler<GetGoalsPageRequest, GetGoalsPageResponse>
{
    private readonly IComebackDbContext _context;

    public GetGoalsPageHandler(IComebackDbContext context)
        => _context = context;

    public async Task<GetGoalsPageResponse> Handle(GetGoalsPageRequest request, CancellationToken cancellationToken)
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


