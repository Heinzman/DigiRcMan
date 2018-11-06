using System.Diagnostics;

namespace Elreg.FrameworkContracts
{
    public interface IEventLogHandler
    {
        void WriteEntry(string message, EventLogEntryType type);
        bool SourceExists { get; }
        void CreateEventSource(string logName);
    }
}
