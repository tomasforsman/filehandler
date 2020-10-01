﻿using System;

namespace Pri.Contracts
{
    public interface FileInfoSubmissionRejected
    {
        Guid FileId { get; }

        DateTime Timestamp { get; }

        string FileName { get; }

        string Folder { get; }

        string Reason { get; set; }
    }
}