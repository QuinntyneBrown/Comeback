// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using FluentValidation;
using MediatR;

namespace Comeback.Core.AggregatesModel.GoalAggregate.Commands;

public class CreateDailyMeasurementValidator : AbstractValidator<CreateDailyMeasurementRequest>
{
    public CreateDailyMeasurementValidator()
    {
        RuleFor(x => x.Weight).NotNull().NotEmpty();
        RuleFor(x => x.Date)
            .NotNull()
            .NotEmpty()
            .NotEqual(default(DateTime));
    }

}

public class CreateDailyMeasurementRequest : IRequest<CreateDailyMeasurementResponse>
{
    public decimal Weight { get; set; }
    public DateTime Date { get; set; }
}

public class CreateDailyMeasurementResponse : ResponseBase
{
    public required DailyMeasurementDto DailyMeasurement { get; set; }
}

public class CreateDailyMeasurementHandler : IRequestHandler<CreateDailyMeasurementRequest, CreateDailyMeasurementResponse>
{
    private readonly IComebackDbContext _context;

    public CreateDailyMeasurementHandler(IComebackDbContext context)
        => _context = context;

    public async Task<CreateDailyMeasurementResponse> Handle(CreateDailyMeasurementRequest request, CancellationToken cancellationToken)
    {
        var dailyMeasurement = new DailyMeasurement(
            DateOnly.FromDateTime(request.Date),
            request.Weight,
            string.Empty);

        _context.DailyMeasurements.Add(dailyMeasurement);

        await _context.SaveChangesAsync(cancellationToken);

        return new CreateDailyMeasurementResponse()
        {
            DailyMeasurement = dailyMeasurement.ToDto()
        };
    }

}


