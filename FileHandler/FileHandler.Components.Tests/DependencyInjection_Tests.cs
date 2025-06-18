using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MassTransit;
using Xunit;
using FileHandler.Components.Consumers;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.ApplicationInsights.Extensibility;

namespace FileHandler.Components.Tests
{
    public class DependencyInjection_Tests
    {
        [Fact]
        public void Should_register_consumers_with_dependency_injection()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumersFromNamespaceContaining<SubmitFileInfoConsumer>();
                cfg.UsingInMemory((context, configurator) =>
                {
                    configurator.ConfigureEndpoints(context);
                });
            });

            var serviceProvider = services.BuildServiceProvider();

            // Act & Assert
            var consumer = serviceProvider.GetService<SubmitFileInfoConsumer>();
            Assert.NotNull(consumer);
        }

        [Fact]
        public void Should_register_telemetry_services_as_singletons()
        {
            // Arrange
            var services = new ServiceCollection();
            
            var module = new DependencyTrackingTelemetryModule();
            var telemetryConfiguration = TelemetryConfiguration.CreateDefault();
            telemetryConfiguration.InstrumentationKey = "test-key";
            var telemetryClient = new TelemetryClient(telemetryConfiguration);

            services.AddSingleton(telemetryConfiguration);
            services.AddSingleton(telemetryClient);
            services.AddSingleton(module);

            var serviceProvider = services.BuildServiceProvider();

            // Act
            var config1 = serviceProvider.GetService<TelemetryConfiguration>();
            var config2 = serviceProvider.GetService<TelemetryConfiguration>();
            var client1 = serviceProvider.GetService<TelemetryClient>();
            var client2 = serviceProvider.GetService<TelemetryClient>();
            var module1 = serviceProvider.GetService<DependencyTrackingTelemetryModule>();
            var module2 = serviceProvider.GetService<DependencyTrackingTelemetryModule>();

            // Assert
            Assert.NotNull(config1);
            Assert.NotNull(client1);
            Assert.NotNull(module1);
            Assert.Same(config1, config2); // Verify singleton behavior
            Assert.Same(client1, client2); // Verify singleton behavior
            Assert.Same(module1, module2); // Verify singleton behavior
        }

        [Fact]
        public void Should_dispose_telemetry_services_with_service_provider()
        {
            // Arrange
            var services = new ServiceCollection();
            
            var module = new DependencyTrackingTelemetryModule();
            var telemetryConfiguration = TelemetryConfiguration.CreateDefault();
            telemetryConfiguration.InstrumentationKey = "test-key";
            var telemetryClient = new TelemetryClient(telemetryConfiguration);

            services.AddSingleton(telemetryConfiguration);
            services.AddSingleton(telemetryClient);
            services.AddSingleton(module);

            var serviceProvider = services.BuildServiceProvider();

            // Act - Get services to ensure they're created
            var config = serviceProvider.GetService<TelemetryConfiguration>();
            var client = serviceProvider.GetService<TelemetryClient>();
            var moduleService = serviceProvider.GetService<DependencyTrackingTelemetryModule>();

            // Disposing service provider should dispose all disposable services
            Assert.NotNull(config);
            Assert.NotNull(client);
            Assert.NotNull(moduleService);

            // Act & Assert - Should not throw when disposing
            serviceProvider.Dispose();
        }

        [Fact]
        public void Should_use_built_in_mass_transit_hosting()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddLogging();
            
            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumersFromNamespaceContaining<SubmitFileInfoConsumer>();
                cfg.UsingInMemory((context, configurator) =>
                {
                    configurator.ConfigureEndpoints(context);
                });
            });
            
            // No need to explicitly add hosted service - it's automatic

            var serviceProvider = services.BuildServiceProvider();

            // Act
            var hostedServices = serviceProvider.GetServices<Microsoft.Extensions.Hosting.IHostedService>();
            
            // Assert
            Assert.NotEmpty(hostedServices);
            Assert.Contains(hostedServices, service => 
                service.GetType().Namespace?.StartsWith("MassTransit") == true);
        }
    }
}