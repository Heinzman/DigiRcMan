using System;
using System.IO;
using System.Text;
using Catel;
using Catel.Logging;
using Elreg.FrameworkContracts;

namespace Elreg.CatelLogging
{
    public class FileLogListener : LogListenerBase
    {
        private string _fileNameWithPath;
        private readonly string _logRootPath;
        private readonly string _computer;
        private readonly string _userId;
        private readonly IDateTime _dateTime;
        private string _logPathWithDate;
        private ITextWriterHandler _textWriter;
        private string _directoryOfDay;

        public FileLogListener(string logRootPath, string computer, string userId, IDateTime dateTime, ITextWriterHandler textWriter)
        {
            Argument.IsNotNullOrEmpty("logRootPath", logRootPath);
            _logRootPath = logRootPath;
            _computer = computer;
            _userId = userId;
            _dateTime = dateTime;
            _textWriter = textWriter;
            InitFilePath();
        }

        protected override void Write(ILog log, string message, LogEvent logEvent, object extraData)
        {
            CheckToInitFileNameAndWriter();
            CheckToCreateDir();
            CheckToCreateTextFile();
            CheckToCreateStreamWriter();
            WriteMessageToFile(message, extraData);
        }

        private void InitFilePath()
        {
            DetermineLogPathWithDate();
            DetermineFileNameWithPath();
        }

        private void DetermineLogPathWithDate()
        {
            _directoryOfDay = DirectoryOfDay;
            _logPathWithDate = _logRootPath + "\\" + _directoryOfDay + "\\";
        }

        private void DetermineFileNameWithPath()
        {
            string fileName = "Log_" + _computer + "_" +
                                 _dateTime.Now.Year +
                                 _dateTime.Now.Month.ToString().PadLeft(2, '0') +
                                 _dateTime.Now.Day.ToString().PadLeft(2, '0') + "_" +
                                 _dateTime.Now.Hour.ToString().PadLeft(2, '0') +
                                 _dateTime.Now.Minute.ToString().PadLeft(2, '0') +
                                 _dateTime.Now.Second.ToString().PadLeft(2, '0') + ".txt";
            _fileNameWithPath = _logPathWithDate + fileName;
        }

        private string DirectoryOfDay
        {
            get
            {
                return _dateTime.Now.Year + _dateTime.Now.Month.ToString().PadLeft(2, '0') +
                       _dateTime.Now.Day.ToString().PadLeft(2, '0');
            }
        }

        private void CheckToCreateStreamWriter()
        {
            if (!_textWriter.IsCreated)
                _textWriter.CreateInstance(_fileNameWithPath);
        }

        private void WriteMessageToFile(string message, object extraData)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("DateTime: ");
            sb.Append(DateTime.Now.ToString("dd.mm.yyyy HH:MM:ss"));
            sb.AppendLine();
            sb.Append("Computer: ");
            sb.Append(_computer);
            sb.AppendLine();
            sb.Append("UserId: ");
            sb.Append(_userId);
            sb.AppendLine();
            sb.AppendLine(message);
            if (extraData != null)
                sb.AppendLine(extraData.ToString());
            sb.AppendLine("-----------------------------");

            _textWriter.WriteLine(sb.ToString());
            _textWriter.Flush();
        }

        private void CheckToInitFileNameAndWriter()
        {
            if (MustFilePathBeChanged)
            {
                _textWriter.Close();
                _textWriter = null;
                InitFilePath();
            }
        }

        private bool MustFilePathBeChanged
        {
            get { return DirectoryOfDay != _directoryOfDay; }
        }

        private void CheckToCreateTextFile()
        {
            if (!File.Exists(_fileNameWithPath))
            {
                var fs = new FileStream(_fileNameWithPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                fs.Close();
            }
        }

        private void CheckToCreateDir()
        {
            if (!Directory.Exists(_logPathWithDate))
                Directory.CreateDirectory(_logPathWithDate);
        }

    }
}
