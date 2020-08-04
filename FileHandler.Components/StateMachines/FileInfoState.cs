using System;
using Automatonymous;
using MassTransit.RedisIntegration;

namespace FileHandler.Components.StateMachines
{
    public class FileInfoState :
        SagaStateMachineInstance,
        IVersionedSaga
    {
        public Guid CorrelationId { get; set; }
        public int Version { get; set; }

        public string CurrentState { get; set; }

        public DateTime? Updated { get; set; }
        public DateTime? SubmitDate { get; set; }
        public string FileName { get; set; }
        public string Text { get; set; }
    }
}