using System.Collections.Generic;
using System.IO;
using Elreg.BusinessObjects.Interfaces;
using Elreg.Logger;
using Elreg.BusinessObjects;
using Elreg.RaceOptionsService;
using Elreg.BusinessObjects.Options;

namespace Elreg.DomainModels.Logs
{
    public class LoggerModel
    {
        public static readonly LoggerModel Inst = new LoggerModel();
        private RaceLogger _raceLogger;
        private RaceReplayLogger _raceReplayLogger;
        private PortReaderLogger _portReaderLogger;
        private PortParserLogger _portParserLogger;
        private SerializerService<LoggerSettings> _serializerService;
        private LoggerSettings _loggerSettings;

        private const string LoggerSettingsFile = "LoggerSettings.Xml";

        public ISerialPortReader PortReader
        {
            set { _portReaderLogger = new PortReaderLogger(value); }
        }

        public ISerialPortParser SerialPortParser
        {
            set { _portParserLogger = new PortParserLogger(value); }
        }

        public bool RaceLoggerActivated
        {
            get { return _raceLogger.Activated; }
            set { _raceLogger.Activated = value; }
        }

        public bool RaceReplayLoggerActivated
        {
            get { return _raceReplayLogger.Activated; }
            set { _raceReplayLogger.Activated = value; }
        }

        public bool PortReaderLoggerActivated
        {
            get { return _portReaderLogger.Activated; }
            set { _portReaderLogger.Activated = value; }
        }

        public bool PortParserLoggerActivated
        {
            get { return _portParserLogger.Activated; }
            set { _portParserLogger.Activated = value; }
        }

        public void SaveData()
        {
            DetermineLoggerSettings();
            _serializerService.Save(_loggerSettings);
        }

        public void LoadData()
        {
            _serializerService = new SerializerService<LoggerSettings>(ServiceHelper.ConfigPath, LoggerSettingsFile);
            _loggerSettings = _serializerService.Object;
            AssignSettingToLoggers();
        }

        public string RaceLogFileName
        {
            get { return GetLogFileName(_raceLogger); }
        }

        public string RaceReplayLogFileName
        {
            get { return GetLogFileName(_raceReplayLogger); }
        }

        public string PortParserLogFileName
        {
            get { return GetLogFileName(_portParserLogger); }
        }

        public string ComPortLogFileName
        {
            get { return GetLogFileName(_portReaderLogger); }
        }

        public RaceModel.RaceModel RaceModel
        {
            set
            {
                _raceLogger = new RaceLogger(value);
                _raceReplayLogger = new RaceReplayLogger(value, new RaceReplayLoggerModel(value));
            }
        }

        private string GetLogFileName(LoggerBase loggerBase)
        {
            string logFileName = null;
            string textFileName = loggerBase.TextFileName; 

            if (File.Exists(textFileName))
                logFileName = textFileName;
            else
            {
                string[] files = Directory.GetFiles(loggerBase.LogsPath, loggerBase.LoggerName + "*");
                var fileList = new List<string>(files);
                fileList.Sort();
                if (fileList.Count > 0)
                    logFileName = fileList[fileList.Count-1];
            }
            return logFileName;
        }

        private void DetermineLoggerSettings()
        {
            _loggerSettings = new LoggerSettings
                                  {
                                      RaceLoggerActivated = RaceLoggerActivated,
                                      RaceReplayLoggerActivated = RaceReplayLoggerActivated,
                                      PortReaderLoggerActivated = PortReaderLoggerActivated,
                                      PortParserLoggerActivated = PortParserLoggerActivated
                                  };
        }

        private void AssignSettingToLoggers()
        {
            RaceLoggerActivated = _loggerSettings.RaceLoggerActivated;
            RaceReplayLoggerActivated = _loggerSettings.RaceReplayLoggerActivated;
            PortReaderLoggerActivated = _loggerSettings.PortReaderLoggerActivated;
            PortParserLoggerActivated = _loggerSettings.PortParserLoggerActivated;
        }

    }
}
