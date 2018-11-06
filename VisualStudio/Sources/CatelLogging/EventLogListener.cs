using System.Diagnostics;
using Catel.Logging;
using Elreg.FrameworkContracts;

namespace Elreg.CatelLogging
{
    public class EventLogListener : LogListenerBase
    {
        private readonly IEventLogHandler _eventLogHandler;

        public EventLogListener(IEventLogHandler eventLogHandler)
        {
            _eventLogHandler = eventLogHandler;
        }

        protected override void Write(ILog log, string message, LogEvent logEvent, object extraData)
        {
            string entry = message;
            if (extraData != null)
                entry += extraData.ToString();

            if (!_eventLogHandler.SourceExists)
                _eventLogHandler.CreateEventSource("Application");
            _eventLogHandler.WriteEntry(entry, MapLogEvent(logEvent));
        }

        private EventLogEntryType MapLogEvent(LogEvent logEvent)
        {
            EventLogEntryType eventLogEntryType;
            switch (logEvent)
            {
                case LogEvent.Error:
                    eventLogEntryType = EventLogEntryType.Error;
                    break;
                case LogEvent.Warning:
                    eventLogEntryType = EventLogEntryType.Warning;
                    break;
                 default:
                    eventLogEntryType = EventLogEntryType.Information;
                    break;
            }
            return eventLogEntryType;
        }
    }
}
