using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Receipt.Extract.Services.ReceiptExtract;
using Receipt.Extract.Services.ServiceBus;

var builder = FunctionsApplication.CreateBuilder(args);

builder.Services.AddScoped<IReceiptExtractService, ReceiptExtractService>();
builder.Services.AddScoped<IServiceBus, ServiceBusProduct>();
builder.ConfigureFunctionsWebApplication();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

builder.Build().Run();
