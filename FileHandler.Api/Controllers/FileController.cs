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
                FileId = id,
                FileName = filename,
                Folder = folder
            });

            return Ok();
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

    [ApiController]
    [Route("[controller]")]
    public class ReadController : ControllerBase
    {
        readonly IPublishEndpoint _publishEndpoint;

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

//     [HttpPatch]
//         public async Task<IActionResult> FindDestination(Guid id, string filedestination)
//         {
//             await _publishEndpoint.Publish<FileDestinationFound>(new
//             {
//                 FileId = id,
//                 FileDestination = filedestination
//             });
//
//             return Ok();
//         }
//         
//         [HttpPatch]
//         public async Task<IActionResult> Send(Guid id)
//         {
//             await _publishEndpoint.Publish<FileSent>(new
//             {
//                 FileId = id,
//             });
//
//             return Ok();
//         }
//         
//         [HttpPatch]
//         public async Task<IActionResult> Report(Guid id)
//         {
//             await _publishEndpoint.Publish<TransactionReported>(new
//             {
//                 FileId = id,
//             });
//
//             return Ok();
//         }
//     }
// }