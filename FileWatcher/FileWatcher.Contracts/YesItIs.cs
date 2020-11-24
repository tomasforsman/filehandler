using System;

namespace Pri.Contracts
{
  public interface YesItIs
  {
    DateTime FileSeen { get; }
    Guid FileGuid { get; }
    string FileName { get; }
    string FilePath { get; }
  }
}