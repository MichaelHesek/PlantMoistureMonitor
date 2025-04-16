using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PlantMoistureMonitor.ConsoleApp.Services;

//injecting the services into the host
var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<IPlantMonitorService, PlantMonitorService>();
        services.AddSingleton<IMoistureSensor, SimulatedMoistureSensor>();
        services.AddSingleton<INotificationService, ConsoleNotificationService>();
    })
    .Build();

// Run the application
var monitorService = host.Services.GetRequiredService<IPlantMonitorService>();
await monitorService.RunAsync();
