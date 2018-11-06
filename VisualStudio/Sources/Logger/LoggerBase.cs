using Elreg.BusinessObjects;

namespace Elreg.Logger
{
    public abstract class LoggerBase
    {
        private readonly bool _createWithTimeStamp;
        protected bool Activated;
        protected TextLogger TextLogger;

        protected abstract int MaxLinesInChapter { get; }
        public abstract string LoggerName { get; }

        protected LoggerBase()
        {}

        protected LoggerBase(bool createWithTimeStamp)
        {
            _createWithTimeStamp = createWithTimeStamp;
        }

        public virtual string LogsPath
        {
            get { return ServiceHelper.LogsPath; }
        }

        public string TextFileName
        {
            get
            {
                string textFileName = string.Empty;
                if (TextLogger != null)
                    textFileName = TextLogger.TextFileName;
                return textFileName;
            }
        }

        protected virtual void StartLogging()
        {
            TextLogger = new TextLogger(LogsPath, LoggerName, MaxLinesInChapter, _createWithTimeStamp);
        }

        protected void StopLogging()
        {
            TextLogger.Stop();
        }
    }
}
