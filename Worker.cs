using System.Diagnostics;
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
        var rulesConfiguration = JsonConvert.DeserializeObject<RulesConfiguration>(await File.ReadAllTextAsync("configuration/rules.json"));

        var consoleLog = new ConsoleLogger();
        var webhook = new WebhookSender(rulesConfiguration, _httpClientFactory);

        var queueRuleManager = new RuleManager<QueueDto>(rulesConfiguration, "queues", _httpClientFactory);
        queueRuleManager.AddRule(new ConsumerQuantity(rulesConfiguration));
        queueRuleManager.AddRule(new QueueType(rulesConfiguration));
        queueRuleManager.AddAlert(webhook);

        var nodeRuleManager = new RuleManager<NodeDto>(rulesConfiguration, "nodes", _httpClientFactory);
        nodeRuleManager.AddRule(new NodeRunning(rulesConfiguration));

        nodeRuleManager.AddAlert(webhook);

        if (Debugger.IsAttached)
        {
            queueRuleManager.AddAlert(consoleLog);
            nodeRuleManager.AddAlert(consoleLog);
        }

        var ruleManagers = new List<IRuleManager>();
        ruleManagers.Add(queueRuleManager);
        ruleManagers.Add(nodeRuleManager);

        while (!stoppingToken.IsCancellationRequested)
        {
            Parallel.ForEach(ruleManagers, async manager =>
            {
                await manager.Run();
            });

            await Task.Delay(rulesConfiguration.rabbitmq.interval, stoppingToken);
        }
    }
}