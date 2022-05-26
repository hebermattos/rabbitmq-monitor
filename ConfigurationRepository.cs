namespace monitor_rabbit
{
    public class ConfigurationRepository
    {
        public List<string> GetQueuesNoConsumer()
        {
            return new List<string> { "fila.teste" };
        }
    }
}