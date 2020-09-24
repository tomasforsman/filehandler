﻿using System;

namespace FileHandler.Contracts
{
    public interface FileInfoSubmissionAccepted
    {
        Guid FileId { get; }

        DateTime Timestamp { get; }

        string FileName { get; }
        
        string OriginFolder { get; set; }

        string Folder { get; }
    }
}