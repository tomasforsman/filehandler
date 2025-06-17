﻿using System.Net.Http;
using System.Threading.Tasks;
using FileHandler.Contracts.Configuration;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: true)
        .AddEnvironmentVariables()
        .Build();

      var appConfig = ConfigurationValidator.GetValidatedConfiguration(configuration);
      var telemetryConfiguration = TelemetryConfiguration.CreateDefault();

      telemetryConfiguration.InstrumentationKey = appConfig.ApplicationInsights.InstrumentationKey;
      telemetryConfiguration.TelemetryInitializers.Add(new HttpDependenciesParsingTelemetryInitializer());

      var telemetryClient = new TelemetryClient(telemetryConfiguration);
      using (InitializeDependencyTracking(telemetryConfiguration))
      {
        // run app...

        telemetryClient.TrackTrace("Hello World!");

        using (var httpClient = new HttpClient())
        {
          // Http dependency is automatically tracked!
          httpClient.GetAsync("https://microsoft.com").Wait();
        }
      }

      // before exit, flush the remaining data
      telemetryClient.Flush();

      // flush is not blocking when not using InMemoryChannel so wait a bit. There is an active issue regarding the need for `Sleep`/`Delay`
      // which is tracked here: https://github.com/microsoft/ApplicationInsights-dotnet/issues/407
      Task.Delay(5000).Wait();
    }

    private static DependencyTrackingTelemetryModule InitializeDependencyTracking(TelemetryConfiguration configuration)
    {
      var module = new DependencyTrackingTelemetryModule();

      // prevent Correlation Id to be sent to certain endpoints. You may add other domains as needed.
      module.ExcludeComponentCorrelationHttpHeadersOnDomains.Add("core.windows.net");
      module.ExcludeComponentCorrelationHttpHeadersOnDomains.Add("core.chinacloudapi.cn");
      module.ExcludeComponentCorrelationHttpHeadersOnDomains.Add("core.cloudapi.de");
      module.ExcludeComponentCorrelationHttpHeadersOnDomains.Add("core.usgovcloudapi.net");
      module.ExcludeComponentCorrelationHttpHeadersOnDomains.Add("localhost");
      module.ExcludeComponentCorrelationHttpHeadersOnDomains.Add("127.0.0.1");

      // enable known dependency tracking, note that in future versions, we will extend this list. 
      // please check default settings in https://github.com/microsoft/ApplicationInsights-dotnet-server/blob/develop/WEB/Src/DependencyCollector/DependencyCollector/ApplicationInsights.config.install.xdt

      module.IncludeDiagnosticSourceActivities.Add("Microsoft.Azure.ServiceBus");
      module.IncludeDiagnosticSourceActivities.Add("Microsoft.Azure.EventHubs");

      // initialize the module
      module.Initialize(configuration);

      return module;
    }
  }
}