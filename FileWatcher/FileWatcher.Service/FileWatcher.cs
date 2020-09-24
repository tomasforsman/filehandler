using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;
using FileHandler.Contracts;
using FileWatcher.Contracts;
using PRI.Contracts;


namespace FileWatcher.Service
{
    public class FileWatcher :
        IHostedService
    {
        private Timer _timer;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // var timeInSeconds = 5;
            // _timer = new Timer(CheckForFile, null, TimeSpan.FromSeconds(timeInSeconds),
            //     TimeSpan.FromSeconds(timeInSeconds));

            CheckForFile();
            return Task.CompletedTask;
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer.Dispose();
            return Task.CompletedTask;
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private async Task CheckForFile()
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                var watchFolder = "W:\\code\\dotnet\\microservices\\filehandler\\data";
                watcher.Path = watchFolder;
                

                // Watch for changes in LastAccess and LastWrite times, and
                // the renaming of files or directories.
                watcher.NotifyFilter = NotifyFilters.LastAccess
                                       | NotifyFilters.LastWrite
                                       | NotifyFilters.FileName
                                       | NotifyFilters.DirectoryName;

                // Only watch text files.
                watcher.Filter = "*.xml";

                // Add event handlers.
                //watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                //watcher.Deleted += OnChanged;
                //watcher.Renamed += OnRenamed;

                // Begin watching.
                watcher.EnableRaisingEvents = true;

                // Wait for the user to quit the program.
                Console.WriteLine("Press 'q' to quit the sample.");
                while (Console.Read() != 'q') ;
            }
        }
        
        private async void OnChanged(object source, FileSystemEventArgs e)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq();
            var cancelsource = new CancellationTokenSource(TimeSpan.FromSeconds(50));
            await busControl.StartAsync(cancelsource.Token); 
            try
            {
                do
                {
                    Guid fileId = Guid.NewGuid();
                    var watchFolder = e.FullPath.Remove(e.FullPath.Length - e.Name.Length);
                    var newFolder = watchFolder + "moved\\" + fileId.ToString() + "\\";
                    //var newFolder = @"W:\code\dotnet\microservices\filehandler\data\moved\";
                    Directory.CreateDirectory(newFolder);
                    var movedFile = newFolder + e.Name;
                    File.Move(e.FullPath, movedFile);

                    Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
                    Console.WriteLine($"Moved to: {0}", movedFile);
                    //var endpoint = await busControl.GetSendEndpoint(new Uri("queue:submit-file-info"));
                    var client = busControl.CreateRequestClient<SubmitFileInfo>(new Uri("queue:submit-file-info"));

                    //await endpoint.Send<FileInfoSubmitted>(new
                    var (accepted, rejected) = await client
                        .GetResponse<FileInfoSubmissionAccepted, FileInfoSubmissionRejected>(new
                        {
                            FileId = fileId,
                            InVar.Timestamp,
                            FileName = e.Name,
                            OriginFolder = watchFolder,
                            Folder = newFolder //e.FullPath.Remove(e.FullPath.Length-e.Name.Length)
                        }, cancelsource.Token).ConfigureAwait(false);


                    if (accepted.IsCompletedSuccessfully)
                    {
                        var response = await accepted.ConfigureAwait(false);
                        Console.WriteLine("File Sent: {0}", response.Message.FileName);
                    }
                    else
                    {
                        var response = await rejected.ConfigureAwait(false);
                        Console.WriteLine("File Rejected: {0}", response.Message.Reason);
                    }
                    break;
                } while (true);
            }
            finally
            {
                await busControl.StopAsync(cancelsource.Token);
            }
        }

        private async void OnRenamed(object source, RenamedEventArgs e) =>
            // Specify what is done when a file is renamed.
            Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
    }
}