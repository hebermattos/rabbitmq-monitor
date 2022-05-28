namespace rabbitmq.monitor
{
    public class NodeRunning : IRule<NodeDto>
    {
        public string Run(NodeDto nodeDto)
        {  
            if (!nodeDto.running)            
                return $"Node {nodeDto.name} is not running";            

            return string.Empty;
        }
    }
}