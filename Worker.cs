namespace rabbitmq.monitor;

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
        var consoleLog = new ConsoleLog();

        var consumerQuantity = new ConsumerQuantity(new QueueConfigurationRepository());
        var queueType = new QueueType(new QueueConfigurationRepository());

        var queue = new RuleManager<QueueDto>("queues",_httpClientFactory,
            new List<IRule<QueueDto>> { consumerQuantity, queueType },
            new List<IAlert> { consoleLog });

        var nodeRunning = new NodeRunning();

        var node = new RuleManager<NodeDto>("nodes",_httpClientFactory,
            new List<IRule<NodeDto>> { nodeRunning },
            new List<IAlert> { consoleLog });

        var managers = new List<IRuleManager>();
        managers.Add(queue);
        managers.Add(node);

        while (!stoppingToken.IsCancellationRequested)
        {
            foreach (var manager in managers)            
                await manager.Run();            

            await Task.Delay(5000, stoppingToken);
        }
    }
}