using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MassTransit;
using Xunit;
using PriWebCommunicator.Components.Consumers;

namespace FileHandler.Components.Tests
{
    public class ConsumerRegistration_Tests
    {
        [Fact]
        public void PriWebCommunicator_Should_register_consumers_properly()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddLogging();
            
            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumersFromNamespaceContaining<FindFileDestinationConsumer>();
                cfg.UsingInMemory((context, configurator) =>
                {
                    configurator.ConfigureEndpoints(context);
                });
            });

            var serviceProvider = services.BuildServiceProvider();

            // Act
            var consumer = serviceProvider.GetService<FindFileDestinationConsumer>();

            // Assert
            Assert.NotNull(consumer);
        }

        [Fact]
        public void FindFileDestinationConsumer_Should_require_logger_dependency()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddTransient<FindFileDestinationConsumer>();

            var serviceProvider = services.BuildServiceProvider();

            // Act
            var consumer = serviceProvider.GetService<FindFileDestinationConsumer>();

            // Assert
            Assert.NotNull(consumer);
        }

        [Fact]
        public void FindFileDestinationConsumer_Should_throw_when_logger_is_null()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FindFileDestinationConsumer(null));
        }
    }
}