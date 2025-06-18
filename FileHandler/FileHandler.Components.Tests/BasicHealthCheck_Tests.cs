using System;
using System.Threading;
using System.Threading.Tasks;
using FileHandler.Components.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace FileHandler.Components.Tests
{
    public class BasicHealthCheck_Tests
    {
        [Fact]
        public void Should_require_logger_in_constructor()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new BasicHealthCheck(null));
        }

        [Fact]
        public async Task Should_return_healthy_status()
        {
            // Arrange
            var logger = new NullLogger<BasicHealthCheck>();
            var healthCheck = new BasicHealthCheck(logger);
            var context = new HealthCheckContext();

            // Act
            var result = await healthCheck.CheckHealthAsync(context, CancellationToken.None);

            // Assert
            Assert.Equal(HealthStatus.Healthy, result.Status);
            Assert.Equal("Service is healthy", result.Description);
        }

        [Fact]
        public void Should_create_health_check_with_valid_logger()
        {
            // Arrange
            var logger = new NullLogger<BasicHealthCheck>();
            
            // Act
            var healthCheck = new BasicHealthCheck(logger);
            
            // Assert
            Assert.NotNull(healthCheck);
        }

        [Fact]
        public async Task Should_return_healthy_status_with_custom_context()
        {
            // Arrange
            var logger = new NullLogger<BasicHealthCheck>();
            var healthCheck = new BasicHealthCheck(logger);
            var context = new HealthCheckContext
            {
                Registration = new HealthCheckRegistration("test", healthCheck, HealthStatus.Healthy, null)
            };

            // Act
            var result = await healthCheck.CheckHealthAsync(context, CancellationToken.None);

            // Assert
            Assert.Equal(HealthStatus.Healthy, result.Status);
            Assert.Equal("Service is healthy", result.Description);
            Assert.Null(result.Exception);
        }
    }
}