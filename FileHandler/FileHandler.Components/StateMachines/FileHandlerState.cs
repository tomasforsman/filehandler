using MassTransit.Saga;

namespace FileHandler.Components.StateMachines
{
using System;
using Automatonymous;
using MassTransit.MongoDbIntegration.Saga;
using MongoDB.Bson.Serialization.Attributes;

    public class FileHandlerState :
        SagaStateMachineInstance,
        ISagaVersion
    {
        [BsonId]
        public Guid CorrelationId { get; set; }
        public int Version { get; set; }
        public string FileName { get; set; }
        public string OriginFolder { get; set; }
        public string CurrentState { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? SubmitDate { get; set; }
        
        public string CurrentFolder { get; set; }
        
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        
        public string FileDestination { get; set; }
    }
}