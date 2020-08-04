using System;
using System.Threading.Tasks;
using FileWatcher.Contracts;
using MassTransit;

namespace FileWatcher.Components
{
    public class FileWatcherConsumer :
        IConsumer<IsFileExisting>
    {
        public Task Consume(ConsumeContext<IsFileExisting> context)
        {
            var now = DateTimeOffset.Now;
            if (now.DayOfWeek == DayOfWeek.Thursday && now.Hour >= 11 && now.Minute >= 05)
            {
                return context.RespondAsync<YesItIs>(new { });
            }

            return context.RespondAsync<NoNotYet>(new { });
        }
    }
}