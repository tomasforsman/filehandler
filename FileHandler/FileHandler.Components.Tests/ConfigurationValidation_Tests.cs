using System;
using FileHandler.Contracts.Configuration;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace FileHandler.Components.Tests
{
    public class ConfigurationValidation_Tests
    {
        [Fact]
        public void Should_validate_complete_configuration()
        {
            // Arrange
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddInMemoryCollection(new[]
            {
                new System.Collections.Generic.KeyValuePair<string, string>("AppConfig:ApplicationInsights:InstrumentationKey", "test-key"),
                new System.Collections.Generic.KeyValuePair<string, string>("AppConfig:MongoDb:ConnectionString", "mongodb://localhost"),
                new System.Collections.Generic.KeyValuePair<string, string>("AppConfig:MongoDb:DatabaseName", "testdb"),
                new System.Collections.Generic.KeyValuePair<string, string>("AppConfig:RabbitMq:HostAddress", "localhost"),
            });
            var configuration = configurationBuilder.Build();

            // Act
            var appConfig = ConfigurationValidator.GetValidatedConfiguration(configuration);

            // Assert
            Assert.NotNull(appConfig);
            Assert.Equal("test-key", appConfig.ApplicationInsights.InstrumentationKey);
            Assert.Equal("mongodb://localhost", appConfig.MongoDb.ConnectionString);
            Assert.Equal("testdb", appConfig.MongoDb.DatabaseName);
            Assert.Equal("localhost", appConfig.RabbitMq.HostAddress);
        }

        [Fact]
        public void Should_throw_on_missing_required_configuration()
        {
            // Arrange
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddInMemoryCollection(new[]
            {
                new System.Collections.Generic.KeyValuePair<string, string>("AppConfig:ApplicationInsights:InstrumentationKey", "test-key"),
                // Missing MongoDb configuration
            });
            var configuration = configurationBuilder.Build();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => 
                ConfigurationValidator.GetValidatedConfiguration(configuration));
        }

        [Fact]
        public void Should_use_default_values_for_optional_configuration()
        {
            // Arrange
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddInMemoryCollection(new[]
            {
                new System.Collections.Generic.KeyValuePair<string, string>("AppConfig:ApplicationInsights:InstrumentationKey", "test-key"),
                new System.Collections.Generic.KeyValuePair<string, string>("AppConfig:MongoDb:ConnectionString", "mongodb://localhost"),
                new System.Collections.Generic.KeyValuePair<string, string>("AppConfig:MongoDb:DatabaseName", "testdb"),
                new System.Collections.Generic.KeyValuePair<string, string>("AppConfig:RabbitMq:HostAddress", "localhost"),
            });
            var configuration = configurationBuilder.Build();

            // Act
            var appConfig = ConfigurationValidator.GetValidatedConfiguration(configuration);

            // Assert
            Assert.Equal("states", appConfig.MongoDb.CollectionName); // Default value
            Assert.Equal("/", appConfig.RabbitMq.VirtualHost); // Default value
            Assert.Equal("submit-file-info", appConfig.Queues.SubmitFileInfo); // Default value
            Assert.Equal("quartz", appConfig.Queues.Quartz); // Default value
        }
    }
}