using Microsoft.Extensions.Logging;
using PlantMoistureMonitor.Core.Interfaces;

namespace PlantMoistureMonitor.ConsoleApp.Services
{
    public class PlantMonitorService : IPlantMonitorService
    {
        private readonly IMoistureSensor _sensor;
        private readonly INotificationService _notifier;
        private readonly ILogger<PlantMonitorService> _logger;

        private const int Threshold = 30;

        /// <summary>
        /// Service to monitor plant moisture levels.
        /// </summary>
        /// <param name="sensor">the sensor to monitor</param>
        /// <param name="notifier">notification vehicle</param>
        /// <param name="logger">logger</param>
        public PlantMonitorService(
            IMoistureSensor sensor,
            INotificationService notifier,
            ILogger<PlantMonitorService> logger)
        {
            _sensor = sensor;
            _notifier = notifier;
            _logger = logger;
        }

        /// <summary>
        /// Main loop for monitoring plant moisture.
        /// This method will run indefinitely, checking the moisture level every minute.
        /// If the moisture level is below the specified threshold, it will notify the user.
        /// </summary>
        /// <returns></returns>
        public async Task RunAsync()
        {
            _logger.LogInformation("Starting plant moisture monitoring...");

            while (true)
            {
                //check sensor and report moisture level
                int moistureLevel = _sensor.ReadMoistureLevel();
                _logger.LogInformation("Current moisture level: {Level}", moistureLevel);

                //if moisture level is below the specified threshold, notify user
                if (moistureLevel < Threshold)
                {
                    await _notifier.NotifyAsync($"Moisture too low: {moistureLevel}. Please water the plant.");
                }

                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }
    }
}
