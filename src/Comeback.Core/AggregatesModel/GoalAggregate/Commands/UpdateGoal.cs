// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Comeback.Core.AggregatesModel.GoalAggregate.Commands;

public class UpdateGoalValidator : AbstractValidator<UpdateGoalRequest>
{
    public UpdateGoalValidator()
    {
        RuleFor(x => x.GoalId).NotNull().NotEmpty();
        RuleFor(x => x.Description).NotNull().NotEmpty();
    }

}

public class UpdateGoalRequest : IRequest<UpdateGoalResponse>
{
    public Guid GoalId { get; set; }
    public required string Description { get; set; }
}

public class UpdateGoalResponse : ResponseBase
{
    public GoalDto Goal { get; set; }
}

public class UpdateGoalHandler : IRequestHandler<UpdateGoalRequest, UpdateGoalResponse>
{
    private readonly IComebackDbContext _context;

    public UpdateGoalHandler(IComebackDbContext context)
        => _context = context;

    public async Task<UpdateGoalResponse> Handle(UpdateGoalRequest request, CancellationToken cancellationToken)
    {
        var goal = await _context.Goals.SingleAsync(x => x.GoalId == request.GoalId);

        goal.SetDescription(request.Description);

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Goal = goal.ToDto()
        };
    }

}


