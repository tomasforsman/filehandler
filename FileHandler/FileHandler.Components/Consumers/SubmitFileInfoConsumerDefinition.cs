using GreenPipes;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;
using MassTransit;

namespace FileHandler.Components.Consumers
{
  public class SubmitFileInfoConsumerDefinition :
    ConsumerDefinition<SubmitFileInfoConsumer>
  {
    public SubmitFileInfoConsumerDefinition()
    {
      Endpoint(x => x.PrefetchCount = 50);
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
      IConsumerConfigurator<SubmitFileInfoConsumer> consumerConfigurator)
    {
      consumerConfigurator.Options<BatchOptions>(options => options
        .SetMessageLimit(100)
        .SetTimeLimit(1000)
        .SetConcurrencyLimit(10));

      endpointConfigurator.UseMessageRetry(r =>
        r.Intervals(5, 500)); // (number of retries, time between each retry)
    }
  }
}