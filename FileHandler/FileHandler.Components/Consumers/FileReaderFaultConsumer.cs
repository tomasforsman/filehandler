using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using Newtonsoft.Json;
using Pri.Contracts;

namespace FileHandler.Components.Consumers
{
  public class FileReader_ErrorConsumer : IConsumer<Fault<ReadFile>>, ISlackClient
  {
    private readonly ILogger<FileReader_ErrorConsumer> _logger;
    private readonly string _uri;
    private readonly Encoding _encoding = new UTF8Encoding();

    public FileReader_ErrorConsumer(ILogger<FileReader_ErrorConsumer> logger)
    {
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
      //_uri = new Uri(Environment.GetEnvironmentVariable("SLACK_URL"));
      _uri = "https://hooks.slack.com/services/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";
    }
    public async Task Consume(ConsumeContext<Fault<ReadFile>> context)
    {
      try
      {
        _logger.LogError("FileReader fault occurred for FileId: {FileId}, Exceptions: {Exceptions}", 
          context.Message.Message.FileId, context.Message.Exceptions);
        PostMessage(context.Message.Exceptions.ToJson(), "microservices");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error processing FileReader fault for FileId: {FileId}", 
          context.Message.Message.FileId);
        throw;
      }
    }

    public string PostMessage(string text, string channel = null)
    {
      var payload = new Payload
        {
          Channel = channel,
          Text = text
        };
        return PostMessage(payload);
    }
    
    private string PostMessage(Payload payload)
    {
      var payloadJson = JsonConvert.SerializeObject(payload);
      using (var client = new WebClient())
      {
        var data = new NameValueCollection {["payload"] = payloadJson};
        var response = client.UploadValues(_uri, "POST", data);
        //The response text is usually "ok"
        return _encoding.GetString(response);
      }
    }
  }
  
  public class Payload
  {
    [JsonProperty("channel")]
    public string Channel { get; set; }
    [JsonProperty("text")]
    public string Text { get; set; }
  }
  public interface ISlackClient
  {
    string PostMessage(string text, string channel = null);
  }
}