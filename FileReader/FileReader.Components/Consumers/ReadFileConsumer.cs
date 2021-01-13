using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Xsl;
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
    private const String removeNameSpaceAndPrefix = "RemoveNameSpaceAndPrefix.xslt";
    private const String getPeppolInvoiceInfo = "GetPeppolInvoiceInfo.xslt";
    private const String getSVEInvoiceInfo = "GetSVEInvoiceInfo.xslt";
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
      var downloadPath = @"fromblob\"+fileId+@"\";
      
      Directory.CreateDirectory(downloadPath);

      GetFile(connectionString, fileId, downloadPath, fileName);
      

      //await new BlobClient(new Uri("https://aka.ms/bloburl")).DownloadToAsync(downloadPath);
      Console.WriteLine("Läser Fil: {0}", downloadPath + fileName);

      //Console.WriteLine("rootName: {0}", rootName);
      //root = rootName != "Invoice" ? root = root.Element("Invoice") : root;
      string buyerId;
      string sellerId;
      string invoiceId;
      List<string> fileTypes = new List<string> {"SVE", "Peppol"};

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
      Directory.Delete(downloadPath, true);
      
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
        string ID = null;


        foreach (string type in fileTypes)
        {
          Transform(downloadPath, fileName, type);
          var doc = XDocument.Parse(File.ReadAllText(downloadPath + type+"_"+fileName));
          XNamespace cac = "urn:sfti:CommonAggregateComponents:1:0";
          XNamespace sh = "urn:sfti:documents:StandardBusinessDocumentHeader";
          var root = doc.Root;
          var rootName = root.Name.LocalName;
          
            ID = root.DescendantsAndSelf().Elements()
              .FirstOrDefault(element => element.Name.LocalName == "SellerIdentity")
              ?.Value;
          
          if (ID != null) break;
        }
        
        if (ID == null)
        {
          throw new InvalidOperationException("Not able to retrieve ID");
        }
        return ID;
      }

      void Transform(string path, string filename, string type)
      {
        string schema = "Get" + type + "InvoiceInfo.xslt";
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load(removeNameSpaceAndPrefix);
        xslt.Transform( path + filename, "output_temp.xml");
        //xslt.Load(getPeppolInvoiceInfo);
        xslt.Load(schema);
        xslt.Transform("output_temp.xml", path+type+"_"+filename);
      }
    }

    private void GetFile(string connectionString, string fileId, string downloadPath, string fileName)
    {
      var container = new BlobContainerClient(connectionString, "Invoice");


      //TODO: Read Stream instead of file
      try
      {
        
        var blob = container.GetBlobClient(fileId);

        // Download the blob's contents and save it to a file
        BlobDownloadInfo download = blob.Download();
        using (var file = File.OpenWrite(downloadPath + fileName))
        {
          download.Content.CopyTo(file);
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
    }
  }
}