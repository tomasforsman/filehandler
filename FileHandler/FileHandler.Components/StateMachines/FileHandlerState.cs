﻿using System;
using Automatonymous;
using MassTransit.Saga;
using MongoDB.Bson.Serialization.Attributes;

namespace FileHandler.Components.StateMachines
{
    public class FileHandlerState :
        SagaStateMachineInstance,
        ISagaVersion
    {
        public string FileName { get; set; }
        public string OriginFolder { get; set; }
        public string CurrentState { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? SubmitDate { get; set; }

        public string CurrentFolder { get; set; }

        public string SenderId { get; set; }
        public string ReceiverId { get; set; }

        public string FileDestination { get; set; }
        public int Version { get; set; }

        [BsonId] public Guid CorrelationId { get; set; }
    }
}