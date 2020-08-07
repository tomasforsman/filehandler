using System;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Automatonymous;
using FileHandler.Components.Consumers;
using FileHandler.Components.StateMachines;
using FileHandler.Contracts;
using MassTransit;
using MassTransit.Testing;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

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
                    Timestamp = InVar.Timestamp,
                    FileName = "filename.file",
                    Folder = "c:/folder/",
                    Text = "Det finns ingen som älskar smärtan i sig"
                });
                var instanceID = await saga.Exists(fileId, x => x.Submitted);
                var instance = saga.Sagas.Contains(instanceID.Value);

                Assert.NotNull(instanceID);
                Assert.True(saga.Created.Select(x => x.CorrelationId == fileId).Any());
            }
            finally
            {
                await harness.Stop();
            }
        }
        
        
    }
}