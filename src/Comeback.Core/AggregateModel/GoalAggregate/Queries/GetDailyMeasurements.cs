// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;


using Microsoft.EntityFrameworkCore;
using Comeback.Core.AggregateModel.GoalAggregate.Commands;


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


