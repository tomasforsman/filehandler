using GreenPipes;
using MassTransit;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;

namespace FileHandler.Components.Consumers
{
  public class FileReader_ErrorConsumerDefinition :
    ConsumerDefinition<FileReader_ErrorConsumer>
  {
    
    public FileReader_ErrorConsumerDefinition()
    {
      Endpoint(x => x.PrefetchCount = 50);
    }
    
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
      IConsumerConfigurator<FileReader_ErrorConsumer> consumerConfigurator)
    {
      endpointConfigurator.UseMessageRetry(r =>
        r.Intervals(5, 500)); // (number of retries, time between each retry)
    }
  }
}