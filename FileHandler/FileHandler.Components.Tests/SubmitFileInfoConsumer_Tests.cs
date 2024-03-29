﻿using System;
using System.Linq;
using System.Threading.Tasks;
using FileHandler.Components.Consumers;
using MassTransit;
using MassTransit.Testing;
using Pri.Contracts;
using Xunit;

namespace FileHandler.Components.Tests
{
  public class When_a_filehandler_request_is_consumed
  {
    [Fact]
    public async Task Should_consume_submit_fileinfo_commands()
    {
      // Arrange (Given)
      var harness = new InMemoryTestHarness {TestTimeout = TimeSpan.FromSeconds(5)};
      var consumer = harness.Consumer<SubmitFileInfoConsumer>();

      await harness.Start();
      try
      {
        var fileId = NewId.NextGuid();

        // Act (When)
        await harness.InputQueueSendEndpoint.Send<SubmitFileInfo>(new
        {
          FileId = fileId,
          FileName = "filename.file",
          InVar.Timestamp,
          LocalFolder = "c:/folder/"
        });

        // Assert (Then)
        Assert.False(harness.Sent.Select<FileInfoSubmissionAccepted>().Any());
        Assert.False(harness.Sent.Select<FileInfoSubmissionRejected>().Any());
        Assert.True(consumer.Consumed.Select<SubmitFileInfo>().Any());
      }
      finally
      {
        await harness.Stop();
      }
    }

    [Fact]
    public async Task Should_respond_with_acceptance_if_accepted()
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
          FileName = "filename.file",
          InVar.Timestamp,
          LocalFolder = "c:/folder/"
        });

        // Assert (Then)
        Assert.Equal(response.Message.FileId, fileId);
        Assert.True(consumer.Consumed.Select<SubmitFileInfo>().Any());
        Assert.True(harness.Sent.Select<FileInfoSubmissionAccepted>().Any());
      }
      finally
      {
        await harness.Stop();
      }
    }

    [Fact]
    public async Task Should_respond_with_rejection_if_test_file()
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
        var response = await requestClient.GetResponse<FileInfoSubmissionRejected>(new
        {
          FileId = fileId,
          FileName = "TEST.file",
          InVar.Timestamp,
          LocalFolder = "c:/folder/"
        });

        // Assert (Then)
        Assert.Equal(response.Message.FileId, fileId);
        Assert.True(consumer.Consumed.Select<SubmitFileInfo>().Any());
        Assert.True(harness.Sent.Select<FileInfoSubmissionRejected>().Any());
      }
      finally
      {
        await harness.Stop();
      }
    }

    [Fact]
    public async Task Should_not_publish_fileinfo_submitted_event_when_rejected()
    {
      // Arrange (Given)
      var harness = new InMemoryTestHarness {TestTimeout = TimeSpan.FromSeconds(5)};
      var consumer = harness.Consumer<SubmitFileInfoConsumer>();

      await harness.Start();
      try
      {
        var fileId = NewId.NextGuid();

        await harness.InputQueueSendEndpoint.Send<SubmitFileInfo>(new
        {
          FileId = fileId,
          FileName = "TEST.file",
          InVar.Timestamp,
          LocalFolder = "c:/folder/"
        });

        // Assert (Then)
        Assert.True(consumer.Consumed.Select<SubmitFileInfo>().Any());
        Assert.False(harness.Published.Select<FileInfoSubmitted>().Any());
      }
      finally
      {
        await harness.Stop();
      }
    }

    [Fact]
    public async Task Should_publish_fileinfo_submitted_event()
    {
      // Arrange (Given)
      var harness = new InMemoryTestHarness();
      var consumer = harness.Consumer<SubmitFileInfoConsumer>();

      await harness.Start();
      try
      {
        var fileId = NewId.NextGuid();

        await harness.InputQueueSendEndpoint.Send<SubmitFileInfo>(new
        {
          FileId = fileId,
          FileName = "filename.file",
          InVar.Timestamp,
          LocalFolder = "c:/folder/"
        });

        // Assert (Then)
        Assert.True(harness.Published.Select<FileInfoSubmitted>().Any());
      }
      finally
      {
        await harness.Stop();
      }
    }
  }
}