using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Pri.Contracts;
using System.Threading.Tasks;
using System;

namespace FileHandler.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class DeleteController : ControllerBase
  {
    private readonly IPublishEndpoint _publishEndpoint;

    public DeleteController(IPublishEndpoint publishEndpoint) => _publishEndpoint = publishEndpoint;

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id, string filename, string folder)
    {
      await _publishEndpoint.Publish<FileDeletedFromOriginFolder>(new
      {
        FileId = id,
        FileName = filename,
        LocalFolder = folder
      });

      return Ok();
    }
  }
}