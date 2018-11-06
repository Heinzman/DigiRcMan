using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using Catel.IoC;
using Elreg.BusinessObjectContracts;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Races;
using Elreg.Log;
using Elreg.RaceDataService.RaceData;
using Timer = System.Timers.Timer;

namespace Elreg.DomainModels.RaceControl
{
    public class RaceControlModel : ISerialPortObserver
    {
        private readonly ISerialPortReader _vcuSerialPortReader;
        private readonly RaceModel.RaceModel _raceModel;
        private Race.StatusEnum _lastRaceStatus = Race.StatusEnum.Undefined;
        private string _serialPortData = string.Empty;
        private SerialPortReaderStatus _serialPortStatus = SerialPortReaderStatus.Stopped;
        private SerialPortStatusEventArgs _serialPortStatusEventArgs;
        private readonly Timer _serialPortDataEvalTimer = new Timer();
        private readonly Dictionary<LaneId, int> _positionsOfLastQuali = new Dictionary<LaneId, int>();

        private readonly IPropertySettings _propertySettings = (IPropertySettings)ServiceLocator.Default.ResolveType(typeof(IPropertySettings));

        public event EventHandler<RaceChangedEventArgs> Changed;
        public event EventHandler RaceFinished;
        public event EventHandler RaceStopped;
        public event EventHandler<SerialPortStatusEventArgs> SerialPortStatusReceived;

        public RaceControlModel(RaceModel.RaceModel raceModel, ISerialPortReader vcuSerialPortReader, 
                                RaceDataProvider raceDataProvider)
        {
            _raceModel = raceModel;
            _raceModel.RaceDataProvider = raceDataProvider;
            _vcuSerialPortReader = vcuSerialPortReader;
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
            get { return _raceModel.IsPauseByKeyboardOrArduinoPossible; }
        }

        public bool IsRestartByKeyboardPossible
        {
            get { return _raceModel.StatusHandler.IsRacePausedByKeyboardOrArduino; }
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

        #region ISerialPortObserver Members

        public void SerialPortDataReceived(object sender, string line, DateTime timeStamp)
        {
            try
            {
                _serialPortData = line;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void SerialPortStatusChanged(object sender, SerialPortReaderStatus status)
        {
            try
            {
                _serialPortStatus = status;
                HandleSerialPortStatus();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
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
            LoadPositions();
            StartRace(Race.TypeEnum.Race);
        }

        private void LoadPositions()
        {
            foreach (Lane lane in Lanes)
            {
                int position;
                if (_positionsOfLastQuali.TryGetValue(lane.Id, out position))
                    lane.Position = position;
            }
        }

        public void PauseRaceByKeyboard()
        {
            _raceModel.PauseRaceByKeyboard();
        }

        public void RestartRaceByKeyboard()
        {
            _raceModel.RestartRaceByKeyboardOrArduinoCheckCountDown();
        }

        public void StopRace()
        {
            _raceModel.StopRace();
        }

        public void StartAndAttachVcuSerialPortReader()
        {
            try
            {
                _vcuSerialPortReader.Start();
            }
            catch (IOException ex)
            {
                ErrorLog.LogError(false, ex);
                MessageBox.Show(ex.Message, @"Serial Port", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
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
            try
            {
                HandleSerialPortStatus();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SetRaceType(Race.TypeEnum raceType)
        {
            _raceModel.Race.Type = raceType;
        }

        private void AttachToEvents()
        {
            _vcuSerialPortReader.Attach(this);
            _raceModel.Changed += RaceModelChanged;
            _raceModel.RaceFinished += RaceModelRaceFinished;
            _raceModel.RaceStopped += RaceModelRaceStopped;
        }

        private void RaceModelRaceFinished(object sender, EventArgs e)
        {
            try
            {
                if (RaceFinished != null)
                    RaceFinished(this, null);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceModelRaceStopped(object sender, EventArgs e)
        {
            try
            {
                if (RaceStopped != null)
                    RaceStopped(this, null);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceModelChanged(object sender, EventArgs e)
        {
            try
            {
                CheckToRelayEvent();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void StartRace(Race.TypeEnum raceType)
        {
            _raceModel.Race.Type = raceType;
            _raceModel.StartRaceCheckCountDown();
            if (_propertySettings.AutoPauseAfterStart)
                _raceModel.PauseRaceBeforeStart();
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

        private void CheckToRelayEvent()
        {
            if (Changed != null)
            {
                var raceChangedEventArgs = new RaceChangedEventArgs();
                if ((_raceModel.Race.Status == Race.StatusEnum.PausedByKeyboard || 
                     _raceModel.Race.Status == Race.StatusEnum.PausedByArduino ||
                     _raceModel.Race.Status == Race.StatusEnum.PausedBeforeStart) &&
                    (_lastRaceStatus != Race.StatusEnum.PausedByKeyboard && 
                     _lastRaceStatus != Race.StatusEnum.PausedByArduino && 
                     _lastRaceStatus != Race.StatusEnum.PausedBeforeStart))
                {
                    raceChangedEventArgs.WasJustPaused = true;                  
                }
                else if ((_raceModel.Race.Status == Race.StatusEnum.RestartCountDown || 
                          _raceModel.Race.Status == Race.StatusEnum.Started ||
                          _raceModel.Race.Status == Race.StatusEnum.Restarted) &&
                         (_lastRaceStatus == Race.StatusEnum.PausedByKeyboard ||
                          _lastRaceStatus == Race.StatusEnum.PausedByArduino ||
                          _lastRaceStatus == Race.StatusEnum.PausedBeforeStart))
                {
                    raceChangedEventArgs.WasJustRestartedOrRestartCountDown = true;                
                }
                else if (_raceModel.Race.Status == Race.StatusEnum.Started && _lastRaceStatus != Race.StatusEnum.Started)
                {
                    raceChangedEventArgs.WasJustStarted = true;                    
                }

                if (_raceModel.Race.Status == Race.StatusEnum.StartCountDown && _lastRaceStatus != Race.StatusEnum.StartCountDown ||
                        _raceModel.Race.Status == Race.StatusEnum.RestartCountDown && _lastRaceStatus != Race.StatusEnum.RestartCountDown)
                {
                    raceChangedEventArgs.HasJustCountDownBegan = true;                    
                }
                if (_raceModel.Race.Status == Race.StatusEnum.Stopped && _lastRaceStatus != Race.StatusEnum.Stopped)
                {
                    raceChangedEventArgs.WasJustStopped = true;                    
                }
                Changed(this, raceChangedEventArgs);
            }
            _lastRaceStatus = _raceModel.Race.Status;
        }

        public void StopAllThreads()
        {
            try
            {
                _vcuSerialPortReader.Stop();
                _serialPortDataEvalTimer.Stop();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void CheckToSavePositions()
        {
            if (_raceModel.Race.Type == Race.TypeEnum.Qualification)
            {
                _positionsOfLastQuali.Clear();
                foreach (Lane lane in Lanes)
                    _positionsOfLastQuali.Add(lane.Id, lane.Position);
            }
        }
    }
}