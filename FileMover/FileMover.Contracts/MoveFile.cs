﻿using System;

namespace FileMover.Contracts
{
    public interface MoveFile
    {
        Guid FileId { get; }

        string FileName { get; set; }
        
        string FromFolder { get; set; }
        
        string ToFolder { get; set; }
    }
}