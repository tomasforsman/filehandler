using System;

namespace Pri.Contracts
{
    public interface TransactionReported
    {
        Guid FileId { get; }
    }
}