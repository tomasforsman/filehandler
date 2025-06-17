using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FileHandler.Components.Consumers;
using FileHandler.Components.StateMachines;
using FileHandler.Contracts.Configuration;
using MassTransit;
using MassTransit.Definition;
using MassTransit.MongoDbIntegration.MessageData;
using MassTransit.RabbitMqTransport;
using MassTransit.RedisIntegration.Contexts;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Debugging;

using StackExchange.Redis;

namespace FileHandler.Service
{
  internal class Program
  {
    
    
    /// <summary>
    ///   Service that receives message and does something with it.
    /// </summary>
    private static DependencyTrackingTelemetryModule module;

    private static TelemetryClient telemetryClient;
    private static TelemetryConfiguration configuration;

    private static async Task Main(string[] args)
    {
      SelfLog.Enable(Console.Error);
      
      Thread.CurrentThread.Name = "Main thread";
      
      var isService = !(Debugger.IsAttached || args.Contains("--console"));

      var conf = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
        .Build();
      
      Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(conf)
        .CreateLogger();
      
      Log.Information("Test");
      var builder = new HostBuilder()
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
          config.SetBasePath(Directory.GetCurrentDirectory());
          config.AddJsonFile("appsettings.json", true);
          config.AddEnvironmentVariables();
          if (args != null) config.AddCommandLine(args);
          if (args == null) Log.Error("Message to File");
        })
        .ConfigureServices((hostContext, services) =>
        {
          var appConfig = FileHandler.Contracts.Configuration.ConfigurationValidator.GetValidatedConfiguration(hostContext.Configuration);
          
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
            cfg.AddConsumersFromNamespaceContaining<SubmitFileInfoConsumer>();

            cfg.AddSagaStateMachine<FileHandlerStateMachine, FileHandlerState>(
                typeof(FileHandlerStateMachineDefinition))
              .MongoDbRepository(r =>
              {
                r.Connection = appConfig.MongoDb.ConnectionString;
                r.DatabaseName = appConfig.MongoDb.DatabaseName;
                r.CollectionName = appConfig.MongoDb.CollectionName;
              });

            cfg.UsingRabbitMq((context, configurator) => ConfigureBus(context, configurator, appConfig));
          });

          services.AddHostedService<MassTransitConsoleHostedService>();
        })
        .UseSerilog()
        .ConfigureLogging((hostingContext, logging) =>
        {
          logging.AddSerilog(dispose: true);
          // logging.AddConfiguration(hostingContext.Configuration.GetSection("Serilog"));
          // logging.AddConsole();
          //Log.Information("Logging Configured");
        });
        
      if (isService)
        await builder.UseWindowsService().Build().RunAsync();
      else
        await builder.RunConsoleAsync();
      Log.Information("Test");
      
      module?.Dispose();
      telemetryClient?.Flush();
      Log.CloseAndFlush();
    }
    private static void ConfigureBus(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configurator, FileHandler.Contracts.Configuration.ApplicationConfiguration appConfig)
    {
      configurator.UseMessageData(new MongoDbMessageDataRepository(appConfig.MongoDb.AttachmentsConnectionString, appConfig.MongoDb.AttachmentsDatabaseName));
      configurator.UseMessageScheduler(new Uri($"queue:{appConfig.Queues.Quartz}"));
      configurator.ConfigureEndpoints(context);
    }
  }
}