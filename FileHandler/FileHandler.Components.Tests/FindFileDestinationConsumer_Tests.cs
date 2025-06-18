using System;
using FileHandler.Components.Consumers;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace FileHandler.Components.Tests
{
    public class ReadConsumer_Tests
    {
        [Fact]
        public void Should_require_logger_in_constructor()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ReadConsumer(null));
        }

        [Fact]
        public void Should_create_consumer_with_valid_logger()
        {
            // Arrange
            var logger = new NullLogger<ReadConsumer>();
            
            // Act
            var consumer = new ReadConsumer(logger);
            
            // Assert
            Assert.NotNull(consumer);
        }
    }
}