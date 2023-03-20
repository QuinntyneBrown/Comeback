// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Comeback.Core.AggregatesModel.GoalAggregate.Queries;

public class GetGoalByIdRequest : IRequest<GetGoalByIdResponse>
{
    public Guid GoalId { get; set; }
}

public class GetGoalByIdResponse : ResponseBase
{
    public GoalDto Goal { get; set; }
}

public class GetGoalByIdHandler : IRequestHandler<GetGoalByIdRequest, GetGoalByIdResponse>
{
    private readonly IComebackDbContext _context;

    public GetGoalByIdHandler(IComebackDbContext context)
        => _context = context;

    public async Task<GetGoalByIdResponse> Handle(GetGoalByIdRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            Goal = (await _context.Goals.SingleOrDefaultAsync(x => x.GoalId == request.GoalId)).ToDto()
        };
    }

}


