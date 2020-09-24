using System;

namespace PRI.Contracts
{
    public interface SubmitFileInfo
    {
        Guid FileId { get; }

        DateTime Timestamp { get; }

        string FileName { get; }

        string OriginFolder { get; }
        
        string Folder { get; }
    }
}