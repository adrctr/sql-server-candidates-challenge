
using SyncTaskWorkerService.Models;
using System.Text.Json;

namespace SyncTaskWorkerService.SyncAgentTask
{
    public interface ISyncTaskHandler
    {
        string SyncName { get; }
        Task<TaskResult> HandleAsync(JsonElement parameters, CancellationToken ct);
    }
}
