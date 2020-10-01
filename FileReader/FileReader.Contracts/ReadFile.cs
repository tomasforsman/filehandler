using System;

namespace Pri.Contracts
{
    public interface ReadFile
    {
        public Guid FileId { get; set; }
        public string FileName { get; set; }
        public string FolderName { get; set; }
    }
}