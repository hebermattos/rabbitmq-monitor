namespace monitor_rabbit
{

    public class ConfigurationRepository : IConfigurationRepository
    {
        public List<QueueDAO> GetQueuesNoConsumer()
        {
            return new List<QueueDAO> { new QueueDAO{
                Consumers = 1,
                Name = "fila.teste",
                Type = "asdasdasd"
            } };
        }
    }
}