using System;
using System.Threading.Tasks;
using FileHandler.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace FileHandler.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FindDestinationController : ControllerBase
    {
        readonly IPublishEndpoint _publishEndpoint;

        public FindDestinationController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

     [HttpPatch]
         public async Task<IActionResult> FindDestination(Guid id, string filedestination)
         {
             await _publishEndpoint.Publish<FileDestinationFound>(new
             {
                 FileId = id,
                 FileDestination = filedestination
             });

             return Ok();
         }
    }
}