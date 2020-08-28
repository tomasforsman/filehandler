using System;
using System.Threading.Tasks;
using FileHandler.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace FileHandler.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        readonly IPublishEndpoint _publishEndpoint;

        public FileController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id, string filename, string folder)
        {
            await _publishEndpoint.Publish<FileDeletedFromOriginFolder>(new
            {
                FileId = default(Guid),
                FileName = default(string),
                Folder = default(string)
            });

            return Accepted();
        }
    }
}