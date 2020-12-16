using System;
using System.IO;
using System.Xml.Serialization;

namespace XMLReader
{
  [XmlRoot("productCategory")]
  public class ProductCategory
  {
    [XmlElement("categoryName")] public string CategoryName;

    [XmlElement("categoryDescription")] public string CategoryDescription;

    [XmlElement(ElementName = "launchDate", DataType = "date")]
    public DateTime LaunchDate;

    [XmlArray("products")] [XmlArrayItem("product")]
    public Product[] Products;

    public ProductCategory()
    {
      // Default constructor for deserialization.
    }

    public ProductCategory(string categoryName, string categoryDescription, DateTime launchDate)
    {
      this.CategoryName = categoryName;
      this.CategoryDescription = categoryDescription;
      this.LaunchDate = launchDate;
    }
  }

  public class Product
  {
    [XmlElement("productName")] public string ProductName;
    [XmlElement("productWeight")] public decimal ProductWeight;
    [XmlElement("productPrice")] public decimal ProductPrice;

    [XmlAttributeAttribute(AttributeName = "id")]
    public int Id;

    public Product()
    {

    }

    public Product(int productId, string productName, decimal productWeight, decimal productPrice)
    {
      this.Id = productId;
      this.ProductName = productName;
      this.ProductWeight = productWeight;
      this.ProductPrice = productPrice;

    }
  }
}
