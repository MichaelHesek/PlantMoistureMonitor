namespace PlantMoistureMonitor.Core.Interfaces
{
    public interface IMoistureSensor
    {
        /// <summary>
        /// Reads the moisture level from the sensor.
        /// This method should return a value between 0 and 100, where 0 indicates no moisture and 100 indicates maximum moisture.
        /// The actual implementation of this method will depend on the specific sensor being used.
        /// </summary>
        /// <returns></returns>
        int ReadMoistureLevel();
    }
}
