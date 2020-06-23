using System;

namespace FtpPoll.Contracts
{
    public interface FtpConnectionSubmissionAccepted
    {
        Guid ConnectionId { get; }

        DateTime Timestamp { get; }

        string HostName { get; }

        string UserName { get; }

        string Password { get; }

        string Folder { get; }
    }
}