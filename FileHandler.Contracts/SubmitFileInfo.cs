using System;

namespace FileHandler.Contracts
{
    public interface SubmitFileInfo
    {
        Guid FileId { get; }

        DateTime Timestamp { get; }

        string FileName { get; }

        string Folder { get; }

        string Text { get; }
    }
}