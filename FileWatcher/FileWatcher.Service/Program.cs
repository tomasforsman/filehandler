using FileWatcher.Components;
using FileWatcher.Contracts;
using MassTransit;
using MassTransit.Definition;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FileWatcher.Service
{
    internal class Program
    {
        public static Settings Settings { get; set; }
        //public static AppConfig AppSettings { get; set; }

        private static async Task Main(string[] args)
        {
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
                    services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);

                    services.Configure<Settings.AppConfiguration>(hostContext.Configuration.GetSection("RabbitMq"));

                    services.AddMassTransit(cfg =>
                    {
                        cfg.AddConsumer<LocalFileWatcherConsumer>();
                        //cfg.AddBus(ConfigureBus);
                        cfg.UsingRabbitMq(ConfigureBus);
                        cfg.AddRequestClient<IsFileExisting>(new Uri("queue:file-watcher"));
                    });

                    services.AddHostedService<MassTransitConsoleHostedService>();
                    services.AddHostedService<FileWatcher>();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                });

            if (isService)
                await builder.UseWindowsService().Build().RunAsync();
            //await builder.UseSystemd().Build().RunAsync(); // For Linux, replace the nuget package: "Microsoft.Extensions.Hosting.WindowsServices" with "Microsoft.Extensions.Hosting.Systemd", and then use this line instead
            else
                await builder.RunConsoleAsync();
        }

        public void ConfigureServices(IServiceCollection services)
        {
        }

        private static void ConfigureBus(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configurator) => configurator.ConfigureEndpoints(context);

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