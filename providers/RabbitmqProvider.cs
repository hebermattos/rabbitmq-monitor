using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace rabbitmq.monitor
{

    public class RabbitmqProvider : IRabbitmqProvider
    {
        private IHttpClientFactory _httpClientFactory;
        private RulesConfiguration _rulesConfiguration;

        public RabbitmqProvider(IHttpClientFactory httpClientFactory, RulesConfiguration rulesConfiguration)
        {
            _httpClientFactory = httpClientFactory;
            _rulesConfiguration = rulesConfiguration;
        }

        public async Task<List<T>> GetData<T>(string urlRelative)
        {
            var client = _httpClientFactory.CreateClient("rabbitmq");

            var rabbitmqAuthentication = Convert.ToBase64String(Encoding.UTF8.GetBytes(_rulesConfiguration.rabbitmq.user + ":" + _rulesConfiguration.rabbitmq.password));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("basic", rabbitmqAuthentication);

            var response = await client.GetAsync($"{_rulesConfiguration.rabbitmq.url}/api/{urlRelative}");

            var content = await response.Content.ReadAsStringAsync();

            var itens = JsonConvert.DeserializeObject<List<T>>(content);

            return itens;
        }
    }
}