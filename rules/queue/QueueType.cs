namespace rabbitmq.monitor
{
    public class QueueType : IRule<QueueDto>
    {       
        public string Run(QueueDto queueDto, RulesConfiguration rulesConfiguration)
        {
            var queueConfig = rulesConfiguration.queues.FirstOrDefault(x => x.name.Equals(queueDto.name));

            if (queueConfig == null)
                return string.Empty;

            if (queueDto.arguments.XQueueType != queueConfig.type)
                return $"queue {queueDto.name} is not {queueConfig.type}";

            return string.Empty;
        }
    }
}