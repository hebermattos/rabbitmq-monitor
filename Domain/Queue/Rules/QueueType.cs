namespace monitor_rabbit
{
    public class QueueType : IRule<QueueDto>
    {
        private ConfigurationRepository _configurationRepository;

        public QueueType(ConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public string Run(QueueDto queueDto)
        {
            var queueConfig = _configurationRepository.GetQueuesNoConsumer().FirstOrDefault(x => x.Name.Equals(queueDto.name));

            if (queueConfig == null)            
                return string.Empty;            

            if (queueDto.arguments.XQueueType != queueConfig.Type)
                return $"queue {queueDto.name} is not {queueConfig.Type}";

            return string.Empty;
        }
    }
}