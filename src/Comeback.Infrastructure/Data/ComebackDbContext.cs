// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Comeback.Core;
using Comeback.Core.AggregatesModel.GoalAggregate;
using Comeback.Core.Kernel;
using Microsoft.EntityFrameworkCore;

namespace Comeback.Infrastructure.Data;

public class ComebackDbContext : DbContext, IComebackDbContext
{
    public DbSet<DailyMeasurement> DailyMeasurements { get; private set; }
    public DbSet<Goal> Goals { get; private set; }
    public ComebackDbContext(DbContextOptions options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Comeback");

        modelBuilder.Entity<Goal>(builder =>
        {
            builder.Property(x => x.Date)
            .HasConversion<DateOnlyConverter, DateOnlyComparer>();
        });

        modelBuilder.Entity<DailyMeasurement>(builder =>
        {
            builder.Property(x => x.Date)
            .HasConversion<DateOnlyConverter, DateOnlyComparer>();
        });

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ComebackDbContext).Assembly);
    }
}