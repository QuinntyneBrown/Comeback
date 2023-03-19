// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


using Microsoft.EntityFrameworkCore;


namespace Comeback.Core.AggregateModel.GoalAggregate.Commands;

public class UpdateDailyMeasurementValidator : AbstractValidator<UpdateDailyMeasurementRequest>
{
    public UpdateDailyMeasurementValidator()
    {
        RuleFor(request => request.DailyMeasurement).NotNull();
        RuleFor(request => request.DailyMeasurement).SetValidator(new DailyMeasurementValidator());
    }

}

public class UpdateDailyMeasurementRequest : IRequest<UpdateDailyMeasurementResponse>
{
    public DailyMeasurementDto DailyMeasurement { get; set; }
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
        var dailyMeasurement = await _context.DailyMeasurements.SingleAsync(x => x.DailyMeasurementId == request.DailyMeasurement.DailyMeasurementId);

        dailyMeasurement.Update(
            request.DailyMeasurement.Weight,
            request.DailyMeasurement.Description);

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            DailyMeasurement = dailyMeasurement.ToDto()
        };
    }

}


