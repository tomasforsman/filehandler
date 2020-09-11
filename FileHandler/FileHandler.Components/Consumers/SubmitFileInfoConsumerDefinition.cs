using GreenPipes;
using MassTransit;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;

namespace FileHandler.Components.Consumers
{
    public class SubmitFileInfoConsumerDefinition :
        ConsumerDefinition<SubmitFileInfoConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<SubmitFileInfoConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r =>
                r.Intervals(3, 1000)); // (number of retries, time between each retry)
        }
    }
}