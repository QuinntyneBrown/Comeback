// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Comeback.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
.Enrich.FromLogContext()
.WriteTo.Console()
.CreateBootstrapLogger();

try
{
    Log.Information("Starting web host");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddCoreServices();

    builder.Services.AddInfrastructureServices(builder.Configuration.GetConnectionString("DefaultConnection")!);

    builder.Services.AddApiServices(builder.Configuration);

    var app = builder.Build();

    app.UseSwagger(options => options.SerializeAsV2 = true);

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Comeback");
        options.RoutePrefix = string.Empty;
        options.DisplayOperationId();
    });

    app.UseCors("CorsPolicy");

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    var services = (IServiceScopeFactory)app.Services.GetRequiredService(typeof(IServiceScopeFactory));

    using (var scope = services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ComebackDbContext>();

        if (args.Contains("ci"))
            args = new string[4] { "dropdb", "migratedb", "seeddb", "stop" };

        if (args.Contains("dropdb"))
        {
            context.Database.ExecuteSql($"DROP TABLE Comeback.DailyMeasurements;");

            context.Database.ExecuteSql($"DROP TABLE Comeback.Goals;");

            context.Database.ExecuteSql($"DROP SCHEMA Comeback;");

            context.Database.ExecuteSql($"DELETE from __EFMigrationsHistory where MigrationId like '%_Comeback_%';");
        }

        if (args.Contains("migratedb"))
        {
            context.Database.Migrate();
        }

        if (args.Contains("seeddb"))
        {
            context.Seed();
        }

        if (args.Contains("stop"))
            Environment.Exit(0);
    }

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}