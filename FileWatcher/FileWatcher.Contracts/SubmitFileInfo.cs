using System;

namespace Pri.Contracts
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