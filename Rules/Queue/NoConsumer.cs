namespace monitor_rabbit
{
    public class NoConsumer : IQueueRule
    {
        private ConfigurationRepository _configurationRepository;

        public NoConsumer(ConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public string Run(QueueDto queueDto)
        {
            var queues = _configurationRepository.GetQueuesNoConsumer();

            if (!queues.Contains(queueDto.name))
                return string.Empty;

            if (queueDto.consumers == 0)            
                return $"queue {queueDto.name} has no consumers";            

            return string.Empty;
        }
    }
}