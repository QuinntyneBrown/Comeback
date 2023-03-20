// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Comeback.Core.AggregateModel.GoalAggregate.Commands;

public class UpdateDailyMeasurementValidator : AbstractValidator<UpdateDailyMeasurementRequest>
{
    public UpdateDailyMeasurementValidator()
    {
        RuleFor(x => x.DailyMeasurementId).NotEmpty();
        RuleFor(x => x.Weight).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }

}

public class UpdateDailyMeasurementRequest : IRequest<UpdateDailyMeasurementResponse>
{
    public Guid DailyMeasurementId { get; set; }
    public string Description { get; set; }
    public decimal Weight { get; set; }
}

public class UpdateDailyMeasurementResponse : ResponseBase
{
    public DailyMeasurementDto DailyMeasurement { get; set; }
}

public class UpdateDailyMeasurementHandler : IRequestHandler<UpdateDailyMeasurementRequest, UpdateDailyMeasurementResponse>
{
    private readonly IComebackDbContext _context;

    public UpdateDailyMeasurementHandler(IComebackDbContext context)
        => _context = context;

    public async Task<UpdateDailyMeasurementResponse> Handle(UpdateDailyMeasurementRequest request, CancellationToken cancellationToken)
    {
        var dailyMeasurement = await _context.DailyMeasurements.SingleAsync(x => x.DailyMeasurementId == request.DailyMeasurementId);

        dailyMeasurement.Update(
            request.Weight,
            request.Description);

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            DailyMeasurement = dailyMeasurement.ToDto()
        };
    }

}


