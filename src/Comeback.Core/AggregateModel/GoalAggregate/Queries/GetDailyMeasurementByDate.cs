// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Comeback.Core.AggregateModel.GoalAggregate.Commands;
using MediatR;


namespace Comeback.Core.AggregateModel.GoalAggregate.Queries;

public class GetDailyMeasurementByDateRequest : IRequest<GetDailyMeasurementByDateResponse>
{
    public DateTime Date { get; set; } = DateTime.Now.Date;
}

public class GetDailyMeasurementByDateResponse
{
    public DailyMeasurementDto DailyMeasurement { get; set; }
}

public class GetDailyMeasurementByDateHandler : IRequestHandler<GetDailyMeasurementByDateRequest, GetDailyMeasurementByDateResponse>
{
    private readonly IComebackDbContext _context;

    public GetDailyMeasurementByDateHandler(IComebackDbContext context)
    {
        _context = context;
    }

    public async Task<GetDailyMeasurementByDateResponse> Handle(GetDailyMeasurementByDateRequest request, CancellationToken cancellationToken)
    {
        var dailyMeasurement = _context.DailyMeasurements
            .FirstOrDefault(x => x.Date.Date == request.Date);

        if(dailyMeasurement == null)
        {
            return new();
        }

        return new()
        {
            DailyMeasurement = dailyMeasurement.ToDto()
        };
    }
}


