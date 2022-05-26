namespace monitor_rabbit
{
    public interface IConfigurationRepository
    {
        List<QueueDAO> GetQueuesNoConsumer();
    }
}