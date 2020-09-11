using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FileReader.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FileReader.Components.Consumers
{
    public class ReadFileConsumer :
        IConsumer<IsFileExisting>
    {
        private readonly ILogger<ReadFileConsumer> _logger;

        public ReadFileConsumer()
        {
        }

        public ReadFileConsumer(ILogger<ReadFileConsumer> logger)
        {
            _logger = logger;
        }


        public async Task Consume(ConsumeContext<IsFileExisting> context)
        {
            await CheckTime();

            async Task CheckTime()
            {
                var now = DateTimeOffset.Now;
                if (now.DayOfWeek == DayOfWeek.Thursday && now.Hour >= 13 && now.Minute >= 24) Debug.WriteLine("Yes");
                Debug.WriteLine("No");
            }
        }
    }
}