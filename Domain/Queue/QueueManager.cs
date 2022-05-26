namespace monitor_rabbit
{
    public class QueueManager : ManagerBase<QueueDto>
    {
        public QueueManager(IConfigurationRepository configurationRepository, IHttpClientFactory httpClientFactory, IList<IRule<QueueDto>> rules, IList<IAlert> alerts)
        : base(configurationRepository, httpClientFactory, rules, alerts)
        {
            base.UrlRelative = "queues";
            base.IsList = true;
        }

    }
}