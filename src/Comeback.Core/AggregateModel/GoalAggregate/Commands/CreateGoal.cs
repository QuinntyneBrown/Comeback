// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;



using System;


namespace Comeback.Core.AggregateModel.GoalAggregate.Commands;

public class CreateGoalValidator : AbstractValidator<CreateGoalRequest>
{
    public CreateGoalValidator()
    {
        RuleFor(request => request.Goal).NotNull();
        RuleFor(request => request.Goal).SetValidator(new GoalValidator());
    }

}

public class CreateGoalRequest : IRequest<CreateGoalResponse>
{
    public GoalDto Goal { get; set; }
}

public class CreateGoalResponse : ResponseBase
{
    public GoalDto Goal { get; set; }
}

public class CreateGoalHandler : IRequestHandler<CreateGoalRequest, CreateGoalResponse>
{
    private readonly IComebackDbContext _context;

    public CreateGoalHandler(IComebackDbContext context)
        => _context = context;

    public async Task<CreateGoalResponse> Handle(CreateGoalRequest request, CancellationToken cancellationToken)
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


