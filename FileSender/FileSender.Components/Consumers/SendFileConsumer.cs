using MassTransit;
using Microsoft.Extensions.Logging;
using Pri.Contracts;
using System.Threading.Tasks;
using System;
using WinSCP;

namespace FileSender.Components.Consumers
{
  public class SendFileConsumer :
    IConsumer<SendFile>
  {
    private readonly ILogger<SendFileConsumer> _logger;

    public SendFileConsumer()
    {
    }

    public SendFileConsumer(ILogger<SendFileConsumer> logger) => _logger = logger;

    public async Task Consume(ConsumeContext<SendFile> context)
    {
      var FileId = context.Message.FileId;
      var FileName = context.Message.FileName;
      var HostName = context.Message.HostName;
      var LocalFolder = context.Message.LocalFolder;
      var Password = context.Message.Password;
      var Port = context.Message.Port;
      var Protocol = context.Message.Protocol;
      var RemoteFolder = context.Message.RemoteFolder;
      var SshHostKeyFingerprint = context.Message.SshHostKeyFingerprint;
      var UserName = context.Message.UserName;

      Console.WriteLine(FileId);
      Console.WriteLine(HostName);

      try
      {
        // Set up session options
        SessionOptions sessionOptions = new SessionOptions
        {
          //SshHostKeyFingerprint = "ssh-ed25519 255 GToJwUC9DtZLqnuBBmpfGozh3lnKjOqq9ooWYijOck0=",
          GiveUpSecurityAndAcceptAnySshHostKey = true,
          HostName = "192.168.1.55",
          Password = "",
          PortNumber = 2200,
          Protocol = WinSCP.Protocol.Sftp,
          UserName = "tomas"
        };

        using (Session session = new Session())
        {
          // Connect
          session.Open(sessionOptions);

          // Your code

          TransferOptions transferOptions = new TransferOptions();
          transferOptions.TransferMode = TransferMode.Binary;

          var transferResult = session.PutFiles(
            LocalFolder + FileName, "/home/tomas/upload/", false, transferOptions);

          foreach (TransferEventArgs transfer in transferResult.Transfers)
          {
            Console.WriteLine("Upload of {0} succeeded.", transfer.FileName);
          }
        }
      }
      catch (Exception e)
      {
        Console.WriteLine("Error: {0}", e);
        throw;
      }

      await context.RespondAsync<FileSent>(new
      {
        FileId = context.Message.FileId,
      });
    }
  }
}