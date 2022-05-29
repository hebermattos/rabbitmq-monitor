namespace rabbitmq.monitor
{
    public class ConsumerQuantity : IRule<QueueDto>
    {
        private RulesConfiguration _rulesConfiguration;

        public ConsumerQuantity(RulesConfiguration rulesConfiguration)
        {
            _rulesConfiguration = rulesConfiguration;
        }

        public string Run(QueueDto queueDto)
        {
            var queueConfig = _rulesConfiguration.queues.FirstOrDefault(x => x.name.Equals(queueDto.name));

            if (queueConfig == null)            
                return string.Empty;            

            if (queueDto.consumers != queueConfig.consumers)
                return $"queue {queueDto.name} doesn't have {queueConfig.consumers} consumers";

            return string.Empty;
        }
    }
}