using System;
using WinSCP;

namespace FileUpload
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        // Set up session options
        SessionOptions sessionOptions = new SessionOptions
        {
          Protocol = Protocol.Sftp,
          HostName = "192.168.1.55",
          PortNumber = 2200,
          UserName = args[0],
          Password = args[1],
          GiveUpSecurityAndAcceptAnySshHostKey = true
          //SshHostKeyFingerprint = "" //"ssh-ed25519 255 GToJwUC9DtZLqnuBBmpfGozh3lnKjOqq9ooWYijOck0=",
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
              @"W:\code\dotnet\microservices\filehandler\Sandbox\WinSCP\FileUpload\testfile\svefakt.xml",
              "/home/tomas/upload/", false, transferOptions);

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
    }
  }
}