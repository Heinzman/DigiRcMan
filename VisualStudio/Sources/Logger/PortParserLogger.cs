using System;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.Log;

namespace Elreg.Logger
{
    public class PortParserLogger : LoggerBase
    {
        private const string Separator = "; ";
        private readonly ISerialPortParser _serialPortParser;
        private string _logText;

        private const int MaxLinesInChapterConst = 5;
        private const string LoggerNameConst = "PortParserLog";

        public PortParserLogger(ISerialPortParser serialPortParser)
        {
            _serialPortParser = serialPortParser;
        }

        public new bool Activated
        {
            get { return base.Activated; }
            set
            {
                if (!base.Activated && value)
                    StartLogging();
                else if (base.Activated && !value)
                    _serialPortParser.DataReceived -= SerialPortParserDataReceived;
                base.Activated = value;
            }
        }

        public override string LoggerName
        {
            get { return LoggerNameConst; }
        }

        protected override int MaxLinesInChapter
        {
            get { return MaxLinesInChapterConst; }
        }

        protected override void StartLogging()
        {
            base.StartLogging();
            _serialPortParser.DataReceived += SerialPortParserDataReceived;
        }

        private void SerialPortParserDataReceived(object sender, PortParserEventArgs portParserEventArgs)
        {
            try
            {
                CreateLogText(portParserEventArgs);
                TextLogger.Log(_logText);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CreateLogText(PortParserEventArgs portParserEventArgs)
        {
            var textCreator = new PortDataActionTextCreator(portParserEventArgs);
            string dateTime = DateTime.Now + Separator;
            string dataDetected = "Data Detected: " + portParserEventArgs.ComPortLine + Separator;
            string action = "Action: " + textCreator.ActionText + Separator;
            string dataIgnored = string.Empty;
            string dataOutstanding = string.Empty;
            if (!string.IsNullOrEmpty(portParserEventArgs.ComPortDataIgnored))
                dataIgnored = "Data Ignored: " + portParserEventArgs.ComPortDataIgnored + Separator;
            if (!string.IsNullOrEmpty(portParserEventArgs.ComPortDataOutstanding))
                dataOutstanding = "Data Outstanding: " + portParserEventArgs.ComPortDataOutstanding + Separator;

            _logText = dateTime + dataDetected + action + dataIgnored + dataOutstanding;
        }
    }
}