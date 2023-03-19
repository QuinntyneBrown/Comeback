// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Comeback.Core.AggregateModel.GoalAggregate;

public class DailyMeasurement
{
    public Guid DailyMeasurementId { get; private set; }
    public decimal Weight { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }

    public DailyMeasurement(DateTime date, decimal weight, string description)
    {
        Date = date;
        Weight = weight;
        Description = description;
    }

    public void Update(decimal weight, string description)
    {
        Weight = weight;
        Description = description;
    }

    private DailyMeasurement()
    {

    }
}


