using System;
using System.Threading.Tasks;
using Automatonymous;
using MassTransit;
using Microsoft.Extensions.Logging;
using Pri.Contracts;

namespace FileHandler.Components.Consumers
{
  public class CommunicationSettingsConsumer : IConsumer<CommunicationSettings>
  {
    private readonly ILogger<CommunicationSettingsConsumer> _logger;

    public CommunicationSettingsConsumer()
    {
    }

    public async Task Consume(ConsumeContext<CommunicationSettings> context)
    {
      _logger?.Log(LogLevel.Debug, "FileReadConsumer: {context}", context);

      var busControl = Bus.Factory.CreateUsingRabbitMq();
      var endpoint = await busControl.GetSendEndpoint(new Uri("queue:file-sender"));

      await endpoint.Send<SendFile>(new
      {
        context.Message.FileId,
        context.Message.FileName,
        context.Message.LocalFolder,
        context.Message.Protocol,
        context.Message.HostName,
        context.Message.RemoteFolder,
        context.Message.Password,
        context.Message.UserName,
        context.Message.Port,
        context.Message.SshHostKeyFingerprint
      });
    }
  }
}