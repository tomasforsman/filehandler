using System;
using System.Threading;

namespace FileHandler.Components.Telemetry
{
    public static class CorrelationContext
    {
        private static readonly AsyncLocal<string> _correlationId = new AsyncLocal<string>();

        public static string CorrelationId
        {
            get => _correlationId.Value ?? GenerateNewCorrelationId();
            set => _correlationId.Value = value;
        }

        public static string GenerateNewCorrelationId()
        {
            var correlationId = Guid.NewGuid().ToString("N")[..8];
            _correlationId.Value = correlationId;
            return correlationId;
        }

        public static void Clear()
        {
            _correlationId.Value = null;
        }
    }
}