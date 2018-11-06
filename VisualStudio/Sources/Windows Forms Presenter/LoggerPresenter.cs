using System;
using System.Diagnostics;
using System.IO;
using Elreg.DomainModels.Logs;
using Elreg.DomainModels.RaceReplay;
using Elreg.Log;
using Elreg.ResourcesService;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsPresenter
{
    public class LoggerPresenter
    {
        private readonly ILoggerView _loggerView;

        public LoggerPresenter(ILoggerView loggerView)
        {
            try
            {
                _loggerView = loggerView;
                AdjustCultureStrings();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void ObtainActivationsOfLoggers()
        {
            try
            {
                _loggerView.RaceLoggerChecked = LoggerModel.Inst.RaceLoggerActivated;
                _loggerView.RaceReplayLoggerChecked = LoggerModel.Inst.RaceReplayLoggerActivated;
                _loggerView.PortReaderLoggerChecked = LoggerModel.Inst.PortReaderLoggerActivated;
                _loggerView.PortParserLoggerChecked = LoggerModel.Inst.PortParserLoggerActivated;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void ShowRaceLog()
        {
            try
            {
                ShowLog(LoggerModel.Inst.RaceLogFileName);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void ShowRaceReplayLog()
        {
            try
            {
                RaceReplayModel raceReplayModel = new RaceReplayModel(LoggerModel.Inst.RaceReplayLogFileName);
                raceReplayModel.ParseFile();
                raceReplayModel.CreateRaceReplayTableFile();

                ShowLog(raceReplayModel.RaceReplayTableFileName);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void ShowPortParserLog()
        {
            try
            {
                ShowLog(LoggerModel.Inst.PortParserLogFileName);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void ShowComPortLog()
        {
            try
            {
                ShowLog(LoggerModel.Inst.ComPortLogFileName);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void HandleOk()
        {
            try
            {
                CheckToActivateLoggers();
                SaveData();
                _loggerView.Close();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void HandleCancel()
        {
            try
            {
                _loggerView.Close();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SaveData()
        {
            LoggerModel.Inst.SaveData();
        }

        private void CheckToActivateLoggers()
        {
            LoggerModel.Inst.RaceLoggerActivated = _loggerView.RaceLoggerChecked;
            LoggerModel.Inst.RaceReplayLoggerActivated = _loggerView.RaceReplayLoggerChecked;
            LoggerModel.Inst.PortReaderLoggerActivated = _loggerView.PortReaderLoggerChecked;
            LoggerModel.Inst.PortParserLoggerActivated = _loggerView.PortParserLoggerChecked;
        }

        private void ShowLog(string fileName)
        {
            if (File.Exists(fileName))
            {
                string systemDir = Environment.SystemDirectory;
                Process.Start(systemDir + "\\notepad.exe", fileName);
            }
        }

        private void AdjustCultureStrings()
        {
            _loggerView.Text = LanguageManager.GetString("LoggerFormCaption");
            _loggerView.BtnOk.Text = LanguageManager.GetString("LoggerFormBtnOk");
            _loggerView.BtnCancel.Text = LanguageManager.GetString("LoggerFormBtnCancel");
            _loggerView.BtnOpenComPortLog.Text = LanguageManager.GetString("LoggerFormBtnOpenComPortLog");
            _loggerView.BtnOpenPortParserLog.Text = LanguageManager.GetString("LoggerFormBtnOpenPortParserLog");
            _loggerView.BtnOpenRaceLog.Text = LanguageManager.GetString("LoggerFormBtnOpenRaceLog");
        }
    }
}
