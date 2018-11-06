using System;
using System.IO;
using System.Windows.Forms;

namespace Elreg.Log
{
    // ReSharper disable EmptyGeneralCatchClause
    public class ErrorLog
    {
        private const string ErrorCaption = "An Error occurred";
        private static readonly ErrorLog Inst = new ErrorLog();
        private string _appUserId;
        private string _computer;
        private Exception _ex;
        private bool _initialized;
        private string _ntUserId;
        private string _txtFileName;
        private string _txtFilePath;
        private bool _alwaysShowMessageBox;

        public static void Init(string appUserId, string ntUserId,
                                string computer, bool alwaysShowMessageBox)
        {
            Inst._appUserId = appUserId;
            Inst._ntUserId = ntUserId;
            Inst._computer = computer;
            Inst._initialized = true;
            Inst.CreateTxtFileName();
            Inst._alwaysShowMessageBox = alwaysShowMessageBox;
        }

        public static void LogError(bool showErrorMsg, Exception ex)
        {
            if (Inst._initialized == false)
                throw new Exception("ErrorLog must be initialized first!");

            Inst._ex = ex;
            Inst.LogIntoTextFile();

            if (showErrorMsg || Inst._alwaysShowMessageBox)
                MessageBox.Show(Inst._ex.ToString(), ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LogIntoTextFile()
        {
            try
            {
                // does it already exist?
                if (!File.Exists(_txtFileName))
                    CreateTextFile();

                var sw = new StreamWriter(_txtFileName, true);
                sw.WriteLine("Source        : " + _ex.Source);
                if (_ex.TargetSite != null)
                    sw.WriteLine("TargetSite        : " + _ex.TargetSite.Name);
                sw.WriteLine("Date        : " + DateTime.Now.ToLongTimeString());
                sw.WriteLine("Time        : " + DateTime.Now.ToShortDateString());
                sw.WriteLine("Computer    : " + _computer);
                sw.WriteLine("NT-UserID    : " + _ntUserId);
                sw.WriteLine("App-UserID    : " + _appUserId);
                sw.WriteLine("Error        : " + _ex.Message.Trim());
                if (_ex.StackTrace != null)
                    sw.WriteLine("Stack Trace    : " + _ex.StackTrace.Trim());
                sw.WriteLine("^^-------------------------------------------------------------------^^");
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }

        private void CreateTextFile()
        {
            CheckToCreateDir();
            var fs = new FileStream(_txtFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fs.Close();
        }

        private void CheckToCreateDir()
        {
            try
            {
                if (Directory.Exists(_txtFilePath) == false)
                    Directory.CreateDirectory(_txtFilePath);
            }
            catch { }
        }

        private void CreateTxtFileName()
        {
            if (string.IsNullOrEmpty(_txtFilePath))
                _txtFilePath = Application.StartupPath + "\\ErrorLogs" + DirectoryOfDay;

            Inst._txtFileName = _txtFilePath + "ErrorLog" + Inst._computer + "_" +
                           DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + "_" +
                           DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".txt";

        }

        private string DirectoryOfDay
        {
            get
            {
                string directoryOfDay = DateTime.Today.Year + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Day.ToString().PadLeft(2, '0');
                directoryOfDay = "\\" + directoryOfDay + "\\";
                return directoryOfDay;
            }
        }

    }
}