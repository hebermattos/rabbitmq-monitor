using System.Net.Http.Headers;
using rabbitmq.monitor;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddHttpClient("rabbitmq", x =>
            { x.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("basic", "YWRtaW46YWRtaW4="); }
        );
    })
    .Build();

await host.RunAsync();
