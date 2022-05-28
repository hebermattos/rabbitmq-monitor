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
        var a1 = new ConsoleLog();

        var r1 = new ConsumerQuantity(new QueueConfigurationRepository());
        var r2 = new QueueType(new QueueConfigurationRepository());

        var q = new QueueManager(_httpClientFactory, 
            new List<IRule<QueueDto>> { r1, r2 }, 
            new List<IAlert> { a1 });

        var managers = new List<IRuleManager>();
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