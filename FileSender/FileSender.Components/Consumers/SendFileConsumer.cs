using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Pri.Contracts;
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
            var LocalFolder = context.Message.LocalFolder;
            var Protocol = context.Message.Protocol;
            var HostName = context.Message.HostName;
            var RemoteFolder = context.Message.RemoteFolder;
            var Password = context.Message.Password;
            var UserName = context.Message.UserName;
            var Port = context.Message.Port;
            var SshHostKeyFingerprint = context.Message.SshHostKeyFingerprint;

            Console.WriteLine(FileId);
            Console.WriteLine(HostName);
            
            try
            {
                // Set up session options
                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = WinSCP.Protocol.Sftp,
                    HostName = "192.168.1.55",
                    PortNumber = 2200,
                    UserName = "tomas",
                    Password = "fyrtal24",
                    GiveUpSecurityAndAcceptAnySshHostKey = true
                    //SshHostKeyFingerprint = "ssh-ed25519 255 GToJwUC9DtZLqnuBBmpfGozh3lnKjOqq9ooWYijOck0=",
                };

                using (Session session = new Session())
                {
                    // Connect
                    session.Open(sessionOptions);
                    
                    // Your code
                    
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;

                    TransferOperationResult transferResult;
                    transferResult =
                        session.PutFiles(
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