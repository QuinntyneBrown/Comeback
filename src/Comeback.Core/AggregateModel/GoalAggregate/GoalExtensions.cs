// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Comeback.Core.AggregateModel.GoalAggregate;

public static class GoalExtensions
{
    public static GoalDto ToDto(this Goal goal)
    {
        return new()
        {
            GoalId = goal.GoalId,
            Name = goal.Name,
            Date = goal.Date,
            Weight = goal.Weight,
            Description = goal.Description,
            Status = goal.Status
        };
    }
}