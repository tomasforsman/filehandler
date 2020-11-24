using System;

namespace Pri.Contracts
{
  public interface FileInfoSubmissionRejected
  {
    DateTime Timestamp { get; }
    Guid FileId { get; }
    string FileName { get; }
    string LocalFolder { get; }
    string OriginFolder { get; set; }
    string Reason { get; set; }
  }
}