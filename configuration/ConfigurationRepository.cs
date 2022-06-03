using Newtonsoft.Json;

namespace rabbitmq.monitor
{
    public class ConfigurationRepository: IConfigurationRepository
    {
        public async Task<RulesConfiguration> Get()
        {
            return JsonConvert.DeserializeObject<RulesConfiguration>(await File.ReadAllTextAsync("configuration/rules.json"));
   
        }
    }
}