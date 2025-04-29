using Aspire.Hosting;
using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");



    var sql = builder.AddSqlServer("sql")
                 .WithLifetime(ContainerLifetime.Persistent);

    var bariastaDb = sql.AddDatabase("barista-db");


//else
//{
//    var sql = builder.AddAzureSqlServer("sql");

//    var bariastaDb = sql.AddDatabase("barista-db");


//}


var baristaApi = builder.AddProject<Projects.ACOC2_BaristaApi>("acoc2-baristaapi")
                    .WithReference(bariastaDb)
                    .WaitFor(bariastaDb)
                    .WithHttpsHealthCheck("/health");

var apiService = builder.AddProject<Projects.ACOC2_CoffeeApi>("coffeeapi")
    .WithHttpsHealthCheck("/health")
    .WithReference(baristaApi)
    .WaitFor(baristaApi);

builder.AddProject<Projects.ACOC2_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpsHealthCheck("/health")
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);



builder.Build().Run();
