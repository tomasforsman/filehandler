using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Pri.Contracts;

namespace FileHandler.Components.Consumers
{
    public class ReadConsumer : IConsumer<Read>
    {
        private readonly ILogger<ReadConsumer> _logger;

        public ReadConsumer()
        {
        }
        
        public async Task Consume(ConsumeContext<Read> context)
        {
            _logger?.Log(LogLevel.Debug, "ReadConsumer: {context}", context);
            
            var busControl = Bus.Factory.CreateUsingRabbitMq();
            var endpoint = await busControl.GetSendEndpoint(new Uri("queue:pri-web-communicator"));

            await endpoint.Send<GetCommunicationSettings>(new
            {
                context.Message.FileId,
                context.Message.BuyerId,
                context.Message.SellerId
            });
        }
    }
}