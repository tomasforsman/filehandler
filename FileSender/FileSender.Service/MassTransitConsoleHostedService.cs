using MassTransit;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace FileSender.Service
{
  public class MassTransitConsoleHostedService :
    IHostedService
  {
    private readonly IBusControl _bus;

    public MassTransitConsoleHostedService(IBusControl bus) => _bus = bus;

    public async Task StartAsync(CancellationToken cancellationToken) =>
      await _bus.StartAsync(cancellationToken).ConfigureAwait(false);

    public Task StopAsync(CancellationToken cancellationToken) => _bus.StopAsync(cancellationToken);
  }
}