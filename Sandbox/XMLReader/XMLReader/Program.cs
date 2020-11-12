using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XMLReader
{
  class Program
  {
    static async Task Main(string[] args)
    {
      XDocument doc = XDocument.Parse(File.ReadAllText(@"W:\code\dotnet\microservices\filehandler\data\testdata\hd.xml"));
      XNamespace cac = "urn:sfti:CommonAggregateComponents:1:0";
      XNamespace sh = "urn:sfti:documents:StandardBusinessDocumentHeader";
      var root = doc.Root;
      var rootName = root.Name.LocalName;
      //Console.WriteLine("rootName: {0}", rootName);
      //root = rootName != "Invoice" ? root = root.Element("Invoice") : root;
      await getID("Buyer");
      var buyerId = await getID("Buyer");
      var sellerId = await getID("Seller");

      Console.WriteLine("Buyer ID: {0}", buyerId);
      Console.WriteLine("Seller ID: {0}", sellerId);
      
      async Task<string> getID(string party)
      {
        var ID = root.DescendantsAndSelf().Elements().FirstOrDefault(element => element.Name.LocalName == party + "Party").Descendants().FirstOrDefault(element => element.Name.LocalName == "ID").Value;
        return ID;
      }
    }
  }
}