namespace rabbitmq.monitor
{
    public interface IRabbitmqProvider
    {
        Task<List<T>> GetData<T>(string urlRelative);
    }
}