using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Pri.Contracts;
using System.Threading.Tasks;
using System;

namespace FileHandler.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class SendController : ControllerBase
  {
    private readonly IPublishEndpoint _publishEndpoint;

    public SendController(IPublishEndpoint publishEndpoint) => _publishEndpoint = publishEndpoint;

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