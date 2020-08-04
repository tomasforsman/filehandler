using System;
using System.Threading;
using System.Threading.Tasks;
using FileWatcher.Contracts;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RabbitMQ.Client.Framing.Impl;

namespace FileWatcher.Service
{
    public class FileWatcher :
        IHostedService
    {
        readonly IRequestClient<IsFileExisting> _client;
        Timer _timer;

        public FileWatcher(IRequestClient<IsFileExisting> client)
        {
            _client = client;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            int timeInSeconds = 5;
            _timer = new Timer(CheckForFile, null, TimeSpan.FromSeconds(timeInSeconds), TimeSpan.FromSeconds(timeInSeconds));

            return Task.CompletedTask;
        }

        async void CheckForFile(object state)
        {
            var (yes, no) = await _client.GetResponse<YesItIs, NoNotYet>(new { });

            if (yes.IsCompletedSuccessfully)
                await Console.Out.WriteLineAsync("It's party time!");

            if (no.IsCompletedSuccessfully)
                await Console.Out.WriteLineAsync("Nope, not yet");
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer.Dispose();

            return Task.CompletedTask;
        }
    }
}