using System.Collections;
using Newtonsoft.Json;

namespace monitor_rabbit
{
    public abstract class ManagerBase<T> : IManager
        where T : class
    {
        private HttpClient _client;
        private IList<IRule<T>> _rules;
        private IList<IAlert> _alerts;
        protected string UrlRelative;
        protected bool IsList;

        public ManagerBase(IHttpClientFactory httpClientFactory, IList<IRule<T>> rules, IList<IAlert> alerts)
        {
            _client = httpClientFactory.CreateClient("rabbitmq");
            _rules = rules;
            _alerts = alerts;
        }

        public async Task RunAsync()
        {
            var response = await _client.GetAsync($"http://localhost:15672/api/{UrlRelative}");

            var content = await response.Content.ReadAsStringAsync();

            if (IsList)
            {
                var itens = JsonConvert.DeserializeObject<List<T>>(content);

                foreach (var item in itens as IList<T>)
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
            else
            {
                var item = JsonConvert.DeserializeObject<T>(content);

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