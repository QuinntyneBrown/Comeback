// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;





namespace Comeback.Core.AggregateModel.GoalAggregate.Commands;

public class CreateDailyMeasurementValidator : AbstractValidator<CreateDailyMeasurementRequest>
{
    public CreateDailyMeasurementValidator()
    {
        RuleFor(request => request.DailyMeasurement).NotNull();
        RuleFor(request => request.DailyMeasurement).SetValidator(new DailyMeasurementValidator());
    }

}

public class CreateDailyMeasurementRequest : IRequest<CreateDailyMeasurementResponse>
{
    public DailyMeasurementDto DailyMeasurement { get; set; }
}

public class CreateDailyMeasurementResponse : ResponseBase
{
    public DailyMeasurementDto DailyMeasurement { get; set; }
}

public class CreateDailyMeasurementHandler : IRequestHandler<CreateDailyMeasurementRequest, CreateDailyMeasurementResponse>
{
    private readonly IComebackDbContext _context;

    public CreateDailyMeasurementHandler(IComebackDbContext context)
        => _context = context;

    public async Task<CreateDailyMeasurementResponse> Handle(CreateDailyMeasurementRequest request, CancellationToken cancellationToken)
    {
        var dailyMeasurement = new DailyMeasurement(
            request.DailyMeasurement.Date,
            request.DailyMeasurement.Weight,
            request.DailyMeasurement.Description);

        _context.DailyMeasurements.Add(dailyMeasurement);

        await _context.SaveChangesAsync(cancellationToken);

        return new CreateDailyMeasurementResponse()
        {
            DailyMeasurement = dailyMeasurement.ToDto()
        };
    }

}


