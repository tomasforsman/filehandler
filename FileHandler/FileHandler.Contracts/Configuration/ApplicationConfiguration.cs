using System.ComponentModel.DataAnnotations;

namespace FileHandler.Contracts.Configuration
{
    /// <summary>
    /// Main application configuration containing all service configurations
    /// </summary>
    public class ApplicationConfiguration
    {
        /// <summary>
        /// Application Insights configuration for telemetry
        /// </summary>
        [Required]
        public ApplicationInsightsConfiguration ApplicationInsights { get; set; } = new();
        
        /// <summary>
        /// MongoDB database configuration
        /// </summary>
        [Required]
        public MongoDbConfiguration MongoDb { get; set; } = new();
        
        /// <summary>
        /// RabbitMQ message broker configuration
        /// </summary>
        [Required]
        public RabbitMqConfiguration RabbitMq { get; set; } = new();
        
        /// <summary>
        /// Queue configuration for message processing
        /// </summary>
        [Required]
        public QueueConfiguration Queues { get; set; } = new();
    }

    /// <summary>
    /// Configuration for Application Insights telemetry service
    /// </summary>
    public class ApplicationInsightsConfiguration
    {
        /// <summary>
        /// Instrumentation key for Application Insights
        /// </summary>
        [Required]
        public string InstrumentationKey { get; set; } = string.Empty;
    }

    /// <summary>
    /// Configuration for MongoDB database connections
    /// </summary>
    public class MongoDbConfiguration
    {
        /// <summary>
        /// MongoDB connection string
        /// </summary>
        [Required]
        public string ConnectionString { get; set; } = string.Empty;
        
        /// <summary>
        /// Name of the database to use
        /// </summary>
        [Required]
        public string DatabaseName { get; set; } = string.Empty;
        
        /// <summary>
        /// Name of the collection for state storage
        /// </summary>
        public string CollectionName { get; set; } = "states";
        
        /// <summary>
        /// Connection string for attachments database
        /// </summary>
        public string AttachmentsConnectionString { get; set; } = string.Empty;
        
        /// <summary>
        /// Name of the attachments database
        /// </summary>
        public string AttachmentsDatabaseName { get; set; } = "attachments";
    }

    /// <summary>
    /// Configuration for RabbitMQ message broker
    /// </summary>
    public class RabbitMqConfiguration
    {
        /// <summary>
        /// RabbitMQ host address
        /// </summary>
        [Required]
        public string HostAddress { get; set; } = string.Empty;
        
        /// <summary>
        /// Virtual host to connect to
        /// </summary>
        public string VirtualHost { get; set; } = "/";
        
        /// <summary>
        /// Username for authentication
        /// </summary>
        public string Username { get; set; } = string.Empty;
        
        /// <summary>
        /// Password for authentication
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }

    /// <summary>
    /// Configuration for message queues
    /// </summary>
    public class QueueConfiguration
    {
        /// <summary>
        /// Queue name for submitting file information
        /// </summary>
        public string SubmitFileInfo { get; set; } = "submit-file-info";
        
        /// <summary>
        /// Queue name for Quartz scheduler
        /// </summary>
        public string Quartz { get; set; } = "quartz";
    }
}