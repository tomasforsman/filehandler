using System;

namespace Pri.Contracts
{
    public interface YesItIs
    {
        Guid FileGuid { get; }
        string FileName { get; }
        string FilePath { get; }
        DateTime FileSeen { get; }
    }
}