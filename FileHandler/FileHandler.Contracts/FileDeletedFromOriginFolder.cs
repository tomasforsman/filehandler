using System;

namespace Pri.Contracts
{
    public interface FileDeletedFromOriginFolder
    {
        Guid FileId { get; }

        string FileName { get; set; }

        string Folder { get; set; }
    }
}