namespace rabbitmq.monitor
{
    public class ConsumerQuantity : IRule<QueueDto>
    {
        private IQueueConfigurationRepository _configurationRepository;

        public ConsumerQuantity(IQueueConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public string Run(QueueDto queueDto)
        {
            var queueConfig = _configurationRepository.GetQueuesConfiguration().FirstOrDefault(x => x.Name.Equals(queueDto.name));

            if (queueConfig == null)            
                return string.Empty;            

            if (queueDto.consumers != queueConfig.Consumers)
                return $"queue {queueDto.name} doesn't have {queueConfig.Consumers} consumers";

            return string.Empty;
        }
    }
}