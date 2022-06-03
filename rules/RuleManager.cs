using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace rabbitmq.monitor
{
    public class RuleManager<T> : IRuleManager
        where T : class
    {
        private IRabbitmqProvider _rabbitmqProvider;
        private IList<IRule<T>> _rules;
        private IList<IAlert> _alerts;
        private RulesConfiguration _rulesConfiguration;
        private string _urlRelative;

        public RuleManager(RulesConfiguration rulesConfiguration, string urlRelative, IRabbitmqProvider rabbitmqProvider)
        {
            _rules = new List<IRule<T>>();
            _alerts = new List<IAlert>();

            _rulesConfiguration = rulesConfiguration;
            _rabbitmqProvider = rabbitmqProvider;
            _urlRelative = urlRelative;
        }

        public async Task Run()
        {
            var itens = await _rabbitmqProvider.GetData<T>(_urlRelative);

            foreach (var item in itens)
            {
                foreach (var rule in _rules)
                {
                    var mensage = rule.Run(item, _rulesConfiguration);

                    if (String.IsNullOrEmpty(mensage))
                        continue;

                    foreach (var alert in _alerts)                    
                        await alert.Send(mensage);                    
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