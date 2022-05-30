namespace rabbitmq.monitor
{
    public class ConsoleLog : IAlert
    {
        public async Task Send(string mensage)
        {
           await Console.Out.WriteLineAsync(mensage);
        }
    }
}