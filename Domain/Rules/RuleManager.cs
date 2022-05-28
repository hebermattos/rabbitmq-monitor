using Newtonsoft.Json;

namespace rabbitmq.monitor
{
    public class RuleManager<T> : IRuleManager
        where T : class
    {
        private IHttpClientFactory _httpClientFactory;
        private IList<IRule<T>> _rules;
        private IList<IAlert> _alerts;
        private string _urlRelative;

        public RuleManager(string urlRelative, IHttpClientFactory httpClientFactory,
                            IList<IRule<T>> rules, IList<IAlert> alerts)
        {
            _httpClientFactory = httpClientFactory;
            _rules = rules;
            _alerts = alerts;
            _urlRelative = urlRelative;
        }

        public async Task Run()
        {
            var client = _httpClientFactory.CreateClient("rabbitmq");

            var response = await client.GetAsync($"http://localhost:15672/api/{_urlRelative}");

            var content = await response.Content.ReadAsStringAsync();

            var itens = JsonConvert.DeserializeObject<List<T>>(content);

            foreach (var item in itens)
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