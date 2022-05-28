namespace rabbitmq.monitor
{
    public class QueueManager : RuleManagerBase<QueueDto>
    {
        public QueueManager(IHttpClientFactory httpClientFactory, IList<IRule<QueueDto>> rules, IList<IAlert> alerts)
        : base(httpClientFactory, rules, alerts)
        {
            base.UrlRelative = "queues";
        }
    }
}