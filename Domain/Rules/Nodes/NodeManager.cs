namespace rabbitmq.monitor
{
    public class NodeManager : RuleManagerBase<NodeDto>
    {
        public NodeManager(IHttpClientFactory httpClientFactory, IList<IRule<NodeDto>> rules, IList<IAlert> alerts)
        : base(httpClientFactory, rules, alerts)
        {
            base.UrlRelative = "nodes";
            base.IsList = true;
        }

    }
}