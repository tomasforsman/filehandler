using Automatonymous;
using MassTransit;
using System;
using Pri.Contracts;

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

      // x => x.CorrelateById(m => m.Message.FileId));
      // x => x.CorrelateBy((saga, context) => saga.FileName == context.Message.FileName));

      Event(() => FileRead, x => x.CorrelateById(m => m.Message.FileId));
      Event(() => CommunicationSettingsFound, x => x.CorrelateById(m => m.Message.FileId));
      Event(() => FileSent, x => x.CorrelateById(m => m.Message.FileId));
      Event(() => TransactionReported, x => x.CorrelateById(m => m.Message.FileId));


      InstanceState(x => x.CurrentState);
      Initially(
        When(FileInfoSubmitted)
          .Then(context =>
          {
            context.Instance.FileId = context.Data.FileId;
            context.Instance.SubmitDate = context.Data.Timestamp;
            context.Instance.FileName = context.Data.FileName;
            context.Instance.OriginFolder = context.Data.OriginFolder;
            context.Instance.LocalFolder = context.Data.LocalFolder;

            context.Instance.Updated = DateTime.UtcNow;
          })
          .TransitionTo(Submitted));

      During(Submitted,
        Ignore(FileInfoSubmitted),
        When(FileRead)
          .Then(context =>
          {
            context.Instance.BuyerId = context.Data.BuyerId;
            context.Instance.SellerId = context.Data.SellerId;
          })
          .PublishAsync(context => context.Init<Read>(new
          {
            FileId = context.Instance.FileId,
            BuyerId = context.Instance.BuyerId,
            SellerId = context.Instance.SellerId
          }))
          .TransitionTo(Read));

      During(Read,
        When(CommunicationSettingsFound)
          .Then(context =>
          {
            context.Instance.Protocol = context.Data.Protocol;
            context.Instance.HostName = context.Data.HostName;
            context.Instance.RemoteFolder = context.Data.RemoteFolder;
            context.Instance.Password = context.Data.Password;
            context.Instance.UserName = context.Data.UserName;
            context.Instance.Port = context.Data.Port;
            context.Instance.SshHostKeyFingerprint = context.Data.SshHostKeyFingerprint;
          })
          .PublishAsync(context => context.Init<CommunicationSettings>(new
          {
            FileId = context.Instance.FileId,
            FileName = context.Instance.FileName,
            LocalFolder = context.Instance.LocalFolder,
            Protocol = context.Instance.Protocol,
            HostName = context.Instance.HostName,
            RemoteFolder = context.Instance.RemoteFolder,
            Password = context.Instance.Password,
            UserName = context.Instance.UserName,
            Port = context.Instance.Port,
            SshHostKeyFingerprint = context.Instance.SshHostKeyFingerprint
          }))
          .TransitionTo(ComSettingsFound));

      During(ComSettingsFound,
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
            context.Instance.LocalFolder = context.Data.LocalFolder;
          })
          .TransitionTo(Submitted)
      );
    }

    public State Submitted { get; set; }
    public State Read { get; set; }
    public State ComSettingsFound { get; set; }
    public State Sent { get; set; }
    public State Reported { get; set; }

    public Event<FileInfoSubmitted> FileInfoSubmitted { get; set; }
    public Event<CheckFileInfo> FileInfoStatusRequested { get; set; }
    public Event<FileRead> FileRead { get; set; }
    public Event<CommunicationSettingsFound> CommunicationSettingsFound { get; set; }
    public Event<FileSent> FileSent { get; set; }
    public Event<TransactionReported> TransactionReported { get; set; }
  }
}