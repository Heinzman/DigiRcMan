using System;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.Log;

namespace Elreg.Logger
{
    public class PortReaderLogger : LoggerBase, ISerialPortObserver
    {
        private readonly ISerialPortReader _portReader;

        private const int MaxLinesInChapterConst = 50;
        private const string LoggerNameConst = "PortReaderLog";
        private const string Separator1 = " | ";
        private const string Separator2 = ";";

        public PortReaderLogger(ISerialPortReader portReader)
        {
            _portReader = portReader;
        }

        public new bool Activated
        {
            get { return base.Activated; }
            set
            {
                if (!base.Activated && value)
                    StartLogging();
                else if (base.Activated && !value)
                    _portReader.Detach(this);

                base.Activated = value;
            }
        }

        public void SerialPortStatusChanged(object sender, SerialPortReaderStatus status)
        {
        }

        public void SerialPortDataReceived(object sender, string line, DateTime timeStamp)
        {
            try
            {
                string textToLog = timeStamp.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK") + Separator1 + line + Separator2;
                TextLogger.Log(textToLog);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
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
            _portReader.Attach(this);
        }

    }
}