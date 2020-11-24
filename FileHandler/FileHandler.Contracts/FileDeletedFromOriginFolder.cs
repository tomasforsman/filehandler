using System;

namespace Pri.Contracts
{
  public interface FileDeletedFromOriginFolder
  {
    Guid FileId { get; }
    string FileName { get; set; }
    string LocalFolder { get; set; }
  }
}