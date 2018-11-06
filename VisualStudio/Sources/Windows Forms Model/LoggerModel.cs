using System.Collections.Generic;
using System.IO;
using Heinzman.BusinessObjects.Interfaces;
using Heinzman.Logger;
using Heinzman.PortDataParser;
using Heinzman.BusinessObjects;
using Heinzman.RaceOptionsService;
using Heinzman.BusinessObjects.Options;

namespace Heinzman.DomainModels
{
    public class LoggerModel
    {
        private static readonly LoggerModel _inst = new LoggerModel();
        private RaceLogger _raceLogger;
        private PortReaderLogger _portReaderLogger;
        private PortParserLogger _portParserLogger;
        private CarSoundLogger _carSoundLogger;
        private SpeedSumLogger _speedSumLogger;
        private bool _carSoundLoggerActivated;
        private RaceRecoveryLogger _raceRecoveryLogger;
        private SerializerService<LoggerSettings> _serializerService;
        private LoggerSettings _loggerSettings;

        private const string LoggerSettingsFile = "LoggerSettings.Xml";

        public static LoggerModel Inst
        {
            get { return _inst; }
        }

        public ISerialPortReader PortReader
        {
            set { _portReaderLogger = new PortReaderLogger(value); }
        }

        public IPortParser PortParser
        {
            set { _portParserLogger = new PortParserLogger(value); }
        }

        public bool RaceLoggerActivated
        {
            get { return _raceLogger.Activated; }
            set { _raceLogger.Activated = value; }
        }

        public bool SpeedSumLoggerActivated
        {
            get { return _speedSumLogger.Activated; }
            set { _speedSumLogger.Activated = value; }
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

        public bool RaceRecoveryLoggerActivated
        {
            get { return _raceRecoveryLogger.Activated; }
            set { _raceRecoveryLogger.Activated = value; }
        }

        public bool CarSoundLoggerActivated
        {
            get { return _carSoundLoggerActivated; }
            set { _carSoundLoggerActivated = value; }
        }

        public CarSoundLogger CarSoundLogger
        {
            get { return _carSoundLogger; }
            set
            {
                _carSoundLogger = value;
                CarSoundLogger.Activated = _carSoundLoggerActivated;
            }
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

        public string SpeedSumLoggerFileName
        {
            get { return GetLogFileName(_speedSumLogger); }
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
                _speedSumLogger = new SpeedSumLogger(value);
                _raceRecoveryLogger = new RaceRecoveryLogger(value);
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
                                      PortReaderLoggerActivated = PortReaderLoggerActivated,
                                      PortParserLoggerActivated = PortParserLoggerActivated,
                                      RaceRecoveryLoggerActivated = RaceRecoveryLoggerActivated,
                                      SpeedSumLoggerActivated = SpeedSumLoggerActivated
                                  };
        }

        private void AssignSettingToLoggers()
        {
            RaceLoggerActivated = _loggerSettings.RaceLoggerActivated;
            PortReaderLoggerActivated = _loggerSettings.PortReaderLoggerActivated;
            PortParserLoggerActivated = _loggerSettings.PortParserLoggerActivated;
            RaceRecoveryLoggerActivated = _loggerSettings.RaceRecoveryLoggerActivated;
            SpeedSumLoggerActivated = _loggerSettings.SpeedSumLoggerActivated;
        }

    }
}
