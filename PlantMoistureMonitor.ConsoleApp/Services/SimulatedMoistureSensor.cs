using PlantMoistureMonitor.Core.Interfaces;

namespace PlantMoistureMonitor.ConsoleApp.Services
{
    public class SimulatedMoistureSensor : IMoistureSensor
    {
        private readonly Random _random = new();

        /// <summary>
        /// Reads the moisture level from a sensor.
        /// This is a simulated sensor - it is only generating a random value to represent a moisture level.
        /// In a real-world scenario, this would interface with actual hardware.
        /// </summary>
        /// <returns></returns>
        public int ReadMoistureLevel()
        {
            return _random.Next(10, 100);
        }
    }
}
