

using System;
using FileHandler.Contracts.Configuration;
using MassTransit;
using MassTransit.MongoDbIntegration.MessageData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Pri.Contracts;

namespace FileHandler
{
  /// <summary>
  ///   API that sends put or post requests to FileHandler.Service using MassTransit and RabbitMQ.
  /// </summary>
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    private IConfiguration Configuration { get; }
    

    public void ConfigureServices(IServiceCollection services)
    {
      var appConfig = ConfigurationValidator.GetValidatedConfiguration(Configuration);
      
      services.AddHealthChecks();

      // services.AddApplicationInsightsTelemetry();
      //
      // services.ConfigureTelemetryModule<DependencyTrackingTelemetryModule>((module, o) =>
      // {
      //     module.IncludeDiagnosticSourceActivities.Add("MassTransit");
      // });

      services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);
      
      services.Configure<MassTransitHostOptions>(options =>
      {
        options.WaitUntilStarted = true;
        options.StartTimeout = TimeSpan.FromSeconds(30);
        options.StopTimeout = TimeSpan.FromMinutes(1);
      });

      services.AddMassTransit(mt =>
      {
        mt.UsingRabbitMq((context, cfg) =>
        {
          MessageDataDefaults.ExtraTimeToLive = TimeSpan.FromDays(1);
          MessageDataDefaults.Threshold = 2000;
          MessageDataDefaults.AlwaysWriteToRepository = false;
          cfg.UseMessageData(new MongoDbMessageDataRepository(appConfig.MongoDb.AttachmentsConnectionString, appConfig.MongoDb.AttachmentsDatabaseName));
        });

        mt.AddRequestClient<SubmitFileInfo>(new Uri($"queue:{appConfig.Queues.SubmitFileInfo}"));
        mt.AddRequestClient<CheckFileInfo>();
      });


      services.Configure<HealthCheckPublisherOptions>(options =>
      {
        options.Delay = TimeSpan.FromSeconds(2);
        options.Predicate = check => check.Tags.Contains("ready");
      });
      
      services.AddOpenApiDocument(cfg => cfg.PostProcess = d => d.Info.Title = "FileHandler API");
      services.AddControllers();
      //services.AddSwaggerDocument();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

      app.UseHttpsRedirection();

      app.UseOpenApi();
      app.UseSwaggerUi3();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions
        {
          Predicate = check => check.Tags.Contains("ready")
        });

        endpoints.MapHealthChecks("/health/live", new HealthCheckOptions
        {
          // Exclude all checks and return a 200-Ok.
          Predicate = _ => false
        });
      });
    }
  }
}