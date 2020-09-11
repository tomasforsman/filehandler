namespace FileHandler.Components.StateMachines
{
using GreenPipes;
using MassTransit;
using MassTransit.Definition;


    public class FileHandlerStateMachineDefinition :
        SagaDefinition<FileHandlerState>
    {
        public FileHandlerStateMachineDefinition()
        {
            ConcurrentMessageLimit = 12;
        }
        protected override void ConfigureSaga(IReceiveEndpointConfigurator endpointConfigurator, ISagaConfigurator<FileHandlerState> sagaConfigurator)
        {
            // base.ConfigureSaga(endpointConfigurator, sagaConfigurator);
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 5000, 10000));
            endpointConfigurator.UseInMemoryOutbox();
        }
    }
}