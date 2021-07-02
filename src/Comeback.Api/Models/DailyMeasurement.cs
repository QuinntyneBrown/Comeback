using System;

namespace Comeback.Api.Models
{
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

        public void Update(string description)
        {

            Description = description;
        }

        private DailyMeasurement()
        {

        }
    }
}
