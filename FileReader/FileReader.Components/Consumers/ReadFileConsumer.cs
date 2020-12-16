using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using MassTransit;
using Microsoft.Extensions.Logging;
using Pri.Contracts;

namespace FileReader.Components.Consumers
{
  public class ReadFileConsumer :
    IConsumer<ReadFile>
  {
    private readonly ILogger<ReadFileConsumer> _logger;

    private readonly string connectionString =
      "DefaultEndpointsProtocol=https;AccountName=prifilehandlertest;AccountKey=xAKHtHiV9iuBRRPLO+dA6IFD9jD3MzrMNFgvsvqAp8ol4caBsWR4jzp7JuFMw/Nc07Wh/ntWgmL87gR2l6c/jA==;EndpointSuffix=core.windows.net";


    public ReadFileConsumer()
    {
    }

    public ReadFileConsumer(ILogger<ReadFileConsumer> logger)
    {
      _logger = logger;
    }


    public async Task Consume(ConsumeContext<ReadFile> context)
    {
      //var folder = context.Message.LocalFolder;
      var fileId = context.Message.FileId.ToString();
      var fileName = context.Message.FileName;

      //Console.WriteLine("Läser Fil: {0}", folder + fileName);
      var downloadPath = @"fromblob\";
      Directory.CreateDirectory(downloadPath);
      var container = new BlobContainerClient(connectionString, fileId);


      //TODO: Read Stream instead of file
      try
      {
        
        var blob = container.GetBlobClient(fileName);

        // Download the blob's contents and save it to a file
        BlobDownloadInfo download = blob.Download(new HttpRange(0, 10000));
        using (var file = File.OpenWrite(downloadPath + fileName))
        {
          download.Content.CopyTo(file);
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }

      //await new BlobClient(new Uri("https://aka.ms/bloburl")).DownloadToAsync(downloadPath);
      Console.WriteLine("Läser Fil: {0}", downloadPath + fileName);

      var doc = XDocument.Parse(File.ReadAllText(downloadPath + fileName));
     
      XNamespace cac = "urn:sfti:CommonAggregateComponents:1:0";
      XNamespace sh = "urn:sfti:documents:StandardBusinessDocumentHeader";
      var root = doc.Root;
      var rootName = root.Name.LocalName;
      //Console.WriteLine("rootName: {0}", rootName);
      //root = rootName != "Invoice" ? root = root.Element("Invoice") : root;
      string buyerId;
      string sellerId;
      string invoiceId;
      try
      {
        buyerId = await getID("BuyerParty");
        sellerId = await getID("SellerParty");
        invoiceId = await getID("Invoice");
      }
      catch (Exception e)
      {
        throw new InvalidOperationException("Not able to retrieve ID" + e.Message);
      }

      Console.WriteLine("Buyer ID: {0}", buyerId);

      await context.RespondAsync<FileRead>(new
      {
        BuyerId = buyerId,
        context.Message.FileId,
        SellerId = sellerId,
        InvoiceId = invoiceId
      });

      async ValueTask<string> getID(string target)
      {
        string ID;
        try{
          ID = root.DescendantsAndSelf().Elements()
          .FirstOrDefault(element => element.Name.LocalName == target)
          ?.Descendants()
          .FirstOrDefault(element => element.Name.LocalName == "ID")
          ?.Value;
        }
        catch (Exception e)
        {
          throw new InvalidOperationException("Not able to retrieve ID" + e.Message);
        }
        return ID;
      }
    }


  }
}