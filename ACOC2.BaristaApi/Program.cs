
using ACOC2.BaristaApi._2_Domain;
using ACOC2.BaristaApi._3_Data;

namespace ACOC2.BaristaApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

        // Add services to the container.

        
        builder.Services.AddControllers();
        builder.Services.AddGrpc();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.AddSqlServerDbContext<BaristaDbContext>(connectionName: "barista-db");
        var app = builder.Build();



        app.MapDefaultEndpoints();
        app.MapGrpcService<BaristaGrpcService>();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
