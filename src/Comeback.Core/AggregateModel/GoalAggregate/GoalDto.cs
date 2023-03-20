// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Comeback.Core.AggregateModel.GoalAggregate;

public class GoalDto
{
    public Guid? GoalId { get; set; }
    public string Name { get; set; }
    public decimal Weight { get; set; }
    public string Description { get; set; }
    public DateOnly Date { get; set; }
    public GoalStatus Status { get; set; } = GoalStatus.Initial;
}


