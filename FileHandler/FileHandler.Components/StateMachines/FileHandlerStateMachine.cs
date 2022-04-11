using System;
using Automatonymous;
using MassTransit;
using Pri.Contracts;

namespace FileHandler.Components.StateMachines
{
  // Resharper disable UnassignedGetOnlyAutoProperty MemberCanBePrivate.Global
  public class FileHandlerStateMachine :
    MassTransitStateMachine<FileHandlerState>
  {
    /// <summary>
    ///   FileHandlerStateMachine.cs - The saga state machine structure.    
    ///   FileHandlerState.cs - State data definition.
    ///   FileHandlerStateMachineExtensions.cs - State event logic
    ///   
    /// </summary>
    public FileHandlerStateMachine()
    {
      // x => x.CorrelateById(m => m.Message.FileId));
      // x => x.CorrelateBy((saga, context) => saga.FileName == context.Message.FileName));
      Event(() => CommunicationSettingsFound, x => x.CorrelateById(m => m.Message.FileId));
      Event(() => FileRead, x => x.CorrelateById(m => m.Message.FileId));
      Event(() => FileSent, x => x.CorrelateById(m => m.Message.FileId));
      Event(() => FileInfoStatusRequested, x =>
      {
        x.CorrelateById(m => m.Message.FileId);
        x.OnMissingInstance(m => m.ExecuteAsync(async context =>
        {
          if (context.RequestId.HasValue)
            await context.RespondAsync<FileNotFound>(new {context.Message.FileId});
        }));
      });
      Event(() => FileInfoSubmitted, x => x.CorrelateById(m => m.Message.FileId));
      Event(() => ReadFileFaulted, x => x.CorrelateBy((instance, context) => 
      instance.FileId == context.Message.Message.FileId));
        // .CorrelateById(m => m.Message.Message.FileId) // Fault<T> includes the original message
        // .SelectId(m => m.Message.Message.FileId));
      Event(() => TransactionReported, x => x.CorrelateById(m => m.Message.FileId));


      InstanceState(x => x.CurrentState);
      Initially(
        When(FileInfoSubmitted)
          .CopyInfoToInstance()
          .TransitionTo(File_Is_Submitted));

      During(File_Is_Submitted,
        Ignore(FileInfoSubmitted),
        When(FileRead)
          .AddFileContentToInstance()
          .PublishFileContent()
          .TransitionTo(File_Has_Been_Read));

      During(File_Has_Been_Read,
        When(CommunicationSettingsFound)
          .AddFtpInformationToInstance()
          .PublishFtpInformationToInstance()
          .TransitionTo(Ftp_Settings_Has_Been_Retrieved));

      During(Ftp_Settings_Has_Been_Retrieved,
        When(FileSent)
          .Then(context => { context.Instance.Updated = DateTime.UtcNow; })
          .TransitionTo(File_Is_Sent));

      During(File_Is_Sent,
        When(TransactionReported)
          .Then(context => { context.Instance.Updated = DateTime.UtcNow; })
          .TransitionTo(Job_Result_Is_Reported));


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
        When(ReadFileFaulted)
          .Then(context =>
          {
            context.Instance.Updated = DateTime.UtcNow;
            context.Instance.FaultMessage = context.Data.Exceptions;
          })
          .TransitionTo(Fault_Has_Occured));
    }

    // State
    public State File_Is_Submitted { get; set; }
    public State File_Has_Been_Read { get; set; }
    public State Ftp_Settings_Has_Been_Retrieved { get; set; }
    public State File_Is_Sent { get; set; }
    public State Job_Result_Is_Reported { get; set; }
    public State Fault_Has_Occured { get; set; }

    // Events
    public Event<FileInfoSubmitted> FileInfoSubmitted { get; set; }
    public Event<FileRead> FileRead { get; set; }
    public Event<CommunicationSettingsFound> CommunicationSettingsFound { get; set; }
    public Event<FileSent> FileSent { get; set; }
    public Event<TransactionReported> TransactionReported { get; set; }
    public Event<CheckFileInfo> FileInfoStatusRequested { get; set; }
    //public Event<Fault<FaultMessage>> FaultMessageReceived { get; private set; }
    public Event<Fault<ReadFile>> ReadFileFaulted { get; private set; }
  }
}