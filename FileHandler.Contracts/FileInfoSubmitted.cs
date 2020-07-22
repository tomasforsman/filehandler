using System;

namespace FileHandler.Contracts
{
    public interface FileInfoSubmitted
    {
        Guid FileId { get; }

        DateTime Timestamp { get; }

        string FileName { get; }

        string Folder { get; }
    }
}