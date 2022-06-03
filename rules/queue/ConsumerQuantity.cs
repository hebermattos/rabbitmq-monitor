namespace rabbitmq.monitor
{
    public class ConsumerQuantity : IRule<QueueDto>
    {
       
        public string Run(QueueDto queueDto, RulesConfiguration rulesConfiguration)
        {
            var queueConfig = rulesConfiguration.queues.FirstOrDefault(x => x.name.Equals(queueDto.name));

            if (queueConfig == null)            
                return string.Empty;            

            if (queueDto.consumers != queueConfig.consumers)
                return $"queue {queueDto.name} doesn't have {queueConfig.consumers} consumers";

            return string.Empty;
        }
    }
}