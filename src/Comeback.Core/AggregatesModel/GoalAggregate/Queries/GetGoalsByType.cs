// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using MediatR;

namespace Comeback.Core.AggregatesModel.GoalAggregate.Queries;

public class GetGoalsByTypeRequest : IRequest<GetGoalsByTypeResponse>
{
    public GoalType Type { get; set; }
}

public class GetGoalsByTypeResponse
{
    public List<GoalDto> Goals { get; set; }
}

public class GetGoalsByTypeHandler : IRequestHandler<GetGoalsByTypeRequest, GetGoalsByTypeResponse>
{
    private readonly IComebackDbContext _context;

    public GetGoalsByTypeHandler(IComebackDbContext context)
    {
        _context = context;
    }

    public async Task<GetGoalsByTypeResponse> Handle(GetGoalsByTypeRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            Goals = _context.Goals
            .Where(x => x.Type == request.Type)
            .Select(x => x.ToDto()).ToList()
        };
    }
}


