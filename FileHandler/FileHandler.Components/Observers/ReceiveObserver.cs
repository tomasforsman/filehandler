using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using FileHandler.Components.Telemetry;

namespace FileHandler.Components.Observers
{
  public class ReceiveObserver :
    IReceiveObserver
  {
    private readonly ILogger<ReceiveObserver> _logger;

    public ReceiveObserver(ILogger<ReceiveObserver> logger)
    {
      _logger = logger;
    }
    public async Task PreReceive(ReceiveContext context)
    {
      // called immediately after the message was delivery by the transport
      CorrelationContext.GenerateNewCorrelationId();
      _logger.LogDebug("PreReceive: {MessageId} [CorrelationId: {CorrelationId}]", 
        context.GetMessageId()?.ToString(), CorrelationContext.CorrelationId);
    }

    public async Task PostReceive(ReceiveContext context)
    {
      // called after the message has been received and processed
      _logger.LogDebug("PostReceive: {MessageId} [CorrelationId: {CorrelationId}]", 
        context.GetMessageId()?.ToString(), CorrelationContext.CorrelationId);
    }

    public async Task PostConsume<T>(ConsumeContext<T> context, TimeSpan duration, string consumerType)
      where T : class
    {
      // called when the message was consumed, once for each consumer
      _logger.LogInformation("PostConsume: {MessageId} Duration: {Duration}ms ConsumerType: {ConsumerType} [CorrelationId: {CorrelationId}]", 
        context.MessageId?.ToString(), duration.TotalMilliseconds, consumerType, CorrelationContext.CorrelationId);
    }

    public async Task ConsumeFault<T>(ConsumeContext<T> context, TimeSpan elapsed, string consumerType,
      Exception exception) where T : class
    {
      // called when the message is consumed but the consumer throws an exception
      _logger.LogError(exception, "ConsumeFault: {MessageId} Duration: {Duration}ms ConsumerType: {ConsumerType} [CorrelationId: {CorrelationId}]",
        context.MessageId?.ToString(), elapsed.TotalMilliseconds, consumerType, CorrelationContext.CorrelationId);
    }

    public async Task ReceiveFault(ReceiveContext context, Exception exception)
    {
      // called when an exception occurs early in the message processing, such as deserialization, etc.
      _logger.LogError(exception, "ReceiveFault: {MessageId} [CorrelationId: {CorrelationId}]", 
        context.GetMessageId()?.ToString(), CorrelationContext.CorrelationId);
    }
  }
}