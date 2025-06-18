using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Pri.Contracts;

namespace FileHandler.Api.Controllers
{
  /// <summary>
  /// Controller for file deletion operations
  /// </summary>
  [ApiController]
  [Route("[controller]")]
  public class DeleteController : ControllerBase
  {
    private readonly IPublishEndpoint _publishEndpoint;

    /// <summary>
    /// Initializes a new instance of the DeleteController
    /// </summary>
    /// <param name="publishEndpoint">Endpoint for publishing messages</param>
    public DeleteController(IPublishEndpoint publishEndpoint)
    {
      _publishEndpoint = publishEndpoint;
    }

    /// <summary>
    /// Deletes a file from the origin folder
    /// </summary>
    /// <param name="id">The file ID to delete</param>
    /// <param name="fileName">The name of the file to delete</param>
    /// <param name="folder">The folder containing the file</param>
    /// <returns>OK result when delete operation is initiated</returns>
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id, string fileName, string folder)
    {
      await _publishEndpoint.Publish<FileDeletedFromOriginFolder>(new
      {
        FileId = id,
        FileName = fileName,
        LocalFolder = folder
      });

      return Ok();
    }
  }
}