using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FileWatcher.Service
{
  public class MassTransitConsoleHostedService :
    IHostedService
  {
    private readonly IBusControl _bus;
    private readonly ILogger _logger;

    public MassTransitConsoleHostedService(IBusControl bus, ILoggerFactory loggerFactory)
    {
      _bus = bus;
      _logger = loggerFactory.CreateLogger<MassTransitConsoleHostedService>();
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
      _logger.LogInformation("Starting bus");
      await _bus.StartAsync(cancellationToken).ConfigureAwait(false);
      _logger.LogInformation("bus Started");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
      _logger.LogInformation("Stopping bus");
      return _bus.StopAsync(cancellationToken);
    }
  }
}