﻿using System;

namespace Pri.Contracts
{
  public interface FileRead
  {
    public Guid FileId { get; set; }
    public string BuyerId { get; set; }
    public string SellerId { get; set; }
    public string InvoiceId { get; set; }
  }
}