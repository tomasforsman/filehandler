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
        private readonly IRequestClient<CheckFileInfo> _checkFileInfoClient;
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public FileInfoController(ILogger<FileInfoController> logger, IRequestClient<SubmitFileInfo> submitFileInfoRequestClient, ISendEndpointProvider sendEndpointProvider, IRequestClient<CheckFileInfo> checkFileInfoClient)
        {
            _logger = logger;
            _submitFileInfoRequestClient = submitFileInfoRequestClient;
            _sendEndpointProvider = sendEndpointProvider;
            _checkFileInfoClient = checkFileInfoClient;
        }


        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _checkFileInfoClient.GetResponse<FileStatus>(new
            {
                FileId = id
            });

            return Ok(response.Message);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Guid id, string fileName, string folder, string text)
        {
            var (accepted, rejected) = await _submitFileInfoRequestClient.GetResponse<FileInfoSubmissionAccepted, FileInfoSubmissionRejected>(new
            {
                FileId = id,
                InVar.Timestamp,
                FileName = fileName,
                Folder = folder,
                Text = text
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
        public async Task<IActionResult> Put(Guid id, string fileName, string folder, string text)
        {
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("exchange:submit-ftp-connection")).ConfigureAwait(false);
            await endpoint.Send<SubmitFileInfo>(new
            {
                FileId = id,
                InVar.Timestamp,
                FileName = fileName,
                Folder = folder,
                Text = text
            }).ConfigureAwait(false);

            return Accepted();
        }
    }
}