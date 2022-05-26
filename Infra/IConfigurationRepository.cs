namespace monitor_rabbit
{
    public interface IConfigurationRepository
    {
        List<string> GetQueuesNoConsumer();
    }
}