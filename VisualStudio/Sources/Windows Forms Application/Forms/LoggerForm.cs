using System;
using System.Windows.Forms;
using Elreg.DomainModels.Logs;
using Elreg.DomainModels.RaceModel;
using Elreg.Log;
using Elreg.RaceOptionsService;
using Elreg.WindowsFormsPresenter;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class LoggerForm : WinFormsPresentationFramework.Forms.Form, ILoggerView
    {
        private readonly RaceModel _raceModel;
        private readonly DriversService _driversService;
        private readonly CarsService _carsService;
        private readonly LoggerPresenter _loggerPresenter;

        public LoggerForm(RaceModel raceModel, 
                          DriversService driversService, CarsService carsService)
        {
            _raceModel = raceModel;
            _driversService = driversService;
            _carsService = carsService;
            InitializeComponent();
            _loggerPresenter = new LoggerPresenter(this);
        }

        #region ILoggerView Members

        public bool RaceReplayLoggerChecked
        {
            get { return chkRaceReplayLoggingActivated.Checked; }
            set { chkRaceReplayLoggingActivated.Checked = value; }
        }

        public bool RaceLoggerChecked
        {
            get { return chkRaceLoggingActivated.Checked; }
            set { chkRaceLoggingActivated.Checked = value; }
        }

        public bool PortReaderLoggerChecked
        {
            get { return chkPortReaderLoggingActivated.Checked; }
            set { chkPortReaderLoggingActivated.Checked = value; }
        }

        public bool PortParserLoggerChecked
        {
            get { return chkPortParserLoggingActivated.Checked; }
            set { chkPortParserLoggingActivated.Checked = value; }
        }

        public Button BtnOk
        {
            get { return btnOK; }
        }

        public Button BtnCancel
        {
            get { return btnCancel; }
        }

        public Button BtnOpenRaceLog
        {
            get { return btnOpenRaceLog; }
        }

        public Button BtnOpenComPortLog
        {
            get { return btnOpenComPortLog; }
        }

        public Button BtnOpenPortParserLog
        {
            get { return btnOpenPortParserLog; }
        }

        #endregion

        private void BtnOkClick(object sender, EventArgs e)
        {
            try
            {
                _loggerPresenter.HandleOk();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            try
            {
                _loggerPresenter.HandleCancel();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void LoggerFormLoad(object sender, EventArgs e)
        {
            try
            {
                _loggerPresenter.ObtainActivationsOfLoggers();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnOpenComPortLogClick(object sender, EventArgs e)
        {
            try
            {
                _loggerPresenter.ShowComPortLog();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnOpenPortParserLogClick(object sender, EventArgs e)
        {
            try
            {
                _loggerPresenter.ShowPortParserLog();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnOpenRaceLogClick(object sender, EventArgs e)
        {
            try
            {
                _loggerPresenter.ShowRaceLog();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnOpenRaceDiagramClick(object sender, EventArgs e)
        {
            try
            {
                RaceDiagramForm raceDiagramForm = new RaceDiagramForm(LoggerModel.Inst.RaceLogFileName);
                raceDiagramForm.Show();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnOpenRaceReplayLogClick(object sender, EventArgs e)
        {
            try
            {
                _loggerPresenter.ShowRaceReplayLog();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnOpenRaceReplayFormClick(object sender, EventArgs e)
        {
            try
            {
                RaceReplayForm raceReplayForm = new RaceReplayForm(_raceModel, _driversService, _carsService);
                raceReplayForm.Show();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }

        }
    }
}