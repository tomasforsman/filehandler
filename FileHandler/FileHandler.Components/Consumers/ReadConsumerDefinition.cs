﻿using GreenPipes;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;
using MassTransit;

namespace FileHandler.Components.Consumers
{
  public class FileReadConsumerDefinition :
    ConsumerDefinition<ReadConsumer>
  {
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
      IConsumerConfigurator<ReadConsumer> consumerConfigurator) => endpointConfigurator.UseMessageRetry(r =>
      r.Intervals(5, 500)); // (number of retries, time between each retry)
  }
}