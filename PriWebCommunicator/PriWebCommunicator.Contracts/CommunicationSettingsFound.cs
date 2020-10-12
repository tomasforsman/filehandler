using System;

namespace Pri.Contracts
{
    public interface CommunicationSettingsFound
    {
        public Guid FileId { get; }
        public string Protocol { get; set; }
        public string HostName { get; set; }
        public string RemoteFolder { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Port { get; set; }
        public string SshHostKeyFingerprint { get; set; }
    }
}