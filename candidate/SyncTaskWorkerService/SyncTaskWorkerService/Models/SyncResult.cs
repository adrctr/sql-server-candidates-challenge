using System.Text.Json;

namespace SyncTaskWorkerService.Models
{
    public class SyncResult
    {
        public string TaskId { get; set; } = string.Empty;

        public string TaskType { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public JsonElement? Data { get; set; }

        public int RecordCount { get; set; }

        public DateTime ExecutedAt { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
