using System;

namespace FtpPoll.Contracts
{
    public interface SubmitFtpConnection
    {
        Guid ConnectionId { get; }
        DateTime Timestamp { get; }

        string HostName { get; }
        string UserName { get; }
        string Password { get; }
        string Folder { get; }
    }
}