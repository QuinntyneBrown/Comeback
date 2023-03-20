// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using MediatR;

namespace Comeback.Core.AggregateModel.GoalAggregate.Queries;

public class GetGoalByDateRequest : IRequest<GetGoalByDateResponse>
{
    public DateTime Date { get; set; } = DateTime.UtcNow.Date;
}

public class GetGoalByDateResponse
{
    public GoalDto Goal { get; set; }
}

public class GetGoalByDateHandler : IRequestHandler<GetGoalByDateRequest, GetGoalByDateResponse>
{
    private readonly IComebackDbContext _context;

    public GetGoalByDateHandler(IComebackDbContext context)
    {
        _context = context;
    }

    public async Task<GetGoalByDateResponse> Handle(GetGoalByDateRequest request, CancellationToken cancellationToken)
    {

        var measurement = _context.DailyMeasurements.FirstOrDefault();

        if(measurement == null) {

            return new();
        }

        var days = DateOnly.FromDateTime(request.Date).DayNumber - measurement.Date.DayNumber + 1;

        return new()
        {
            Goal = new GoalDto
            {
                Name = "Date",
                Date = DateOnly.FromDateTime(DateTime.UtcNow),
                Weight = measurement.Weight - days * 0.6m
            }
        };
    }
}


