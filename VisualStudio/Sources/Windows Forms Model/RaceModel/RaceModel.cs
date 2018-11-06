using System;
using System.Collections.Generic;
using Heinzman.BusinessObjects;
using Heinzman.BusinessObjects.DerivedEventArgs;
using Heinzman.BusinessObjects.Interfaces;
using Heinzman.BusinessObjects.Lanes;
using Heinzman.BusinessObjects.Options;
using Heinzman.BusinessObjects.Races;
using Heinzman.DomainModels.RaceModel.LaneModel;
using Heinzman.Exceptions;
using Heinzman.Log;
using Heinzman.ParallelPortDataHandler;
using Heinzman.RaceOptionsService;

namespace Heinzman.DomainModels.RaceModel
{
    public class RaceModel : IRaceModel
    {
        private IRaceDataProvider _raceDataProvider;
        private DataParser _parallelPortParser;
        private readonly CountDownModel _countDownModel = new CountDownModel();
        private List<InitialLane> _initialLanes;
        private readonly FuelConsumptionService _fuelConsumptionService;
        private IRaceDataHandler _raceHandler = new RaceDataHandlerDummy();
        private readonly StatusHandler _statusHandler = new StatusHandler();

        public event EventHandler Changed;
        public event EventHandler RaceStatusChanged;
        public event EventHandler RaceInitialized;
        public event EventHandler RaceRestarted;
        public event EventHandler RacePaused;
        public event EventHandler RaceFinished;
        public event EventHandler RaceStarted;
        public event EventHandler RaceStopped;

        public RaceModel() 
        {
            _fuelConsumptionService = new FuelConsumptionService();
            Lane.PenaltyTimerElapsed += LanePenaltyTimerElapsed;
            Lane.RefuelTimerElapsed += LaneRefuelTimerElapsed;
            _countDownModel.CountDownChanged += CountDownModelCountDownChanged;
        }

        public IStatusHandler StatusHandler
        {
            get { return _statusHandler; }
        }

        public IRaceDataHandler RaceHandler
        {
            get { return _raceHandler; }
        }

        public ICountDownModel CountDownModel
        {
            get { return _countDownModel; }
        }

        public RaceSettings RaceSettings { get; set; }

        public IRaceDataProvider RaceDataProvider
        {
            set 
            { 
                _raceDataProvider = value;
                AttachRaceDataProviderEvents();
            }
        }

        public DataParser ParallelPortParser
        {
            set 
            {
                _parallelPortParser = value;
                AttachParallelPortParserEvents();
            }
        }

        public List<InitialLane> InitialLanes
        {
            set { _initialLanes = value; }
        }

        public Race Race { get; private set; }

        public void RestoreRace(Race race, List<InitialLane> initialLanes)
        {
            _initialLanes = initialLanes;
            Race = race;
            _statusHandler.Race = Race;
            _raceHandler = new RaceDataHandler(Race, SerialPortReader);
            AttachRaceHandlerEvents();
            RaiseEventsForRaceInit();
        }

        public void InitRace()
        {
            try
            {
                if (StatusHandler.IsRaceNotSetuped || StatusHandler.IsRaceInitialized || StatusHandler.IsRaceStoppedOrFinished)
                {
                    Race = new Race(RaceSettings);
                    _statusHandler.Race = Race;
                    _raceHandler = new RaceDataHandler(Race, SerialPortReader, _initialLanes);
                    AttachRaceHandlerEvents();
                    RaiseEventsForRaceInit();
                }
                else
                    throw new LcException("Race Status does not allow init race.");
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AttachRaceHandlerEvents()
        {
            _raceHandler.RaceChanged += RaceHandlerRaceChanged;
            _raceHandler.RaceFinished += RaceHandlerRaceFinished;
            _raceHandler.RaceStarted += RaceHandlerRaceStarted;
            _raceHandler.RaceStopped += RaceHandlerRaceStopped;
        }

        public void ChangeRaceData(IEnumerable<ChangedLane> changedLanes)
        {
            try
            {
                if (StatusHandler.IsRaceStartedOrPaused)
                {
                    UpdateRaceWith(changedLanes);
                    RaiseEventsRaceChanged();
                }
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
                if (IsStopPossible)
                {
                    if (StatusHandler.IsRaceInCountDown)
                        _countDownModel.StopCountDown();
                    RaceHandler.Stop();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void StartRaceCheckCountDown()
        {
            try
            {
                if (StatusHandler.IsRaceReadyToStart || StatusHandler.IsRaceWaitingForStart)
                {
                    if (Race.IsStartCountDownActivated)
                        BeginCountDownOfStart();
                    else
                        StartRaceWithoutCountDown();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void RestartRaceByKeyboardCheckCountDown()
        {
            try
            {
                if (StatusHandler.IsRacePaused)
                {
                    if (Race.IsRestartCountDownActivated)
                        BeginCountDownOfRestart();
                    else
                        RestartRace();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void PauseRaceByKeyboard()
        {
            PauseRaceByKeyboardForced(false);
        }

        private void PauseRaceByKeyboardForced(bool force)
        {
            try
            {
                if (IsPauseByKeyboardPossible || force)
                {
                    if (StatusHandler.IsRaceInRestartCountDown)
                        _countDownModel.StopCountDown();
                    RaceHandler.PauseByKeyboard();
                    RaiseEventRacePaused();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void PauseRaceByParallelPort()
        {
            try
            {
                if (IsPauseByParallelPortPossible)
                {
                    if (StatusHandler.IsRaceInRestartCountDown)
                        _countDownModel.StopCountDown();
                    RaceHandler.PauseByParallelPort();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void AddLapManuallyFor(LaneId laneId)
        {
            try
            {
                if (IsLaneInRace(laneId))
                {
                    RaceLaneModel raceLaneModel = new RaceLaneModel(this, _fuelConsumptionService, laneId, RaceSettings);
                    raceLaneModel.AddLapManually();
                    CheckRaceFinished();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void RemoveLapFor(LaneId laneId)
        {
            try
            {
                if (IsLaneInRace(laneId))
                {
                    RaceLaneModel raceLaneModel = new RaceLaneModel(this, _fuelConsumptionService, laneId, RaceSettings);
                    raceLaneModel.RemoveLap();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void AddPenaltyFor(LaneId laneId)
        {
            try
            {
                if (IsLaneInRace(laneId))
                {
                    RaceLaneModel raceLaneModel = new RaceLaneModel(this, _fuelConsumptionService, laneId, RaceSettings);
                    raceLaneModel.AddPenalty();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void UndoPenaltyFor(LaneId laneId)
        {
            try
            {
                if (IsLaneInRace(laneId))
                {
                    RaceLaneModel raceLaneModel = new RaceLaneModel(this, _fuelConsumptionService, laneId, RaceSettings);
                    raceLaneModel.UndoPenaltyFor();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void HandlePitInFor(LaneId laneId)
        {
            try
            {
                if (IsLaneInRace(laneId))
                {
                    RaceLaneModel raceLaneModel = new RaceLaneModel(this, _fuelConsumptionService, laneId, RaceSettings);
                    raceLaneModel.HandlePitIn();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void HandlePitOutFor(LaneId laneId)
        {
            try
            {
                if (IsLaneInRace(laneId))
                {
                    RaceLaneModel raceLaneModel = new RaceLaneModel(this, _fuelConsumptionService, laneId, RaceSettings);
                    raceLaneModel.HandlePitOut();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void AddFuelInLitresFor(LaneId laneId, float litres)
        {
            try
            {
                if (IsLaneInRace(laneId))
                {
                    RaceLaneModel raceLaneModel = new RaceLaneModel(this, _fuelConsumptionService, laneId, RaceSettings);
                    raceLaneModel.AddFuel(litres);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void RemoveFuelInLitresFor(LaneId laneId, float litres)
        {
            try
            {
                if (IsLaneInRace(laneId))
                {
                    RaceLaneModel raceLaneModel = new RaceLaneModel(this, _fuelConsumptionService, laneId, RaceSettings);
                    raceLaneModel.RemoveFuel(litres);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void HandleFuelConsumptionFor(LaneId laneId, uint speed)
        {
            try
            {
                if (IsLaneInRace(laneId))
                {
                    CheckFalseStart(laneId, speed);
                    RaceLaneModel raceLaneModel = new RaceLaneModel(this, _fuelConsumptionService, laneId, RaceSettings);
                    raceLaneModel.HandleFuelConsumption(speed);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void Attach(IRaceObserver raceObserver)
        {
            try
            {
                Changed += raceObserver.RaceChanged;
                RaceStatusChanged += raceObserver.RaceStatusChanged;
                RaceLaneModel.LapAdded += raceObserver.LapAdded;
                RaceLaneModel.LapNotAddedDuePenaltyOrNoFuel += raceObserver.LapNotAddedDuePenaltyOrNoFuel;
                RaceLaneModel.LapNotAddedDueMinSeconds += raceObserver.LapNotAddedDueMinSeconds;
                RaceLaneModel.AutoDetectedLapAdded += raceObserver.AutoDetectedLapAdded;
                RaceLaneModel.LaneChanged += raceObserver.LaneChanged;
                RaceLaneModel.Disqualified += raceObserver.Disqualified;
                RaceLaneModel.FalseStartDetected += raceObserver.FalseStartDetected;
                RaceLaneModel.LowFuelDetected += raceObserver.LowFuelDetected;
                RaceLaneModel.NoFuelDetected += raceObserver.NoFuelDetected;
                RaceLaneModel.PenaltyAdded += raceObserver.PenaltyAdded;
                RaceLaneModel.PitInDetected += raceObserver.PitInDetected;
                RaceLaneModel.PitOutDetected += raceObserver.PitOutDetected;
                RaceLaneModel.Refueled += raceObserver.Refueled;
                RaceLaneModel.Finished += raceObserver.Finished;
                RaceLaneModel.PenaltiesDone += raceObserver.PenaltiesDone;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void Detach(IRaceObserver raceObserver)
        {
            try
            {
                Changed -= raceObserver.RaceChanged;
                RaceStatusChanged -= raceObserver.RaceStatusChanged;
                RaceLaneModel.LapAdded -= raceObserver.LapAdded;
                RaceLaneModel.LapNotAddedDuePenaltyOrNoFuel -= raceObserver.LapNotAddedDuePenaltyOrNoFuel;
                RaceLaneModel.LapNotAddedDueMinSeconds -= raceObserver.LapNotAddedDueMinSeconds;
                RaceLaneModel.AutoDetectedLapAdded -= raceObserver.AutoDetectedLapAdded;
                RaceLaneModel.LaneChanged -= raceObserver.LaneChanged;
                RaceLaneModel.Disqualified -= raceObserver.Disqualified;
                RaceLaneModel.FalseStartDetected -= raceObserver.FalseStartDetected;
                RaceLaneModel.LowFuelDetected -= raceObserver.LowFuelDetected;
                RaceLaneModel.NoFuelDetected -= raceObserver.NoFuelDetected;
                RaceLaneModel.PenaltyAdded -= raceObserver.PenaltyAdded;
                RaceLaneModel.PitInDetected -= raceObserver.PitInDetected;
                RaceLaneModel.PitOutDetected -= raceObserver.PitOutDetected;
                RaceLaneModel.Refueled -= raceObserver.Refueled;
                RaceLaneModel.Finished -= raceObserver.Finished;
                RaceLaneModel.PenaltiesDone -= raceObserver.PenaltiesDone;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void Attach(ILaneBaseObserver raceObserver)
        {
            try
            {
                RaceLaneModel.LaneChanged += raceObserver.LaneChanged;
                RaceStatusChanged += raceObserver.RaceStatusChanged;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void Detach(ILaneBaseObserver raceObserver)
        {
            try
            {
                RaceLaneModel.LaneChanged -= raceObserver.LaneChanged;
                RaceStatusChanged += raceObserver.RaceStatusChanged;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void Attach(IRaceLapObserver raceObserver)
        {
            try
            {
                RaceLaneModel.LapAdded += raceObserver.LapAdded;
                RaceLaneModel.LapNotAddedDuePenaltyOrNoFuel += raceObserver.LapNotAddedDuePenaltyOrNoFuel;
                RaceLaneModel.LapNotAddedDueMinSeconds += raceObserver.LapNotAddedDueMinSeconds;
                RaceLaneModel.AutoDetectedLapAdded += raceObserver.AutoDetectedLapAdded;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void Attach(IRaceStatusObserver raceObserver)
        {
            try
            {
                RaceRestarted += raceObserver.RaceRestarted;
                RacePaused += raceObserver.RacePaused;
                RaceInitialized += raceObserver.RaceInitialized;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void DetermineRaceStatus()
        {
            if (StatusHandler.IsRaceReadyToStart && IsPausedByParallelPort)
                _raceHandler.WaitForStartByParallelPort();               
        }

        public bool IsPauseByKeyboardPossible
        {
            get { return !RaceSettings.PausePyParallelPortActivated && StatusHandler.IsRaceStartedOrInRestartCountDown; }
        }

        public bool IsPauseByParallelPortPossible
        {
            get { return RaceSettings.PausePyParallelPortActivated && StatusHandler.IsRaceStartedOrInRestartCountDown; }
        }

        public bool IsStopPossible
        {
            get { return StatusHandler.IsRaceWaitingForStart || StatusHandler.IsRaceStartedOrInCountDown || StatusHandler.IsRacePausedOrBreaked; }
        }

        public TimeSpan GetNetTimeSpanFromStart()
        {
            if (Race != null)
                return Race.RacingTime.GetNetTimeSpanFromStart();
            else
                return new TimeSpan();
        }

        public int GetLapNumberOf(Lane lane)
        {
            return Race.GetLapNumberOf(lane);
        }

        public void BreakRace()
        {
            try
            {
                if (IsBreakPossible)
                    RaceHandler.Break();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void UnbreakRace()
        {
            try
            {
                if (StatusHandler.IsRaceBreaked)
                    RaceHandler.Unbreak(IsPausedByParallelPort);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public ISerialPortReader SerialPortReader { private get; set; }

        public ISpeedSumAvgCalculator SpeedSumAvgCalculator { get; set; }

        public bool IsBreakPossible
        {
            get { return StatusHandler.IsRacePausedByKeyboard || StatusHandler.IsRacePausedByParallelPort; }
        }

        public void SetupContest()
        {
            RaceHandler.ResetLanes();
            RaiseEventRaceStatusChanged();
            RaiseEventChanged();
        }

        private void BeginCountDownOfStart()
        {
            try
            {
                if (StatusHandler.IsRaceReadyToStart || StatusHandler.IsRaceWaitingForStart)
                {
                    RaceHandler.ResetLanes();
                    RaceHandler.StartCountDown();
                    _countDownModel.StartCountDown(Race.StartCountDownInitNo);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BeginCountDownOfRestart()
        {
            try
            {
                if (StatusHandler.IsRacePaused)
                    _countDownModel.StartCountDown(Race.RestartCountDownInitNo);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SetRaceToWaitingForRace()
        {
            try
            {
                if (StatusHandler.IsRaceInCountDown)
                {
                    if (StatusHandler.IsRaceInCountDown)
                        _countDownModel.StopCountDown();
                    RaceHandler.WaitForStartByParallelPort();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private bool IsStartPossible
        {
            get { return StatusHandler.IsRaceReadyToStart || StatusHandler.IsRaceInStartCountDown || StatusHandler.IsRaceWaitingForStart; }
        }

        private bool IsPausedByParallelPort
        {
            get { return RaceSettings.PausePyParallelPortActivated && !_parallelPortParser.IsPinSwitchedOn; }
        }

        public bool ShouldRaceResultBeShown
        {
            get { return StatusHandler.IsRaceFinished || Race.ShouldRaceResultBeShown; }
        }

        private void StartRace()
        {
            try
            {
                if (IsStartPossible)
                {
                    RaceHandler.Start();
                    SpeedSumAvgCalculator.Reset();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private bool IsLaneInRace(LaneId laneId)
        {
            return Race != null && RaceHandler.GetLaneById(laneId) != null; 
        }

        private void AttachRaceDataProviderEvents()
        {
            _raceDataProvider.AddLapForLane += RaceDataProviderAddLapForLane;
            _raceDataProvider.HandleFuelComsumptionForLane += RaceDataProviderHandleFuelComsumptionForLane;
            _raceDataProvider.PitstopInForLane += RaceDataProviderPitstopInForLane;
            _raceDataProvider.PitstopOutForLane += RaceDataProviderPitstopOutForLane;
            _raceDataProvider.PenaltyAdditionForLane += RaceDataProviderPenaltyAdditionForLane;
            _raceDataProvider.GetLaneById += RaceDataProviderGetLaneById;
        }

        private void AttachParallelPortParserEvents()
        {
            _parallelPortParser.PinValueChanged += ParallelPortParserPinValueChanged;
        }

        private void ParallelPortParserPinValueChanged(object sender, bool pinValue)
        {
            if (RaceSettings.PausePyParallelPortActivated)
            {
                if (pinValue)
                    StartOrRestartRaceCheckCountDown();
                else
                    PauseOrStopRaceByParallelPort();
            }
        }

        private void RaceDataProviderGetLaneById(LaneId laneId, out Lane lane)
        {
            lane = RaceHandler.GetLaneById(laneId);
        }

        private void CountDownModelCountDownChanged(object sender, CountDownEventArgs e)
        {
            if (e.Type == CountDownEventArgs.TypeEnum.BeginCountDown)
            {
                if (StatusHandler.IsRacePausedOrInRestartCountDown)
                    _raceHandler.RestartCountDown();
                else
                    _raceHandler.StartCountDown();
            }
            else if (e.Type == CountDownEventArgs.TypeEnum.Go)
            {
                if (StatusHandler.IsRacePausedOrInRestartCountDown)
                    RestartRace();
                else
                    StartRace();
            }
        }

        private void StartRaceWithoutCountDown()
        {
            RaceHandler.ResetLanes();
            StartRace();
        }

        private void CheckFalseStart(LaneId laneId, uint speed)
        {
            if (StatusHandler.IsRaceInCountDown && speed >= _raceDataProvider.SpeedToDetectFalseStart)
                HandleFalseStart(laneId);
        }

        private void HandleFalseStart(LaneId laneId)
        {
            RaceLaneModel raceLaneModel = new RaceLaneModel(this, _fuelConsumptionService, laneId, RaceSettings);
            raceLaneModel.AddFalseStart();
        }

        private void RaceDataProviderAddLapForLane(LaneId laneId, DateTime? timeStamp)
        {
            AddLapFor(laneId, timeStamp);
        }

        private void RaceDataProviderHandleFuelComsumptionForLane(LaneId laneId, uint speed)
        {
            try
            {
                if (IsLaneInRace(laneId))
                {
                    HandleFuelConsumptionFor(laneId, speed);
                    RaceLaneModel raceLaneModel = new RaceLaneModel(this, _fuelConsumptionService, laneId, RaceSettings);
                    raceLaneModel.CheckAutoDetectedLap(speed);
                    CheckRaceFinished();
                    CheckRaceShouldBeBreaked();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CheckRaceShouldBeBreaked()
        {
            if (Race.ShouldRaceBeBreaked)
            {
                PauseRaceByKeyboardForced(true);
                BreakRace();
            }
        }

        private void RaceDataProviderPitstopOutForLane(LaneId laneId)
        {
            HandlePitOutFor(laneId);
        }

        private void RaceDataProviderPitstopInForLane(LaneId laneId)
        {
            HandlePitInFor(laneId);
        }

        private void RaceDataProviderPenaltyAdditionForLane(LaneId laneId)
        {
            AddPenaltyFor(laneId);
        }

        private void RaceHandlerRaceChanged(object sender, EventArgs e)
        {
            RaiseEventsRaceChanged();
        }

        private void RaceHandlerRaceFinished(object sender, EventArgs e)
        {
            if (RaceFinished != null)
                RaceFinished(this, null);
        }

        private void RaceHandlerRaceStarted(object sender, EventArgs e)
        {
            if (RaceStarted != null)
                RaceStarted(this, null);
        }

        private void RaceHandlerRaceStopped(object sender, EventArgs e)
        {
            if (RaceStopped != null)
                RaceStopped(this, null);
        }

        private void RaiseEventsRaceChanged()
        {
            RaiseEventRaceStatusChanged();
            RaiseEventChanged();
        }

        private void RaiseEventChanged()
        {
            if (Changed != null)
                Changed(this, null);
        }

        private void RaiseEventRaceStatusChanged()
        {
            if (RaceStatusChanged != null)
                RaceStatusChanged(this, null);
        }

        private void RaiseEventRaceInitialized()
        {
            if (RaceInitialized != null)
                RaceInitialized(this, null);
        }

        private void RaiseEventRaceRestarted()
        {
            if (RaceRestarted != null)
                RaceRestarted(this, null);
        }

        private void RaiseEventRacePaused()
        {
            if (RacePaused != null)
                RacePaused(this, null);
        }

        private void LanePenaltyTimerElapsed(object sender, LaneEventArgs e)
        {
            RaceLaneModel raceLaneModel = new RaceLaneModel(this, _fuelConsumptionService, e.Lane.Id, RaceSettings);
            raceLaneModel.HandlePenaltyTimerElapsed();
        }

        private void LaneRefuelTimerElapsed(object sender, LaneEventArgs e)
        {
            RaceLaneModel raceLaneModel = new RaceLaneModel(this, _fuelConsumptionService, e.Lane.Id, RaceSettings);
            raceLaneModel.HandleRefuelTimerElapsed();
        }

        private void CheckRaceFinished()
        {
            bool finished = false;

            if (Race != null)
                finished = Race.IsRaceFinished;

            if (finished && !StatusHandler.IsRaceFinished)
                _raceHandler.Finish();
        }

        private void RestartRace()
        {
            if (StatusHandler.IsRacePausedOrInRestartCountDown)
            {
                RaceHandler.Restart();
                RaiseEventRaceRestarted();
            }
        }

        private void AddLapFor(LaneId laneId, DateTime? timeStamp)
        {
            try
            {
                if (IsLaneInRace(laneId))
                {
                    RaceLaneModel raceLaneModel = new RaceLaneModel(this, _fuelConsumptionService, laneId, RaceSettings);
                    raceLaneModel.CheckToAddLapWithLapTime(timeStamp);
                    CheckRaceFinished();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void UpdateRaceWith(IEnumerable<ChangedLane> changedLanes)
        {
            foreach (ChangedLane changedLane in changedLanes)
            {
                ChangedLane lane1 = changedLane;
                Lane lane = Race.Lanes.Find(laneIt => lane1.Id == laneIt.Id);
                if (lane != null)
                {
                    if (changedLane.Driver != null && changedLane.Driver.Name != lane.Driver.Name)
                        lane.Driver = changedLane.Driver;
                    if (changedLane.Car != null && changedLane.Car.Name != lane.Car.Name)
                        lane.Car = changedLane.Car;
                    if (changedLane.FuelConsumptionFactor != null)
                        lane.FuelConsumptionFactor = (float)changedLane.FuelConsumptionFactor;
                    if (changedLane.CurrentFuelLevelInLitres != null)
                        lane.CurrentFuelLevelInLitres = (float)changedLane.CurrentFuelLevelInLitres;
                    if (changedLane.Lap != null)
                        lane.Lap = (int)changedLane.Lap;
                    if (changedLane.PenaltyQueue != null)
                        lane.PenaltyQueue = changedLane.PenaltyQueue;
                    if (changedLane.TankMaximumInLitres != null)
                        lane.TankMaximumInLitres = (float)changedLane.TankMaximumInLitres;
                    lane.Status = changedLane.Status;
                    lane.FuelLevelChangedByDialog = changedLane.FuelLevelChangedByDialog | lane.FuelLevelChangedByDialog;
                    lane.PenaltyCount = changedLane.PenaltyCount;
                }
            }
        }

        private void StartOrRestartRaceCheckCountDown()
        {
            if (StatusHandler.IsRaceWaitingForStart)
                StartRaceCheckCountDown();
            else if (StatusHandler.IsRacePausedByParallelPort)
                RestartRaceByKeyboardCheckCountDown();
        }

        private void PauseOrStopRaceByParallelPort()
        {
            if (StatusHandler.IsRaceInStartCountDown)
                SetRaceToWaitingForRace();
            else if (IsPauseByParallelPortPossible)
                PauseRaceByParallelPort();
        }

        private void RaiseEventsForRaceInit()
        {
            RaiseEventRaceInitialized();
            RaiseEventsRaceChanged();
        }

    }
}
