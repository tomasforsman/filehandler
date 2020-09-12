using FileMover.Contracts;
using MassTransit;
using System.Threading.Tasks;

namespace FileMover.Components.Consumers
{
    public class MoveFileConsume :
        IConsumer<MoveFile>
    {
        public async Task Consume(ConsumeContext<MoveFile> context)
        {
            await Task.Delay(500);

            await context.RespondAsync<FileMoved>(new
            {
                context.Message.FileId,
                context.Message.FileName,
                context.Message.FromFolder,
                context.Message.ToFolder
            });
        }
    }
}