using System;
using System.Threading.Tasks;
using FileHandler.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Read(Guid id, string senderid, string receiverid)
        {
            await _publishEndpoint.Publish<FileRead>(new
            {
                FileId = id,
                SenderId = senderid,
                ReceiverId = receiverid
            });

            return Ok();
        }
    }
}