using System;
using System.Threading.Tasks;
using MassTransit;

namespace FileWatcher.Components.Observers
{
  public class SendObserver : ISendObserver
  {
    public async Task PreSend<T>(SendContext<T> context) where T : class
    {
      // called just before a message is sent, all the headers should be setup and everything
      Console.WriteLine("Presend");
    }

    public async Task PostSend<T>(SendContext<T> context) where T : class
    {
      // called just after a message it sent to the transport and acknowledged (RabbitMQ)
      Console.WriteLine("PostSend");
    }

    public async Task SendFault<T>(SendContext<T> context, Exception exception) where T : class
    {
      // called if an exception occurred sending the message
      Console.WriteLine("SendFault");
    }
  }
}