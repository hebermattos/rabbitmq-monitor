using Newtonsoft.Json;

namespace rabbitmq.monitor
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        public async Task<RulesConfiguration> Get()
        {
            var data = JsonConvert.DeserializeObject<RulesConfiguration>(await File.ReadAllTextAsync("configuration/rules.json"));

            if (data == null)
                throw new NullReferenceException("Rules configuration is null");

            return data;
        }
    }
}