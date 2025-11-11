using System.Diagnostics;

namespace FTPSyncLib
{
    public static class Eventing
    {
        public enum LogLevel
        {
            Info,
            Warning,
            Error
        }
        private static readonly string EventSource = "FTPSyncService";
        public static void Log(LogLevel level, string name, string message)
        {
            try
            {
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
#pragma warning disable CA1416 // Validate platform compatibility
                    if (!EventLog.SourceExists(EventSource))
                        EventLog.CreateEventSource(EventSource, "Application");
                    using var eventLog = new EventLog("Application");
                    eventLog.Source = EventSource;
                    EventLogEntryType entryType = level switch
                    {
                        LogLevel.Info => EventLogEntryType.Information,
                        LogLevel.Warning => EventLogEntryType.Warning,
                        LogLevel.Error => EventLogEntryType.Error,
                        _ => EventLogEntryType.Information,
                    };
                    eventLog.WriteEntry(name + ":" + message, entryType);
#pragma warning restore CA1416 // Validate platform compatibility
                }
            }
            catch
            {
                //Not much to do hanymore
            }
        }
    }
}
