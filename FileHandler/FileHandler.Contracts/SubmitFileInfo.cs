using System;

namespace Pri.Contracts
{
    public interface SubmitFileInfo
    {
        Guid FileId { get; set; }

        DateTime Timestamp { get; set; }

        string FileName { get; set; }
        
        string OriginFolder { get; set; }

        string LocalFolder { get; set; }
    }
}