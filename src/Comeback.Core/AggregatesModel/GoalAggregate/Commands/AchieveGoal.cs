// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Comeback.Core.AggregatesModel.GoalAggregate.Commands;

public class AchieveGoalValidator : AbstractValidator<AchieveGoalRequest>
{
    public AchieveGoalValidator()
    {
        RuleFor(x => x.GoalId).NotEqual(default(Guid));
    }

}

public class AchieveGoalRequest : IRequest<AchieveGoalResponse>
{
    public Guid GoalId { get; set; }
}

public class AchieveGoalResponse : ResponseBase
{
    public GoalDto Goal { get; set; }
}

public class AchieveGoalHandler : IRequestHandler<AchieveGoalRequest, AchieveGoalResponse>
{
    private readonly IComebackDbContext _context;

    public AchieveGoalHandler(IComebackDbContext context)
        => _context = context;

    public async Task<AchieveGoalResponse> Handle(AchieveGoalRequest request, CancellationToken cancellationToken)
    {
        var goal = await _context.Goals.SingleAsync(x => x.GoalId == request.GoalId);

        goal.Achieved();

        await _context.SaveChangesAsync(cancellationToken);

        return new AchieveGoalResponse()
        {
            Goal = goal.ToDto()
        };
    }

}


