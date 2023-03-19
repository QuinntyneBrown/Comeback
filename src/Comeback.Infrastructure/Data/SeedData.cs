// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Comeback.Infrastructure.Data;

public static class SeedData
{
    public static void Seed(this ComebackDbContext context)
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


