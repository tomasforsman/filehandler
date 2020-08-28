using System;
using Automatonymous;
using MassTransit.MongoDbIntegration.Saga;
using MongoDB.Bson.Serialization.Attributes;


namespace FileHandler.Components.StateMachines
{
    public class FileHandlerState :
        SagaStateMachineInstance,
        IVersionedSaga
    {
        [BsonId]
        public Guid CorrelationId { get; set; }
        public int Version { get; set; }

        public string CurrentState { get; set; }

        public DateTime? Updated { get; set; }
        public DateTime? SubmitDate { get; set; }
        public string FileName { get; set; }
        public string Text { get; set; }
    }
}