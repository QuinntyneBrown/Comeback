using Comeback.Api.Models;
using System.Linq;

namespace Comeback.Api.Data
{
    public static class SeedData
    {
        public static void Seed(ComebackDbContext context)
        {
            GoalConfiguration.Seed(context);
        }

        public static class GoalConfiguration
        {
            public static void Seed(ComebackDbContext context)
            {

            }
        }
    }
}
