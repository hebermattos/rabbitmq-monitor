namespace rabbitmq.monitor
{
    public interface IQueueConfigurationRepository
    {
        List<QueueDAO> GetQueuesConfiguration();
    }
}