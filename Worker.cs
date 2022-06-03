using System.Diagnostics;
using Newtonsoft.Json;

namespace rabbitmq.monitor;

public class Worker : BackgroundService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfigurationRepository _configurationRepository;
    private readonly IRabbitmqProvider _rabbitmqProvider;

    public Worker(IHttpClientFactory httpClientFactory, IConfigurationRepository configurationRepository, IRabbitmqProvider rabbitmqProvider)
    {
        _httpClientFactory = httpClientFactory;
        _configurationRepository = configurationRepository;
        _rabbitmqProvider = rabbitmqProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var rulesConfiguration = await _configurationRepository.Get();
        
        var consoleLog = new ConsoleLogger();
        var webhook = new WebhookSender(rulesConfiguration, _httpClientFactory);

        var queueRuleManager = new RuleManager<QueueDto>(rulesConfiguration, "queues", _rabbitmqProvider);
        queueRuleManager.AddRule(new ConsumerQuantity());
        queueRuleManager.AddRule(new QueueType());
        queueRuleManager.AddAlert(webhook);

        var nodeRuleManager = new RuleManager<NodeDto>(rulesConfiguration, "nodes", _rabbitmqProvider);
        nodeRuleManager.AddRule(new NodeRunning());

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