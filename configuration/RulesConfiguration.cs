namespace rabbitmq.monitor
{
    public class Header
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Nodes
    {
        public bool allRunning { get; set; }
    }

    public class Queue
    {
        public string name { get; set; }
        public int consumers { get; set; }
        public string type { get; set; }
    }

    public class Rabbitmq
    {
        public string url { get; set; }
        public int interval { get; set; }
        public string user { get; set; }
        public string password { get; set; }
    }

    public class RulesConfiguration
    {
        public Rabbitmq rabbitmq { get; set; }
        public Webhook webhook { get; set; }
        public Nodes nodes { get; set; }
        public List<Queue> queues { get; set; }
    }

    public class Webhook
    {
        public string url { get; set; }
        public List<Header> headers { get; set; }
    }




}