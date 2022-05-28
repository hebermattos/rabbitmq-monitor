using Newtonsoft.Json;

namespace rabbitmq.monitor
{
    public abstract class RuleManagerBase<T> : IRuleManager
        where T : class
    {
        private HttpClient _client;
        private IList<IRule<T>> _rules;
        private IList<IAlert> _alerts;
        protected string UrlRelative;
        protected bool IsList;

        public RuleManagerBase(IHttpClientFactory httpClientFactory,
                            IList<IRule<T>> rules, IList<IAlert> alerts)
        {
            _client = httpClientFactory.CreateClient("rabbitmq");
            _rules = rules;
            _alerts = alerts;
        }

        public async Task Run()
        {
            var response = await _client.GetAsync($"http://localhost:15672/api/{UrlRelative}");

            var content = await response.Content.ReadAsStringAsync();

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
    }
}