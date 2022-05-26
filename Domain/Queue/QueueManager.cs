namespace monitor_rabbit
{
    public class QueueManager : ManagerBase<QueueDto>
    {
        public QueueManager(IHttpClientFactory httpClientFactory, IList<IRule<QueueDto>> rules, IList<IAlert> alerts)
        : base(httpClientFactory, rules, alerts)
        {
            base.UrlRelative = "queues";
            base.IsList = true;
        }

    }
}