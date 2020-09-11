using System;
using System.Threading.Tasks;
using FileWatcher.Contracts;
using MassTransit;

namespace FileWatcher.Components
{
    public class LocalFileWatcherConsumer :
        IConsumer<LocalIsFileExisting>
    {
        public Task Consume(ConsumeContext<LocalIsFileExisting> context)
        {
            var now = DateTimeOffset.Now;
            if (now.DayOfWeek == DayOfWeek.Thursday && now.Hour >= 13 && now.Minute >= 24)
                return context.RespondAsync<YesItIs>(new { });

            return context.RespondAsync<NoNotYet>(new { });
        }
    }
}