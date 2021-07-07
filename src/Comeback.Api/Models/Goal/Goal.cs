using System;

namespace Comeback.Api.Models
{
    public class Goal
    {
        public Guid GoalId { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public GoalStatus Status { get; private set; }
        public GoalType Type { get; private set; } = GoalType.Incremental;
        public Goal(string name, DateTime date, decimal weight, string description)
        {
            Name = name;
            Date = date;
            Weight = weight;
            Description = description;
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
}
