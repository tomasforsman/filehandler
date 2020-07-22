using System;
using FileHandler.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FileHandler.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileInfoController : ControllerBase
    {
        private readonly ILogger<FileInfoController> _logger;
        private readonly IRequestClient<SubmitFileInfo> _submitFileInfoRequestClient;
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public FileInfoController(ILogger<FileInfoController> logger, IRequestClient<SubmitFileInfo> submitFileInfoRequestClient, ISendEndpointProvider sendEndpointProvider)
        {
            _logger = logger;
            _submitFileInfoRequestClient = submitFileInfoRequestClient;
            _sendEndpointProvider = sendEndpointProvider;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Guid id, string fileName, string folder)
        {
            var (accepted, rejected) = await _submitFileInfoRequestClient.GetResponse<FileInfoSubmissionAccepted, FileInfoSubmissionRejected>(new
            {
                FileId = id,
                InVar.Timestamp,
                FileName = fileName,
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
        public async Task<IActionResult> Put(Guid id, string fileName, string folder)
        {
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("exchange:submit-ftp-connection")).ConfigureAwait(false);
            await endpoint.Send<SubmitFileInfo>(new
            {
                FileId = id,
                InVar.Timestamp,
                FileName = fileName,
                Folder = folder
            }).ConfigureAwait(false);

            return Accepted();
        }
    }
}