namespace rabbitmq.monitor
{
    public interface IAlert
    {
        Task Send(string mensage);
    }
}