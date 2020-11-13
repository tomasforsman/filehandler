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
    //State
    [BsonId] public Guid CorrelationId { get; set; }
    public int Version { get; set; }
    public string CurrentState { get; set; }
    public DateTime? Updated { get; set; }

    //File_Is_Submitted
    public Guid FileId { get; set; }
    public string FileName { get; set; }
    public string OriginFolder { get; set; }
    public DateTime? SubmitDate { get; set; }

    //File_Has_Been_Read
    public string BuyerId { get; set; }
    public string SellerId { get; set; }
    public DateTime? ReadDate { get; set; }

    //FTP_Settings_Has_Been_Retrieved
    public string Protocol { get; set; }
    public string HostName { get; set; }
    public string RemoteFolder { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public string Port { get; set; }
    public string SshHostKeyFingerprint { get; set; }
    public DateTime? FTPSettingsRetrieveDate { get; set; }
    
    public string FaultMessage { get; set; }
    public string FaultStackTrace { get; set; }

  }
}