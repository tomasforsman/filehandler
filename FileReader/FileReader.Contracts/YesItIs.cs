using System;

namespace FileReader.Contracts
{
  public interface YesItIs
  {
    DateTime FileSeen { get; }
    Guid FileGuid { get; }
    string FileName { get; }
    string FilePath { get; }
  }
}