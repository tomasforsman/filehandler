using System;

namespace FileHandler.Contracts
{
    public interface FileNotFound
    {
        Guid FileId { get; }
    }
}