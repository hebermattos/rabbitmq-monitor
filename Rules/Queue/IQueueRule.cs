namespace monitor_rabbit
{
    public interface IQueueRule
    {
        void Run(QueueDto queueDto);
    }
}