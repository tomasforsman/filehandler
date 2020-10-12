using System.Linq;
using System.Threading.Tasks;
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

        public Submitting_file_info(ITestOutputHelper output) => this.output = output;

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
                    LocalFolder = "c:/folder/"
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
                    LocalFolder = "c:/folder/"
                });
                var instanceID = await saga.Exists(fileId, x => x.Submitted);
                var instance = saga.Sagas.Contains(instanceID.Value);

                var requestClient = await harness.ConnectRequestClient<CheckFileInfo>();

                var response = await requestClient.GetResponse<FileStatus>(new { FileId = fileId });

                Assert.Equal(response.Message.State, fileHandlerStateMachine.Submitted.Name);
            }
            finally
            {
                await harness.Stop();
            }
        }
    }
}