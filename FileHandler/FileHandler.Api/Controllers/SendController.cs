using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Pri.Contracts;

namespace FileHandler.Api.Controllers
{
  /// <summary>
  /// Controller for file sending operations
  /// </summary>
  [ApiController]
  [Route("[controller]")]
  public class SendController : ControllerBase
  {
    private readonly IPublishEndpoint _publishEndpoint;

    /// <summary>
    /// Initializes a new instance of the SendController
    /// </summary>
    /// <param name="publishEndpoint">Endpoint for publishing messages</param>
    public SendController(IPublishEndpoint publishEndpoint)
    {
      _publishEndpoint = publishEndpoint;
    }

    /// <summary>
    /// Initiates sending of a file via FTP
    /// </summary>
    /// <param name="id">The file ID to send</param>
    /// <returns>OK result when send operation is initiated</returns>
    [HttpPatch]
    public async Task<IActionResult> Send(Guid id)
    {
      await _publishEndpoint.Publish<FileSent>(new
      {
        FileId = id
      });

      return Ok();
    }
  }
}