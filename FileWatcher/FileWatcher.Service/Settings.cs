namespace FileWatcher.Service
{
    public class Settings
    {
        public AppConfiguration AppConfig { get; set; }

        public class AppConfiguration
        {
            public RabbitMqSettings RabbitMq { get; set; }

            public class RabbitMqSettings
            {
                public string Host { get; set; }
                public string VirtualHost { get; set; }
                public string Username { get; set; }

                public string Password { get; set; }
                // public bool SSLActive { get; set; }
                // public string SSLThumbprint { get; set; }
                // public int TimeInSeconds { get; set; }
            }
        }
    }
}