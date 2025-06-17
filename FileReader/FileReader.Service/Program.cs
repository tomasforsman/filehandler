using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FileHandler.Contracts.Configuration;
using FileReader.Components.Consumers;
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

namespace FileReader.Service
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
          var appConfig = ConfigurationValidator.GetValidatedConfiguration(hostContext.Configuration);
          
          module = new DependencyTrackingTelemetryModule();
          module.IncludeDiagnosticSourceActivities.Add("MassTransit");
          configuration = TelemetryConfiguration.CreateDefault();
          configuration.InstrumentationKey = appConfig.ApplicationInsights.InstrumentationKey;
          configuration.TelemetryInitializers.Add(new HttpDependenciesParsingTelemetryInitializer());
          telemetryClient = new TelemetryClient(configuration);
          module.Initialize(configuration);

          services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);
          services.AddMassTransit(cfg =>
          {
            cfg.AddConsumersFromNamespaceContaining<ReadFileConsumer>();
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
      var readFileConsumer = new ReadFileConsumer();
      configurator.UseMessageScheduler(new Uri("queue:quartz"));
      configurator.ReceiveEndpoint("file-reader", e => { e.Instance(readFileConsumer); });
    }
  }
}