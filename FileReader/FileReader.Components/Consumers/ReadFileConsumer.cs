using FileReader.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Pri.Contracts;

namespace FileReader.Components.Consumers
{
  public class ReadFileConsumer :
    IConsumer<ReadFile>
  {
    private readonly ILogger<ReadFileConsumer> _logger;

    public ReadFileConsumer()
    {
    }

    public ReadFileConsumer(ILogger<ReadFileConsumer> logger) => _logger = logger;


    public async Task Consume(ConsumeContext<ReadFile> context)
    {
      var fileName = context.Message.FileName;
      var folder = context.Message.LocalFolder;

      Console.WriteLine("Läser Fil: {0}", folder + fileName);

      XDocument doc = XDocument.Parse(File.ReadAllText(folder + fileName));
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