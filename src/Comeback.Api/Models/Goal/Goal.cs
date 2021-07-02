using System;

namespace Comeback.Api.Models
{
    public class Goal
    {
        public Guid GoalId { get; set; }
        public decimal Weight { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public GoalStatus Status { get; private set; }

        public Goal(DateTime date, decimal weight, string description)
        {
            Date = date;
            Weight = weight;
            Description = description;
            Status = GoalStatus.Initial;
        }

        public void SetDescription(string description)
        {

            Description = description;
        }

        public void Achieved()
        {

            Status = GoalStatus.Met;
        }

        private Goal()
        {

        }
    }
}
