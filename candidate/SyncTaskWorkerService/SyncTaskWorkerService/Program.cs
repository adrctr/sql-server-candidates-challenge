using SyncTaskWorkerService;
using SyncTaskWorkerService.CentralPlatformHttpClient;
using SyncTaskWorkerService.Data;

var builder = Host.CreateApplicationBuilder(args);


builder.Services.AddSingleton<IDbConnection>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString= configuration.GetConnectionString("SqlServer:ConnectionString");
    return new SqlServerConnection(connectionString!);
});

builder.Services.AddHttpClient<IPlatformHttpClient, PlatformHttpClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["HttpClient:BaseUrl"]!);
    client.DefaultRequestHeaders.Add("X-Api-Key", builder.Configuration["HttpClient:ApiKey"]!);
});

builder.Services.AddHostedService<Worker>();
var host = builder.Build();
host.Run();
