using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using TramsDataApi;
using TramsDataApi.SerilogCustomEnrichers;

var builder = WebApplication.CreateBuilder(args);


var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

builder.Host.UseSerilog((context, services, loggerConfiguration) =>
{
    var enricher = services.GetRequiredService<ApiUserEnricher>();

    loggerConfiguration
    .WriteTo.ApplicationInsights(services.GetRequiredService<TelemetryConfiguration>(), TelemetryConverter.Traces)
    .Enrich.FromLogContext()
    .Enrich.With(enricher)
    .WriteTo.Console();
    });

builder.Services.AddApplicationDependencyGroup(builder.Configuration);

var app = builder.Build();

var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

startup.Configure(app, app.Environment, provider);

ILogger<Program> logger = app.Services.GetRequiredService<ILogger<Program>>();

logger.LogInformation("Logger is working...");

app.Run();
