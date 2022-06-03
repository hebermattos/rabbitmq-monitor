namespace rabbitmq.monitor
{
    public interface IConfigurationRepository
    {
        Task<RulesConfiguration> Get();
    }
}