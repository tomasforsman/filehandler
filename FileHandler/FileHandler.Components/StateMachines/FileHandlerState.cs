using Automatonymous;
using MassTransit.Saga;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace FileHandler.Components.StateMachines
{
    public class FileHandlerState :
        SagaStateMachineInstance,
        ISagaVersion
    {
        public Guid FileId { get; set; }
        public string FileName { get; set; }
        public string OriginFolder { get; set; }
        public string LocalFolder { get; set; }
        public string CurrentState { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? SubmitDate { get; set; }

        public string BuyerId { get; set; }
        public string SellerId { get; set; }

        public string FileDestination { get; set; }
        public int Version { get; set; }
        public string Protocol { get; set; }
        public string HostName { get; set; }
        public string RemoteFolder { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Port { get; set; }
        public string SshHostKeyFingerprint { get; set; }

        [BsonId] public Guid CorrelationId { get; set; }
    }
}