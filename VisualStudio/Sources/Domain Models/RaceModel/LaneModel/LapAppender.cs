using System;
using Elreg.BusinessObjects.Lanes;

namespace Elreg.DomainModels.RaceModel.LaneModel
{
    public class LapAppender
    {
        private readonly RaceLaneModel _raceLaneModel;
        private bool _calcLapTime;
        private bool _lapManuallyAdded;
        private DateTime _timeStampLapWasDetected;

        public event RaceLaneModel.LaneChangedHandler LapAdded;
        public event RaceLaneModel.LaneChangedHandler Finished;

        public LapAppender(RaceLaneModel raceLaneModel)
        {
            _raceLaneModel = raceLaneModel;
        }

        public void AddLapManually()
        {
            _timeStampLapWasDetected = DateTime.Now;
            _calcLapTime = false;
            _lapManuallyAdded = true;
            CheckAndHandleLapAddition();
        }

        public void AddLapWithLapTime(DateTime? timeStamp)
        {
            _timeStampLapWasDetected = timeStamp ?? DateTime.Now;
            _calcLapTime = true;
            _lapManuallyAdded = false;
            CheckAndHandleLapAddition();
        }

        private Lane CurrentLane { get { return _raceLaneModel.CurrentLane; } }

        private RaceModel RaceModel { get { return _raceLaneModel.RaceModel; } }

        private void CheckAndHandleLapAddition()
        {
            if (_raceLaneModel.LaneIsInRaceAndRaceIsInStartedOrCountDownOrPaused)
            {
                CheckToCalcLapTime();
                CheckToCalcCurrentLaneBestLapTime();
                RaceModel.RaceHandler.AddLapFor(CurrentLane.Id);
                CheckToSetLastTimeALapWasAdded();
                CurrentLane.CalcLapTime = _calcLapTime;
                RaceLaneModel.LaneChangedHandler laneChangedHandler = GetLaneChangedHandler();

                RaceModel.CalcPositionsOfAllLanes();
                RaceModel.CalcDeltaLapTime(CurrentLane);
                bool isJustFinished = IsCurrentLaneJustFinished();
                _raceLaneModel.CalcCurrentLaneStatus();
                _raceLaneModel.RaiseEventWithLaneChanged(laneChangedHandler);

                if (isJustFinished)
                    _raceLaneModel.RaiseEvent(Finished);

                ResetLaneAttributes();
            }
        }

        private RaceLaneModel.LaneChangedHandler GetLaneChangedHandler()
        {
            RaceLaneModel.LaneChangedHandler laneChangedHandler = LapAdded;
            return laneChangedHandler;
        }

        private void CheckToSetLastTimeALapWasAdded()
        {
            if (!_lapManuallyAdded)
                RaceModel.RaceHandler.SetLastTimeALapWasAdded(CurrentLane.Id, _timeStampLapWasDetected);
        }

        private void CheckToCalcLapTime()
        {
            if (_calcLapTime && CurrentLane.CalcLapTime)
                CalcCurrentLaneLapTimes();
            else
            {
                CurrentLane.LapTime = null;
                CurrentLane.LapTimeNet = null;
            }
        }

        private void ResetLaneAttributes()
        {
            CurrentLane.PositionOfLastLap = CurrentLane.Position;
            CurrentLane.PauseTimeSpan = new TimeSpan();
        }

        private void CheckToCalcCurrentLaneBestLapTime()
        {
            if (_calcLapTime && CurrentLane.CalcLapTime)
                CalcCurrentLaneBestLapTime();
        }

        private bool IsCurrentLaneJustFinished()
        {
            return RaceModel.Race.IsLaneJustFinished(CurrentLane);
        }


        public TimeSpan? CalcLapTimeNet(DateTime timeStampLapWasDetected)
        {
            TimeSpan? lapTimeNet = null;

            if (CurrentLane.LastTimeALapWasAdded != null)
            {
                TimeSpan lapTime = timeStampLapWasDetected - (DateTime)CurrentLane.LastTimeALapWasAdded;
                lapTimeNet = lapTime - CurrentLane.PauseTimeSpan;
            }
            return lapTimeNet;
        }

        private void CalcCurrentLaneLapTimes()
        {
            CurrentLane.LapTimeNet = CalcLapTimeNet(_timeStampLapWasDetected);

            if (CurrentLane.LastTimeALapWasAdded != null)
            {
                TimeSpan lapTime = _timeStampLapWasDetected - (DateTime)CurrentLane.LastTimeALapWasAdded;
                CurrentLane.LapTime = lapTime;
            }
        }

        private void CalcCurrentLaneBestLapTime()
        {
            if (CurrentLane.LapTimeNet < CurrentLane.BestLapTime ||
                    CurrentLane.BestLapTime == null ||
                    CurrentLane.BestLapTime == new TimeSpan())
                CurrentLane.BestLapTime = CurrentLane.LapTimeNet;
        }

    }
}
