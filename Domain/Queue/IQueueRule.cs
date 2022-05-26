namespace monitor_rabbit
{
    public interface IQueueRule
    {
        string Run(QueueDto queueDto);
    }
}