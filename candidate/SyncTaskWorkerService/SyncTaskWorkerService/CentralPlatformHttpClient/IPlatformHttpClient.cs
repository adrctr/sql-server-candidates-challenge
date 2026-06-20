using SyncTaskWorkerService.Models;

namespace SyncTaskWorkerService.CentralPlatformHttpClient
{
    public interface IPlatformHttpClient
    {
        Task<SyncTask?> GetTaskAsync(CancellationToken cancellationToken);


    }
}
