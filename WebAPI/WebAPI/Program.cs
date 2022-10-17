using Common;
using Common.Helpers;
using Common.Interfaces;
using Serilog;
using Serilog.Enrichers.WithCaller;
using Serilog.Events;
using Weather;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string directory = Path.Combine(AppContext.BaseDirectory, @"Logs\log_.log");
Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
             .Enrich.FromLogContext()
             .Enrich.WithCaller()
             .WriteTo.Console()
             .WriteTo.File(
                           directory,
                           fileSizeLimitBytes: 1L * 1024 * 1024, // 1MB
                           rollOnFileSizeLimit: true,
                           rollingInterval: RollingInterval.Day,
                           shared: true,
                           flushToDiskInterval: TimeSpan.FromMinutes(1))
             .CreateLogger();

// Add services to the container.
builder.Services.AddSingleton<ModuleRepository>();
builder.Services.AddSingleton<Producer>();
builder.Services.AddSingleton<Consumer>();
builder.Services.AddSingleton<LogHelper>();
builder.Services.AddSingleton(Log.Logger);
builder.Services.AddSingleton<IModule, WeatherModule>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var modules = app.Services.GetService<IEnumerable<IModule>>();
if (modules != null)
{
    foreach (IModule module in modules)
    {
        module.InitializeModule();
    }
}

app.Run();

var consumer = Consumer.GetInstance();
modules = consumer.Gets<IModule>();
foreach (IModule module in modules)
{
    module.TerminateModule();
}

app.StopAsync();
