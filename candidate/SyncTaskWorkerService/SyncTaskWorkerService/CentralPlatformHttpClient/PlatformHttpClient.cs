using SyncTaskWorkerService.Models;
using System.Net;
using System.Text.Json;

namespace SyncTaskWorkerService.CentralPlatformHttpClient
{
    public class PlatformHttpClient(HttpClient _httpClient) : IPlatformHttpClient
    {
        public async Task<SyncTask?> GetTaskAsync(CancellationToken cancellationToken)
        {
            var result = await _httpClient.GetAsync("api/sync/next-task", cancellationToken);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var content = await result.Content.ReadAsStringAsync(cancellationToken);
                var task = JsonSerializer.Deserialize<SyncTask>(content);
                return task;
            }
            else
            {
                return null;
            }

        }
    }
}
