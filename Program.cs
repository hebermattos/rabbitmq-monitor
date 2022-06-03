using rabbitmq.monitor;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
        services.AddScoped<IRabbitmqProvider, RabbitmqProvider>();
        services.AddHttpClient("webhook");
        services.AddHttpClient("rabbitmq");
    })
    .Build();

await host.RunAsync();
