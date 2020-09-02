using System;

namespace FileHandler.Contracts
{
    public interface TransactionReported
    {
        Guid FileId { get; }
    }
}