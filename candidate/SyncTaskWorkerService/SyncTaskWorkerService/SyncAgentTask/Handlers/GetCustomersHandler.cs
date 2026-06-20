
using Dapper;
using SyncTaskWorkerService.Data;
using SyncTaskWorkerService.Models;
using System.Text.Json;

namespace SyncTaskWorkerService.SyncAgentTask.Handlers
{
    public class GetCustomersHandler(IDbConnection dbConnection) : ISyncTaskHandler
    {
        public string SyncName => "GetCustomers";
        public async Task<TaskResult> HandleAsync(JsonElement parameters, CancellationToken ct)
        {
            DateTime modifiedSince = parameters.GetProperty("modifiedSince").GetDateTime();

            var connection = dbConnection.Create();

            var sql = @"
                SELECT 
                    CustomerID,
                    PersonID,
                    StoreID,
                    TerritoryID,
                    AccountNumber,
                    rowguid,
                    ModifiedDate
                FROM Sales.Customer
                WHERE ModifiedDate >= @ModifiedDate";

            var result = connection.Query(sql, new { ModifiedDate = modifiedSince });

            return new TaskResult
            {
                Data = result,
                Count = result.Count()
            };
        }
    }
}
