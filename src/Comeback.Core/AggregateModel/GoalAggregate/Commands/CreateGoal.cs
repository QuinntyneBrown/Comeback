// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using FluentValidation;
using MediatR;
using System;


namespace Comeback.Core.AggregateModel.GoalAggregate.Commands;

public class CreateGoalValidator : AbstractValidator<CreateGoalRequest>
{
    public CreateGoalValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.Date)
            .NotNull()
            .NotEmpty()
            .NotEqual(default(DateTime));
        RuleFor(x => x.Weight).NotNull().NotEmpty().NotEqual(default(decimal));
    }

}

public class CreateGoalRequest : IRequest<CreateGoalResponse>
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public decimal Weight { get; set; }
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
            request.Name,
            DateOnly.FromDateTime(request.Date),
            request.Weight);

        _context.Goals.Add(goal);

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Goal = goal.ToDto()
        };

    }

}


