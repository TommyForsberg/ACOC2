using ACOC2.CoffeeApi.Clients;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddGrpcClient<BaristaService.BaristaServiceClient>(options =>
{
    options.Address = new("https://acoc2-baristaapi");
});
builder.Services.AddHttpClient<BaristaClient>((client) =>
{
    client.BaseAddress = new("https+http://acoc2-baristaapi");
});
// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

app.MapGroup("coffee").MapGet("/menu", async (BaristaService.BaristaServiceClient baristaClient) => 
{
    var menu = await baristaClient.ListCoffeesAsync(new ListCoffeesRequest());
    return menu;
})
.WithName("GetWeatherForecast");

app.MapGet("/", () => $"A Cup of Coffee By Tommy Forsberg Version 1.0");

app.MapDefaultEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
