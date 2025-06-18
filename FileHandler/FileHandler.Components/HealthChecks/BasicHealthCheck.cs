using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace FileHandler.Components.HealthChecks
{
    public class BasicHealthCheck : IHealthCheck
    {
        private readonly ILogger<BasicHealthCheck> _logger;

        public BasicHealthCheck(ILogger<BasicHealthCheck> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                // Basic service health check
                _logger.LogDebug("Basic health check executed");
                return await Task.FromResult(HealthCheckResult.Healthy("Service is healthy"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Basic health check failed");
                return HealthCheckResult.Unhealthy("Service is unhealthy", ex);
            }
        }
    }
}