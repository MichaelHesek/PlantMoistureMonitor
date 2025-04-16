using PlantMoistureMonitor.Core.Interfaces;

namespace PlantMoistureMonitor.ConsoleApp.Services
{
    public class ConsoleNotificationService : INotificationService
    {
        public Task NotifyAsync(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[NOTIFICATION] {message}");
            Console.ResetColor();

            return Task.CompletedTask;
        }
    }
}
