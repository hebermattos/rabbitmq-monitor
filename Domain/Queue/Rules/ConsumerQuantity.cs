namespace monitor_rabbit
{
    public class ConsumerQuantity : IRule<QueueDto>
    {
        private ConfigurationRepository _configurationRepository;

        public ConsumerQuantity(ConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public string Run(QueueDto queueDto)
        {
            var queueConfig = _configurationRepository.GetQueuesNoConsumer().FirstOrDefault(x => x.Name.Equals(queueDto.name));

            if (queueConfig == null)            
                return string.Empty;            

            if (queueDto.consumers != queueConfig.Consumers)
                return $"queue {queueDto.name} doesn't have {queueConfig.Consumers} consumers";

            return string.Empty;
        }
    }
}