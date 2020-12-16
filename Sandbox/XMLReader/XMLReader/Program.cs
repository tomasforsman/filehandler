using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace XMLReader
{
  class Program
  {
    
    private const String removeNameSpaceAndPrefix = "RemoveNameSpaceAndPrefix.xslt";
    private const String getPeppolInvoiceInfo = "GetPeppolInvoiceInfo.xslt";
    private const String getSVEInvoiceInfo = "GetSVEInvoiceInfo.xslt";
    
    static async Task Main(string[] args)
    {
      Transform("peppol.xml", "GetPeppolInvoiceInfo.xslt");
      Transform("svefakt.xml", "GetSVEInvoiceInfo.xslt");
      Transform("hd_svefakt.xml", "GetSVEInvoiceInfo.xslt");
      // XPathDocument xpathdocument = new XPathDocument(filename);
      // XmlTextWriter writer = new XmlTextWriter(Console.Out);
      // writer.Formatting = Formatting.Indented;

      //xslt.Transform(xpathdocument, null, writer, null);
      
      // XmlSerializer deserializer =
      //   new XmlSerializer(typeof(Invoice1));
      // TextReader textReader = new StreamReader(@".\faktura.xml");
      // Invoice1 inv = 
      //   (Invoice1)deserializer.Deserialize(textReader);
      // textReader.Close();
      // Console.WriteLine(inv.MyPropertyA);
      //
      //
      // ProductCategory prodCategory;
      // XmlSerializer objXMLSerializer = new XmlSerializer(typeof(ProductCategory));
      // TextReader productDetailsReader = new StreamReader(@".\ProductDetails.xml");
      // prodCategory = (ProductCategory)objXMLSerializer.Deserialize(productDetailsReader);
      // productDetailsReader.Close();
      // Console.WriteLine(prodCategory.Products.First().ProductName);
      //
      // Svefaktura svefakt;
      // XmlSerializer serializer = new XmlSerializer(typeof(Svefaktura));
      // TextReader reader = new StreamReader(@".\svefakt.xml");
      // svefakt = (Svefaktura)serializer.Deserialize(reader);
      // reader.Close();
      // Console.WriteLine(svefakt.Header.HeaderVersion);
      //Console.WriteLine(svefakt.invoice.ID);
      
      
//       Serializer ser = new Serializer();
//       string path = string.Empty;
//       string xmlInputData = string.Empty;
//       string xmlOutputData = string.Empty;
//
// // EXAMPLE 2
//       path = Directory.GetCurrentDirectory() + @"\peppol.xml";
//       xmlInputData = File.ReadAllText(path);
//
//       Hantverksdata.Peppol.Invoice svefa = ser.Deserialize<Hantverksdata.Peppol.Invoice >(xmlInputData);
//       xmlOutputData = ser.Serialize<Hantverksdata.Peppol.Invoice >(svefa);
      //Console.Write(xmlOutputData);
      //Console.WriteLine(svefa.ID.Value);
      //Console.WriteLine(svefa.Invoice.BuyerParty.Party.PartyIdentification[0].ID.Value);
      //Console.Write(svefa.invoice.ID);
      
      // XDocument doc = XDocument.Parse(File.ReadAllText(@"W:\code\dotnet\microservices\filehandler\data\testdata\hd.xml"));
      // XNamespace cac = "urn:sfti:CommonAggregateComponents:1:0";
      // XNamespace sh = "urn:sfti:documents:StandardBusinessDocumentHeader";
      // var root = doc.Root;
      // var rootName = root.Name.LocalName;
      // //Console.WriteLine("rootName: {0}", rootName);
      // //root = rootName != "Invoice" ? root = root.Element("Invoice") : root;
      // await getID("Buyer");
      // var buyerId = await getID("Buyer");
      // var sellerId = await getID("Seller");
      //
      // Console.WriteLine("Buyer ID: {0}", buyerId);
      // Console.WriteLine("Seller ID: {0}", sellerId);
      //
      // async Task<string> getID(string party)
      // {
      //   var ID = root.DescendantsAndSelf().Elements().FirstOrDefault(element => element.Name.LocalName == party + "Party").Descendants().FirstOrDefault(element => element.Name.LocalName == "ID").Value;
      //   return ID;
      // }
    }

    private static void Transform(string filename, string schema)
    {
      XslCompiledTransform xslt = new XslCompiledTransform();
      xslt.Load(removeNameSpaceAndPrefix);
      xslt.Transform(filename, "output_temp.xml");
      //xslt.Load(getPeppolInvoiceInfo);
      xslt.Load(schema);
      xslt.Transform("output_temp.xml", "output_"+filename);
    }
  }
  
  [XmlRoot("MyObject")]
  public class Invoice1
  {
    public int MyPropertyA {get; set;}
    public int MyPropertyB {get; set;}
  }
  
  public class Serializer
  {       
    public T Deserialize<T>(string input) where T : class
    {
      System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

      using (StringReader sr = new StringReader(input))
      {
        return (T)ser.Deserialize(sr);
      }
    }

    public string Serialize<T>(T ObjectToSerialize)
    {
      XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

      using (StringWriter textWriter = new StringWriter())
      {
        xmlSerializer.Serialize(textWriter, ObjectToSerialize);
        return textWriter.ToString();
      }
    }
  }
}