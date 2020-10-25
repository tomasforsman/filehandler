using FileReader.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Pri.Contracts;

namespace FileReader.Components.Consumers
{
  public class ReadFileConsumer :
    IConsumer<ReadFile>
  {
    private readonly ILogger<ReadFileConsumer> _logger;
    private string connectionString = "DefaultEndpointsProtocol=https;AccountName=prifilehandlertest;AccountKey=xAKHtHiV9iuBRRPLO+dA6IFD9jD3MzrMNFgvsvqAp8ol4caBsWR4jzp7JuFMw/Nc07Wh/ntWgmL87gR2l6c/jA==;EndpointSuffix=core.windows.net";


    public ReadFileConsumer()
    {
    }

    public ReadFileConsumer(ILogger<ReadFileConsumer> logger) => _logger = logger;


    public async Task Consume(ConsumeContext<ReadFile> context)
    {
      var fileName = context.Message.FileName;
      //var folder = context.Message.LocalFolder;
      var fileId = context.Message.FileId.ToString();

      //Console.WriteLine("Läser Fil: {0}", folder + fileName);
      string downloadPath = @"fromblob\";
      Directory.CreateDirectory(downloadPath);
      BlobContainerClient container = new BlobContainerClient(connectionString, fileId);
      
      try
      {
        // Get a reference to a blob named "sample-file"
        BlobClient blob = container.GetBlobClient(fileName);

        // Download the blob's contents and save it to a file
        BlobDownloadInfo download = blob.Download();
        using (FileStream file = File.OpenWrite(downloadPath+fileName))
        {
          download.Content.CopyTo(file);
        }
        
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
      finally
      {
        // Clean up after the test when we're finished
        // container.Delete();
      }
      //await new BlobClient(new Uri("https://aka.ms/bloburl")).DownloadToAsync(downloadPath);
      Console.WriteLine("Läser Fil: {0}", downloadPath+fileName);

      XDocument doc = XDocument.Parse(File.ReadAllText(downloadPath+fileName));
      XNamespace cac = "urn:sfti:CommonAggregateComponents:1:0";
      XNamespace sh = "urn:sfti:documents:StandardBusinessDocumentHeader";
      var root = doc.Root;
      var rootName = root.Name.LocalName;
      //Console.WriteLine("rootName: {0}", rootName);
      root = rootName != "Invoice" ? root = root.Element("Invoice") : root;

      var buyerId = await getID("Buyer");
      var sellerId = await getID("Seller");

      Console.WriteLine("Buyer ID: {0}", buyerId);
      Console.WriteLine("Seller ID: {0}", sellerId);

      await context.RespondAsync<FileRead>(new
      {
        FileId = context.Message.FileId,
        BuyerId = buyerId,
        SellerId = sellerId
      });

      async Task<string> getID(string party)
      {
        var IDs = root.Element(cac + party + "Party").Elements(cac + "Party")
          .Elements(cac + "PartyIdentification");

        var result = "";
        foreach (var ID in IDs)
        {
          var id = ID.Element(cac + "ID");
          result = id.Value;
          if (id.HasAttributes && (id.Attributes().FirstOrDefault().Name.LocalName) ==
            "identificationSchemeAgencyID")
          {
            break;
          }
        }

        return result;
      }
    }
  }
}