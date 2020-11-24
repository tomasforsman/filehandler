using FileHandler.Components.Consumers;
using FileHandler.Components.StateMachines;
using MassTransit.Definition;
using MassTransit.MongoDbIntegration.MessageData;
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
using Serilog.Events;
using Serilog;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace FileHandler.Service
{
  internal class Program
  {
    /// <summary>
    ///     Service that receives message and does something with it.
    /// </summary>
    private static DependencyTrackingTelemetryModule module;

    private static TelemetryClient telemetryClient;
    private static TelemetryConfiguration configuration;

    private static async Task Main(string[] args)
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
          configuration.InstrumentationKey = "05d55b31-6ab4-40f9-a226-a356f41457c5";
          configuration.TelemetryInitializers.Add(new HttpDependenciesParsingTelemetryInitializer());
          telemetryClient = new TelemetryClient(configuration);
          module.Initialize(configuration);

          services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);
          services.AddMassTransit(cfg =>
          {
            cfg.AddConsumersFromNamespaceContaining<SubmitFileInfoConsumer>();

            cfg.AddSagaStateMachine<FileHandlerStateMachine, FileHandlerState>(
                typeof(FileHandlerStateMachineDefinition))
              .MongoDbRepository(r =>
              {
                r.Connection = "mongodb://localhost";
                r.DatabaseName = "filedb";
                r.CollectionName = "states";
              });

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
      configurator.UseMessageData(new MongoDbMessageDataRepository("mongodb://127.0.0.1", "attachments"));
      configurator.UseMessageScheduler(new Uri("queue:quartz"));
      configurator.ConfigureEndpoints(context);
    }
  }
}