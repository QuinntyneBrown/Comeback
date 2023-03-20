// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Comeback.Core.AggregateModel.GoalAggregate.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Comeback.Core.AggregateModel.GoalAggregate.Queries;

public class GetDailyMeasurementsRequest : IRequest<GetDailyMeasurementsResponse> { }

public class GetDailyMeasurementsResponse : ResponseBase
{
    public List<DailyMeasurementDto> DailyMeasurements { get; set; }
}

public class GetDailyMeasurementsHandler : IRequestHandler<GetDailyMeasurementsRequest, GetDailyMeasurementsResponse>
{
    private readonly IComebackDbContext _context;

    public GetDailyMeasurementsHandler(IComebackDbContext context)
        => _context = context;

    public async Task<GetDailyMeasurementsResponse> Handle(GetDailyMeasurementsRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            DailyMeasurements = await _context.DailyMeasurements
            .OrderByDescending(x => x.Date)
            .Select(x => x.ToDto()).ToListAsync()
        };
    }

}


