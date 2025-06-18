using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using FileHandler.Contracts.Configuration;

namespace FileHandler.Components.HealthChecks
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        private readonly ApplicationConfiguration _config;
        private readonly ILogger<DatabaseHealthCheck> _logger;

        public DatabaseHealthCheck(ApplicationConfiguration config, ILogger<DatabaseHealthCheck> logger)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new MongoClient(_config.MongoDb.ConnectionString);
                var database = client.GetDatabase(_config.MongoDb.DatabaseName);
                
                // Simple ping to check connectivity
                await database.RunCommandAsync((Command<MongoDB.Bson.BsonDocument>)"{ping:1}", cancellationToken: cancellationToken);
                
                _logger.LogDebug("MongoDB health check passed");
                return HealthCheckResult.Healthy("MongoDB is healthy");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "MongoDB health check failed");
                return HealthCheckResult.Unhealthy("MongoDB is unhealthy", ex);
            }
        }
    }
}