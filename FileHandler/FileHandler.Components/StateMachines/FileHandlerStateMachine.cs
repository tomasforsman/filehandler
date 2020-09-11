using System;
using Automatonymous;
using FileHandler.Contracts;
using MassTransit;

namespace FileHandler.Components.StateMachines
{
    public class FileHandlerStateMachine :
        MassTransitStateMachine<FileHandlerState>
    {
        /// <summary>
        ///     Automatonymous state machine for a MassTransit saga.
        /// </summary>
        public FileHandlerStateMachine()
        {
            Event(() => FileInfoSubmitted, x => x.CorrelateById(m => m.Message.FileId));
            Event(() => FileInfoStatusRequested, x =>
            {
                x.CorrelateById(m => m.Message.FileId);
                x.OnMissingInstance(m => m.ExecuteAsync(async context =>
                {
                    if (context.RequestId.HasValue)
                        await context.RespondAsync<FileNotFound>(new {context.Message.FileId});
                }));
            });
            Event(() => FileDeletedFromOriginFolder,
                x => x.CorrelateBy((saga, context) =>
                    saga.FileName == context.Message.FileName && saga.OriginFolder == context.Message.Folder ||
                    saga.CorrelationId == context.Message.FileId));

            Event(() => FileMoved,
                x => x.CorrelateBy((saga, context) =>
                    saga.FileName == context.Message.FileName && saga.OriginFolder == context.Message.ToFolder ||
                    saga.CorrelationId == context.Message.FileId));
            // x => x.CorrelateById(m => m.Message.FileId));
            // x => x.CorrelateBy((saga, context) => saga.FileName == context.Message.FileName));

            Event(() => FileRead, x => x.CorrelateById(m => m.Message.FileId));
            Event(() => FileDestinationFound, x => x.CorrelateById(m => m.Message.FileId));
            Event(() => FileSent, x => x.CorrelateById(m => m.Message.FileId));
            Event(() => TransactionReported, x => x.CorrelateById(m => m.Message.FileId));


            InstanceState(x => x.CurrentState);
            Initially(
                When(FileInfoSubmitted)
                    .Then(context =>
                    {
                        context.Instance.SubmitDate = context.Data.Timestamp;
                        context.Instance.FileName = context.Data.FileName;
                        context.Instance.OriginFolder = context.Data.Folder;
                        context.Instance.Updated = DateTime.UtcNow;
                    })
                    .TransitionTo(Submitted));

            During(Submitted,
                Ignore(FileInfoSubmitted),
                When(FileDeletedFromOriginFolder)
                    .TransitionTo(DeletedFromOriginFolder));


            During(DeletedFromOriginFolder,
                When(FileMoved)
                    .Then(context =>
                    {
                        context.Instance.Updated = DateTime.UtcNow;
                        context.Instance.FileName = context.Data.FileName ?? context.Instance.FileName;
                        context.Instance.OriginFolder = context.Data.FromFolder;
                        context.Instance.CurrentFolder = context.Data.ToFolder;
                    })
                    .TransitionTo(Moved));

            During(Moved,
                When(FileRead)
                    .TransitionTo(Read));

            During(Read,
                When(FileDestinationFound)
                    .TransitionTo(DestinationFound));

            During(DestinationFound,
                When(FileSent)
                    .TransitionTo(Sent));

            During(Sent,
                When(TransactionReported)
                    .TransitionTo(Reported));


            //DuringAny includes all states except initial and final.

            DuringAny(
                When(FileInfoStatusRequested)
                    .RespondAsync(x => x.Init<FileStatus>(new
                    {
                        FileId = x.Instance.CorrelationId,
                        State = x.Instance.CurrentState
                    }))
            );

            DuringAny(
                When(FileInfoSubmitted)
                    .Then(context =>
                    {
                        context.Instance.Updated = DateTime.UtcNow;
                        context.Instance.FileName = context.Data.FileName ?? context.Instance.FileName;
                        context.Instance.CurrentFolder = context.Data.Folder;
                    })
                    .TransitionTo(Submitted)
            );
        }

        public State Submitted { get; set; }
        public State DeletedFromOriginFolder { get; set; }
        public State Moved { get; set; }
        public State Read { get; set; }
        public State DestinationFound { get; set; }
        public State Sent { get; set; }
        public State Reported { get; set; }

        public Event<FileInfoSubmitted> FileInfoSubmitted { get; set; }
        public Event<CheckFileInfo> FileInfoStatusRequested { get; set; }
        public Event<FileDeletedFromOriginFolder> FileDeletedFromOriginFolder { get; set; }
        public Event<FileMoved> FileMoved { get; set; }
        public Event<FileRead> FileRead { get; set; }
        public Event<FileDestinationFound> FileDestinationFound { get; set; }
        public Event<FileSent> FileSent { get; set; }
        public Event<TransactionReported> TransactionReported { get; set; }
    }
}