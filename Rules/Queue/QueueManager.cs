using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace monitor_rabbit
{
    public class QueueManager : IManager
    {
        private HttpClient _client;
        private IList<IQueueRule> _rules;

        public QueueManager(IHttpClientFactory httpClientFactory, IList<IQueueRule> rules)
        {
            _client = httpClientFactory.CreateClient("rabbitmq");
            _rules = rules;
        }

        public async Task RunAsync()
        {
            var response = await _client.GetAsync("http://localhost:15672/api/queues");

            var content = await response.Content.ReadAsStringAsync();

            var itens = JsonConvert.DeserializeObject<List<QueueDto>>(content);

            foreach (var item in itens)
            {
                foreach (var rule in _rules)
                {
                    rule.Run(item);
                }
            }
        }
    }
}