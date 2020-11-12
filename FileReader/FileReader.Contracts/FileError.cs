using System;

namespace Pri.Contracts
{
  public interface FileError
  {
    public Guid FileId { get; set; }
    public string ErrorMessage { get; set; }
  }
}