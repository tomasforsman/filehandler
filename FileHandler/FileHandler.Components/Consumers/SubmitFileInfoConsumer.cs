using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Pri.Contracts;

namespace FileHandler.Components.Consumers
{
  public class SubmitFileInfoConsumer : IConsumer<Batch<SubmitFileInfo>>
  {
    private readonly ILogger<SubmitFileInfoConsumer> _logger;

    public SubmitFileInfoConsumer()
    {
    }

    public SubmitFileInfoConsumer(ILogger<SubmitFileInfoConsumer> logger)
    {
      _logger = logger;
    }

    public async Task Consume(ConsumeContext<Batch<SubmitFileInfo>> context)
    {
      _logger?.Log(LogLevel.Debug, "SubmitFileInfoConsumer: {0}", context);
      for (var i = 0; i < context.Message.Length; i++)
      {
        var ctx = context.Message[i];

        // if (ctx.Message.FileName.Contains("TEST"))
        // {
        //   if (context.RequestId != null)
        //     await context.RespondAsync<FileInfoSubmissionRejected>(new
        //     {
        //       InVar.Timestamp,
        //       ctx.Message.FileId,
        //       ctx.Message.FileName,
        //       ctx.Message.OriginFolder,
        //       Reason = $"Unable to submit File with name containing TEST: {ctx.Message.FileName}"
        //     });
        //   return;
        // }


        await context.Publish<FileInfoSubmitted>(new
        {
          ctx.Message.FileId,
          ctx.Message.Timestamp,
          ctx.Message.FileName,
          ctx.Message.OriginFolder
        });

        var busControl = Bus.Factory.CreateUsingRabbitMq();
        var endpoint = await busControl.GetSendEndpoint(new Uri("queue:file-reader"));
        var faultAddress = await busControl.GetSendEndpoint(new Uri("queue:file-fault"));


        await endpoint.Send<ReadFile>(new
        {
          ctx.Message.FileId,
          ctx.Message.FileName,
          //__FaultAddress = "queue:file-fault"
        });
        // await context.RespondAsync("Ok");


        if (context.RequestId != null)
          await context.RespondAsync<FileInfoSubmissionAccepted>(new
          {
            InVar.Timestamp,
            ctx.Message.FileId,
            ctx.Message.FileName,
            ctx.Message.OriginFolder
          }).ConfigureAwait(false);
      }
    }
  }
}