using System;
using System.Threading.Tasks;
using FileHandler.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace FileHandler.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendController : ControllerBase
    {
        readonly IPublishEndpoint _publishEndpoint;

        public SendController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

         [HttpPatch]
         public async Task<IActionResult> Send(Guid id)
         {
             await _publishEndpoint.Publish<FileSent>(new
             {
                 FileId = id,
             });

             return Ok();
         }

    }
}