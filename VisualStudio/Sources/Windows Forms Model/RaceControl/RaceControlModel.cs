using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using Heinzman.BusinessObjects;
using Heinzman.BusinessObjects.DerivedEventArgs;
using Heinzman.BusinessObjects.Interfaces;
using Heinzman.BusinessObjects.Lanes;
using Heinzman.BusinessObjects.Options;
using Heinzman.BusinessObjects.Races;
using Heinzman.Log;
using Heinzman.ParallelPortDataHandler;
using Heinzman.RaceDataService.RaceData;
using Heinzman.RaceRecovery;
using Timer = System.Timers.Timer;

namespace Heinzman.DomainModels.RaceControl
{
    public class RaceControlModel : ISerialPortObserver
    {
        private readonly DataParser _parallelPortParser;
        private readonly ISerialPortReader _portReader;
        private readonly RaceModel.RaceModel _raceModel;
        private readonly RaceRecovery _raceRecovery;
        private Race.StatusEnum _lastRaceStatus = Race.StatusEnum.Undefined;
        private ParallelPortPinValueEventArgs _parallelPortPinValueEventArgs;
        private string _serialPortData = string.Empty;
        private SerialPortReaderStatus _serialPortStatus = SerialPortReaderStatus.Stopped;
        private SerialPortStatusEventArgs _serialPortStatusEventArgs;
        private readonly Timer _serialPortDataEvalTimer = new Timer();

        public event EventHandler<RaceChangedEventArgs> Changed;
        public event EventHandler RaceFinished;
        public event EventHandler RaceStopped;
        public event EventHandler<SerialPortStatusEventArgs> SerialPortStatusReceived;
        public event EventHandler<ParallelPortPinValueEventArgs> ParallelPortPinValueChanged;

        public RaceControlModel(RaceModel.RaceModel raceModel, ISerialPortReader portReader, DataParser parallelPortParser,
                                RaceSettings raceSettings, RaceDataProvider raceDataProvider,
                                ApplicationSettingsService applicationSettingsService)
        {
            _raceModel = raceModel;
            _raceModel.RaceSettings = raceSettings;
            _raceModel.RaceDataProvider = raceDataProvider;
            _raceModel.ParallelPortParser = parallelPortParser;
            _portReader = portReader;
            _parallelPortParser = parallelPortParser;
            _raceRecovery = new RaceRecovery(applicationSettingsService, raceModel);
            InitSerialPortDataEvalTimer();
            AttachToEvents();
        }

        public bool IsInitPossible
        {
            get { return _raceModel.StatusHandler.IsRaceNotSetuped || _raceModel.StatusHandler.IsRaceReadyToStart; }
        }

        public bool IsStartTrainingPossible
        {
            get { return _raceModel.StatusHandler.IsRaceReadyToStart; }
        }

        public bool IsStartQualificationPossible
        {
            get { return _raceModel.StatusHandler.IsRaceReadyToStart; }
        }

        public bool IsStartRacePossible
        {
            get { return _raceModel.StatusHandler.IsRaceReadyToStart; }
        }

        public bool IsPauseByKeyboardPossible
        {
            get { return _raceModel.IsPauseByKeyboardPossible; }
        }

        public bool IsRestartByKeyboardPossible
        {
            get { return _raceModel.StatusHandler.IsRacePausedByKeyboard; }
        }

        public bool IsRaceWaitingForStart
        {
            get { return _raceModel.StatusHandler.IsRaceWaitingForStart; }
        }

        public bool IsStopPossible
        {
            get { return _raceModel.IsStopPossible; }
        }

        public bool IsChangeRacePossible
        {
            get { return _raceModel.StatusHandler.IsRaceStartedOrPaused; }
        }

        public bool ShouldRaceResultBeShown
        {
            get { return _raceModel.ShouldRaceResultBeShown; }
        }

        public List<Lane> Lanes
        {
            get { return _raceModel.Race.Lanes; }
        }

        public bool WasRaceCrashedInLastAppRun
        {
            get { return _raceRecovery.WasRaceCrashedInLastAppRun; }
        }

        #region ISerialPortObserver Members

        public void SerialPortDataReceived(object sender, string line, DateTime timeStamp)
        {
            _serialPortData = line;
        }

        public void SerialPortStatusChanged(object sender, SerialPortReaderStatus status)
        {
            _serialPortStatus = status;
            HandleSerialPortStatus();
        }

        #endregion

        public void InitRace(List<InitialLane> initialLanes)
        {
            _raceModel.InitialLanes = initialLanes;
            _raceModel.InitRace();
        }

        public void ChangeRaceData(IEnumerable<ChangedLane> changedLanes)
        {
            _raceModel.ChangeRaceData(changedLanes);
        }

        public void StartTraining()
        {
            StartRace(Race.TypeEnum.Training);
        }

        public void StartQualification()
        {
            StartRace(Race.TypeEnum.Qualification);
        }

        public void StartRace()
        {
            StartRace(Race.TypeEnum.Race);
        }

        public void PauseRaceByKeyboard()
        {
            _raceModel.PauseRaceByKeyboard();
        }

        public void RestartRaceByKeyboard()
        {
            _raceModel.RestartRaceByKeyboardCheckCountDown();
        }

        public void StopRace()
        {
            _raceModel.StopRace();
        }

        public void DetermineRaceStatus()
        {
            _raceModel.DetermineRaceStatus();
        }

        public void StartAndAttachPortReader()
        {
            try
            {
                _portReader.Start();
            }
            catch (IOException ex)
            {
                ErrorLog.LogError(false, ex);
                MessageBox.Show(ex.Message, @"Serial Port", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(true, ex);
            }
        }

        public void StopPortReader()
        {
            try
            {
                _portReader.Stop();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(true, ex);
            }
        }

        public void DetermineInitalParallelPortPinValue()
        {
            bool pinValue = _parallelPortParser.IsPinSwitchedOn;
            HandleParallelPortPinValueChanged(pinValue);
        }

        public void ClearFlagRaceInProgress()
        {
            _raceRecovery.ClearFlagRaceInProgress();
        }

        public void SaveFlagAppClosedNormally(bool isAppClosedNormally)
        {
            _raceRecovery.SaveFlagAppClosedNormally(isAppClosedNormally);
        }

        public void RestoreCrashedRace()
        {
            _raceRecovery.RestoreCrashedRace();
        }

        public void PrepareTraining()
        {
            SetRaceType(Race.TypeEnum.Training);
        }

        public void PrepareQualification()
        {
            SetRaceType(Race.TypeEnum.Qualification);
        }

        public void PrepareRace()
        {
            SetRaceType(Race.TypeEnum.Race);
        }

        public void SetupContest()
        {
            _raceModel.SetupContest();
        }

        private void InitSerialPortDataEvalTimer()
        {
            _serialPortDataEvalTimer.Interval = 1000;
            _serialPortDataEvalTimer.Elapsed += SerialPortDataEvalTimerElapsed;
            _serialPortDataEvalTimer.Start();
        }

        private void SerialPortDataEvalTimerElapsed(object sender, ElapsedEventArgs e)
        {
            HandleSerialPortStatus();
        }

        private void SetRaceType(Race.TypeEnum raceType)
        {
            _raceModel.Race.Type = raceType;
        }

        private void AttachToEvents()
        {
            _portReader.Attach(this);
            _parallelPortParser.PinValueChanged += ParallelPortParserPinValueChanged;
            _raceModel.Changed += RaceModelChanged;
            _raceModel.RaceFinished += RaceModelRaceFinished;
            _raceModel.RaceStopped += RaceModelRaceStopped;
        }

        private void RaceModelRaceFinished(object sender, EventArgs e)
        {
            if (RaceFinished != null)
                RaceFinished(this, null);
        }

        private void RaceModelRaceStopped(object sender, EventArgs e)
        {
            if (RaceStopped != null)
                RaceStopped(this, null);
        }

        private void RaceModelChanged(object sender, EventArgs e)
        {
            _raceRecovery.CheckToSetFlagIsRaceInProgress();
            CheckToRelayEvent();
        }

        private void StartRace(Race.TypeEnum raceType)
        {
            _raceModel.Race.Type = raceType;
            _raceModel.StartRaceCheckCountDown();
        }

        private void HandleSerialPortStatus()
        {
            CalcSerialPortStatus();
            RaiseEventSerialPortStatusReceived();
        }

        private void CalcSerialPortStatus()
        {
            SerialPortStatus status;

            if (_serialPortStatus == SerialPortReaderStatus.Connecting)
                status = SerialPortStatus.Connecting;
            else if (_serialPortStatus == SerialPortReaderStatus.Stopped)
                status = SerialPortStatus.Closed;
            else if (_serialPortStatus == SerialPortReaderStatus.Started)
            {
                if (string.IsNullOrEmpty(_serialPortData))
                    status = SerialPortStatus.OpenWithoutData;
                else
                    status = SerialPortStatus.OpenWithData;
            }
            else if (_serialPortStatus == SerialPortReaderStatus.Disabled)
                status = SerialPortStatus.Disabled;
            else
                status = SerialPortStatus.Undefined;
            _serialPortStatusEventArgs = new SerialPortStatusEventArgs(status);
        }

        private void RaiseEventSerialPortStatusReceived()
        {
            if (SerialPortStatusReceived != null && _serialPortStatusEventArgs != null)
                SerialPortStatusReceived(this, _serialPortStatusEventArgs);
        }

        private void ParallelPortParserPinValueChanged(object sender, bool pinValue)
        {
            HandleParallelPortPinValueChanged(pinValue);
        }

        private void HandleParallelPortPinValueChanged(bool pinValue)
        {
            _parallelPortPinValueEventArgs = new ParallelPortPinValueEventArgs(pinValue);
            RaiseEventParallelPortPinValueChanged();
        }

        private void RaiseEventParallelPortPinValueChanged()
        {
            if (ParallelPortPinValueChanged != null)
                ParallelPortPinValueChanged(this, _parallelPortPinValueEventArgs);
        }

        private void CheckToRelayEvent()
        {
            if (Changed != null)
            {
                var raceChangedEventArgs = new RaceChangedEventArgs();
                if (_raceModel.Race.Status == Race.StatusEnum.PausedByKeyboard && _lastRaceStatus != Race.StatusEnum.PausedByKeyboard)
                    raceChangedEventArgs.WasJustPausedByKeyboard = true;
                else if (_raceModel.Race.Status == Race.StatusEnum.PausedByParallelPort && _lastRaceStatus != Race.StatusEnum.PausedByParallelPort)
                    raceChangedEventArgs.WasJustPausedByParallelPort = true;
                else if (_raceModel.Race.Status == Race.StatusEnum.Breaked && _lastRaceStatus != Race.StatusEnum.Breaked)
                    raceChangedEventArgs.WasJustBreaked = true;
                else if ((_raceModel.Race.Status == Race.StatusEnum.RestartCountDown || _raceModel.Race.Status == Race.StatusEnum.Started) &&
                         (_lastRaceStatus == Race.StatusEnum.PausedByKeyboard || _lastRaceStatus == Race.StatusEnum.PausedByParallelPort)) 
                    raceChangedEventArgs.WasJustRestartedOrRestartCountDown = true;
                else if (_raceModel.Race.Status == Race.StatusEnum.WaitingForStartByParallelPort && _lastRaceStatus != Race.StatusEnum.WaitingForStartByParallelPort)
                    raceChangedEventArgs.WasJustSetWaitForStart = true;
                else if (_raceModel.Race.Status == Race.StatusEnum.Started && _lastRaceStatus != Race.StatusEnum.Started)
                    raceChangedEventArgs.WasJustStarted = true;

                if (_raceModel.Race.Status == Race.StatusEnum.StartCountDown && _lastRaceStatus != Race.StatusEnum.StartCountDown ||
                        _raceModel.Race.Status == Race.StatusEnum.RestartCountDown && _lastRaceStatus != Race.StatusEnum.RestartCountDown)
                    raceChangedEventArgs.HasJustCountDownBegan = true;

                if (_raceModel.Race.Status == Race.StatusEnum.Stopped && _lastRaceStatus != Race.StatusEnum.Stopped)
                    raceChangedEventArgs.WasJustStopped = true;

                Changed(this, raceChangedEventArgs);
            }
            _lastRaceStatus = _raceModel.Race.Status;
        }

    }
}