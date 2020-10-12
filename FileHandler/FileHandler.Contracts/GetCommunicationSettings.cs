using System;

namespace Pri.Contracts
{
    public interface GetCommunicationSettings
    {
        Guid FileId { get; }
        public string BuyerId { get; set; }
        public string SellerId { get; set; }
    }
}