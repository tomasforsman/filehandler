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

    public ReadConsumer(ILogger<ReadConsumer> logger)
    {
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Consume(ConsumeContext<Read> context)
    {
      try
      {
        _logger.LogInformation("Processing read request for FileId: {FileId}, BuyerId: {BuyerId}, SellerId: {SellerId}", 
          context.Message.FileId, context.Message.BuyerId, context.Message.SellerId);

        var busControl = Bus.Factory.CreateUsingRabbitMq();
        var endpoint = await busControl.GetSendEndpoint(new Uri("queue:pri-web-communicator"));

        await endpoint.Send<GetCommunicationSettings>(new
        {
            context.Message.FileId,
            context.Message.BuyerId,
            context.Message.SellerId
        });

        _logger.LogInformation("Communication settings request sent for FileId: {FileId}", context.Message.FileId);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error processing read request for FileId: {FileId}", context.Message.FileId);
        throw;
      }
    }
  }
}