using System;

namespace Comeback.Api.Features
{
    public class DailyMeasurementDto
    {
        public Guid DailyMeasurementId { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
