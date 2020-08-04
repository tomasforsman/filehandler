using GreenPipes;
using MassTransit;
using MassTransit.Definition;

namespace FileHandler.Components.StateMachines
{
    public class FileHandlerStateMachineDefinition :
        SagaDefinition<FileInfoState>
    {
        public FileHandlerStateMachineDefinition()
        {
            ConcurrentMessageLimit = 4;
        }
        protected override void ConfigureSaga(IReceiveEndpointConfigurator endpointConfigurator, ISagaConfigurator<FileInfoState> sagaConfigurator)
        {
            // base.ConfigureSaga(endpointConfigurator, sagaConfigurator);
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 5000, 10000));
            endpointConfigurator.UseInMemoryOutbox();
        }
    }
}