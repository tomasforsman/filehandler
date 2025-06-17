using System.ComponentModel.DataAnnotations;

namespace FileHandler.Contracts.Configuration
{
    public class ApplicationConfiguration
    {
        [Required]
        public ApplicationInsightsConfiguration ApplicationInsights { get; set; } = new();
        
        [Required]
        public MongoDbConfiguration MongoDb { get; set; } = new();
        
        [Required]
        public RabbitMqConfiguration RabbitMq { get; set; } = new();
        
        [Required]
        public QueueConfiguration Queues { get; set; } = new();
    }

    public class ApplicationInsightsConfiguration
    {
        [Required]
        public string InstrumentationKey { get; set; } = string.Empty;
    }

    public class MongoDbConfiguration
    {
        [Required]
        public string ConnectionString { get; set; } = string.Empty;
        
        [Required]
        public string DatabaseName { get; set; } = string.Empty;
        
        public string CollectionName { get; set; } = "states";
        
        public string AttachmentsConnectionString { get; set; } = string.Empty;
        
        public string AttachmentsDatabaseName { get; set; } = "attachments";
    }

    public class RabbitMqConfiguration
    {
        [Required]
        public string HostAddress { get; set; } = string.Empty;
        
        public string VirtualHost { get; set; } = "/";
        
        public string Username { get; set; } = string.Empty;
        
        public string Password { get; set; } = string.Empty;
    }

    public class QueueConfiguration
    {
        public string SubmitFileInfo { get; set; } = "submit-file-info";
        
        public string Quartz { get; set; } = "quartz";
    }
}