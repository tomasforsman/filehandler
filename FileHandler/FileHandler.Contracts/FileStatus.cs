using System;

namespace FileHandler.Contracts
{
    public interface FileStatus
    {
        Guid FileId { get; }
        string State { get; }
    }
}