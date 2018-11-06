using System;
using System.Diagnostics;
using Heinzman.BusinessObjects;
using Heinzman.BusinessObjects.Lanes;
using Heinzman.BusinessObjects.Options;
using Heinzman.BusinessObjects.Races;
using Heinzman.RaceOptionsService;

namespace Heinzman.DomainModels.RaceModel.LaneModel
{
    public class RaceLaneModel
    {
        private readonly LaneId _laneId;
        private readonly RaceSettings _raceSettings;
        private readonly FuelConsumptionService _fuelConsumptionService;
        private readonly PositionsCalculator _positionsCalculator;
        private readonly AutoDetection _autoDetection;
        private float _calcedLitresToConsume;

        public delegate void LaneChangedHandler(LaneId laneId);
        public static event LaneChangedHandler LaneChanged;
        public static event LaneChangedHandler LapNotAddedDueMinSeconds;
        public static event LaneChangedHandler PenaltyAdded;
        public static event LaneChangedHandler FalseStartDetected;
        public static event LaneChangedHandler PitInDetected;
        public static event LaneChangedHandler PitOutDetected;
        public static event LaneChangedHandler LowFuelDetected;
        public static event LaneChangedHandler NoFuelDetected;
        public static event LaneChangedHandler Disqualified;
        public static event LaneChangedHandler Refueled;
        public static event LaneChangedHandler Refueling;
        public static event LaneChangedHandler PenaltiesDone;
        public static event LaneChangedHandler LapAdded;
        public static event LaneChangedHandler AutoDetectedLapAdded;
        public static event LaneChangedHandler LapNotAddedDuePenaltyOrNoFuel;
        public static event LaneChangedHandler Finished;

        public RaceLaneModel(RaceModel raceModel, FuelConsumptionService fuelConsumptionService, 
                             LaneId laneId, RaceSettings raceSettings)
        {
            _laneId = laneId;
            RaceModel = raceModel;
            _fuelConsumptionService = fuelConsumptionService;
            _raceSettings = raceSettings;
            LapAppender = new LapAppender(this, raceSettings);
            _autoDetection = new AutoDetection(this, raceSettings);
            LapAppender.AutoDetectedLapAdded += LapAppenderAutoDetectedLapAdded;
            LapAppender.Finished += LapAppenderFinished;
            LapAppender.LapAdded += LapAppenderLapAdded;
            LapAppender.LapNotAddedDuePenaltyOrNoFuel += LapAppenderLapNotAddedDuePenaltyOrNoFuel;
            FindAndSetCurrentLane();
            _positionsCalculator = new PositionsCalculator(raceModel);
        }

        private void LapAppenderLapNotAddedDuePenaltyOrNoFuel(LaneId laneId)
        {
            RaiseEvent(LapNotAddedDuePenaltyOrNoFuel);
        }

        private void LapAppenderLapAdded(LaneId laneId)
        {
            RaiseEvent(LapAdded);
        }

        private void LapAppenderFinished(LaneId laneId)
        {
            RaiseEvent(Finished);
        }

        private void LapAppenderAutoDetectedLapAdded(LaneId laneId)
        {
            RaiseEvent(AutoDetectedLapAdded);
        }

        public void HandleFuelConsumption(uint speed)
        {
            if (LaneIsInRaceOrFinishedAndRaceIsInStartedOrCountDown)
            {
                if (CurrentLaneIsStartedOrInitialized)
                {
                    float litres = CalcLitresBySpeed(speed);
                    CalcAndConsume(litres);
                }
                CurrentLane.CurrentSpeed = speed;
                HandleFuelEvents();
                if (CurrentLaneIsStartedOrInitialized)
                    CurrentLane.LastFuelLevelInLitres = CurrentLane.CurrentFuelLevelInLitres;
            }
        }

        private void CalcAndConsume(float litres)
        {
            FuelConsumptionCalculator fuelConsumptionCalculator = new FuelConsumptionCalculator(CurrentLane, _raceSettings);
            fuelConsumptionCalculator.CalcAndConsume(litres);
        }

        public void AddFuel(float litres)
        {
            if (LaneIsInRaceAndRaceIsInStartedOrCountDownOrPaused)
            {
                CalcLitresToAddWithoutConsumptionFactor(litres);
                HandleAddOrRemoveFuel();
            }
        }

        public void RemoveFuel(float litres)
        {
            if (LaneIsInRaceAndRaceIsInStartedOrCountDownOrPaused)
            {
                _calcedLitresToConsume = litres;
                HandleAddOrRemoveFuel();
            }
        }

        public void CheckToAddLapWithLapTime(DateTime? timeStamp)
        {
            if (IsLapValidDueMinSecs())
            {
                if (CurrentLane.Lap == -1)
                    RaceModel.SpeedSumAvgCalculator.AddSpeedSumOfZerothLap(CurrentLane.SpeedSum);
                else if (CurrentLane.Lap >= 0)
                    RaceModel.SpeedSumAvgCalculator.AddSpeedSum(CurrentLane.SpeedSum);
                LapAppender.AddLapWithLapTime(timeStamp);
            }
            else
            {
                CurrentLane.SpeedSum = 0;
                CurrentLane.LastTimeALapNotAddedDueMinSeconds = DateTime.Now;
                RaiseEventWithLaneChanged(LapNotAddedDueMinSeconds);
            }
        }

        private bool IsLapValidDueMinSecs()
        {
            return CurrentLane.Lap == -1 ||
                   IsFirstLapAndValidDueMinSecs ||
                   IsNormalLapAndValidDueMinSecs;
        }

        private bool IsFirstLapAndValidDueMinSecs
        {
            get
            {
                int sec = SecondsSinceDetectedZerothLap;
                bool b1 = (CurrentLane.Lap == 0);
                bool b2 = (CurrentLane.ZerothLapWasAutoDetected && SecondsSinceDetectedZerothLap >= _raceSettings.SecondsForValidLap / 2 && HasHalfSpeedSumAvg);
                bool b5 = (!CurrentLane.ZerothLapWasAutoDetected && SecondsSinceLastDetectedLap >= _raceSettings.SecondsForValidLap);
                bool b4 = (!CurrentLane.ZerothLapWasAutoDetected && SecondsSinceRaceStart >= _raceSettings.SecondsForValidLap);
                return CurrentLane.Lap == 0 &&
                       ((CurrentLane.ZerothLapWasAutoDetected && SecondsSinceDetectedZerothLap >= _raceSettings.SecondsForValidLap / 2 && HasHalfSpeedSumAvg) ||
                        (!CurrentLane.ZerothLapWasAutoDetected && SecondsSinceLastDetectedLap >= _raceSettings.SecondsForValidLap) ||
                        (!CurrentLane.ZerothLapWasAutoDetected && SecondsSinceRaceStart >= _raceSettings.SecondsForValidLap && HasHalfSpeedSumAvg));
            }
        }

        private bool HasHalfSpeedSumAvg
        {
            get { return RaceModel.SpeedSumAvgCalculator.SpeedSumAvg == null || CurrentLane.SpeedSum >= RaceModel.SpeedSumAvgCalculator.SpeedSumAvg/2; }
        }

        private bool IsNormalLapAndValidDueMinSecs
        {
            get
            {
                return CurrentLane.Lap > 0 &&
                       ((CurrentLane.LastLapsAutoDetectedCount == 0 && SecondsSinceLastDetectedLap >= _raceSettings.SecondsForValidLap) ||
                        (CurrentLane.LastLapsAutoDetectedCount > 0 &&
                         SecondsSinceLastDetectedLap >= _raceSettings.SecondsForValidLap*(CurrentLane.LastLapsAutoDetectedCount + 1)));
            }
        }

        public void AddLapManually()
        {
            LapAppender.AddLapManually();
        }

        public void RemoveLap()
        {
            if (RaceModel.StatusHandler.IsRaceStartedOrPaused)
            {
                if (CurrentLane.Lap > -1)
                {
                    RaceModel.RaceHandler.RemoveLapFor(_laneId);
                    CalcCurrentLaneStatus();
                    CalcPositionsOfAllLanes();
                    RaiseEvent(LaneChanged);
                }
            }
        }

        public void AddPenalty()
        {
            if (LaneIsInRaceAndRaceIsInStartedOrCountDownOrPaused)
            {
                AddPenaltyForced();
                RaiseEventWithLaneChanged(PenaltyAdded);
                CheckDisqualification();
            }
        }

        public void AddFalseStart()
        {
            if (RaceModel.StatusHandler.IsRaceInCountDown)
            {
                if (IsFalseStartPossible())
                {
                    CurrentLane.LastFalseStartDateTime = DateTime.Now;
                    AddPenaltyForced();
                    RaiseEventWithLaneChanged(FalseStartDetected);
                    CheckDisqualification();
                }
            }
        }

        private void CheckDisqualification()
        {
            if (RaceModel.Race.Type == Race.TypeEnum.Race &&
                _raceSettings.AutoDisqualificationRaceActivated && 
                CurrentLane.PenaltyCount >= _raceSettings.AutoDisqualificationRaceAfterPenalties)
            {
                DisqualifyCurrentLane();
            }
        }

        private void RemovePenalty()
        {
            if (LaneIsInRaceAndRaceIsInStartedOrCountDownOrPaused)
                DequeuePenaltyQueue();
        }

        public void UndoPenaltyFor()
        {
            if (LaneIsInRaceAndRaceIsInStartedOrCountDownOrPaused)
            {
                if (CurrentLane.PenaltyCount > 0)
                    CurrentLane.PenaltyCount--;
                DequeuePenaltyQueue();
            }
        }

        public void HandlePitIn()
        {
            if (LaneIsInRaceAndRaceIsInStarted)
            {
                if (CurrentLane.IsInPitstop == false && CurrentLane.IsPitstopAllowed)
                {
                    CurrentLane.IsPitstopAllowed = false;
                    CheckToStartPitstopAction();
                    CurrentLane.PitstopCount++;
                    RaiseEventWithLaneChanged(PitInDetected);
               }
            }
        }

        public void HandlePitOut()
        {
            if (LaneIsInRaceAndRaceIsInStarted)
            {
                if (CurrentLane.IsInPitstop)
                {
                    CurrentLane.PitstopStatus = Lane.PitstopStatusEnum.Out;
                    CurrentLane.StopPenaltyTimer();
                    CurrentLane.StopRefuelTimer();
                    AdjustFuelLevelOfLastLap();
                    RaiseEventWithLaneChanged(PitOutDetected);
                }
            }
        }

        public void CheckAutoDetectedLap(uint speed)
        {
            _autoDetection.CheckAutoDetectedLap(speed);
        }

        internal int SecondsSinceLastDetectedLap
        {
            get
            {
                TimeSpan timespan = CurrentLane.RaceTimeNet;
                if (CurrentLane.LastTimeALapAlsoIrregularWasAdded.HasValue)
                    timespan = DateTime.Now - CurrentLane.LastTimeALapAlsoIrregularWasAdded.Value - CurrentLane.PauseTimeSpan;
                return timespan.Seconds;
            }
        }

        internal int SecondsSinceDetectedZerothLap
        {
            get
            {
                TimeSpan timespan = CurrentLane.RaceTimeNet;
                if (CurrentLane.TimeAutoDetectedZerothLapWasAdded.HasValue)
                    timespan = DateTime.Now - CurrentLane.TimeAutoDetectedZerothLapWasAdded.Value - CurrentLane.PauseTimeSpan;
                return timespan.Seconds;
            }
        }

        private int SecondsSinceRaceStart
        {
            get
            {
                TimeSpan timespan = CurrentLane.RaceTimeNet;
                if (CurrentLane.LastTimeALapAlsoIrregularWasAdded.HasValue)
                    timespan = DateTime.Now - CurrentLane.LastTimeALapAlsoIrregularWasAdded.Value;
                return timespan.Seconds;
            }
        }

        private void AdjustFuelLevelOfLastLap()
        {
            if (CurrentLane.FuelLevelBeforeRefueling != null)
            {
                CurrentLane.FuelLevelOfLastLap += CurrentLane.CurrentFuelLevelInLitres - CurrentLane.FuelLevelBeforeRefueling;
                CurrentLane.FuelLevelBeforeRefueling = null;
            }
        }

        public void HandleToggleDisqualified()
        {
            if (LaneIsInRaceOrFinishedOrDisqualifiedAndRaceIsInStartedOrPaused)
            {
                if (CurrentLane.IsStarted)
                    DisqualifyCurrentLane();
                else if (CurrentLane.IsDisqualified)
                {
                    CurrentLane.Status = Lane.LaneStatusEnum.Started;
                    RaiseEvent(LaneChanged);
                }
            }
        }

        private void DisqualifyCurrentLane()
        {
            CurrentLane.Status = Lane.LaneStatusEnum.Disqualified;
            RaiseEventWithLaneChanged(Disqualified);
        }

        public void HandlePenaltyTimerElapsed()
        {
            if (LaneIsInRaceAndRaceIsInStarted)
            {
                RemovePenalty();
                CurrentLane.PitstopStatus = Lane.PitstopStatusEnum.PenaltyDone;

                if (RaceModel.Race.ServingMultiplePenaltiesAllowed && CurrentLane.PenaltyQueue.Count > 0)
                    StartPenaltyWaitingForCurrentLane();
                else if (WasLastLapButWithPenalty() && CurrentLane.PenaltyQueue.Count == 0)
                    AddLapManually();
                else if (RaceModel.Race.RefuelingAfterServingPenaltyAllowed && CurrentLane.PenaltyQueue.Count == 0)
                    StartRefuelingForCurrentLane();
                else if (!RaceModel.Race.RefuelingAfterServingPenaltyAllowed && CurrentLane.PenaltyQueue.Count == 0)
                    RaiseEvent(PenaltiesDone);

                RaiseEvent(LaneChanged);
            }
        }

        public void HandleRefuelTimerElapsed()
        {
            if (LaneIsInRaceAndRaceIsInStarted)
            {
                if (CurrentLane.CurrentFuelLevelInLitres <= CurrentLane.TankMaximumInLitres)
                {
                    RefuelCurrentLaneInLitres(_raceSettings.LitresRefuelingPer100Ms);
                    if (CurrentLaneIsRefueled)
                    {
                        CurrentLane.PitstopStatus = Lane.PitstopStatusEnum.RefuelingDone;
                        CurrentLane.StopRefuelTimer();
                        AdjustFuelLevelOfLastLap();
                        RaiseEventWithLaneChanged(Refueled);
                    }
                    else
                        RaiseEvent(LaneChanged);
                }
            }
        }

        internal Lane CurrentLane { get; private set; }

        internal RaceModel RaceModel { get; private set; }

        private void DequeuePenaltyQueue()
        {
            if (CurrentLane.PenaltyQueue.Count > 0)
            {
                int lapsLeftToStop = CurrentLane.PenaltyQueue.Peek().LapsLeftToStop;
                CurrentLane.PenaltyQueue.Dequeue();
                if (CurrentLane.PenaltyQueue.Count > 0)
                    CurrentLane.PenaltyQueue.Peek().LapsLeftToStop = lapsLeftToStop;
                RaiseEvent(LaneChanged);
            }
        }

        private bool IsFalseStartPossible()
        {
            bool isPossible = true;
            if (CurrentLane.LastFalseStartDateTime != null)
            {
                TimeSpan timeSpan = DateTime.Now - CurrentLane.LastFalseStartDateTime.Value;
                isPossible = timeSpan > new TimeSpan(0, 0, 0, 2);
            }
            return isPossible;
        }

        private void HandleAddOrRemoveFuel()
        {
            if (LaneIsInRaceAndRaceIsInStartedOrCountDownOrPaused)
            {
                CurrentLane.FuelLevelBeforeRefueling = CurrentLane.CurrentFuelLevelInLitres;
                CurrentLane.ConsumeFuelInLitres(_calcedLitresToConsume);
                AdjustFuelLevelOfLastLap();
                RaiseEvent(LaneChanged);
            }
        }

        private void AddPenaltyForced()
        {
            Penalty penalty = new Penalty(RaceModel.Race.LapsToStopForPenalty);
            CurrentLane.PenaltyQueue.Enqueue(penalty);
            CurrentLane.PenaltyCount++;
        }

        private void FindAndSetCurrentLane()
        {
            CurrentLane = RaceModel.RaceHandler.GetLaneById(_laneId);
        }

        private float CalcLitresBySpeed(uint speed)
        {
            return _fuelConsumptionService.GetFuelConsumptionPer(speed);
        }

        private void CalcLitresToAddWithoutConsumptionFactor(float litres)
        {
            if (CurrentLane.CurrentFuelLevelInLitres + litres > CurrentLane.TankMaximumInLitres)
                _calcedLitresToConsume = CurrentLane.TankMaximumInLitres - CurrentLane.CurrentFuelLevelInLitres;
            else
                _calcedLitresToConsume = litres;

            _calcedLitresToConsume *= -1;
        }

        internal void RaiseEventWithLaneChanged(LaneChangedHandler eventHandler)
        {
            RaiseEvent(eventHandler);
            RaiseEvent(LaneChanged);
        }

        internal void RaiseEvent(LaneChangedHandler eventHandler)
        {
            if (eventHandler != null)
                eventHandler(_laneId);
        }

        private bool CurrentLaneIsStartedOrFinished
        {
            get { return CurrentLane != null && CurrentLane.IsStartedOrFinished; }
        }

        private bool CurrentLaneIsStartedOrInitialized
        {
            get { return CurrentLane != null && CurrentLane.IsStartedOrInitialized; }
        }

        private bool CurrentLaneIsDisqualified
        {
            get { return CurrentLane != null && CurrentLane.Status == Lane.LaneStatusEnum.Disqualified; }
        }

        internal void CalcCurrentLaneStatus()
        {
            RaceModel.Race.CalcLaneStatus(CurrentLane);
        }

        internal void CalcPositionsOfAllLanes()
        {
            _positionsCalculator.DoWork();
        }

        private void CheckToStartPitstopAction()
        {
            if (CurrentLane.PenaltyQueue.Count > 0)
                StartPenaltyWaitingForCurrentLane();
            else
                StartRefuelingForCurrentLane();
        }

        private bool WasLastLapButWithPenalty()
        {
            return CurrentLane.CurrentFuelLevelInLitres >= 0 &&
                   CurrentLane.PenaltyQueue.Count == 0 &&
                   CurrentLane.WasLastLapAndPenaltyExisted;
        }

        private void RefuelCurrentLaneInLitres(float litres)
        {
            float addedVolume = CurrentLane.CurrentFuelLevelInLitres + litres;

            if (addedVolume > CurrentLane.TankMaximumInLitres)
                CurrentLane.CurrentFuelLevelInLitres = CurrentLane.TankMaximumInLitres;
            else
                CurrentLane.CurrentFuelLevelInLitres = addedVolume;
        }

        private void StartPenaltyWaitingForCurrentLane()
        {
            CurrentLane.PitstopStatus = Lane.PitstopStatusEnum.PenaltyWaiting;
            CurrentLane.StartPenaltyTimer(RaceModel.Race.IntervalInSecsForPenalty);
        }

        private void StartRefuelingForCurrentLane()
        {
            CurrentLane.PitstopStatus = Lane.PitstopStatusEnum.Refueling;
            CurrentLane.FuelLevelBeforeRefueling = CurrentLane.CurrentFuelLevelInLitres;
            CurrentLane.StartRefuelTimer();
            RaiseEventWithLaneChanged(Refueling);
        }

        private bool CurrentLaneIsRefueled
        {
            get { return CurrentLane.CurrentFuelLevelInLitres >= CurrentLane.TankMaximumInLitres; }
        }

        internal bool LaneIsInRaceAndRaceIsInStartedOrCountDownOrPaused
        {
            get
            {
                return CurrentLaneIsStartedOrInitialized &&
                       (RaceModel.StatusHandler.IsRaceStartedOrInCountDown || RaceModel.StatusHandler.IsRacePaused);
            }
        }

        private bool LaneIsInRaceOrFinishedOrDisqualifiedAndRaceIsInStartedOrPaused
        {
            get { return (CurrentLaneIsStartedOrFinished || CurrentLaneIsDisqualified) && RaceModel.StatusHandler.IsRaceStartedOrPaused; }
        }

        internal bool LaneIsInRaceAndRaceIsInStartedOrCountDown
        {
            get { return CurrentLaneIsStartedOrInitialized && RaceModel.StatusHandler.IsRaceStartedOrInCountDown; }
        }

        private bool LaneIsInRaceOrFinishedAndRaceIsInStartedOrCountDown
        {
            get { return CurrentLaneIsStartedOrFinished && RaceModel.StatusHandler.IsRaceStartedOrInCountDown; }
        }

        private bool LaneIsInRaceAndRaceIsInStarted
        {
            get { return CurrentLaneIsStartedOrFinished && RaceModel.StatusHandler.IsRaceStarted; }
        }

        internal LapAppender LapAppender { get; private set; }

        private void HandleFuelEvents()
        {
            if (CurrentLane.CurrentFuelLevelInLitres <= 0 &&
                    (CurrentLane.LastFuelLevelInLitres == null || CurrentLane.LastFuelLevelInLitres > 0))
                RaiseEventWithLaneChanged(NoFuelDetected);
            else if (CurrentLane.CurrentFuelLevelInLitres <= _raceSettings.FuelLevelInLitresToWarn &&
                    (CurrentLane.LastFuelLevelInLitres == null || CurrentLane.LastFuelLevelInLitres > _raceSettings.FuelLevelInLitresToWarn))
                RaiseEventWithLaneChanged(LowFuelDetected);
            else
                RaiseEvent(LaneChanged);
        }

    }
}
