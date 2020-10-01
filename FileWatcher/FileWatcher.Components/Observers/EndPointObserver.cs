using System;
using MassTransit;
using MassTransit.EndpointConfigurators;

namespace FileWatcher.Components.Observers
{
    public class EndPointObserver : IEndpointConfigurationObserver
    {
        public void EndpointConfigured<T>(T configurator) where T : IReceiveEndpointConfigurator
        {
            var result = configurator.GetType().FullName.ToString();
            Console.WriteLine("Configurator: {0}", result);
        }
    }
}