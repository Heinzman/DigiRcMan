using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using Elreg.Log;

namespace Elreg.Logger
{
    public class TextLogger
    {
        private readonly string _txtFilePath;
        private readonly string _loggerName;
        private readonly int _maxLinesInChapter;
        private readonly bool _createWithTimeStamp;
        private readonly bool _useBackgroundWorker;
        private string _chapterToFill;
        private string _chapterToLog;
        private int _linesInChapter;
        private BackgroundWorker _backgroundWorker;
        private string _logText;
        private string _textFileName;
        private StreamWriter _streamWriter;
        private bool _shouldStop;

        public TextLogger(string txtFilePath, string loggerName, int maxLinesInChapter, 
                          bool createWithTimeStamp = true, bool useBackgroundWorker = true)
        {
            _txtFilePath = txtFilePath;
            _loggerName = loggerName;
            _maxLinesInChapter = maxLinesInChapter;
            _createWithTimeStamp = createWithTimeStamp;
            _useBackgroundWorker = useBackgroundWorker;
            CreateTextFileName();
            Init();
        }

        private void Init()
        {
            try
            {
                _backgroundWorker = new BackgroundWorker();
                _backgroundWorker.DoWork += BackgroundWorkerDoWork;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void Log(string logText)
        {
            _logText = logText;
            AddToChapter();
            CheckToLogIntoTextFile();
        }

        public void Flush()
        {
            StreamWriter.Flush();
        }

        public string TextFileName
        {
            get { return _textFileName; }
        }

        public static string TimeStamp
        {
            get { return string.Format("{0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.Now); }
        }
        
        private void CheckToCreateTextFile()
        {
            if (!File.Exists(TextFileName))
            {
                var fs = new FileStream(TextFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                fs.Close();
            }
        }

        private void CreateTextFileName()
        {
            CheckToCreateDirectory(_txtFilePath);
            _textFileName = _txtFilePath + _loggerName;
            if (_createWithTimeStamp)
                _textFileName += "_" + TimeStampForFileName;
            _textFileName  += ".txt";
        }

        private static string TimeStampForFileName
        {
            get { return string.Format("{0:yyyyMMdd_HHmmss}", DateTime.Now); }
        }
        
        private void CheckToCreateDirectory(string txtFilePath)
        {
            if (Directory.Exists(txtFilePath) == false)
                Directory.CreateDirectory(txtFilePath);
        }

        private void AddToChapter()
        {
            _chapterToFill += _logText + "\r\n";
            _linesInChapter++;
        }

        private void CheckToLogIntoTextFile()
        {
            if (CanBeLogged)
            {
                _chapterToLog = _chapterToFill;
                if (_useBackgroundWorker)
                    LogIntoTextFileAsync();
                else
                    LogIntoTextFile();
                _linesInChapter = 0;
                _chapterToFill = string.Empty;
            }
        }

        private void LogIntoTextFileAsync()
        {
            _backgroundWorker.RunWorkerAsync();
        }

        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                LogIntoTextFile();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private bool CanBeLogged
        {
            get { return IsChapterFilled && (!_backgroundWorker.IsBusy || !_useBackgroundWorker); }
        }

        private bool IsChapterFilled
        {
            get { return _linesInChapter >= _maxLinesInChapter; }
        }

        private StreamWriter StreamWriter
        {
            get
            {
                if (_streamWriter == null)
                {
                    CheckToCreateTextFile();
                    _streamWriter = new StreamWriter(TextFileName, true);
                }
                return _streamWriter;
            }
        }

        private void LogIntoTextFile()
        {
            try
            {
                StreamWriter.Write(_chapterToLog);
                Flush();

                if (_shouldStop)
                {
                    StreamWriter.Close();
                    _streamWriter = null;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void Stop()
        {
            Flush();

            lock (this)
                _shouldStop = true;

            if ((!_backgroundWorker.IsBusy) || !_useBackgroundWorker)
                StreamWriter.Close();
            else if (_backgroundWorker.IsBusy)
            {
                int i = 0;
                while (i++ < 400)
                {
                    Thread.Sleep(20);
                    CheckToLogIntoTextFile();
                    if (!_backgroundWorker.IsBusy)
                    {
                        StreamWriter.Close();
                        break;
                    }
                }             
            }
            StreamWriter.Close();
        }
    }
}
