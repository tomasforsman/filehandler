using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using FileHandler.Contracts;
using MassTransit;
using MassTransit.Courier;

namespace FileHandler.Components.FileActivities
{
    public class MoveFileActivity :
        IActivity<MoveFileArguments, MoveFileLog>
    {
        private readonly IRequestClient<MoveFile> _client;

        public MoveFileActivity(IRequestClient<MoveFile> client)
        {
            _client = client;
        }
        
        public async Task<ExecutionResult> Execute(ExecuteContext<MoveFileArguments> context)
        {
            var fileId = context.Arguments.FileId;
            var fileName = context.Arguments.FileName;
            var fromFolder = context.Arguments.FromFolder;
            var toFolder = context.Arguments.ToFolder;
            
            var response = await _client.GetResponse<FileMoved>(new
            {
                   FileId = fileId,
                   FileName = fileName,
                   FromFolder = fromFolder,
                   ToFolder = toFolder
            });

            return context.Completed(new
            {
                FileId = fileId
            });
        }

        public Task<CompensationResult> Compensate(CompensateContext<MoveFileLog> context)
        {
            throw new NotImplementedException();
        }
    }

    public interface MoveFileArguments
    {
        Guid FileId { get; }
        string FileName { get; }
        string FromFolder { get; }
        string ToFolder { get; }
    }
    public interface MoveFileLog
    {
        Guid FileId { get; }
    }
}