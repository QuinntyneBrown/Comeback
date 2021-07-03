using Comeback.Api.Models;
using System;

namespace Comeback.Api.Features
{
    public class GoalDto
    {
        public Guid GoalId { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public GoalStatus Status { get; set; }
    }
}
