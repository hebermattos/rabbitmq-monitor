using System.Threading.Tasks;

namespace rabbitmq.monitor
{
    public interface IRuleManager
    {
        Task RunAsync();
    }
}