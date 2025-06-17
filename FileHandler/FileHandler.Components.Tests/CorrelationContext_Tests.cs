using FileHandler.Components.Telemetry;
using Xunit;

namespace FileHandler.Components.Tests
{
    public class CorrelationContext_Tests
    {
        [Fact]
        public void Should_generate_unique_correlation_ids()
        {
            // Act
            var id1 = CorrelationContext.GenerateNewCorrelationId();
            var id2 = CorrelationContext.GenerateNewCorrelationId();
            
            // Assert
            Assert.NotEqual(id1, id2);
            Assert.Equal(8, id1.Length);
            Assert.Equal(8, id2.Length);
        }

        [Fact]
        public void Should_maintain_correlation_id_across_calls()
        {
            // Arrange
            CorrelationContext.Clear();
            
            // Act
            var originalId = CorrelationContext.GenerateNewCorrelationId();
            var retrievedId = CorrelationContext.CorrelationId;
            
            // Assert
            Assert.Equal(originalId, retrievedId);
        }

        [Fact]
        public void Should_allow_setting_custom_correlation_id()
        {
            // Arrange
            var customId = "custom123";
            
            // Act
            CorrelationContext.CorrelationId = customId;
            var retrievedId = CorrelationContext.CorrelationId;
            
            // Assert
            Assert.Equal(customId, retrievedId);
            
            // Cleanup
            CorrelationContext.Clear();
        }

        [Fact]
        public void Should_clear_correlation_id()
        {
            // Arrange
            CorrelationContext.CorrelationId = "test123";
            
            // Act
            CorrelationContext.Clear();
            
            // Assert - After clear, accessing CorrelationId should generate a new one
            var newId = CorrelationContext.CorrelationId;
            Assert.NotEqual("test123", newId);
            Assert.Equal(8, newId.Length);
        }
    }
}