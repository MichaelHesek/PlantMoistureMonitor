using System.Threading.Tasks;

namespace PlantMoistureMonitor.Core.Interfaces
{
    public interface INotificationService
    {
        Task NotifyAsync(string message);
    }
}
