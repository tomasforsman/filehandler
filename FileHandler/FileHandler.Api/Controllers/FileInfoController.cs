using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pri.Contracts;

namespace FileHandler.Api.Controllers
{
  /// <summary>
  /// Controller for managing file information operations
  /// </summary>
  [ApiController]
  [Route("[controller]")]
  public class FileInfoController : ControllerBase
  {
    private readonly IRequestClient<CheckFileInfo> _checkFileInfoClient;
    private readonly ILogger<FileInfoController> _logger;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ISendEndpointProvider _sendEndpointProvider;
    private readonly IRequestClient<SubmitFileInfo> _submitFileInfoRequestClient;

    /// <summary>
    /// Initializes a new instance of the FileInfoController
    /// </summary>
    /// <param name="logger">Logger instance</param>
    /// <param name="submitFileInfoRequestClient">Client for submitting file info requests</param>
    /// <param name="sendEndpointProvider">Provider for send endpoints</param>
    /// <param name="checkFileInfoClient">Client for checking file info</param>
    /// <param name="publishEndpoint">Endpoint for publishing messages</param>
    public FileInfoController(ILogger<FileInfoController> logger,
      IRequestClient<SubmitFileInfo> submitFileInfoRequestClient, ISendEndpointProvider sendEndpointProvider,
      IRequestClient<CheckFileInfo> checkFileInfoClient, IPublishEndpoint publishEndpoint)
    {
      _logger = logger;
      _submitFileInfoRequestClient = submitFileInfoRequestClient;
      _sendEndpointProvider = sendEndpointProvider;
      _checkFileInfoClient = checkFileInfoClient;
      _publishEndpoint = publishEndpoint;
    }

    /// <summary>
    /// Gets file information by ID
    /// </summary>
    /// <param name="id">The file ID to retrieve information for</param>
    /// <returns>File status information or not found result</returns>
    [HttpGet]
    public async Task<IActionResult> Get(Guid id)
    {
      var (status, notFound) =
        await _checkFileInfoClient.GetResponse<FileStatus, FileNotFound>(new {FileId = id});

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

    /// <summary>
    /// Submits new file information for processing
    /// </summary>
    /// <param name="id">The file ID</param>
    /// <param name="fileName">The name of the file</param>
    /// <param name="folder">The local folder containing the file</param>
    /// <returns>Accepted result if successful, bad request if rejected</returns>
    [HttpPost]
    public async Task<IActionResult> Post(Guid id, string fileName, string folder)
    {
      var (accepted, rejected) = await _submitFileInfoRequestClient
        .GetResponse<FileInfoSubmissionAccepted, FileInfoSubmissionRejected>(new
        {
          FileId = id,
          InVar.Timestamp,
          FileName = fileName,
          LocalFolder = folder
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

    /// <summary>
    /// Updates file information using send endpoint
    /// </summary>
    /// <param name="id">The file ID</param>
    /// <param name="fileName">The name of the file</param>
    /// <param name="folder">The local folder containing the file</param>
    /// <returns>Accepted result</returns>
    [HttpPut]
    public async Task<IActionResult> Put(Guid id, string fileName, string folder)
    {
      var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("exchange:submit-file-info"))
        .ConfigureAwait(false);
      await endpoint.Send<SubmitFileInfo>(new
      {
        FileId = id,
        InVar.Timestamp,
        FileName = fileName,
        LocalFolder = folder
      }).ConfigureAwait(false);

      return Accepted();
    }
  }
}