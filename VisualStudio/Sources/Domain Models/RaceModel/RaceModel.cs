using System;
using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.Races;
using Elreg.DomainModels.RaceModel.LaneModel;
using Elreg.Exceptions;
using Elreg.Log;

namespace Elreg.DomainModels.RaceModel
{
    public class RaceModel : IRaceModel
    {
        private IRaceDataProvider _raceDataProvider;
        private readonly CountDownModel _countDownModel = new CountDownModel();
        private IRaceDataHandler _raceHandler = new RaceDataHandlerDummy();
        private readonly StatusHandler _statusHandler = new StatusHandler();
        private readonly RaceResultsModel _raceResultsModel;
        private readonly Dictionary<LaneId, RaceLaneModel> _raceLaneModels = new Dictionary<LaneId, RaceLaneModel>();
        private readonly IRaceLaneModel _raceLaneModelNullObject = new RaceLaneModelNullObject();
        private readonly PositionsCalculator _positionsCalculator;
        private readonly DeltaLapTimeCalculator _deltaLapTimeCalculator;

        public event EventHandler Changed;
        public event EventHandler RaceStatusChanged;
        public event EventHandler RaceInitialized;
        public event EventHandler RaceRestarted;
        public event EventHandler RacePaused;
        public event EventHandler RaceFinished;
        public event EventHandler RaceIsBeforeStart;
        public event EventHandler RaceStarted;
        public event EventHandler RaceStopped;
        public event RaceLaneModel.LaneChangedHandler LaneChanged;
        public event RaceLaneModel.LaneChangedHandler LapNotAddedDueMinSeconds;
        public event RaceLaneModel.LaneChangedHandler PenaltyAdded;
        public event RaceLaneModel.LaneChangedHandler Disqualified;
        public event RaceLaneModel.LaneChangedHandler LapAdded;
        public event RaceLaneModel.LaneChangedHandler Finished;

        public RaceModel() 
        {
            _positionsCalculator = new PositionsCalculator(this);
            _deltaLapTimeCalculator = new DeltaLapTimeCalculator(this);
            _raceResultsModel = new RaceResultsModel(this);
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

        public List<Lane> LanesWithActivatedSound
        {
            get { return Race.Lanes; }
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

        public List<InitialLane> InitialLanes { get; set; }

        public Race Race { get; private set; }

        public void RestoreRace(Race race, List<InitialLane> initialLanes)
        {
            InitialLanes = initialLanes;
            Race = race;
            _statusHandler.Race = Race;
            _raceHandler = new RaceDataHandler(Race);
            AttachRaceHandlerEvents();
            RaiseEventsForRaceInit();
        }

        public void InitRace()
        {
            if ((StatusHandler.IsRaceNotSetuped || StatusHandler.IsRaceInitialized || StatusHandler.IsRaceStoppedOrFinished) &&
                InitialLanes != null && InitialLanes.Count > 0)
            {
                Race = new Race(RaceSettings);
                _statusHandler.Race = Race;
                _raceHandler = new RaceDataHandler(Race, InitialLanes);
                AttachRaceHandlerEvents();
                RaiseEventsForRaceInit();
            }
            else
                throw new LcException("Wrong Status or InitialLanes are null.");
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
                if (StatusHandler.IsRaceReadyToStart)
                {
                    if (RaceIsBeforeStart != null)
                        RaceIsBeforeStart(this, null);
                    CreateRaceLaneModels();
                    RaiseEventsRaceChanged();
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

        private void CreateRaceLaneModels()
        {
            ClearRaceLaneModels();
            foreach (InitialLane initialLane in InitialLanes)
            {
                RaceLaneModel raceLaneModel = CreateRaceLaneModel(initialLane);
                _raceLaneModels.Add(initialLane.Id, raceLaneModel);
            }
        }

        private void ClearRaceLaneModels()
        {
            foreach (KeyValuePair<LaneId, RaceLaneModel> keyValuePair in _raceLaneModels)
            {
                RaceLaneModel raceLaneModel = keyValuePair.Value;
                raceLaneModel.Disqualified -= RaceLaneModelDisqualified;
                raceLaneModel.Finished -= RaceLaneModelFinished;
                raceLaneModel.LaneChanged -= RaceLaneModelLaneChanged;
                raceLaneModel.LapAdded -= RaceLaneModelLapAdded;
                raceLaneModel.LapNotAddedDueMinSeconds -= RaceLaneModelLapNotAddedDueMinSeconds;
                raceLaneModel.PenaltyAdded -= RaceLaneModelPenaltyAdded;
            }
            _raceLaneModels.Clear();
        }

        private RaceLaneModel CreateRaceLaneModel(InitialLane initialLane)
        {
            RaceLaneModel raceLaneModel = new RaceLaneModel(this, initialLane.Id, RaceSettings);
            raceLaneModel.Disqualified += RaceLaneModelDisqualified;
            raceLaneModel.Finished += RaceLaneModelFinished;
            raceLaneModel.LaneChanged += RaceLaneModelLaneChanged;
            raceLaneModel.LapAdded += RaceLaneModelLapAdded;
            raceLaneModel.LapNotAddedDueMinSeconds += RaceLaneModelLapNotAddedDueMinSeconds;
            raceLaneModel.PenaltyAdded += RaceLaneModelPenaltyAdded;
            return raceLaneModel;
        }

        private void RaceLaneModelPenaltyAdded(LaneId laneId)
        {
            try
            {
                if (PenaltyAdded != null)
                    PenaltyAdded(laneId);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceLaneModelLapNotAddedDueMinSeconds(LaneId laneId)
        {
            try
            {
                if (LapNotAddedDueMinSeconds != null)
                    LapNotAddedDueMinSeconds(laneId);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceLaneModelLapAdded(LaneId laneId)
        {
            try
            {
                if (LapAdded != null)
                    LapAdded(laneId);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceLaneModelLaneChanged(LaneId laneId)
        {
            try
            {
                if (LaneChanged != null)
                    LaneChanged(laneId);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceLaneModelFinished(LaneId laneId)
        {
            try
            {
                if (Finished != null)
                    Finished(laneId);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceLaneModelDisqualified(LaneId laneId)
        {
            try
            {
                if (Disqualified != null)
                    Disqualified(laneId);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void RestartRaceByKeyboardOrArduinoCheckCountDown()
        {
            try
            {
                if (StatusHandler.IsRacePaused)
                {
                    if (Race.IsRestartCountDownActivated)
                    {
                        if (StatusHandler.IsRacePausedBeforeStart)
                            BeginCountDownOfStart();
                        else
                            BeginCountDownOfRestart();
                    }
                    else
                        RestartRace();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void PauseRaceBeforeStart()
        {
            try
            {
                if (StatusHandler.IsRaceStartedOrInCountDown)
                {
                    if (StatusHandler.IsRaceInStartCountDown)
                        _countDownModel.StopCountDown();
                    RaceHandler.PauseBeforeStart();
                    RaiseEventRacePaused();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void PauseRaceByArduino()
        {
            try
            {
                if (IsPauseByKeyboardOrArduinoPossible)
                {
                    if (StatusHandler.IsRaceInCountDown)
                        _countDownModel.StopCountDown();
                    RaceHandler.PauseByArduino();
                    RaiseEventRacePaused();
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
                if (IsPauseByKeyboardOrArduinoPossible || force)
                {
                    if (StatusHandler.IsRaceInCountDown)
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

        public void AddLapManuallyFor(LaneId laneId)
        {
            try
            {
                if (IsLaneInRace(laneId))
                {
                    IRaceLaneModel raceLaneModel = GetRaceLaneModelOf(laneId);
                    raceLaneModel.CheckToAddLapWithLapTime(DateTime.Now);
                    // todo raceLaneModel.AddLapManually();
                    CheckRaceFinished();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private IRaceLaneModel GetRaceLaneModelOf(LaneId laneId)
        {
            RaceLaneModel raceLaneModel;
            if (!_raceLaneModels.TryGetValue(laneId, out raceLaneModel))
                return _raceLaneModelNullObject;
            else
                return raceLaneModel;
        }

        public void RemoveLapFor(LaneId laneId)
        {
            try
            {
                if (IsLaneInRace(laneId))
                {
                    IRaceLaneModel raceLaneModel = GetRaceLaneModelOf(laneId);
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
                    IRaceLaneModel raceLaneModel = GetRaceLaneModelOf(laneId);
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
                    IRaceLaneModel raceLaneModel = GetRaceLaneModelOf(laneId);
                    raceLaneModel.UndoPenaltyFor();
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
                LapAdded += raceObserver.LapAdded;
                LapNotAddedDueMinSeconds += raceObserver.LapNotAddedDueMinSeconds;
                LaneChanged += raceObserver.LaneChanged;
                Disqualified += raceObserver.Disqualified;
                PenaltyAdded += raceObserver.PenaltyAdded;
                Finished += raceObserver.Finished;
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
                LapAdded -= raceObserver.LapAdded;
                LapNotAddedDueMinSeconds -= raceObserver.LapNotAddedDueMinSeconds;
                LaneChanged -= raceObserver.LaneChanged;
                Disqualified -= raceObserver.Disqualified;
                PenaltyAdded -= raceObserver.PenaltyAdded;
                Finished -= raceObserver.Finished;
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
                LaneChanged += raceObserver.LaneChanged;
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
                LaneChanged -= raceObserver.LaneChanged;
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
                LapAdded += raceObserver.LapAdded;
                LapNotAddedDueMinSeconds += raceObserver.LapNotAddedDueMinSeconds;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void Detach(IRaceLapObserver raceObserver)
        {
            try
            {
                LapAdded -= raceObserver.LapAdded;
                LapNotAddedDueMinSeconds -= raceObserver.LapNotAddedDueMinSeconds;
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
                RaceFinished += raceObserver.RaceFinished;
                RaceStopped += raceObserver.RaceStopped;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public bool IsPauseByKeyboardOrArduinoPossible
        {
            get { return StatusHandler.IsRaceStartedOrInCountDown; }
        }

        public bool IsStopPossible
        {
            get { return StatusHandler.IsRaceStartedOrInCountDown || StatusHandler.IsRacePaused; }
        }

        public TimeSpan GetNetTimeSpanFromStart()
        {
            if (Race != null)
                return Race.RacingTime.NetTimeSpanFromStart;
            else
                return new TimeSpan();
        }

        public int GetLapNumberOf(Lane lane)
        {
            return Race.GetLapNumberOf(lane);
        }

        public ILapTimeAvgCalculator LapTimeAvgCalculator { get; set; }

        public bool IsBreakPossible
        {
            get { return StatusHandler.IsRacePausedByKeyboardOrArduino; }
        }

        public void SetupContest()
        {
            RaceHandler.ResetLanes();
            RaceHandler.SetupContest();
            RaiseEventRaceStatusChanged();
            RaiseEventChanged();
        }

        public IRaceResult CreateRaceResult()
        {
            return _raceResultsModel.CreateRaceResult();
        }

        public bool ShouldRaceResultBeShown
        {
            get { return StatusHandler.IsRaceFinished || Race.ShouldRaceResultBeShown; }
        }

        public RaceResultsModel RaceResultsModel
        {
            get { return _raceResultsModel; }
        }

        public void CalcPositionsOfAllLanes()
        {
            _positionsCalculator.DoWork();
        }

        public void CalcDeltaLapTime(Lane lane)
        {
            _deltaLapTimeCalculator.DoWork(lane);
        }

        private void BeginCountDownOfStart()
        {
            try
            {
                if (StatusHandler.IsRaceReadyToStart || StatusHandler.IsRacePausedBeforeStart)
                {
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

        private bool IsStartPossible
        {
            get { return StatusHandler.IsRaceReadyToStart || StatusHandler.IsRaceInStartCountDown; }
        }

        private void StartRace()
        {
            try
            {
                if (IsStartPossible)
                {
                    RaceHandler.Start();
                    LapTimeAvgCalculator.Reset();
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
            _raceDataProvider.PenaltyAdditionForLane += RaceDataProviderPenaltyAdditionForLane;
            _raceDataProvider.GetLaneById += RaceDataProviderGetLaneById;
        }

        private void RaceDataProviderGetLaneById(LaneId laneId, out Lane lane)
        {
            lane = null;
            try
            {
                lane = RaceHandler.GetLaneById(laneId);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CountDownModelCountDownChanged(object sender, CountDownEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void StartRaceWithoutCountDown()
        {
            StartRace();
        }

        private void RaceDataProviderAddLapForLane(LaneId laneId, DateTime? timeStamp)
        {
            try
            {
                AddLapFor(laneId, timeStamp);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceDataProviderPenaltyAdditionForLane(LaneId laneId)
        {
            if (!RaceSettings.IsAllowedPenaltyAdditionByThreeClicksOnlyInPauseOrCountDown ||
                StatusHandler.IsRacePaused || StatusHandler.IsRaceInCountDown)
            {
                AddPenaltyFor(laneId);
            }
        }

        private void RaceHandlerRaceChanged(object sender, EventArgs e)
        {
            try
            {
                RaiseEventsRaceChanged();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceHandlerRaceFinished(object sender, EventArgs e)
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

        private void RaceHandlerRaceStarted(object sender, EventArgs e)
        {
            try
            {
                if (RaceStarted != null)
                    RaceStarted(this, null);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceHandlerRaceStopped(object sender, EventArgs e)
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

        private void RaiseEventsRaceChanged()
        {
            RaiseEventRaceStatusChanged();
            RaiseEventChanged();
        }

        public void RaiseEventChanged()
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
                    IRaceLaneModel raceLaneModel = GetRaceLaneModelOf(laneId);
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
                    if (changedLane.Driver != null && changedLane.Driver.Id != lane.Driver.Id)
                        lane.Driver = changedLane.Driver;
                    if (changedLane.Car != null && changedLane.Car.Id != lane.Car.Id)
                        lane.Car = changedLane.Car;
                    if (changedLane.Lap != null)
                        lane.Lap = (int)changedLane.Lap;
                    lane.Status = changedLane.Status;
                    lane.PenaltyCount = changedLane.PenaltyCount;
                }
            }
        }

        private void RaiseEventsForRaceInit()
        {
            RaiseEventRaceInitialized();
            RaiseEventsRaceChanged();
        }
    }
}
