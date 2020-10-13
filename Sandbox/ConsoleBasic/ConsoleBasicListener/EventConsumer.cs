using System;
using System.Threading.Tasks;
using MassTransit;
using SharedContracts;

namespace ConsoleBasicListener
{
  class EventConsumer :
    IConsumer<ValueEntered>
  {
    public async Task Consume(ConsumeContext<ValueEntered> context)
    {
      Console.WriteLine("Value: {0}", context.Message.Value);
    }
  }
}