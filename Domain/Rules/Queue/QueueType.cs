namespace rabbitmq.monitor
{
    public class QueueType : IRule<QueueDto>
    {
        private IQueueConfigurationRepository _configurationRepository;

        public QueueType(IQueueConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public string Run(QueueDto queueDto)
        {
            var queueConfig = _configurationRepository.GetQueuesConfiguration().FirstOrDefault(x => x.Name.Equals(queueDto.name));

            if (queueConfig == null)            
                return string.Empty;            

            if (queueDto.arguments.XQueueType != queueConfig.Type)
                return $"queue {queueDto.name} is not {queueConfig.Type}";

            return string.Empty;
        }
    }
}