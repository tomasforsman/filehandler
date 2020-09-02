using System;

namespace FileHandler.Contracts
{
    public interface FileInfoSubmitted
    {
        Guid FileId { get; }

        DateTime Timestamp { get; set; }

        string FileName { get; set; }

        string Folder { get; set; }
    }
}