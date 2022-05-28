namespace rabbitmq.monitor
{
    public interface IRule<T> where T : class
    {
        string Run(T data);
    }
}