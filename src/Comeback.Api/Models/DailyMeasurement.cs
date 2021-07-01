using System;

namespace Comeback.Api.Models
{
    public class DailyMeasurement
    {
        public Guid DailyMeasurementId { get; private set; }
        public decimal Weight { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }

        public DailyMeasurement()
        {

        }

        private DailyMeasurement()
        {

        }
    }
}
