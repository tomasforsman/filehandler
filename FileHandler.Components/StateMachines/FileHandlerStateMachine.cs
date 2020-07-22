using System;
using System.Collections.Generic;
using System.Text;
using Automatonymous;
using FileHandler.Contracts;
using MassTransit.RedisIntegration;

namespace FileHandler.Components.StateMachines
{
    public class FileHandlerStateMachine :
        MassTransitStateMachine<FileInfoState>
    {
        /// <summary>
        ///   Automatonymous state machine for a MassTransit saga.
        /// </summary>

        public FileHandlerStateMachine()
        {
            Event(()=> FileInfoSubmitted, x => x.CorrelateById(m => m.Message.FileId));
            InstanceState(x => x.CurrentState);
            Initially(
                When(FileInfoSubmitted)
                    .Then(context =>
                    {
                        context.Instance.SubmitDate = context.Data.Timestamp;
                        context.Instance.FileName = context.Data.FileName;
                        context.Instance.Updated = DateTime.UtcNow;
                    })
                    .TransitionTo(Submitted));

            During(Submitted,
                Ignore(FileInfoSubmitted));


            //DuringAny never includes initial or final state, but all others.
            DuringAny(
                When(FileInfoSubmitted)
                    .Then(context =>
                    {
                        context.Instance.SubmitDate ??= context.Data.Timestamp;
                        context.Instance.FileName ??= context.Data.FileName;
                    })
                );
        }

        public State Submitted { get; private set; }

        public Event<FileInfoSubmitted> FileInfoSubmitted { get; private set; }
    }

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

    }
}