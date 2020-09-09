
using System.Threading.Tasks;
using FileMover.Contracts;
using MassTransit;

namespace FileMover.Components.Consumers
{
    public class MoveFileConsume:
        IConsumer<MoveFile>
    {
        public async Task Consume(ConsumeContext<MoveFile> context)
        {
            await Task.Delay(500);

            await context.RespondAsync<FileMoved>(new
            {
                FileId = context.Message.FileId,
                FileName = context.Message.FileName,
                FromFolder = context.Message.FromFolder,
                ToFolder = context.Message.ToFolder
            });
        }
    }
}