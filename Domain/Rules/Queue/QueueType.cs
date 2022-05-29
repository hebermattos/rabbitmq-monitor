namespace rabbitmq.monitor
{
    public class QueueType : IRule<QueueDto>
    {
        private RulesConfiguration _rulesConfiguration;

        public QueueType(RulesConfiguration rulesConfiguration)
        {
            _rulesConfiguration = rulesConfiguration;
        }

        public string Run(QueueDto queueDto)
        {
            var queueConfig = _rulesConfiguration.queues.FirstOrDefault(x => x.name.Equals(queueDto.name));

            if (queueConfig == null)
                return string.Empty;

            if (queueDto.arguments.XQueueType != queueConfig.type)
                return $"queue {queueDto.name} is not {queueConfig.type}";

            return string.Empty;
        }
    }
}