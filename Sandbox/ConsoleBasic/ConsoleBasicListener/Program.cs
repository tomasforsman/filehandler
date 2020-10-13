using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;

namespace ConsoleBasicListener
{
  public class Program
  {
    public static async Task Main()
    {
      var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
      {
        cfg.ReceiveEndpoint("event-listener", e => { e.Consumer<EventConsumer>(); });
      });

      var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

      await busControl.StartAsync(source.Token);
      try
      {
        Console.WriteLine("Press enter to exit");

        await Task.Run(Console.ReadLine, source.Token);
      }
      finally
      {
        await busControl.StopAsync(source.Token);
      }
    }
  }
}