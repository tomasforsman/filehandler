using FileHandler.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FileHandler.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public ReportController(IPublishEndpoint publishEndpoint) => _publishEndpoint = publishEndpoint;

        [HttpPatch]
        public async Task<IActionResult> Report(Guid id)
        {
            await _publishEndpoint.Publish<TransactionReported>(new
            {
                FileId = id
            });

            return Ok();
        }
    }
}