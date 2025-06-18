using System;
using System.Data.SQLite;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Pri.Contracts;
using PriWebCommunicator.Components.Telemetry;

namespace PriWebCommunicator.Components.Consumers
{
  public class FindFileDestinationConsumer :
    IConsumer<GetCommunicationSettings>
  {
    private readonly ILogger<FindFileDestinationConsumer> _logger;

    public FindFileDestinationConsumer(ILogger<FindFileDestinationConsumer> logger)
    {
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Consume(ConsumeContext<GetCommunicationSettings> context)
    {
      try
      {
        // Set or inherit correlation ID
        if (string.IsNullOrEmpty(CorrelationContext.CorrelationId))
        {
          CorrelationContext.GenerateNewCorrelationId();
        }

        _logger.LogInformation("Processing communication settings request for FileId: {FileId}, SellerId: {SellerId}, BuyerId: {BuyerId} [CorrelationId: {CorrelationId}]", 
          context.Message.FileId, context.Message.SellerId, context.Message.BuyerId, CorrelationContext.CorrelationId);

        var connectionStringBuilder = new SQLiteConnectionStringBuilder();
        connectionStringBuilder.DataSource = @"W:\code\dotnet\microservices\filehandler\PriWebCommunicator\data\pccdb.db";
        var senderid = context.Message.SellerId;
        var receiverid = context.Message.BuyerId;

        using (var connection = new SQLiteConnection(connectionStringBuilder.ConnectionString))
        {
          connection.Open();
          var selectCmd = connection.CreateCommand();
          selectCmd.CommandText =
            $"SELECT * FROM connection_types WHERE SenderIdentity = {senderid} AND ReceiverIdentity = {receiverid}";

          using (var reader = selectCmd.ExecuteReader())
          {
            while (reader.Read())
            {
              var protocol = reader.GetValue(3);
              var hostname = reader.GetValue(4);
              var remotefolder = reader.GetValue(5);
              var password = reader.GetValue(6);
              var username = reader.GetValue(7);
              var port = reader.GetValue(8);

              await context.RespondAsync<CommunicationSettingsFound>(new
              {
                context.Message.FileId,
                HostName = hostname,
                Password = password,
                Port = port,
                Protocol = protocol,
                RemoteFolder = remotefolder,
                UserName = username,
                SshHostKeyFingerprint = ""
              });
              
              _logger.LogInformation("Communication settings found and sent for FileId: {FileId} - {Protocol}:{HostName}:{RemoteFolder}:{UserName}:{Port} [CorrelationId: {CorrelationId}]", 
                context.Message.FileId, protocol, hostname, remotefolder, username, port, CorrelationContext.CorrelationId);
            }
          }
        }
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error processing communication settings request for FileId: {FileId} [CorrelationId: {CorrelationId}]", 
          context.Message.FileId, CorrelationContext.CorrelationId);
        throw;
      }
    }
  }
}