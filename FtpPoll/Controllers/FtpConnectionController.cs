using FtpPoll.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FtpPoll.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FtpConnectionController : ControllerBase
    {
        private readonly ILogger<FtpConnectionController> _logger;
        private readonly IRequestClient<SubmitFtpConnection> _submitFtpConnectionRequestClient;
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public FtpConnectionController(ILogger<FtpConnectionController> logger, IRequestClient<SubmitFtpConnection> submitFtpConnectionRequestClient, ISendEndpointProvider sendEndpointProvider)
        {
            _logger = logger;
            _submitFtpConnectionRequestClient = submitFtpConnectionRequestClient;
            _sendEndpointProvider = sendEndpointProvider;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Guid id, string hostName, string userName, string password, string folder)
        {
            var (accepted, rejected) = await _submitFtpConnectionRequestClient.GetResponse<FtpConnectionSubmissionAccepted, FtpConnectionSubmissionRejected>(new
            {
                ConnectionId = id,
                InVar.Timestamp,
                HostName = hostName,
                UserName = userName,
                Password = password,
                Folder = folder
            }).ConfigureAwait(false);

            if (accepted.IsCompletedSuccessfully)
            {
                var response = await accepted.ConfigureAwait(false);
                return Accepted(response);
            }
            else
            {
                var response = await rejected.ConfigureAwait(false);
                return BadRequest(response.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid id, string hostName, string userName, string password, string folder)
        {
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("exchange:submit-ftp-connection")).ConfigureAwait(false);
            await endpoint.Send<SubmitFtpConnection>(new
            {
                ConnectionId = id,
                InVar.Timestamp,
                HostName = hostName,
                UserName = userName,
                Password = password,
                Folder = folder
            }).ConfigureAwait(false);

            return Accepted();
        }
    }
}