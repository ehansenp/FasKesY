using Application;
using Infrastructure;
using Representation;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplication()
    .AddRepresentation()
    .AddInfrastructure();

// builder.Host.UseSerilog((context, Configuration) => Configuration
    // .WriteTo.Debug()
    // .MinimumLevel.Information());

// builder.Host.UseSerilog((context, Configuration) => Configuration
//     .ReadFrom.Configuration(context.Configuration));
    
// builder.Host.UseSerilog((context, configuration) => configuration
//     .ReadFrom.Configuration(context.Configuration)
//     .Enrich.FromLogContext()
//     .WriteTo.Console()
//     .WriteTo.File(new Serilog.Formatting.Json.JsonFormatter(), "Logs/log-.txt", rollingInterval: RollingInterval.Day));

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("Logs/Log.txt")
    .CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// app.UseSerilogRequestLogging();


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

// app.UseSerilogRequestLogging();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
