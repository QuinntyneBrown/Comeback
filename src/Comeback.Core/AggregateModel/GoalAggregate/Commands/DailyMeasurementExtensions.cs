// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;



namespace Comeback.Core.AggregateModel.GoalAggregate.Commands;

public static class DailyMeasurementExtensions
{
    public static DailyMeasurementDto ToDto(this DailyMeasurement dailyMeasurement)
    {
        return new()
        {
            DailyMeasurementId = dailyMeasurement.DailyMeasurementId,
            Date = dailyMeasurement.Date,
            Weight = dailyMeasurement.Weight,
            Description = dailyMeasurement.Description
        };
    }

}


