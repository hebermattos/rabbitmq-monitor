namespace monitor_rabbit
{

    public class ConfigurationRepository : IConfigurationRepository
    {
        public List<string> GetQueuesNoConsumer()
        {
            return new List<string> { "fila.teste" };
        }
    }
}