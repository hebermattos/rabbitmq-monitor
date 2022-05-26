namespace monitor_rabbit
{
    public interface IRule<T> where T : class
    {
        string Run(T data);
    }
}