// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using Comeback.Core.AggregateModel.GoalAggregate;
using Microsoft.EntityFrameworkCore;


namespace Comeback.Core;

public interface IComebackDbContext
{
    DbSet<DailyMeasurement> DailyMeasurements { get; }
    DbSet<Goal> Goals { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}


