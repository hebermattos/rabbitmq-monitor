namespace monitor_rabbit
{
    public class QueueManager : ManagerBase<List<QueueDto>, QueueDto>
    {
        public QueueManager(IHttpClientFactory httpClientFactory, IList<IRule<QueueDto>> rules, IList<IAlert> alerts)
        : base(httpClientFactory, "queues", rules, alerts)
        {

        }

    }
}