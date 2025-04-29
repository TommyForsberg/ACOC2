using ACOC2.BaristaApi._3_Data;
using ACOC2.BaristaApi.MigrationService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddHostedService<Worker>();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));

builder.AddSqlServerDbContext<BaristaDbContext>("barista-db");

var host = builder.Build();
host.Run();
