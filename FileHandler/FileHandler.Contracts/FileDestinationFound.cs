using System;

namespace FileHandler.Contracts
{
    public interface FileDestinationFound
    {
        Guid FileId { get; }

        string FileDestination { get; set; }
    }
}