using System;

namespace FileHandler.Contracts
{
    public interface FileRead
    {
        Guid FileId { get; }

        string SenderId { get; set; }

        string ReceiverId { get; set; }
    }
}