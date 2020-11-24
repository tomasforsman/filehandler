using System;

namespace Pri.Contracts
{
  public interface SubmitFileInfo
  {
    DateTime Timestamp { get; }
    Guid FileId { get; }
    string FileName { get; }
    string LocalFolder { get; }
    string OriginFolder { get; }
  }
}