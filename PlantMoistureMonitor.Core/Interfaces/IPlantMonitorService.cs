using System.Threading.Tasks;

namespace PlantMoistureMonitor.Core.Interfaces
{
    public interface IPlantMonitorService
    {
        Task RunAsync();
    }
}
