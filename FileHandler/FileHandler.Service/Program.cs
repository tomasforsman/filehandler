using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FileHandler.Components.Consumers;
using FileHandler.Components.StateMachines;
using MassTransit;
using MassTransit.Definition;
using MassTransit.MongoDbIntegration.MessageData;
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
          configuration.InstrumentationKey = "ba987c06-f3f2-4624-9720-89d441ca5805";
          //configuration.ConnectionString = "InstrumentationKey=05d55b31-6ab4-40f9-a226-a356f41457c5;IngestionEndpoint=https://northeurope-0.in.applicationinsights.azure.com/";
          configuration.TelemetryInitializers.Add(new HttpDependenciesParsingTelemetryInitializer());

          telemetryClient = new TelemetryClient(configuration);

          module.Initialize(configuration);
          
          // var loggerOptions = new ApplicationInsightsLoggerOptions();
          // var applicationInsightsLoggerProvider = new ApplicationInsightsLoggerProvider(Options.Create(configuration),
          //   Options.Create(loggerOptions));
          
          // ILoggerFactory factory = new LoggerFactory();
          // factory.AddProvider(applicationInsightsLoggerProvider);

          // LogContext.ConfigureCurrentLogContext(factory);

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
      // configuration?.Dispose();
      Log.CloseAndFlush();
    }

    private static void ConfigureBus(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configurator)
    {
      var fileHandlerState = new FileHandlerState();
      configurator.UseMessageData(new MongoDbMessageDataRepository("mongodb://127.0.0.1", "attachments"));
      configurator.UseMessageScheduler(new Uri("queue:quartz"));
      //var SubmitFileInfoConsumer = new SubmitFileInfoConsumer();
      //configurator.ReceiveEndpoint("submit-file", e => { e.Instance(SubmitFileInfoConsumer); });
      configurator.ConfigureEndpoints(context); //, e => e.Exclude<SubmitFileInfoConsumer>());
      // var submitFileInfoConsumer = new SubmitFileInfoConsumer();
      // configurator.ReceiveEndpoint("submit-file-info", e =>
      // {
      //     e.Instance(submitFileInfoConsumer);
      // });
      //
      // var fileHandlerStateMachine = new FileHandlerStateMachine();
      // configurator.ReceiveEndpoint("file-handler-state", e =>
      // {
      //     e.Instance(fileHandlerStateMachine);
      // });
      //
      // configurator.ReceiveEndpoint("submit-file-info", e =>
      // {
      //     e.PrefetchCount = 16;
      //     e.ConfigureConsumer<SubmitFileInfoConsumer>(context);
      // });
      //var observer = new ReceiveObserver();
      //var handle = configurator.ConnectReceiveObserver(observer);
    }
  }
}