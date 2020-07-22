using System;
using System.Diagnostics;

namespace FileHandler.Contracts
{
    public interface FileInfoSubmissionRejected
    {
        Guid FileId { get; }

        DateTime Timestamp { get; }

        string FileName { get; }

        string Folder { get; }

        string Text { get; }

        string Reason { get; set; }
    }
}