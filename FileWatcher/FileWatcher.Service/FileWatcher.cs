using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;

using Pri.Contracts;


namespace FileWatcher.Service
{
    public class FileWatcher :
        IHostedService
    {
        private Timer _timer;
        private FileSystemWatcher watcher = new FileSystemWatcher();
        private string path = @"W:\code\dotnet\microservices\filehandler\data\";
        private bool freeForWork = true;
        private CancellationTokenSource cancelFileSubmitter = null;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            cancelFileSubmitter = new CancellationTokenSource();
            

            TimerCheck(CheckPath, 60);
            //TimerCheck(CancelFileSubmitter, 30);
            return Task.CompletedTask;
        }

        private void CancelFileSubmitter(object? state)
        {
            cancelFileSubmitter.Cancel();
        }
        

        private void TimerCheck(System.Threading.TimerCallback runthis, int timeInSeconds)
        {
            
            _timer = new Timer(runthis, null, TimeSpan.FromSeconds(timeInSeconds), 
                TimeSpan.FromSeconds(timeInSeconds));
        }

        public async void CheckPath(object? state)
        {
            if (Directory.EnumerateFiles(path) != null && freeForWork)
            {
                var fileSubmitterToken = cancelFileSubmitter.Token;
                try
                {
                    await SubmitFilesInPath(fileSubmitterToken);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer.Dispose();
            return Task.CompletedTask;
        }
        
        
        private async Task SubmitFilesInPath(CancellationToken cancel)
        {
            freeForWork = false;
            var busControl = Bus.Factory.CreateUsingRabbitMq();
            var cancelsource = new CancellationTokenSource();
            await busControl.StartAsync(cancelsource.Token); 
            var client = busControl.CreateRequestClient<SubmitFileInfo>(new Uri("queue:submit-file-info"));
            try
            {
                do
                {
                    foreach (string file in Directory.EnumerateFiles(path).Select(Path.GetFileName))
                    {
                        if(cancel.IsCancellationRequested)
                            cancel.ThrowIfCancellationRequested();
                        Guid fileId = Guid.NewGuid();
                        var newPath = path + @"moved\" + fileId.ToString() + @"\";
                        Directory.CreateDirectory(newPath);
                        File.Move(path + file, newPath + file);
                        
                        var (accepted, rejected) = await client
                            .GetResponse<FileInfoSubmissionAccepted, FileInfoSubmissionRejected>(new
                            {
                                FileId = fileId,
                                InVar.Timestamp,
                                FileName = file,
                                OriginFolder = path,
                                Folder = newPath //e.FullPath.Remove(e.FullPath.Length-e.Name.Length)
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
                    }
                    break;
                } while (Directory.EnumerateFiles(path) != null);
            }
            finally
            {
                await busControl.StopAsync(cancelsource.Token);
                freeForWork = true;
            }
        }
    }
}
