// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;


using Microsoft.EntityFrameworkCore;
using Comeback.Core.AggregateModel.GoalAggregate.Commands;


namespace Comeback.Core.AggregateModel.GoalAggregate.Queries;

public class GetDailyMeasurementByIdRequest : IRequest<GetDailyMeasurementByIdResponse>
{
    public Guid DailyMeasurementId { get; set; }
}

public class GetDailyMeasurementByIdResponse : ResponseBase
{
    public DailyMeasurementDto DailyMeasurement { get; set; }
}

public class GetDailyMeasurementByIdHandler : IRequestHandler<GetDailyMeasurementByIdRequest, GetDailyMeasurementByIdResponse>
{
    private readonly IComebackDbContext _context;

    public GetDailyMeasurementByIdHandler(IComebackDbContext context)
        => _context = context;

    public async Task<GetDailyMeasurementByIdResponse> Handle(GetDailyMeasurementByIdRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            DailyMeasurement = (await _context.DailyMeasurements.SingleOrDefaultAsync(x => x.DailyMeasurementId == request.DailyMeasurementId)).ToDto()
        };
    }

}


