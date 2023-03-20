// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.



using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Comeback.Core.AggregateModel.GoalAggregate.Queries;

public class GetGoalRelativeRequest : IRequest<GetGoalRelativeResponse> { }

public class GetGoalRelativeResponse
{
    public GoalDto Goal { get; set; }
}

public class GetGoalRelativeHandler : IRequestHandler<GetGoalRelativeRequest, GetGoalRelativeResponse>
{
    private readonly IComebackDbContext _context;

    public GetGoalRelativeHandler(IComebackDbContext context)
    {
        _context = context;
    }

    public async Task<GetGoalRelativeResponse> Handle(GetGoalRelativeRequest request, CancellationToken cancellationToken)
    {

        var measurement = _context.DailyMeasurements
            .Where(x => x.Date == DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-1).Date))
            .Single();

        return new()
        {
            Goal = new()
            {
                Name = "Relative",
                Date = DateOnly.FromDateTime(DateTime.UtcNow),
                Weight = measurement.Weight - 0.5m
            }
        };
    }
}


