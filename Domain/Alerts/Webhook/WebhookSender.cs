using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;

namespace rabbitmq.monitor
{
    public class WebhookSender: IAlert
    {
        private RulesConfiguration _rulesConfiguration;
        private IHttpClientFactory _httpClientFactory;

        public WebhookSender(RulesConfiguration rulesConfiguration, IHttpClientFactory httpClientFactory)
        {
            _rulesConfiguration = rulesConfiguration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task Send(string mensage)
        {
            var client = _httpClientFactory.CreateClient("webhook");

            WebhookData webhookData = new WebhookData();
            webhookData.Message = mensage;

            var data = new StringContent(JsonConvert.SerializeObject(webhookData), Encoding.UTF8, "application/json");

            foreach (var header in _rulesConfiguration.webhook.headers)            
                client.DefaultRequestHeaders.Add(header.name, header.value);            

            var response = await client.PostAsync(_rulesConfiguration.webhook.url, data);

            response.EnsureSuccessStatusCode();
        }
    }
}