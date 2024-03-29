﻿using GreenPipes;
using MassTransit;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;

namespace FileHandler.Components.Consumers
{
  public class FileReadConsumerDefinition :
    ConsumerDefinition<ReadConsumer>
  {
    
    public FileReadConsumerDefinition()
    {
      Endpoint(x => x.PrefetchCount = 50);
    }
    
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
      IConsumerConfigurator<ReadConsumer> consumerConfigurator)
    {
      endpointConfigurator.UseMessageRetry(r =>
        r.Intervals(5, 500)); // (number of retries, time between each retry)
    }
  }
}