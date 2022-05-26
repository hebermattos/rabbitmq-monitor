namespace monitor_rabbit
{
    public interface IAlert
    {
        Task Send(string mensage);
    }
}