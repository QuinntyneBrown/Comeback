using System;
using Comeback.Api.Models;

namespace Comeback.Api.Features
{
    public static class GoalExtensions
    {
        public static GoalDto ToDto(this Goal goal)
        {
            return new ()
            {
                GoalId = goal.GoalId,
                Name = goal.Name,
                Date = goal.Date,
                Weight = goal.Weight,
                Description = goal.Description,
                Status = goal.Status
            };
        }
        
    }
}
