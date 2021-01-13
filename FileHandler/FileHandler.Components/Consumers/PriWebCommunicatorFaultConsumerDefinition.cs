using GreenPipes;
using MassTransit;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;

namespace FileHandler.Components.Consumers
{
  public class PriWebCommunicator_ErrorConsumerDefinition :
    ConsumerDefinition<PriWebCommunicator_ErrorConsumer>
  {
    
    public PriWebCommunicator_ErrorConsumerDefinition()
    {
      Endpoint(x => x.PrefetchCount = 50);
    }
    
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
      IConsumerConfigurator<PriWebCommunicator_ErrorConsumer> consumerConfigurator)
    {
      endpointConfigurator.UseMessageRetry(r =>
        r.Intervals(5, 500)); // (number of retries, time between each retry)
    }
  }
}