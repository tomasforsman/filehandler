using System;

namespace Pri.Contracts
{
    public interface FileDestinationFound
    {
        Guid FileId { get; }

        string FileDestination { get; set; }
    }
}