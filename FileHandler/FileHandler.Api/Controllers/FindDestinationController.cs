using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Pri.Contracts;
using System.Threading.Tasks;
using System;

namespace FileHandler.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class FindDestinationController : ControllerBase
  {
    private readonly IPublishEndpoint _publishEndpoint;

    public FindDestinationController(IPublishEndpoint publishEndpoint) => _publishEndpoint = publishEndpoint;

    [HttpPatch]
    public async Task<IActionResult> FindDestination(Guid id, string protocol, string hostname, string remotefolder,
      string password, string username, string port)
    {
      await _publishEndpoint.Publish<CommunicationSettings>(new
      {
        FileId = id,
        Protocol = protocol,
        HostName = hostname,
        RemoteFolder = remotefolder,
        Password = password,
        UserName = username,
        Port = port
      });

      return Ok();
    }
  }
}