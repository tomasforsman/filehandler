﻿using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Courier;
using Pri.Contracts;

namespace FileHandler.Components.FileActivities
{
  public class ReadFileActivity :
    IActivity<ReadFileArguments, FileRead>
  {
    private readonly IRequestClient<ReadFile> _client;

    public ReadFileActivity(IRequestClient<ReadFile> client)
    {
      _client = client;
    }

    public async Task<ExecutionResult> Execute(ExecuteContext<ReadFileArguments> context)
    {
      var buyerId = context.Arguments.BuyerId;
      var fileId = context.Arguments.FileId;
      var fileName = context.Arguments.FileName;
      var sellerId = context.Arguments.SellerId;
      var invoiceId = context.Arguments.InvoiceId;

      var response = await _client.GetResponse<FileRead>(new
      {
        FileId = fileId,
        FileName = fileName
      });

      return context.Completed(new
      {
        BuyerId = buyerId,
        FileId = fileId,
        SellerId = sellerId,
        InvoiceId = invoiceId
      });
    }

    public async Task<CompensationResult> Compensate(CompensateContext<FileRead> context)
    {
      return context.Compensated();
    }
  }

  public interface ReadFileArguments
  {
    Guid FileId { get; }
    string BuyerId { get; }
    string FileName { get; }
    string SellerId { get; }
    string InvoiceId { get; }
  }

  public interface FileRead
  {
    Guid FileId { get; }
    string BuyerId { get; }
    string SellerId { get; }
  }
}