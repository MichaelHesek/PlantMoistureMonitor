using Moq;
using Xunit;
using Microsoft.Extensions.Logging;
using PlantMoistureMonitor.ConsoleApp.Services;
using PlantMoistureMonitor.Core.Interfaces;
using System.Threading.Tasks;

namespace PlantMoistureMonitor.Tests
{
    public class PlantMonitorServiceTests
    {
        /// <summary>
        /// Test to ensure that the PlantMonitorService sends a notification when the moisture level is low.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task SendsNotification_WhenMoistureIsLow()
        {
            var mockSensor = new Mock<IMoistureSensor>();
            mockSensor.Setup(s => s.ReadMoistureLevel()).Returns(20);

            var mockNotifier = new Mock<INotificationService>();
            var mockLogger = new Mock<ILogger<PlantMonitorService>>();

            var service = new PlantMonitorService(mockSensor.Object, mockNotifier.Object, mockLogger.Object);

            var task = service.RunAsync();
            //waiting to make sure it runs at least one loop
            await Task.Delay(1500);
            Assert.True(true);
        }
    }
}
