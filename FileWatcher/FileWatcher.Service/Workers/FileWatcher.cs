using Azure.Storage.Blobs;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Pri.Contracts;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace FileWatcher.Service.Workers
{
  public class FileWatcher :
    IHostedService
  {
    private CancellationTokenSource cancelFileSubmitter;
    private FileSystemWatcher watcher = new FileSystemWatcher();
    private Timer _timer;
    private bool freeForWork = true;
    private string path = @"W:\code\dotnet\microservices\filehandler\data\";

    
    

    public Task StartAsync(CancellationToken cancellationToken)
    {
      cancelFileSubmitter = new CancellationTokenSource();

      TimerCheck(CheckPath, 2);
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
            if (cancel.IsCancellationRequested)
              cancel.ThrowIfCancellationRequested();
            Guid fileId = Guid.NewGuid();
            var newPath = path + @"moved\" + fileId.ToString() + @"\";
            Directory.CreateDirectory(newPath);
            File.Move(path + file, newPath + file);
            var filePath = newPath + file;

            string connectionString =
              "DefaultEndpointsProtocol=https;AccountName=prifilehandlertest;AccountKey=xAKHtHiV9iuBRRPLO+dA6IFD9jD3MzrMNFgvsvqAp8ol4caBsWR4jzp7JuFMw/Nc07Wh/ntWgmL87gR2l6c/jA==;EndpointSuffix=core.windows.net";
            var container = new BlobContainerClient(connectionString, fileId.ToString());
            await container.CreateAsync(cancellationToken: cancelsource.Token);
            try
            {
              BlobClient blob = container.GetBlobClient(file);
              await blob.UploadAsync(filePath, cancelsource.Token);
            }
            catch (Exception e)
            {
              Console.WriteLine(e);
            }
            finally
            {
              //await container.DeleteAsync();
            }

            var (accepted, rejected) = await client
              .GetResponse<FileInfoSubmissionAccepted, FileInfoSubmissionRejected>(new
              {
                FileId = fileId,
                FileName = file,
                InVar.Timestamp,
                LocalFolder = newPath, //e.FullPath.Remove(e.FullPath.Length-e.Name.Length)
                OriginFolder = path
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
        } while (true);
      }
      finally
      {
        await busControl.StopAsync(cancelsource.Token);
        freeForWork = true;
      }
    }
  }
}