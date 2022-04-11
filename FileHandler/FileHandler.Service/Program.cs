using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FileHandler.Components.Consumers;
using FileHandler.Components.StateMachines;
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
using Microsoft.Extensions.Configuration;
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
              // .RedisRepository("127.0.0.1");
              .MongoDbRepository(r =>
              {
                r.Connection = "mongodb://localhost";
                r.DatabaseName = "filedb";
                r.CollectionName = "states";
              }); //.RedisRepository("127.0.0.1");

            cfg.UsingRabbitMq(ConfigureBus);
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
    private static void ConfigureBus(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configurator)
    {
      configurator.UseMessageData(new MongoDbMessageDataRepository("mongodb://127.0.0.1", "attachments"));
      configurator.UseMessageScheduler(new Uri("queue:quartz"));
      configurator.ConfigureEndpoints(context);
    }
  }
}