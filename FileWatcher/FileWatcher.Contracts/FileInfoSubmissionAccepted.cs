using System;

namespace Pri.Contracts
{
    public interface FileInfoSubmissionAccepted
    {
        Guid FileId { get; }

        DateTime Timestamp { get; }

        string FileName { get; }

        string LocalFolder { get; }
    }
}