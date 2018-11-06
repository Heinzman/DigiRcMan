using System.Diagnostics;
using Elreg.FrameworkContracts;

namespace Elreg.CatelLogging
{
    public class EventLogHandler : IEventLogHandler
    {
        private readonly string _source;

        public EventLogHandler(string source)
        {
            _source = source;
        }

        public void WriteEntry(string message, EventLogEntryType type)
        {
            var myLog = new EventLog { Source = _source };
            myLog.WriteEntry(message, type);
        }

        public bool SourceExists
        {
            get { return EventLog.SourceExists(_source); }
        }

        public void CreateEventSource(string logName)
        {
            EventLog.CreateEventSource(_source, logName);
        }
    }
}
