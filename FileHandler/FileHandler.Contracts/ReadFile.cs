using System;

namespace Pri.Contracts
{
    public interface ReadFile
    {
        Guid FileId { get; }
        string FileName { get; set; }
        string Folder { get; set; }
    }
}