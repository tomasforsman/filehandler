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
        readonly ILogger<FileInfoController> _logger;
        readonly IRequestClient<SubmitFileInfo> _submitFileInfoRequestClient;
        readonly IRequestClient<CheckFileInfo> _checkFileInfoClient;
        readonly ISendEndpointProvider _sendEndpointProvider;
        readonly IPublishEndpoint _publishEndpoint;

        public FileInfoController(ILogger<FileInfoController> logger, IRequestClient<SubmitFileInfo> submitFileInfoRequestClient, ISendEndpointProvider sendEndpointProvider, IRequestClient<CheckFileInfo> checkFileInfoClient, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _submitFileInfoRequestClient = submitFileInfoRequestClient;
            _sendEndpointProvider = sendEndpointProvider;
            _checkFileInfoClient = checkFileInfoClient;
            _publishEndpoint = publishEndpoint;
        }


        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var (status,notFound) = await _checkFileInfoClient.GetResponse<FileStatus, FileNotFound>(new {FileId = id});

            if (status.IsCompletedSuccessfully)
            {
                var response = await status;
                return Ok(response.Message);
            }
            else
            {
                var response = await notFound;
                return NotFound(response.Message);
            }



        }


        [HttpPost]
        public async Task<IActionResult> Post(Guid id, string fileName, string folder)
        {
            var (accepted, rejected) = await _submitFileInfoRequestClient.GetResponse<FileInfoSubmissionAccepted, FileInfoSubmissionRejected>(new
            {
                FileId = id,
                InVar.Timestamp,
                FileName = fileName,
                Folder = folder,
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
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("exchange:submit-file-info")).ConfigureAwait(false);
            await endpoint.Send<SubmitFileInfo>(new
            {
                FileId = id,
                InVar.Timestamp,
                FileName = fileName,
                Folder = folder,
            }).ConfigureAwait(false);

            return Accepted();
        }
    }
}