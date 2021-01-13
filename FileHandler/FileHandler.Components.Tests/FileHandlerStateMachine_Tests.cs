using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Automatonymous.Graphing;
using Automatonymous.Visualizer;
using FileHandler.Components.StateMachines;
using MassTransit;
using MassTransit.Testing;
using Pri.Contracts;
using Xunit;
using Xunit.Abstractions;

namespace FileHandler.Components.Tests
{
  public class Submitting_file_info
  {
    private readonly ITestOutputHelper output;

    public Submitting_file_info(ITestOutputHelper output)
    {
      this.output = output;
    }

    [Fact]
    public async Task Should_create_a_state_instance()
    {
      // Arrange (Given)
      var harness = new InMemoryTestHarness();
      var fileHandlerStateMachine = new FileHandlerStateMachine();
      var saga = harness.StateMachineSaga<FileHandlerState, FileHandlerStateMachine>(fileHandlerStateMachine);

      await harness.Start();
      try
      {
        var fileId = NewId.NextGuid();

        await harness.Bus.Publish<FileInfoSubmitted>(new
        {
            FileId = fileId,
            InVar.Timestamp,
            FileName = "filename.file",
            LocalFolder = "c:/folder/",
            OriginFolder = "c:/folder/"
        });
        var instanceID = await saga.Exists(fileId, x => x.File_Is_Submitted);
        var instance = saga.Sagas.Contains(instanceID.Value);

        Assert.NotNull(instanceID);
        Assert.True(saga.Created.Select(x => x.CorrelationId == fileId).Any());
      }
      finally
      {
        await harness.Stop();
      }
    }


    [Fact]
    public async Task Should_respond_to_status_checks()
    {
      // Arrange (Given)
      var harness = new InMemoryTestHarness();
      var fileHandlerStateMachine = new FileHandlerStateMachine();
      var saga = harness.StateMachineSaga<FileHandlerState, FileHandlerStateMachine>(fileHandlerStateMachine);

      await harness.Start();
      try
      {
        var fileId = NewId.NextGuid();

        await harness.Bus.Publish<FileInfoSubmitted>(new
        {
            FileId = fileId,
            InVar.Timestamp,
            FileName = "filename.file",
            LocalFolder = "c:/folder/",
            OriginFolder = "c:/folder/"
        });
        var instanceId = await saga.Exists(fileId, x => x.File_Is_Submitted);
        Debug.Assert(instanceId != null, nameof(instanceId) + " != null");
        var instance = saga.Sagas.Contains(instanceId.Value);

        var requestClient = await harness.ConnectRequestClient<CheckFileInfo>();

        var response = await requestClient.GetResponse<FileStatus>(new {FileId = fileId});

        Assert.Equal(response.Message.State, fileHandlerStateMachine.File_Is_Submitted.Name);
      }
      finally
      {
        await harness.Stop();
      }
    }

    [Fact]
    public void Show_Me_The_StateMachine()
    {
      var stateMachine = new FileHandlerStateMachine();

      var graph = stateMachine.GetGraph();

      var generator = new StateMachineGraphvizGenerator(graph);

      var dots = generator.CreateDotFile();

      output.WriteLine(dots);
    }
  }

  public class FileReader_responds
  {
    private readonly ITestOutputHelper output;

    public FileReader_responds(ITestOutputHelper output)
    {
      this.output = output;
    }
    
    [Fact]
    public async Task Status_should_be_file_has_been_read()
    {
      // Arrange (Given)
      var harness = new InMemoryTestHarness();
      var fileHandlerStateMachine = new FileHandlerStateMachine();
      var saga = harness.StateMachineSaga<FileHandlerState, FileHandlerStateMachine>(fileHandlerStateMachine);

      await harness.Start();
      try
      {
        var fileId = NewId.NextGuid();
        
        await harness.Bus.Publish<FileInfoSubmitted>(new
        {
          FileId = fileId,
          InVar.Timestamp,
          FileName = "filename.file",
          LocalFolder = "c:/folder/",
          OriginFolder = "c:/folder/"
        });
        
        //await Task.Delay(2000);

        await saga.Exists(fileId, x => x.File_Is_Submitted);
        await harness.Bus.Publish<FileRead>(new
        {
            FileId = fileId,
            BuyerId = default(string),
            SellerId = default(string),
            InvoiceId = default(string)
        });
        
        var instanceId = await saga.Exists(fileId, x => x.File_Has_Been_Read);
        output.WriteLine(instanceId.ToString());
        

        Debug.Assert(instanceId != null, nameof(instanceId) + " != null");
        var instance = saga.Sagas.Contains(instanceId.Value);

        var requestClient = await harness.ConnectRequestClient<CheckFileInfo>();

        var response = await requestClient.GetResponse<FileStatus>(new {FileId = fileId});

        Assert.Equal(response.Message.State, fileHandlerStateMachine.File_Has_Been_Read.Name);
      }
      finally
      {
        await harness.Stop();
      }
    }
    
  }
  
  public class PriWebCommunicator_responds
  {
    private readonly ITestOutputHelper output;

    public PriWebCommunicator_responds(ITestOutputHelper output)
    {
      this.output = output;
    }
    
    [Fact]
    public async Task Status_should_be_FTP_Settings_Has_Been_Retrieved()
    {
      // Arrange (Given)
      var harness = new InMemoryTestHarness();
      var fileHandlerStateMachine = new FileHandlerStateMachine();
      var saga = harness.StateMachineSaga<FileHandlerState, FileHandlerStateMachine>(fileHandlerStateMachine);

      await harness.Start();
      try
      {
        var fileId = NewId.NextGuid();
        
        await harness.Bus.Publish<FileInfoSubmitted>(new
        {
          FileId = fileId,
          InVar.Timestamp,
          FileName = "filename.file",
          LocalFolder = "c:/folder/",
          OriginFolder = "c:/folder/"
        });
        
        //await Task.Delay(2000);

        await saga.Exists(fileId, x => x.File_Is_Submitted);
        await harness.Bus.Publish<FileRead>(new
        {
          FileId = fileId,
          BuyerId = default(string),
          SellerId = default(string),
          InvoiceId = default(string)
        });
        
        await saga.Exists(fileId, x => x.File_Has_Been_Read);
        await harness.Bus.Publish<CommunicationSettingsFound>(new
        {

            FileId = fileId,
            Protocol = default(string),
            HostName = default(string),
            RemoteFolder = default(string),
            Password = default(string),
            UserName = default(string),
            Port = default(string),
            SshHostKeyFingerprint = default(string)
        });
        
        var instanceId = await saga.Exists(fileId, x => x.Ftp_Settings_Has_Been_Retrieved);
        output.WriteLine(instanceId.ToString());
        

        Debug.Assert(instanceId != null, nameof(instanceId) + " != null");
        var instance = saga.Sagas.Contains(instanceId.Value);

        var requestClient = await harness.ConnectRequestClient<CheckFileInfo>();

        var response = await requestClient.GetResponse<FileStatus>(new {FileId = fileId});

        Assert.Equal(response.Message.State, fileHandlerStateMachine.Ftp_Settings_Has_Been_Retrieved.Name);
      }
      finally
      {
        await harness.Stop();
      }
    }
    
  }
}