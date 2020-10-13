using System;

namespace Pri.Contracts
{
  public interface FileStatus
  {
    Guid FileId { get; }
    string State { get; }
  }
}