namespace rabbitmq.monitor
{
    public class ConsoleLogger : IAlert
    {
        public async Task Send(string mensage)
        {
           await Console.Out.WriteLineAsync(mensage);
        }
    }
}