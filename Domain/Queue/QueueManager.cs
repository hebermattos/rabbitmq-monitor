using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace monitor_rabbit
{
    public class QueueManager : ManagerBase<List<QueueDto>, QueueDto>
    {
        public QueueManager(IHttpClientFactory httpClientFactory, IList<IRule<QueueDto>> rules, IList<IAlert> alerts)
        : base(httpClientFactory, rules, alerts)
        {

        }

    }
}