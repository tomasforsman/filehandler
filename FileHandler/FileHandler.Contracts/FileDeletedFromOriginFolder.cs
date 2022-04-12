using System;

namespace Pri.Contracts
{
  public interface FileDeletedFromOriginFolder
  {
    public Guid FileId { get; }
    public string FileName { get; set; }
    public string LocalFolder { get; set; }
  }
}