using System;

namespace Pri.Contracts
{
  public interface Read
  {
    public Guid FileId { get; set; }
    public string BuyerId { get; set; }
    public string SellerId { get; set; }
  }
}