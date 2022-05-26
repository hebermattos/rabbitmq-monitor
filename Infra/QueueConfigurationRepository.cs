namespace monitor_rabbit
{

    public class QueueConfigurationRepository : IQueueConfigurationRepository
    {
        public List<QueueDAO> GetQueuesConfiguration()
        {
            return new List<QueueDAO> { new QueueDAO{
                Consumers = 1,
                Name = "fila.teste",
                Type = "asdasdasd"
            } };
        }
    }
}