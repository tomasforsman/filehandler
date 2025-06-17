using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Pri.Contracts;

namespace FileHandler.Components.Consumers
{
  public class CommunicationSettingsConsumer : IConsumer<CommunicationSettings>
  {
    private readonly ILogger<CommunicationSettingsConsumer> _logger;

    public CommunicationSettingsConsumer(ILogger<CommunicationSettingsConsumer> logger)
    {
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Consume(ConsumeContext<CommunicationSettings> context)
    {
      try
      {
        _logger.LogInformation("Processing communication settings for FileId: {FileId}, Protocol: {Protocol}, HostName: {HostName}", 
          context.Message.FileId, context.Message.Protocol, context.Message.HostName);

        var busControl = Bus.Factory.CreateUsingRabbitMq();
        var endpoint = await busControl.GetSendEndpoint(new Uri("queue:file-sender"));

        await endpoint.Send<SendFile>(new
        {
          context.Message.FileId,
          context.Message.Protocol,
          context.Message.HostName,
          context.Message.RemoteFolder,
          context.Message.Password,
          context.Message.UserName,
          context.Message.Port,
          context.Message.SshHostKeyFingerprint
        });

        _logger.LogInformation("Send file request sent for FileId: {FileId}", context.Message.FileId);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error processing communication settings for FileId: {FileId}", context.Message.FileId);
        throw;
      }
    }
  }
}