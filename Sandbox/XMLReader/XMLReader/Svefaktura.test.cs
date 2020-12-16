using System;
using System.Xml.Serialization;

namespace XMLReader
{
  [XmlRoot("StandardBusinessDocument", Namespace = "urn:sfti:documents:StandardBusinessDocumentHeader")]
  public class Svefaktura
  {
    [XmlElement("StandardBusinessDocumentHeader")]
    public SvefakturaStandardBusinessDocumentHeader Header;

    [XmlElement("Invoice")] public Invoice invoice;
    public Svefaktura()
    {
      
    }
    
  }

    //[XmlRootAttribute(Namespace = "urn:sfti:documents:BasicInvoice:1:0")]
  [XmlRoot("Invoice", Namespace = "http://www.w3.org/2001/XMLSchema-instance")] 
  public class Invoice
  {

    [XmlElement("ID")] public ulong ID;

    public Invoice()
    {
      
    }
  }

  [XmlRoot("StandardBusinessDocumentHeader")]
  public class SvefakturaStandardBusinessDocumentHeader
  {
    [XmlElement("HeaderVersion", Namespace = "urn:sfti:documents:BasicInvoice:1:0")] public string HeaderVersion;

    public SvefakturaStandardBusinessDocumentHeader()
    {
      
    }
  }
}