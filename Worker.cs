using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace monitor_rabbit;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public Worker(ILogger<Worker> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var r1 = new NoConsumer();
        var q = new QueueManager(_httpClientFactory, new List<IQueueRule> { r1 });

        var managers = new List<IManager>();
        managers.Add(q);

        while (!stoppingToken.IsCancellationRequested)
        {
            foreach (var manager in managers)
            {
                await manager.RunAsync();
            }

            await Task.Delay(5000, stoppingToken);
        }
    }
}
