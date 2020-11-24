using MassTransit.Definition;
using MassTransit.RabbitMqTransport;
using MassTransit;
using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PriWebCommunicator.Components.Consumers;
using Serilog.Events;
using Serilog;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace PriWebCommunicator.Service
{
  public class Program
  {
    private static DependencyTrackingTelemetryModule module;
    private static TelemetryClient telemetryClient;
    private static TelemetryConfiguration configuration;

    public static async Task Main(string[] args)
    {
      var isService = !(Debugger.IsAttached || args.Contains("--console"));

      Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateLogger();

      var builder = new HostBuilder()
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
          config.AddJsonFile("appsettings.json", true);
          config.AddEnvironmentVariables();

          if (args != null) config.AddCommandLine(args);
        })
        .ConfigureServices((hostContext, services) =>
        {
          module = new DependencyTrackingTelemetryModule();
          module.IncludeDiagnosticSourceActivities.Add("MassTransit");
          configuration = TelemetryConfiguration.CreateDefault();
          configuration.InstrumentationKey = "ba987c06-f3f2-4624-9720-89d441ca5805";
          configuration.TelemetryInitializers.Add(new HttpDependenciesParsingTelemetryInitializer());
          telemetryClient = new TelemetryClient(configuration);

          services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);
          services.AddMassTransit(cfg =>
          {
            cfg.AddConsumersFromNamespaceContaining<FindFileDestinationConsumer>();
            cfg.UsingRabbitMq(ConfigureBus);
          });
          
          services.AddHostedService<MassTransitConsoleHostedService>();
        })
        .ConfigureLogging((hostingContext, logging) =>
        {
          logging.AddSerilog(dispose: true);
          logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
          logging.AddConsole();
        });

      if (isService)
        await builder.UseWindowsService().Build().RunAsync();
      else
        await builder.RunConsoleAsync();

      module?.Dispose();
      telemetryClient?.Flush();
      Log.CloseAndFlush();
    }

    private static void ConfigureBus(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configurator)
    {
      var findFileDestinationConsumer = new FindFileDestinationConsumer();
      configurator.UseMessageScheduler(new Uri("queue:quartz"));
      configurator.ReceiveEndpoint("pri-web-communicator", e => { e.Instance(findFileDestinationConsumer); });
    }
  }
}