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
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FileReader.Service
{
    public class Program
    {
        private static DependencyTrackingTelemetryModule _module;
        private static TelemetryClient _telemetryClient;

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
                    _module = new DependencyTrackingTelemetryModule();
                    _module.IncludeDiagnosticSourceActivities.Add("MassTransit");

                    var configuration = TelemetryConfiguration.CreateDefault();
                    configuration.InstrumentationKey = "6b4c6c82-3250-4170-97d3-245ee1449276";
                    configuration.TelemetryInitializers.Add(new HttpDependenciesParsingTelemetryInitializer());

                    _telemetryClient = new TelemetryClient(configuration);

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
            ;

            if (isService)
                await builder.UseWindowsService().Build().RunAsync();
            else
                await builder.RunConsoleAsync();

            _module?.Dispose();
            _telemetryClient?.Flush();

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