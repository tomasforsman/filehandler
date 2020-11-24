using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Pri.Contracts;

namespace FileHandler.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ReadController : ControllerBase
  {
    private readonly IPublishEndpoint _publishEndpoint;

    public ReadController(IPublishEndpoint publishEndpoint)
    {
      _publishEndpoint = publishEndpoint;
    }

    [HttpPatch]
    public async Task<IActionResult> Read(Guid id, string sellerid, string buyerid)
    {
      await _publishEndpoint.Publish<FileRead>(new
      {
        FileId = id,
        SellerId = sellerid
      });

      return Ok();
    }
  }
}