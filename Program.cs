using System.Net.Http.Headers;
using monitor_rabbit;

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
