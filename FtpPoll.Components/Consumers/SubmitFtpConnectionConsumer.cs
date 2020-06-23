using FtpPoll.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FtpPoll.Components.Consumers
{
    public class SubmitFtpConnectionConsumer : IConsumer<SubmitFtpConnection>
    {
        private ILogger<SubmitFtpConnectionConsumer> _logger;

        public SubmitFtpConnectionConsumer(ILogger<SubmitFtpConnectionConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<SubmitFtpConnection> context)
        {
            _logger.Log(LogLevel.Debug, "SubmitFtpConnectionConsumer: {context}", context);
            if (context.Message.HostName.Contains("TEST"))
            {
                if (context.RequestId != null)
                {
                    await context.RespondAsync<FtpConnectionSubmissionRejected>(new
                    {
                        InVar.Timestamp,
                        context.Message.ConnectionId,
                        context.Message.HostName,
                        context.Message.UserName,
                        context.Message.Password,
                        context.Message.Folder,
                        Reason = $"Unable to submit FTP Connection to TEST host: {context.Message.HostName}"
                    });
                    return;
                }
            }

            if (context.RequestId != null)
            {
                await context.RespondAsync<FtpConnectionSubmissionAccepted>(new
                {
                    InVar.Timestamp,
                    context.Message.ConnectionId,
                    context.Message.HostName,
                    context.Message.UserName,
                    context.Message.Password,
                    context.Message.Folder
                });
            }
        }
    }
}