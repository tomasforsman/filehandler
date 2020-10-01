using FileHandler.Contracts;
using MassTransit;
using MassTransit.Courier;
using System;
using System.Threading.Tasks;

namespace FileHandler.Components.FileActivities
{
    public class ReadFileActivity :
        IActivity<MoveFileArguments, MoveFileLog>
    {
        private readonly IRequestClient<ReadFile> _client;

        public ReadFileActivity(IRequestClient<MoveFile> client) => _client = client;

        public async Task<ExecutionResult> Execute(ExecuteContext<MoveFileArguments> context)
        {
            var fileId = context.Arguments.FileId;
            var fileName = context.Arguments.FileName;
            var fromFolder = context.Arguments.FromFolder;
            var toFolder = context.Arguments.ToFolder;

            var response = await _client.GetResponse<FileRead>(new
            {
                FileId = fileId,
                
            });

            return context.Completed(new
            {
                FileId = fileId
            });
        }

        public Task<CompensationResult> Compensate(CompensateContext<MoveFileLog> context) => throw new NotImplementedException();
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