using Newtonsoft.Json;

namespace rabbitmq.monitor;

public class Worker : BackgroundService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public Worker(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var rulesConfiguration = JsonConvert.DeserializeObject<RulesConfiguration>(await File.ReadAllTextAsync("rules.json"));

        var consoleLog = new ConsoleLog();
        var webhook = new WebhookSender(rulesConfiguration,_httpClientFactory);

        var queue = new RuleManager<QueueDto>("queues", _httpClientFactory);
        queue.AddRule(new ConsumerQuantity(rulesConfiguration));
        queue.AddRule(new QueueType(rulesConfiguration));
        queue.AddAlert(consoleLog);

        var node = new RuleManager<NodeDto>("nodes", _httpClientFactory);
        node.AddRule(new NodeRunning(rulesConfiguration));
        node.AddAlert(consoleLog);

        var managers = new List<IRuleManager>();
        managers.Add(queue);
        managers.Add(node);

        while (!stoppingToken.IsCancellationRequested)
        {
            Parallel.ForEach(managers, async manager =>
            {
                await manager.Run();
            });

            await Task.Delay(5000, stoppingToken);
        }
    }
}