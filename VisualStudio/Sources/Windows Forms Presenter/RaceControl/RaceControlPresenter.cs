using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.DomainModels.RaceControl;
using Elreg.DomainModels.RaceModel;
using Elreg.Log;
using Elreg.RaceControlService;
using Elreg.RaceDataService.RaceData;
using Elreg.ResourcesService;
using Elreg.WindowsFormsView;
using Elreg.WinFormsPresentationFramework;
using Elreg.WinFormsPresentationFramework.Resources;

namespace Elreg.WindowsFormsPresenter.RaceControl
{
    public class RaceControlPresenter
    {
        private readonly ISimpleView _championshipListForm;
        private readonly ISimpleView _countDownForm;
        private readonly IPauseView _pauseForm;
        private readonly PauseHandler _pauseHandler;
        private readonly RaceControlModel _raceControlModel;
        private readonly IRaceControlView _raceControlView;
        private readonly IRaceGridView _raceGridForm;
        private readonly ISimpleView _raceResultsListForm;
        private readonly RaceFinishedHandler _raceFinishedHandler;
        private string MessageCloseApp { get; set; }
        private string MessageCancelRace { get; set; }

        private delegate void VoidDelegate();

        public RaceControlPresenter(RaceModel raceModel, ISerialPortReader vcuSerialPortReader, IRaceControlView raceControlView, 
                                    RaceDataProvider raceDataProvider, 
                                    RaceKeyController raceKeyController, 
                                    IPauseView pauseForm, IRaceGridView raceGridForm, ISimpleView countDownForm, 
                                    IChampionshipView championshipForm, ISimpleView raceResultsListForm, 
                                    ISimpleView championshipListForm)
        {
            try
            {
                _raceControlView = raceControlView;
                _raceControlModel = new RaceControlModel(raceModel, vcuSerialPortReader, raceDataProvider);
                _raceControlModel.Changed += RaceControlModelChanged;
                _raceControlModel.RaceFinished += RaceControlModelRaceStoppedOrFinished;
                _raceControlModel.RaceStopped += RaceControlModelRaceStoppedOrFinished;
                _raceControlModel.SerialPortStatusReceived += RaceControlModelSerialPortStatusReceived;
                _pauseForm = pauseForm;
                _raceGridForm = raceGridForm;
                _countDownForm = countDownForm;
                _championshipListForm = championshipListForm;
                _raceResultsListForm = raceResultsListForm;
                _pauseHandler = new PauseHandler(_raceControlView, raceKeyController);
                _raceFinishedHandler = new RaceFinishedHandler(_raceControlView, _raceGridForm, championshipForm, _raceControlModel, _pauseForm, raceModel);
                CalcEnabledStateOfButtons();
                LanguageManager.LanguageChanged += LanguageManagerLanguageChanged;
                AdjustCultureStrings();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public List<Lane> Lanes
        {
            get { return _raceControlModel.Lanes; }
        }

        public void InitRace(IInitLanesView initLanesView)
        {
            try
            {
                if (_raceControlModel.IsInitPossible)
                {
                    initLanesView.ShowDialog();
                    if (initLanesView.Ok)
                        _raceControlModel.InitRace(initLanesView.InitialLanes);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void StartTraining()
        {
            try
            {
                bool isStartPossible = _raceControlModel.IsStartTrainingPossible;
                VoidDelegate startContest = _raceControlModel.StartTraining;
                VoidDelegate prepareContest = _raceControlModel.PrepareTraining;

                StartContest(isStartPossible, startContest, prepareContest);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void StartQualification()
        {
            try
            {
                bool isStartPossible = _raceControlModel.IsStartQualificationPossible;
                VoidDelegate startContest = _raceControlModel.StartQualification;
                VoidDelegate prepareContest = _raceControlModel.PrepareQualification;

                StartContest(isStartPossible, startContest, prepareContest);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void StartRace()
        {
            try
            {
                bool isStartPossible = _raceControlModel.IsStartRacePossible;
                VoidDelegate startContest = _raceControlModel.StartRace;
                VoidDelegate prepareContest = _raceControlModel.PrepareRace;

                StartContest(isStartPossible, startContest, prepareContest);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void PauseOrRestartRaceByKeyboard()
        {
            try
            {
                if (_raceControlModel.IsPauseByKeyboardPossible)
                    _raceControlModel.PauseRaceByKeyboard();
                else if (_raceControlModel.IsRestartByKeyboardPossible)
                    _raceControlModel.RestartRaceByKeyboard();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void StopRace()
        {
            try
            {
                if (_raceControlModel.IsStopPossible)
                {
                    LargeMessageBoxHandler largeMessageBoxHandler = new LargeMessageBoxHandler(_raceControlView);
                    DialogResult dialogResult = largeMessageBoxHandler.ShowDialog(MessageCancelRace);
                    if (dialogResult == DialogResult.Yes)
                        _raceControlModel.StopRace();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void ShowRaceView()
        {
            try
            {
                FormHelper.ShowAndFocus(_raceGridForm);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }


        public void ShowRaceResults()
        {
            try
            {
                FormHelper.ShowAndFocus(_raceResultsListForm);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void ShowChampionships()
        {
            try
            {
                FormHelper.ShowAndFocus(_championshipListForm);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void ChangeRaceData(IUpdateLanesView updateLanesView)
        {
            try
            {
                if (_raceControlModel.IsChangeRacePossible)
                {
                    updateLanesView.ShowDialog();
                    if (updateLanesView.Ok)
                        _raceControlModel.ChangeRaceData(updateLanesView.ChangedLanes);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void StartAndAttachVcuSerialPortReader()
        {
            try
            {
                _raceControlModel.StartAndAttachVcuSerialPortReader();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void HandleFormClosed(FormClosedEventArgs e)
        {
            try
            {
                _raceControlModel.StopAllThreads();
                Application.Exit();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void HandleFormClosing(FormClosingEventArgs e)
        {
            try
            {
                string message = MessageCloseApp.Replace(LanguageManager.ReplaceString1, "DigiRCMan");
                LargeMessageBoxHandler largeMessageBoxHandler = new LargeMessageBoxHandler(_raceControlView);
                DialogResult dialogResult = largeMessageBoxHandler.ShowDialog(message);
                if (dialogResult == DialogResult.No)
                    e.Cancel = true;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AdjustCultureStrings()
        {
            MessageCloseApp = LanguageManager.GetString("RaceControlMessageCloseApp");
            MessageCancelRace = LanguageManager.GetString("RaceControlMessageCancelRace");
            _raceControlView.Text = LanguageManager.GetString("RaceControlCaption");
            _raceControlView.BtnInit.Text = LanguageManager.GetString("RaceControlBtnInit");
            _raceControlView.BtnStartTraining.Text = LanguageManager.GetString("RaceControlBtnStartTraining");
            _raceControlView.BtnStartQualification.Text = LanguageManager.GetString("RaceControlBtnStartQuali");
            _raceControlView.BtnStartRace.Text = LanguageManager.GetString("RaceControlBtnStartRace");
            _raceControlView.BtnPauseOrRestart.Text = LanguageManager.GetString("RaceControlBtnPause");
            _raceControlView.BtnStop.Text = LanguageManager.GetString("RaceControlBtnStop");
            _raceControlView.BtnShowRaceView.Text = LanguageManager.GetString("RaceControlBtnShowRaceView");
            _raceControlView.BtnChangeRace.Text = LanguageManager.GetString("RaceControlBtnChangeRace");
            _raceControlView.BtnShowRaceResults.Text = LanguageManager.GetString("RaceControlBtnShowRaceResults");
            _raceControlView.BtnShowChampionships.Text = LanguageManager.GetString("RaceControlBtnShowChampionships");
            _raceControlView.BtnRaceSettings.Text = LanguageManager.GetString("RaceControlBtnRaceSettings");
            _raceControlView.BtnSoundMixer.Text = LanguageManager.GetString("RaceControlBtnSoundMixer");
            _raceControlView.BtnDriversOptions.Text = LanguageManager.GetString("RaceControlBtnDriversOptions");
            _raceControlView.BtnCarsOptions.Text = LanguageManager.GetString("RaceControlBtnCarsOptions");
            _raceControlView.BtnSoundOptions.Text = LanguageManager.GetString("RaceControlBtnSoundOptions");
            _raceControlView.BtnConfigureArduino.Text = LanguageManager.GetString("RaceControlBtnConfigureArduino");
            _raceControlView.BtnLogging.Text = LanguageManager.GetString("RaceControlBtnLogging");
            _raceControlView.GrpRaceControl.Text = LanguageManager.GetString("RaceControlGrpRaceControl");
            _raceControlView.GrpRace.Text = LanguageManager.GetString("RaceControlGrpRace");
            _raceControlView.GrpResults.Text = LanguageManager.GetString("RaceControlGrpResults");
            _raceControlView.GrpOptions.Text = LanguageManager.GetString("RaceControlGrpOptions");
            _raceControlView.GrpSerialPort.Text = LanguageManager.GetString("RaceControlGrpSerialPort");
            UpdateButtonsWithShortCuts();
        }

        public bool IsPauseOrRestartPossible
        {
            get { return _raceControlModel.IsPauseByKeyboardPossible || _raceControlModel.IsRestartByKeyboardPossible; }
        }

        public bool IsInitPossible
        {
            get { return _raceControlModel.IsInitPossible; }
        }

        public bool IsStartTrainingPossible
        {
            get { return _raceControlModel.IsStartTrainingPossible; }
        }

        public bool IsStartQualificationPossible
        {
            get { return _raceControlModel.IsStartQualificationPossible; }
        }

        public bool IsStartRacePossible
        {
            get { return _raceControlModel.IsStartRacePossible; }
        }

        public bool IsStopPossible
        {
            get { return _raceControlModel.IsStopPossible; }
        }

        public bool IsChangeRacePossible
        {
            get { return _raceControlModel.IsChangeRacePossible; }
        }

        private void StartContest(bool isStartPossible, VoidDelegate startContest, VoidDelegate prepareContest)
        {
            prepareContest();
            SetupContest();

            if (isStartPossible)
            {
                ShowRaceView();
                startContest();
            }
        }

        private void SetupContest()
        {
            ShowRaceView();
            _raceControlModel.SetupContest();
        }

        private void RaceControlModelChanged(object sender, RaceChangedEventArgs e)
        {
            try
            {
                if (e.WasJustPaused)
                    HandlePauseRace();
                if (e.WasJustRestartedOrRestartCountDown)
                    HandleRestartRace();
                if (e.WasJustSetWaitForStart)
                    HandleWaitForStart();
                if (e.HasJustCountDownBegan)
                    HandleCountDown();
                if (e.WasJustStarted)
                    HandleStartRace();
                CalcEnabledStateOfButtons();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void UpdateButtonsWithShortCuts()
        {
            _pauseHandler.UpdateControlsWithShortCuts();
        }

        private void RaceControlModelRaceStoppedOrFinished(object sender, EventArgs e)
        {
            try
            {
                _raceFinishedHandler.DoWork();
                CalcEnabledStateOfButtons();
                _raceControlModel.CheckToSavePositions();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void HandleStartRace()
        {
            ShowRaceView();
            FormHelper.HideForm(_pauseForm);
            _pauseHandler.IsBtnPauseActivated = true;
        }

        private void CalcEnabledStateOfButtons()
        {
            _raceControlView.SetControlPropertyThreadSafe(_raceControlView.BtnInit, "Enabled", IsInitPossible);
            _raceControlView.SetControlPropertyThreadSafe(_raceControlView.BtnStartTraining, "Enabled", IsStartTrainingPossible);
            _raceControlView.SetControlPropertyThreadSafe(_raceControlView.BtnStartQualification, "Enabled", IsStartQualificationPossible);
            _raceControlView.SetControlPropertyThreadSafe(_raceControlView.BtnStartRace, "Enabled", IsStartRacePossible);
            _raceControlView.SetControlPropertyThreadSafe(_raceControlView.BtnPauseOrRestart, "Enabled", IsPauseOrRestartPossible);
            _raceControlView.SetControlPropertyThreadSafe(_raceControlView.BtnStop, "Enabled", IsStopPossible);
            _raceControlView.SetControlPropertyThreadSafe(_raceControlView.BtnChangeRace, "Enabled", IsChangeRacePossible);
        }

        private void HandlePauseRace()
        {
            _pauseHandler.IsBtnPauseActivated = false;
            FormHelper.ShowAndFocus(_pauseForm);
        }

        private void HandleRestartRace()
        {
            ShowRaceView();
            _pauseHandler.IsBtnPauseActivated = true;
            FormHelper.HideForm(_pauseForm);
        }

        private void HandleWaitForStart()
        {
            FormHelper.ShowAndFocus(_pauseForm);
        }

        private void HandleCountDown()
        {
            ShowRaceView();
            FormHelper.HideForm(_pauseForm);
            FormHelper.ShowNotModalDialog(_countDownForm);
        }

        private void RaceControlModelSerialPortStatusReceived(object sender, SerialPortStatusEventArgs e)
        {
            try
            {
                string status = string.Empty;
                Image image = Resources.glossymetal_red;

                if (e.Status == SerialPortStatus.Connecting)
                    status = "Com verbinden...";
                else if (e.Status == SerialPortStatus.Closed)
                    status = "Com closed";
                else if (e.Status == SerialPortStatus.OpenWithoutData)
                    status = "Com offen, keine Daten";
                else if (e.Status == SerialPortStatus.OpenWithData)
                {
                    status = "Com OK";
                    image = Resources.glossymetal_green;
                }
                else if (e.Status == SerialPortStatus.Disabled)
                {
                    status = "Com Pause";
                    image = Resources.glossymetal;
                }
                _raceControlView.SetControlPropertyThreadSafe(_raceControlView.LblComPortStatus, "Image", image);
                _raceControlView.SetControlPropertyThreadSafe(_raceControlView.LblComPortStatus, "Text", status);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void LanguageManagerLanguageChanged(object sender, EventArgs e)
        {
            try
            {
                AdjustCultureStrings();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }
    }
}