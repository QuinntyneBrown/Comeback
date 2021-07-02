using System;
using Comeback.Api.Models;

namespace Comeback.Api.Features
{
    public static class DailyMeasurementExtensions
    {
        public static DailyMeasurementDto ToDto(this DailyMeasurement dailyMeasurement)
        {
            return new ()
            {
                DailyMeasurementId = dailyMeasurement.DailyMeasurementId,
                Date = dailyMeasurement.Date,
                Weight = dailyMeasurement.Weight,
                Description = dailyMeasurement.Description
            };
        }
        
    }
}
