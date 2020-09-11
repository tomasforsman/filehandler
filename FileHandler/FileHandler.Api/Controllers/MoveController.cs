using System;
using System.Threading.Tasks;
using FileHandler.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace FileHandler.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoveController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public MoveController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPatch]
        public async Task<IActionResult> Move(Guid id, string filename, string fromfolder, string tofolder)
        {
            await _publishEndpoint.Publish<FileMoved>(new
            {
                FileId = id,
                FileName = filename,
                FromFolder = fromfolder,
                ToFolder = tofolder
            });

            return Ok();
        }
    }
}