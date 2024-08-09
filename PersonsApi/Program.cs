using Microsoft.AspNetCore.Mvc.ApiExplorer;
using PersonsApi;
using PersonsApi.SerilogCustomEnrichers;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

builder.Host.UseSerilog((context, services, loggerConfiguration) =>
{
    var enricher = services.GetRequiredService<ApiUserEnricher>();
});

builder.Services.AddApplicationDependencyGroup(builder.Configuration);

var app = builder.Build();

var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

startup.Configure(app, app.Environment, provider);

ILogger<Program> logger = app.Services.GetRequiredService<ILogger<Program>>();

logger.LogInformation("Logger is working...");

app.Run();
