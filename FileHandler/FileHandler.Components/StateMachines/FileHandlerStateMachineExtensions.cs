﻿using System;
using Automatonymous;
using Automatonymous.Binders;
using MassTransit;
using Pri.Contracts;

namespace FileHandler.Components.StateMachines
{
  public static class FileHandlerStateMachineExtensions
  {
    // Initially
    public static EventActivityBinder<FileHandlerState, FileInfoSubmitted> CopyInfoToInstance(this
      EventActivityBinder<FileHandlerState, FileInfoSubmitted> binder)
    {
      return binder.Then(context =>
      {
        var i = context.Instance;
        var d = context.Data;
        i.FileId = d.FileId;
        i.FileName = d.FileName;
        i.OriginFolder = d.OriginFolder;
        i.SubmitDate = d.Timestamp;
        i.Updated = DateTime.UtcNow;
      });
    }
    
    // File_Is_Submitted
    public static EventActivityBinder<FileHandlerState, FileRead> AddFileContentToInstance(this
      EventActivityBinder<FileHandlerState, FileRead> binder)
    {
      return binder.Then(context =>
      {
        var i = context.Instance;
        var d = context.Data;
        i.BuyerId = d.BuyerId;
        i.SellerId = d.SellerId;
        i.ReadDate = DateTime.UtcNow;
        i.Updated = DateTime.UtcNow;
      });
    } 
    
    public static EventActivityBinder<FileHandlerState, FileRead> PublishFileContent(this
      EventActivityBinder<FileHandlerState, FileRead> binder)
    {
      return binder.PublishAsync(context => context.Init<Read>(new
      {
        FileId = context.Instance.FileId,
        BuyerId = context.Instance.BuyerId,
        SellerId = context.Instance.SellerId
      }));
    }
    
    // File_Has_Been_Read
    public static EventActivityBinder<FileHandlerState, CommunicationSettingsFound> AddFtpInformationToInstance(this
      EventActivityBinder<FileHandlerState, CommunicationSettingsFound> binder)
    {
      return binder.Then(context =>
      {
        var i = context.Instance;
        var d = context.Data;
        i.Protocol = d.Protocol;
        i.HostName = d.HostName;
        i.RemoteFolder = d.RemoteFolder;
        i.Password = d.Password;
        i.UserName = d.UserName;
        i.Port = d.Port;
        i.SshHostKeyFingerprint = d.SshHostKeyFingerprint;
        i.FTPSettingsRetrieveDate = DateTime.UtcNow;
        i.Updated = DateTime.UtcNow;
      });
    }

    public static EventActivityBinder<FileHandlerState, CommunicationSettingsFound> PublishFtpInformationToInstance(this
      EventActivityBinder<FileHandlerState, CommunicationSettingsFound> binder)
    {
      return binder.PublishAsync(context => context.Init<CommunicationSettings>(new
      {
        FileId = context.Instance.FileId,
        FileName = context.Instance.FileName,
        Protocol = context.Instance.Protocol,
        HostName = context.Instance.HostName,
        RemoteFolder = context.Instance.RemoteFolder,
        Password = context.Instance.Password,
        UserName = context.Instance.UserName,
        Port = context.Instance.Port,
        SshHostKeyFingerprint = context.Instance.SshHostKeyFingerprint
      }));
    }
  }
}