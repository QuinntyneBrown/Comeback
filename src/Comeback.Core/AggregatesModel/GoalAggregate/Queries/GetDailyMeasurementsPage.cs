// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Comeback.Core.AggregatesModel.GoalAggregate.Commands;
using Comeback.Core.Kernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Comeback.Core.AggregatesModel.GoalAggregate.Queries;

public class GetDailyMeasurementsPageRequest : IRequest<GetDailyMeasurementsPageResponse>
{
    public int PageSize { get; set; }
    public int Index { get; set; }
}

public class GetDailyMeasurementsPageResponse : ResponseBase
{
    public int Length { get; set; }
    public List<DailyMeasurementDto> Entities { get; set; }
}

public class GetDailyMeasurementsPageHandler : IRequestHandler<GetDailyMeasurementsPageRequest, GetDailyMeasurementsPageResponse>
{
    private readonly IComebackDbContext _context;

    public GetDailyMeasurementsPageHandler(IComebackDbContext context)
        => _context = context;

    public async Task<GetDailyMeasurementsPageResponse> Handle(GetDailyMeasurementsPageRequest request, CancellationToken cancellationToken)
    {
        var query = from dailyMeasurement in _context.DailyMeasurements
                    select dailyMeasurement;

        var length = await _context.DailyMeasurements.CountAsync();

        var dailyMeasurements = await query.Page(request.Index, request.PageSize)
            .Select(x => x.ToDto()).ToListAsync();

        return new()
        {
            Length = length,
            Entities = dailyMeasurements
        };
    }

}


