using System;
using FileHandler.Components.Observers;
using FileHandler.Components.Telemetry;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace FileHandler.Components.Tests
{
    public class ReceiveObserver_Tests
    {
        [Fact]
        public void Should_require_logger_in_constructor()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ReceiveObserver(null));
        }

        [Fact]
        public void Should_create_observer_with_valid_logger()
        {
            // Arrange
            var logger = new NullLogger<ReceiveObserver>();
            
            // Act
            var observer = new ReceiveObserver(logger);
            
            // Assert
            Assert.NotNull(observer);
        }

        [Fact]
        public void Should_generate_correlation_id()
        {
            // Arrange
            CorrelationContext.Clear();
            
            // Act
            var correlationId = CorrelationContext.GenerateNewCorrelationId();
            
            // Assert
            Assert.False(string.IsNullOrEmpty(correlationId));
            Assert.Equal(8, correlationId.Length);
        }
    }
}