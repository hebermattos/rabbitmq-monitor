namespace rabbitmq.monitor
{
    public class NodeRunning : IRule<NodeDto>
    {
        private RulesConfiguration _ruleConfiguration;

        public NodeRunning(RulesConfiguration ruleConfiguration)
        {
            _ruleConfiguration = ruleConfiguration;
        }

        public string Run(NodeDto nodeDto)
        {
            if (!_ruleConfiguration.nodes.allRunning)
                return string.Empty;

            if (!nodeDto.running)
                return $"Node {nodeDto.name} is not running";

            return string.Empty;
        }
    }
}