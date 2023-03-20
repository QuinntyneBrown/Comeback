// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Comeback.Core.AggregateModel.GoalAggregate;

public class Goal
{
    public Guid GoalId { get; set; }
    public string Name { get; set; }
    public decimal Weight { get; private set; }
    public string Description { get; private set; }
    public DateOnly Date { get; private set; }
    public GoalStatus Status { get; private set; }
    public GoalType Type { get; private set; } = GoalType.Incremental;
    public Goal(string name, DateOnly date, decimal weight)
    {
        Name = name;
        Date = date;
        Weight = weight;
        Description = string.Empty;
        Status = GoalStatus.Initial;
    }

    public void SetDescription(string description)
    {
        Description = description;
    }

    public void SetType(GoalType type)
    {
        Type = type;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void Achieved()
    {

        Status = GoalStatus.Met;
    }

    private Goal()
    {

    }

}


