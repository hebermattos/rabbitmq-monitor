using System.Collections;
using Newtonsoft.Json;

namespace monitor_rabbit
{
    public abstract class ManagerBase<T,U> : IManager
        where T : class
        where U : class
    {
        private HttpClient _client;
        private IList<IRule<U>> _rules;
        private IList<IAlert> _alerts;

        public ManagerBase(IHttpClientFactory httpClientFactory, IList<IRule<U>> rules, IList<IAlert> alerts)
        {
            _client = httpClientFactory.CreateClient("rabbitmq");
            _rules = rules;
            _alerts = alerts;
        }

        public async Task RunAsync()
        {
            var response = await _client.GetAsync("http://localhost:15672/api/queues");

            var content = await response.Content.ReadAsStringAsync();

            var itens = JsonConvert.DeserializeObject<T>(content);

            if (itens is IList)
            {
                foreach (var item in itens as IList<U>)
                {
                    foreach (var rule in _rules)
                    {
                        var mensage = rule.Run(item);

                        if (String.IsNullOrEmpty(mensage))
                            continue;

                        foreach (var alert in _alerts)
                        {
                            await alert.Send(mensage);
                        }
                    }
                }
            }


        }
    }
}