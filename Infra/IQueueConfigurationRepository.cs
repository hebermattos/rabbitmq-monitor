namespace monitor_rabbit
{
    public interface IQueueConfigurationRepository
    {
        List<QueueDAO> GetQueuesConfiguration();
    }
}