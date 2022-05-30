using System.Net.Http.Headers;
using rabbitmq.monitor;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddHttpClient("webhook");
        services.AddHttpClient("rabbitmq");
    })
    .Build();

await host.RunAsync();
