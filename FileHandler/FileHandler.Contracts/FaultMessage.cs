using System;

namespace Pri.Contracts
{
  public interface FaultMessage
  {
    Guid FileId { get; }
    string Message { get; set; }
  }
}