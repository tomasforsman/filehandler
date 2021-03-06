﻿using System;

namespace FileHandler.Contracts
{
    public interface FileDeletedFromOriginFolder
    {
        Guid FileId { get; }

        string FileName { get; set; }
        
        string Folder { get; set; }
    }
}