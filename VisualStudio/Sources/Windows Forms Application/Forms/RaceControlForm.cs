using System;
using System.Windows.Forms;
using Elreg.BusinessObjects.Interfaces;
using Elreg.DomainModels.RaceModel;
using Elreg.Log;
using Elreg.RaceControlService;
using Elreg.RaceDataService.RaceData;
using Elreg.RaceOptionsService;
using Elreg.RaceSoundService;
using Elreg.RaceStatisticsService;
using Elreg.WindowsFormsPresenter.RaceControl;
using Elreg.WindowsFormsView;
using Form = Elreg.WinFormsPresentationFramework.Forms.Form;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class RaceControlForm : Form, IRaceControlView
    {
        private readonly CarsService _carsService;
        private readonly DriversService _driversService;
        private readonly RaceDataProvider _raceDataProvider;
        private readonly RaceKeyController _raceKeyController;
        private readonly RaceSettingsService _raceSettingsService;
        private readonly ISerialPortParser _serialPortParser;
        private readonly RaceModel _raceModel;
        private readonly SoundMixerService _soundMixerService;
        private readonly SoundOptionsService _soundOptionsService;
        private readonly ActionSoundsService _actionSoundsService;
        private readonly StatisticLogger _statisticLogger;
        private readonly VcuSerialPortService _vcuSerialPortService;
        private readonly ISerialPortReader _vcuSerialPortReader;
        private ChampionshipForm _championshipForm;
        private ChampionshipListForm _championshipListForm;
        private CountDownForm _countDownForm;
        private PauseForm _pauseForm;
        private RaceControlPresenter _raceControlPresenter;
        private IRaceGridView _raceGridForm;
        private RaceResultsListForm _raceResultsListForm;
        private RaceSettingsForm _raceSettingsForm;
        private UpdateLanesForm _updateLanesForm;

        public RaceControlForm(RaceModel raceModel, 
                               ISerialPortParser serialPortParser,
                               RaceDataProvider raceDataProvider,                              
                               DriversService driversService, 
                               CarsService carsService,
                               SoundOptionsService soundOptionsService,
                               RaceSettingsService raceSettingsService, 
                               RaceKeyController raceKeyController,
                               SoundMixerService soundMixerService,
                               ActionSoundsService actionSoundsService,
                               StatisticLogger statisticLogger,
                               VcuSerialPortService vcuSerialPortService, 
                               ISerialPortReader vcuSerialPortReader)
        {
            InitializeComponent();

            _raceModel = raceModel;
            _serialPortParser = serialPortParser;
            _raceDataProvider = raceDataProvider;
            _driversService = driversService;
            _carsService = carsService;
            _soundOptionsService = soundOptionsService;
            _raceSettingsService = raceSettingsService;
            _raceKeyController = raceKeyController;
            _soundMixerService = soundMixerService;
            _actionSoundsService = actionSoundsService;
            _statisticLogger = statisticLogger;
            _vcuSerialPortService = vcuSerialPortService;
            _vcuSerialPortReader = vcuSerialPortReader;

            PreLoadForms();
            InitPresenter();
            AttachKeyControllerEvents();
            _raceControlPresenter.StartAndAttachVcuSerialPortReader();
            IsHiddenWhenClosed = false;
        }

        #region IRaceControlView Members

        public Control BtnInit
        {
            get { return btnInit; }
        }

        public Control BtnStartTraining
        {
            get { return btnStartTraining; }
        }

        public Control BtnStartQualification
        {
            get { return btnStartQualification; }
        }

        public Control BtnStartRace
        {
            get { return btnStartRace; }
        }

        public Control BtnPauseOrRestart
        {
            get { return btnPauseOrRestart; }
        }

        public Control BtnStop
        {
            get { return btnStop; }
        }

        public Control BtnChangeRace
        {
            get { return btnChangeRace; }
        }

        public Control BtnShowRaceView
        {
            get { return btnShowRaceView; }
        }

        public Control BtnRaceSettings
        {
            get { return btnRaceSettings; }
        }

        public Control BtnDriversOptions
        {
            get { return btnDriversOptions; }
        }

        public Control BtnCarsOptions
        {
            get { return btnCarsOptions; }
        }

        public Control BtnSoundOptions
        {
            get { return btnSoundOptions; }
        }

        public Control BtnShowRaceResults
        {
            get { return btnShowRaceResults; }
        }

        public Control BtnShowChampionships
        {
            get { return btnShowChampionships; }
        }

        public Control BtnConfigureArduino
        {
            get { return _btnConfigureArduino; }
        }

        public Control BtnLogging
        {
            get { return btnLogging; }
        }

        public Label LblComPortStatus
        {
            get { return lblComPortStatus; }
        }

        public void SetEnabled(Control button, bool enabled)
        {
            button.Enabled = enabled;
        }

        public Control BtnSoundMixer
        {
            get { return btnSoundMixer; }
        }

        public GroupBox GrpRaceControl
        {
            get { return grpRaceControl; }
        }

        public GroupBox GrpRace
        {
            get { return grpRace; }
        }

        public GroupBox GrpResults
        {
            get { return grpResults; }
        }

        public GroupBox GrpOptions
        {
            get { return grpOptions; }
        }

        public GroupBox GrpSerialPort
        {
            get { return grpSerialPort; }
        }

        public Control Form
        {
            get { return this; }
        }

        public IRaceResultsView CreateRaceResultsForm()
        {
            return new RaceResultsForm(_raceKeyController, _raceModel.RaceResultsModel);
        }

        #endregion

        private void PreLoadForms()
        {
            _pauseForm = new PauseForm(_raceKeyController, _raceSettingsService.RaceSettings);
            _pauseForm.ShowAndHide();
            _raceGridForm = new RaceGridWithPositionForm(_raceKeyController, _raceModel, this);
            _countDownForm = new CountDownForm(_raceKeyController, _raceModel);
            _countDownForm.ShowAndHide();
            _championshipForm = new ChampionshipForm(_raceKeyController);
            _raceResultsListForm = new RaceResultsListForm(this);
            _championshipListForm = new ChampionshipListForm(_championshipForm);
            _raceSettingsForm = new RaceSettingsForm(_raceSettingsService);
        }

        private void InitPresenter()
        {
            _raceControlPresenter = new RaceControlPresenter(_raceModel, _vcuSerialPortReader, this, 
                                                             _raceDataProvider,
                                                             _raceKeyController, _pauseForm, _raceGridForm,
                                                             _countDownForm, _championshipForm,
                                                             _raceResultsListForm, _championshipListForm);
        }

        private void BtnInitClick(object sender, EventArgs e)
        {
            try
            {
                if (_raceControlPresenter.IsInitPossible)
                {
                var initLanesForm = new InitLanesForm(_driversService, _carsService);
                _raceControlPresenter.InitRace(initLanesForm);
            }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnStartTrainingClick(object sender, EventArgs e)
        {
            try
            {
                _raceControlPresenter.StartTraining();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnStartQualificationClick(object sender, EventArgs e)
        {
            try
            {
                _raceControlPresenter.StartQualification();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnStartRaceClick(object sender, EventArgs e)
        {
            try
            {
                _raceControlPresenter.StartRace();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnPauseOrRestartClick(object sender, EventArgs e)
        {
            try
            {
                if (_raceControlPresenter.IsPauseOrRestartPossible)
                _raceControlPresenter.PauseOrRestartRaceByKeyboard();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnStopClick(object sender, EventArgs e)
        {
            try
            {
                if (_raceControlPresenter.IsStopPossible)
                    _raceControlPresenter.StopRace();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnRaceSettingsClick(object sender, EventArgs e)
        {
            try
            {
                ShowRaceSettings();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ShowRaceSettings()
        {
            FormHelper.ShowModalDialog(_raceSettingsForm);
        }

        private void BtnDriversOptionsClick(object sender, EventArgs e)
        {
            try
            {
                var view = new MaintainDriversForm(_driversService, _actionSoundsService, _raceModel.RaceSettings);
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnCarsOptionsClick(object sender, EventArgs e)
        {
            try
            {
                var view = new MaintainCarsForm(_carsService);
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnSoundOptionsClick(object sender, EventArgs e)
        {
            try
            {
                var view = new MaintainSoundsForm(_soundOptionsService, _actionSoundsService, _driversService, _raceModel.RaceSettings);
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnConfigureArduinoClick(object sender, EventArgs e)
        {
            try
            {
                VcuSettingsForm settingsForm = new VcuSettingsForm(_vcuSerialPortReader, _vcuSerialPortService, _serialPortParser);
                settingsForm.Show();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnShowRaceViewClick(object sender, EventArgs e)
        {
            try
            {
                _raceControlPresenter.ShowRaceView();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnChangeRaceClick(object sender, EventArgs e)
        {
            try
            {
                if (_raceControlPresenter.IsChangeRacePossible)
                {
                    _updateLanesForm = new UpdateLanesForm(_raceControlPresenter.Lanes, _driversService, _carsService);
                    _raceControlPresenter.ChangeRaceData(_updateLanesForm);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnLoggingClick(object sender, EventArgs e)
        {
            try
            {
                var view = new LoggerForm(_raceModel, _driversService, _carsService);
                view.Show();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnSoundMixerClick(object sender, EventArgs e)
        {
            try
            {
                var view = new SoundMixerForm(_soundMixerService);
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceControlFormKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                _raceKeyController.HandleKey(e);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AttachKeyControllerEvents()
        {
            _raceKeyController.ShowInitRaceForm += BtnInitClick;
            _raceKeyController.ShowChangeRaceForm += BtnChangeRaceClick;
            _raceKeyController.ShowRaceGridForm += BtnShowRaceViewClick;
            _raceKeyController.ShowRaceSettingsForm += BtnRaceSettingsClick;
            _raceKeyController.ShowDriverOptionsForm += BtnDriversOptionsClick;
            _raceKeyController.ShowCarOptionsForm += BtnCarsOptionsClick;
            _raceKeyController.ShowSoundOptionsForm += BtnSoundOptionsClick;
            _raceKeyController.ShowMixerForm += BtnSoundMixerClick;
            _raceKeyController.StopRace += BtnStopClick;
            _raceKeyController.StartRace += BtnStartRaceClick;
            _raceKeyController.StartTraining += BtnStartTrainingClick;
            _raceKeyController.StartQualification += BtnStartQualificationClick;
            _raceKeyController.ShowRaceControlForm += RaceKeyControllerShowRaceControlForm;
        }

        private void RaceKeyControllerShowRaceControlForm(object sender, EventArgs e)
        {
            try
            {
                Focus();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceControlFormLoad(object sender, EventArgs e)
        {
            try
            {
                OnFormLoaded();
                ShowRaceSettings();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnShowRaceResultsClick(object sender, EventArgs e)
        {
            try
            {
                _raceControlPresenter.ShowRaceResults();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnShowChampionshipsClick(object sender, EventArgs e)
        {
            try
            {
                _raceControlPresenter.ShowChampionships();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceControlFormFormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _raceControlPresenter.HandleFormClosed(e);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceControlFormFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _raceControlPresenter.HandleFormClosing(e);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnStatisticsClick(object sender, EventArgs e)
        {
            try
            {
                StatisticsForm statisticsForm = new StatisticsForm(_statisticLogger, _raceSettingsService.RaceSettings);
                statisticsForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }
    }
}