using System;

namespace Pri.Contracts
{
    public interface FileMoved
    {
        Guid FileId { get; }

        string FileName { get; set; }

        string FromFolder { get; set; }

        string ToFolder { get; set; }
    }
}