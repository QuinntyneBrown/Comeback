// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;


namespace Comeback.Core.AggregateModel.GoalAggregate.Commands;

public class DailyMeasurementDto
{
    public Guid? DailyMeasurementId { get; set; }
    public decimal Weight { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
}


