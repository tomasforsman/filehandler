using System;
using System.Linq;
using System.Threading.Tasks;
using FileHandler.Components.Consumers;
using FileHandler.Contracts;
using MassTransit;
using MassTransit.Testing;
using Xunit;

namespace FileHandler.Components.Tests
{
    public class When_a_filehandler_request_is_consumed
    {
        [Fact]
        public async Task Should_consume_submit_fileinfo_commands()
        {
            // Arrange (Given)
            var harness = new InMemoryTestHarness();
            var consumer = harness.Consumer<SubmitFileInfoConsumer>();

            await harness.Start();
            try
            {
                var fileId = NewId.NextGuid();
                var requestClient = harness.ConnectRequestClient<SubmitFileInfo>();

                // Act (When)
                await harness.InputQueueSendEndpoint.Send<SubmitFileInfo>(new
                {
                    FileId = fileId,
                    InVar.Timestamp,
                    FileName = "filename.file",
                    Folder = "c:/folder/",
                    Text = "Det finns ingen som älskar smärtan i sig"
                });
                
                // Assert (Then)
                Assert.True(consumer.Consumed.Select<SubmitFileInfo>().Any());
            }
            finally
            {
                await harness.Stop();
            }
        }
        
        [Fact]
        public async Task Should_respond_with_acceptance_if_ok()
        {
            
            // Arrange (Given)
            var harness = new InMemoryTestHarness();
            var consumer = harness.Consumer<SubmitFileInfoConsumer>();
            await harness.Start();
            try
            {
                
                var fileId = NewId.NextGuid();
                var requestClient = await harness.ConnectRequestClient<SubmitFileInfo>();

                // Act (When)
                var response = await requestClient.GetResponse<FileInfoSubmissionAccepted>(new
                {
                    FileId = fileId,
                    InVar.Timestamp,
                    FileName = "filename.file",
                    Folder = "c:/folder/",
                    Text = "Det finns ingen som älskar smärtan i sig"
                });

                // Assert (Then)
                Assert.Equal<Guid>(response.Message.FileId, fileId);
                Assert.True(consumer.Consumed.Select<SubmitFileInfo>().Any());
                Assert.True(harness.Sent.Select<FileInfoSubmissionAccepted>().Any());
            }
            finally
            {
                await harness.Stop();
            }
        }
    }
}