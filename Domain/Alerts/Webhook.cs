using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;

namespace rabbitmq.monitor
{
    public class Webhook : IAlert
    {
        private IHttpClientFactory _httpClientFactory;

        public Webhook(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task Send(string mensage)
        {
            var client = _httpClientFactory.CreateClient("webhook");

            WebhookData webhookData = new WebhookData();
            webhookData.Message = mensage;

            var data = new StringContent(JsonConvert.SerializeObject(webhookData), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("asdasd", data);

            response.EnsureSuccessStatusCode();
        }
    }
}