using System;

namespace Pri.Contracts
{
  public interface FileInfoSubmitted
  {
    DateTime Timestamp { get; set; }
    Guid FileId { get; }
    string FileName { get; set; }
    string LocalFolder { get; set; }
    string OriginFolder { get; set; }
  }
}