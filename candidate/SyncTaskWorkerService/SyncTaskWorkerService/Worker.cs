using SyncTaskWorkerService.CentralPlatformHttpClient;
using SyncTaskWorkerService.Data;
using System.Data.Common;

namespace SyncTaskWorkerService
{
    public class Worker(ILogger<Worker> logger, IConfiguration configuration, IPlatformHttpClient platformHttpClient) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (logger.IsEnabled(LogLevel.Information))
                {
                    logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                //logger.LogInformation($"db connection {configuration.GetValue<string>("SqlServer:ConnectionString")}");
                var syncTask= await platformHttpClient.GetTaskAsync(stoppingToken);
                string resulttast = (syncTask != null) ? syncTask.ToString() : "pas de tache en cours";
                logger.LogInformation($"Task {resulttast}");
                await Task.Delay(configuration.GetValue<int>("PollingTime"), stoppingToken);
            }
        }
    }
}
