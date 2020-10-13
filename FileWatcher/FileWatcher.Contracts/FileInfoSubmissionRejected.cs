using System;

namespace Pri.Contracts
{
  public interface FileInfoSubmissionRejected
  {
    Guid FileId { get; }

    DateTime Timestamp { get; }

    string FileName { get; }

    string LocalFolder { get; }

    string Reason { get; set; }
  }
}