using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FileSender.Components.Consumers;
using MassTransit;
using MassTransit.Definition;
using MassTransit.RabbitMqTransport;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace FileSender.Service
{
  public class Program
  {
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
          var module = new DependencyTrackingTelemetryModule();
          module.IncludeDiagnosticSourceActivities.Add("MassTransit");
          var telemetryConfiguration = TelemetryConfiguration.CreateDefault();
          telemetryConfiguration.InstrumentationKey = "ba987c06-f3f2-4624-9720-89d441ca5805";
          telemetryConfiguration.TelemetryInitializers.Add(new HttpDependenciesParsingTelemetryInitializer());
          var telemetryClient = new TelemetryClient(telemetryConfiguration);
          module.Initialize(telemetryConfiguration);

          // Register telemetry services for proper disposal
          services.AddSingleton(telemetryConfiguration);
          services.AddSingleton(telemetryClient);
          services.AddSingleton(module);

          services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);
          services.AddMassTransit(cfg =>
          {
            cfg.AddConsumersFromNamespaceContaining<SendFileConsumer>();

            cfg.UsingRabbitMq(ConfigureBus);
          });
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

      Log.CloseAndFlush();
    }

    private static void ConfigureBus(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configurator)
    {
      configurator.UseMessageScheduler(new Uri("queue:quartz"));
      configurator.ConfigureEndpoints(context);
    }
  }
}