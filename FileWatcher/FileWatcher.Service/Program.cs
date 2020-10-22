using FileWatcher.Components;
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
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Pri.Contracts;
using Serilog;
using Serilog.Events;

namespace FileWatcher.Service
{
  internal class Program
  {
    private static DependencyTrackingTelemetryModule _module;
    private static TelemetryClient _telemetryClient;
    
    public static Settings Settings { get; set; }
    //public static AppConfig AppSettings { get; set; }

    private static async Task Main(string[] args)
    {
      Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateLogger();
      
      
      var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", false, true)
        .AddEnvironmentVariables()
        .Build();

      var settings = configuration.Get<Settings>();

      var isService = !(Debugger.IsAttached || args.Contains("--console"));

      var builder = new HostBuilder()
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
          config.AddJsonFile("appsettings.json", false, true);
          config.AddEnvironmentVariables();

          if (args != null)
            config.AddCommandLine(args);
        })
        .ConfigureServices((hostContext, services) =>
        {
          _module = new DependencyTrackingTelemetryModule();
          _module.IncludeDiagnosticSourceActivities.Add("MassTransit");

          var configuration = TelemetryConfiguration.CreateDefault();
          configuration.InstrumentationKey = "05d55b31-6ab4-40f9-a226-a356f41457c5";
          configuration.TelemetryInitializers.Add(new HttpDependenciesParsingTelemetryInitializer());

          _telemetryClient = new TelemetryClient(configuration);
          _module.Initialize(configuration);
          
          services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);

          services.Configure<Settings.AppConfiguration>(hostContext.Configuration.GetSection("RabbitMq"));

          services.AddMassTransit(cfg =>
          {
            cfg.AddConsumer<LocalFileWatcherConsumer>();
            //cfg.AddBus(ConfigureBus);
            cfg.UsingRabbitMq(ConfigureBus);
            cfg.AddRequestClient<SubmitFileInfo>(new Uri("queue:submit-file-info"));
          });

          services.AddHostedService<MassTransitConsoleHostedService>();
          services.AddHostedService<FileWatcher>();
        })
        .ConfigureLogging((hostingContext, logging) =>
        {
          logging.AddSerilog(dispose: true);
          logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
          logging.AddConsole();
        });

      if (isService)
        await builder.UseWindowsService().Build().RunAsync();
      //await builder.UseSystemd().Build().RunAsync(); // For Linux, replace the nuget package: "Microsoft.Extensions.Hosting.WindowsServices" with "Microsoft.Extensions.Hosting.Systemd", and then use this line instead
      else
        await builder.RunConsoleAsync();
      
      _module?.Dispose();
      _telemetryClient?.Flush();

      Log.CloseAndFlush();
    }

    public void ConfigureServices(IServiceCollection services)
    {
    }

    private static void ConfigureBus(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configurator) =>
      configurator.ConfigureEndpoints(context);

    // static IBusControl ConfigureBus(IBusRegistrationContext provider)
    // {
    //     Settings = provider.GetRequiredService<IOptions<Settings>>().Value;
    //
    //     // X509Certificate2 x509Certificate2 = null;
    //     //
    //     // X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
    //     // store.Open(OpenFlags.ReadOnly);
    //     //
    //     // try
    //     // {
    //     //     X509Certificate2Collection certificatesInStore = store.Certificates;
    //     //
    //     //     x509Certificate2 = certificatesInStore.OfType<X509Certificate2>()
    //     //         .FirstOrDefault(cert => cert.Thumbprint?.ToLower() == Settings.AppConfig.RabbitMq.SSLThumbprint?.ToLower());
    //     // }
    //     // finally
    //     // {
    //     //     store.Close();
    //     // }
    //
    //     return Bus.Factory.CreateUsingRabbitMq(cfg =>
    //     {
    //         var RabbitMq = Settings.AppConfig.RabbitMq;
    //         cfg.Host(RabbitMq.Host, RabbitMq.VirtualHost, h =>
    //         {
    //             h.Username(RabbitMq.Username);
    //             h.Password(RabbitMq.Password);
    //
    //             // if (RabbitMq.SSLActive)
    //             // {
    //             //     h.UseSsl(ssl =>
    //             //     {
    //             //         ssl.ServerName = Dns.GetHostName();
    //             //         ssl.AllowPolicyErrors(SslPolicyErrors.RemoteCertificateNameMismatch);
    //             //         //ssl.Certificate = x509Certificate2;
    //             //         //ssl.Protocol = SslProtocols.Tls12;
    //             //         ssl.CertificateSelectionCallback = CertificateSelectionCallback;
    //             //     });
    //             // }
    //         });
    //
    //         cfg.ConfigureEndpoints(provider);
    //     });
    // }

    // private static X509Certificate CertificateSelectionCallback(object sender, string targethost, X509CertificateCollection localcertificates, X509Certificate remotecertificate, string[] acceptableissuers)
    // {
    //     var serverCertificate = localcertificates.OfType<X509Certificate2>()
    //                             .FirstOrDefault(cert => cert.Thumbprint.ToLower() == Settings.AppConfig.RabbitMq.SSLThumbprint.ToLower());
    //
    //     return serverCertificate ?? throw new Exception("Wrong certificate");
    // }
  }
}