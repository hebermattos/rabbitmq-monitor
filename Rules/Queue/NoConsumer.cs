namespace monitor_rabbit
{
    public class NoConsumer : IQueueRule
    {
        public void Run(QueueDto queueDto)
        {
            Console.WriteLine("c: " + queueDto.consumers);
        }
    }
}