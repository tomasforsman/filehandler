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
  public class PriWebCommunicator_ErrorConsumer : IConsumer<Fault<GetCommunicationSettings>>, ISlackClient
  {
    private readonly ILogger<Fault<GetCommunicationSettings>> _logger;
    private readonly string _uri;
    private readonly Encoding _encoding = new UTF8Encoding();

    public PriWebCommunicator_ErrorConsumer()
    {
      //_uri = new Uri(Environment.GetEnvironmentVariable("SLACK_URL"));
      _uri = "https://hooks.slack.com/services/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";
    }
    public async Task Consume(ConsumeContext<Fault<GetCommunicationSettings>> context)
    {
      _logger?.Log(LogLevel.Debug, "FileReader_ErrorConsumer: {context}", context);
      PostMessage(context.Message.Exceptions.ToJson(), "microservices");
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
}