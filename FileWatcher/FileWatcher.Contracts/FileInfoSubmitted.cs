using System;

namespace Pri.Contracts
{
    public interface FileInfoSubmitted
    {
        Guid FileId { get; }

        DateTime Timestamp { get; set; }

        string FileName { get; set; }
        
        string OriginFolder { get; set; }

        string LocalFolder { get; set; }
    }
}