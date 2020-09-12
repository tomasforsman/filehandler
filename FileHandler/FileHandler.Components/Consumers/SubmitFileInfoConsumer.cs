using FileHandler.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FileHandler.Components.Consumers
{
    public class SubmitFileInfoConsumer : IConsumer<SubmitFileInfo>
    {
        private readonly ILogger<SubmitFileInfoConsumer> _logger;

        public SubmitFileInfoConsumer()
        {
        }

        public SubmitFileInfoConsumer(ILogger<SubmitFileInfoConsumer> logger) => _logger = logger;

        public async Task Consume(ConsumeContext<SubmitFileInfo> context)
        {
            _logger?.Log(LogLevel.Debug, "SubmitFileInfoConsumer: {context}", context);
            if (context.Message.FileName.Contains("TEST"))
            {
                if (context.RequestId != null)
                    await context.RespondAsync<FileInfoSubmissionRejected>(new
                    {
                        InVar.Timestamp,
                        context.Message.FileId,
                        context.Message.FileName,
                        context.Message.Folder,
                        Reason = $"Unable to submit File with name containing TEST: {context.Message.FileName}"
                    });
                return;
            }


            await context.Publish<FileInfoSubmitted>(new
            {
                context.Message.FileId,
                context.Message.Timestamp,
                context.Message.FileName,
                context.Message.Folder
            });

            if (context.RequestId != null)
                await context.RespondAsync<FileInfoSubmissionAccepted>(new
                {
                    InVar.Timestamp,
                    context.Message.FileId,
                    context.Message.FileName,
                    context.Message.Folder
                }).ConfigureAwait(false);
        }
    }
}