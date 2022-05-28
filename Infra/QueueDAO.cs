namespace rabbitmq.monitor
{
    public  class QueueDAO
    {
        public string Name { get; set; }
        public int Consumers { get; set; }
        public string Type { get; set; }
    }
}