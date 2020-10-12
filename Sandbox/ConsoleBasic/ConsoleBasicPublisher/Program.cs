using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Pri.Contracts;
using SharedContracts;

namespace ConsoleBasicPublisher
{
  public static class Program
  {
    public static async Task Main()
    {
      var busControl = Bus.Factory.CreateUsingRabbitMq();

      var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

      await busControl.StartAsync(source.Token);
      try
      {
        do
        {
          var value = await Task.Run(() =>
          {
            Console.WriteLine("Enter message (or quit to exit)");
            Console.Write("> ");
            return Console.ReadLine();
          }, source.Token);

          if ("quit".Equals(value, StringComparison.OrdinalIgnoreCase))
            break;
          var endpoint = await busControl.GetSendEndpoint(new Uri("queue:file-reader"));

          await endpoint.Send<ReadFile>(new
          {
            FileId = InVar.Id,
            FileName = value
          });
          await busControl.Publish<ValueEntered>(new
          {
            Value = value
          }, source.Token);
        } while (true);
      }
      finally
      {
        await busControl.StopAsync(source.Token);
      }
    }
  }
}