using System;
using Heinzman.BusinessObjects;
using Heinzman.BusinessObjects.Lanes;
using Heinzman.BusinessObjects.Options;

namespace Heinzman.DomainModels.RaceModel.LaneModel
{
    public class LapAppender
    {
        private readonly RaceLaneModel _raceLaneModel;
        private readonly RaceSettings _raceSettings;
        private bool _calcLapTime;
        private bool _lapAutoDetected;
        private bool _lapManuallyAdded;
        private DateTime _timeStampLapWasDetected;

        public event RaceLaneModel.LaneChangedHandler LapAdded;
        public event RaceLaneModel.LaneChangedHandler AutoDetectedLapAdded;
        public event RaceLaneModel.LaneChangedHandler LapNotAddedDuePenaltyOrNoFuel;
        public event RaceLaneModel.LaneChangedHandler Finished;

        public LapAppender(RaceLaneModel raceLaneModel, RaceSettings raceSettings)
        {
            _raceLaneModel = raceLaneModel;
            _raceSettings = raceSettings;
        }

        public void AddAutoDetectedLap()
        {
            _timeStampLapWasDetected = DateTime.Now;
            _calcLapTime = false;
            _lapAutoDetected = true;
            _lapManuallyAdded = false;
            CheckAndHandleLapAddition();
        }

        public void AddLapManually()
        {
            _timeStampLapWasDetected = DateTime.Now;
            _calcLapTime = false;
            _lapAutoDetected = false;
            _lapManuallyAdded = true;
            CheckAndHandleLapAddition();
        }

        public void AddLapWithLapTime(DateTime? timeStamp)
        {
            _timeStampLapWasDetected = timeStamp ?? DateTime.Now;
            _calcLapTime = true;
            _lapAutoDetected = false;
            _lapManuallyAdded = false;
            CheckAndHandleLapAddition();
        }

        private Lane CurrentLane { get { return _raceLaneModel.CurrentLane; } }

        private RaceModel RaceModel { get { return _raceLaneModel.RaceModel; } }

        private void CheckAndHandleLapAddition()
        {
            if (_raceLaneModel.LaneIsInRaceAndRaceIsInStartedOrCountDownOrPaused)
            {
                CalcWasLastLapAndPenaltyExisted();
                CheckToCalcFuelConsumption();
                CheckToCalcLapTime();
                CheckToCalcCurrentLaneBestLapTime();
                RaceModel.RaceHandler.AddLapAlsoIrregularFor(CurrentLane.Id);
                CheckToHandleAutoDetectedLap();
                CheckToSetLastTimeALapAlsoIrregularWasAdded();
                CurrentLane.CalcLapTime = _calcLapTime;
                CheckToAddLap();
                RaceLaneModel.LaneChangedHandler laneChangedHandler = GetLaneChangedHandler();
                CheckToRemoveOrResetPenalties();
                CheckToResetPauseTimeSpan();
                CheckJustFinished();
                _raceLaneModel.CalcCurrentLaneStatus();
                CalcPenalties();
                _raceLaneModel.CalcPositionsOfAllLanes();
                _raceLaneModel.RaiseEventWithLaneChanged(laneChangedHandler);
                ResetLaneAttributes();
            }
        }

        private void CheckToRemoveOrResetPenalties()
        {
            if (CurrentLaneHasExpiredPenalty)
            {
                if (_raceSettings.ResetPenaltiesAfterInvalidLap)
                    CurrentLane.ActivePenaltiesLapsLeftToStop = _raceSettings.LapsToStopForPenalty + 1;
                if (_raceSettings.PenaltiesToRemoveAfterInvalidLap > 0)
                    RemovePenalties();
            }
        }

        private void RemovePenalties()
        {
            CurrentLane.ActivePenaltiesLapsLeftToStop = PenaltyOfCurrentLane.LapsLeftToStop;
            for (int i = 0; i < _raceSettings.PenaltiesToRemoveAfterInvalidLap; i++)
            {
                if (CurrentLane.PenaltyQueue.Count < 1)
                    break;
                CurrentLane.PenaltyQueue.Dequeue();
            }
        }

        private void CheckToResetPauseTimeSpan()
        {
            if (!_lapAutoDetected && !_lapManuallyAdded)
                CurrentLane.ResetPauseTimeSpan();
        }

        private void CheckToAddLap()
        {
            if (CurrentLaneIsAllowedToAddLap)
                RaceModel.RaceHandler.AddLapFor(CurrentLane.Id);
        }

        private RaceLaneModel.LaneChangedHandler GetLaneChangedHandler()
        {
            RaceLaneModel.LaneChangedHandler laneChangedHandler;
            if (CurrentLaneIsAllowedToAddLap)
            {
                if (_lapAutoDetected)
                    laneChangedHandler = AutoDetectedLapAdded;
                else
                    laneChangedHandler = LapAdded;
            }
            else
            {
                if (_lapAutoDetected)
                    laneChangedHandler = null;
                else
                    laneChangedHandler = LapNotAddedDuePenaltyOrNoFuel;
            }
            return laneChangedHandler;
        }

        private void CheckToSetLastTimeALapAlsoIrregularWasAdded()
        {
            if (!_lapManuallyAdded && !_lapAutoDetected)
                RaceModel.RaceHandler.SetLastTimeALapAlsoIrregularWasAdded(CurrentLane.Id, _timeStampLapWasDetected);
        }

        private void CheckToHandleAutoDetectedLap()
        {
            if (_lapAutoDetected)
            {
                if (CurrentLane.Lap == -1)
                {
                    CurrentLane.ZerothLapWasAutoDetected = true;
                    RaceModel.RaceHandler.SetTimeAutoDetectedZerothLapWasAdded(CurrentLane.Id, _timeStampLapWasDetected);
                }
                else
                {
                    CurrentLane.LastLapsAutoDetectedCount++;
                    RaceModel.RaceHandler.SetLastTimeAutoDetectedLapWasAdded(CurrentLane.Id, _timeStampLapWasDetected);
                }
            }
            else
                CurrentLane.LastLapsAutoDetectedCount = 0;
        }

        private void CheckToCalcFuelConsumption()
        {
            if (_calcLapTime && CurrentLane.CalcLapTime && !LaneMadeFalseStart && !CurrentLane.FuelLevelChangedByDialog)
            {
                CalcFuelConsumption();
                CalcFuelConsumptionAverage();
            }
            else
                CurrentLane.FuelConsumptionPerLap = null;
        }

        private void CheckToCalcLapTime()
        {
            if (_calcLapTime && CurrentLane.CalcLapTime && !LaneMadeFalseStart)
                CalcCurrentLaneLapTimes();
            else
            {
                CurrentLane.LapTime = null;
                CurrentLane.LapTimeNet = null;
                CurrentLane.FuelLevelOfLastLap = CurrentLane.CurrentFuelLevelInLitres;
            }
        }

        private void ResetLaneAttributes()
        {
            CurrentLane.IsPitstopAllowed = true;
            CurrentLane.SpeedSum = 0;
            CurrentLane.PositionOfLastLap = CurrentLane.Position;
            CurrentLane.FuelLevelChangedByDialog = false;
        }

        private void CheckToCalcCurrentLaneBestLapTime()
        {
            if (_calcLapTime && CurrentLane.CalcLapTime && CurrentLaneIsAllowedToAddLap && !LaneMadeFalseStart)
                CalcCurrentLaneBestLapTime();
        }

        private void CalcWasLastLapAndPenaltyExisted()
        {
            CurrentLane.WasLastLapAndPenaltyExisted = CurrentLane.Lap == RaceModel.Race.LapsToDrive - 1 &&
                                                      CurrentLane.PenaltyQueue.Count > 0 && 
                                                      PenaltyOfCurrentLane.LapsLeftToStop > 1;
        }

        private void CheckJustFinished()
        {
            if (RaceModel.Race.IsLaneJustFinished(CurrentLane))
                _raceLaneModel.RaiseEvent(Finished);
        }

        private bool CurrentLaneIsAllowedToAddLap
        {
            get
            {
                return CurrentLane.CurrentFuelLevelInLitres > 0 && 
                       PenaltyOfCurrentLane.LapsLeftToStop > 1 && 
                       CurrentLane.WasLastLapAndPenaltyExisted == false;
            }
        }

        private bool CurrentLaneHasExpiredPenalty
        {
            get { return PenaltyOfCurrentLane.LapsLeftToStop <= 1 && CurrentLane.WasLastLapAndPenaltyExisted == false; }
        }

        private void CalcCurrentLaneLapTimes()
        {
            if (CurrentLane.LastTimeALapAlsoIrregularWasAdded != null)
            {
                TimeSpan lapTime = _timeStampLapWasDetected - (DateTime)CurrentLane.LastTimeALapAlsoIrregularWasAdded;
                CurrentLane.LapTime = lapTime;
                CurrentLane.LapTimeNet = lapTime - CurrentLane.PauseTimeSpan;
            }
        }

        private void CalcFuelConsumption()
        {
            CurrentLane.FuelConsumptionPerLap = null;
            if (CurrentLane.FuelLevelOfLastLap != null)
            {
                float fuelConsumptionPerLap = (float)CurrentLane.FuelLevelOfLastLap - CurrentLane.CurrentFuelLevelInLitres;
                if (fuelConsumptionPerLap > 0)
                {
                    CurrentLane.FuelConsumptionPerLap = fuelConsumptionPerLap;
                    CurrentLane.LapsWithFuelConsumption++;
                }
            }
            CurrentLane.FuelLevelOfLastLap = CurrentLane.CurrentFuelLevelInLitres;
        }

        private void CalcFuelConsumptionAverage()
        {
            if (CurrentLane.LapsWithFuelConsumption > 0 && CurrentLane.FuelConsumptionPerLap != null)
            {
                CurrentLane.FuelConsumptionOverall += (float)CurrentLane.FuelConsumptionPerLap;
                CurrentLane.FuelConsumptionAverage = CurrentLane.FuelConsumptionOverall / CurrentLane.LapsWithFuelConsumption;
            }
        }

        private void CalcCurrentLaneBestLapTime()
        {
            if (CurrentLane.LapTimeNet < CurrentLane.BestLapTime ||
                    CurrentLane.BestLapTime == null ||
                    CurrentLane.BestLapTime == new TimeSpan())
                CurrentLane.BestLapTime = CurrentLane.LapTimeNet;
        }

        private void CalcPenalties()
        {
            if (PenaltyOfCurrentLane.LapsLeftToStop > 0)
                PenaltyOfCurrentLane.LapsLeftToStop -= 1;
        }

        private Penalty PenaltyOfCurrentLane
        {
            get
            {
                Penalty penalty = new PenaltyNullObject(100);
                if (CurrentLane.PenaltyQueue.Count > 0)
                    penalty = CurrentLane.PenaltyQueue.Peek();
                return penalty;
            }
        }

        private bool LaneMadeFalseStart
        {
            get { return CurrentLane.LastFalseStartDateTime.HasValue; }
        }

    }
}
