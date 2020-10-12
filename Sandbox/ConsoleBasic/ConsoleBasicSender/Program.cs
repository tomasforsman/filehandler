using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Pri.Contracts;

namespace ConsoleBasicSender
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
                    var endpoint = await busControl.GetSendEndpoint(new Uri("queue:file-reader"));

                    await endpoint.Send<ReadFile>(new
                    {
                        FileId = InVar.Id,
                        FileName = "filnamn.xml",
                        Folder = "svefakt"
                    },source.Token);
                    break;
                }
                while (true);
            }
            finally
            {
                await busControl.StopAsync(source.Token);
            }
        }
    }
}