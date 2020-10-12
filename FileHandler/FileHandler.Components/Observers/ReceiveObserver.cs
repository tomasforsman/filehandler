using System;
using System.Threading.Tasks;
using MassTransit;

namespace FileHandler.Components.Observers
{
  public class ReceiveObserver :
    IReceiveObserver
  {
    public async Task PreReceive(ReceiveContext context)
    {
      // called immediately after the message was delivery by the transport
      Console.WriteLine("PreRecieve: {0}", context.GetMessageId().Value.ToString());
    }

    public async Task PostReceive(ReceiveContext context)
    {
      // called after the message has been received and processed
      Console.WriteLine("PostRecieve: {0}", context.GetMessageId().Value.ToString());
    }

    public async Task PostConsume<T>(ConsumeContext<T> context, TimeSpan duration, string consumerType)
      where T : class
    {
      // called when the message was consumed, once for each consumer
      Console.WriteLine("PostConsume: {0} TimeSpan: {1} ConsumerType: {2}", context.MessageId.Value.ToString(),
        duration.Milliseconds.ToString(), consumerType);
    }

    public async Task ConsumeFault<T>(ConsumeContext<T> context, TimeSpan elapsed, string consumerType,
      Exception exception) where T : class
    {
      // called when the message is consumed but the consumer throws an exception
      Console.WriteLine("ConsumeFault: {0} TimeSpan: {1} ConsumerType: {2} Exception: {3}",
        context.MessageId.Value.ToString(), elapsed.Milliseconds.ToString(), consumerType, exception);
    }

    public async Task ReceiveFault(ReceiveContext context, Exception exception)
    {
      // called when an exception occurs early in the message processing, such as deserialization, etc.
      Console.WriteLine("PreRecieve: {0}", context.GetMessageId().Value.ToString());
    }
  }
}