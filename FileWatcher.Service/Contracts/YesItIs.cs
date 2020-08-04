using System;
using System.Dynamic;

namespace FileWatcher.Service.Contracts
{
    public interface YesItIs
    {
        Guid FileGuid { get; }
        string FileName { get; }
        string FilePath { get; }
        DateTime FileSeen { get; }
    }
}