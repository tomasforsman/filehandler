using FileWatcher.Contracts;
using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FileWatcher.Service
{
    public class FileWatcher :
        IHostedService
    {
        private readonly IRequestClient<IsFileExisting> _client;
        private Timer _timer;
        public string FileId = Guid.NewGuid().ToString();
        public string FileName = Guid.NewGuid().ToString();
        public string Folder = Guid.NewGuid().ToString();
        public DateTime TimeStamp = DateTime.UtcNow;

        public FileWatcher(IRequestClient<IsFileExisting> client)
        {
            _client = client;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var timeInSeconds = 5;
            _timer = new Timer(CheckForFile, null, TimeSpan.FromSeconds(timeInSeconds),
                TimeSpan.FromSeconds(timeInSeconds));

            return Task.CompletedTask;
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer.Dispose();

            return Task.CompletedTask;
        }

        private async void CheckForFile(object state)
        {
            var (yes, no) = await _client.GetResponse<YesItIs, NoNotYet>(new { });

            if (yes.IsCompletedSuccessfully)
                await Console.Out.WriteLineAsync("It's party time!");

            if (no.IsCompletedSuccessfully)
                await Console.Out.WriteLineAsync("Nope, not yet");
        }
    }
}