using System;

namespace Pri.Contracts
{
  public interface ReadFile
  {
    public Guid FileId { get; }
    public string FileName { get; set; }
  }
}