using System.Threading.Tasks;
using FileHandler.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;


namespace FileHandler.Components.Consumers
{
    public class SubmitFileInfoConsumer : IConsumer<SubmitFileInfo>
    {
        readonly ILogger<SubmitFileInfoConsumer> _logger;

        public SubmitFileInfoConsumer(ILogger<SubmitFileInfoConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<SubmitFileInfo> context)
        {
            _logger.Log(LogLevel.Debug, "SubmitFileInfoConsumer: {context}", context);
            if (context.Message.FileName.Contains("TEST") && context.RequestId != null)
            {
                await context.RespondAsync<FileInfoSubmissionRejected>(new
                {
                    InVar.Timestamp,
                    context.Message.FileId,
                    context.Message.FileName,
                    context.Message.Folder,
                    context.Message.Text,
                    Reason = $"Unable to submit File with name containing TEST: {context.Message.FileName}"
                }).ConfigureAwait(false);
                return;
            }

            await context.Publish<FileInfoSubmitted>(new
            {
                context.Message.FileId,
                context.Message.Timestamp

            });

            if (context.RequestId != null)
            {
                await context.RespondAsync<FileInfoSubmissionAccepted>(new
                {
                    InVar.Timestamp,
                    context.Message.FileId,
                    context.Message.FileName,
                    context.Message.Folder,
                    context.Message.Text
                }).ConfigureAwait(false);
            }
        }
    }
}