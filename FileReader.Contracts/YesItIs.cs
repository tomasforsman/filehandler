using System;

namespace FileReader.Contracts
{
    public interface YesItIs
    {
        Guid FileGuid { get; }
        string FileName { get; }
        string FilePath { get; }
        DateTime FileSeen { get; }
    }
}