using System.Net.Http.Headers;
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

        public RuleManager(string urlRelative, IHttpClientFactory httpClientFactory)
        {
            _rules = new List<IRule<T>>();
            _alerts = new List<IAlert>();

            _httpClientFactory = httpClientFactory;
            _urlRelative = urlRelative;
        }

        public async Task Run()
        {
            var client = _httpClientFactory.CreateClient("rabbitmq");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("basic", "YWRtaW46YWRtaW4="); 

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

        public void AddRule(IRule<T> rule)
        {
            _rules.Add(rule);
        }

        public void AddAlert(IAlert alert)
        {
            _alerts.Add(alert);
        }
    }
}