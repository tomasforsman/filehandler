using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Pri.Contracts;

namespace FileHandler.Api.Controllers
{
  /// <summary>
  /// Controller for file reading operations
  /// </summary>
  [ApiController]
  [Route("[controller]")]
  public class ReadController : ControllerBase
  {
    private readonly IPublishEndpoint _publishEndpoint;

    /// <summary>
    /// Initializes a new instance of the ReadController
    /// </summary>
    /// <param name="publishEndpoint">Endpoint for publishing messages</param>
    public ReadController(IPublishEndpoint publishEndpoint)
    {
      _publishEndpoint = publishEndpoint;
    }

    /// <summary>
    /// Initiates reading of a file with specified seller and buyer information
    /// </summary>
    /// <param name="id">The file ID to read</param>
    /// <param name="sellerId">The seller identification</param>
    /// <param name="buyerId">The buyer identification</param>
    /// <returns>OK result when read operation is initiated</returns>
    [HttpPatch]
    public async Task<IActionResult> Read(Guid id, string sellerId, string buyerId)
    {
      await _publishEndpoint.Publish<FileRead>(new
      {
        FileId = id,
        SellerId = sellerId,
        BuyerId = buyerId
      });

      return Ok();
    }
  }
}