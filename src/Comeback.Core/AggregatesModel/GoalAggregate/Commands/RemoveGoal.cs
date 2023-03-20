// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace Comeback.Core.AggregatesModel.GoalAggregate.Commands;

public class RemoveGoalRequest : IRequest<RemoveGoalResponse>
{
    public Guid GoalId { get; set; }
}

public class RemoveGoalResponse : ResponseBase
{
    public GoalDto Goal { get; set; }
}

public class RemoveGoalHandler : IRequestHandler<RemoveGoalRequest, RemoveGoalResponse>
{
    private readonly IComebackDbContext _context;

    public RemoveGoalHandler(IComebackDbContext context)
        => _context = context;

    public async Task<RemoveGoalResponse> Handle(RemoveGoalRequest request, CancellationToken cancellationToken)
    {
        var goal = await _context.Goals.SingleAsync(x => x.GoalId == request.GoalId);

        _context.Goals.Remove(goal);

        await _context.SaveChangesAsync(cancellationToken);

        return new RemoveGoalResponse()
        {
            Goal = goal.ToDto()
        };
    }

}


