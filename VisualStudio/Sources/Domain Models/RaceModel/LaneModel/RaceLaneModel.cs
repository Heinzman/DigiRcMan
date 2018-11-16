using System;
using System.Diagnostics;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.Races;
using Elreg.Log;

namespace Elreg.DomainModels.RaceModel.LaneModel
{
    public class RaceLaneModel : IRaceLaneModel
    {
        private readonly LaneId _laneId;
        private readonly RaceSettings _raceSettings;

        public delegate void LaneChangedHandler(LaneId laneId);
        public event LaneChangedHandler LaneChanged;
        public event LaneChangedHandler LapNotAddedDueMinSeconds;
        public event LaneChangedHandler PenaltyAdded;
        public event LaneChangedHandler Disqualified;
        public event LaneChangedHandler LapAdded;
        public event LaneChangedHandler Finished;

        public RaceLaneModel(RaceModel raceModel, LaneId laneId, RaceSettings raceSettings)
        {
            _laneId = laneId;
            RaceModel = raceModel;
            _raceSettings = raceSettings;
            LapAppender = new LapAppender(this);

            DisqualificationDueToLapTimeHandler disqualificationDueToLapTimeHandler = new DisqualificationDueToLapTimeHandler(this, raceSettings);
            disqualificationDueToLapTimeHandler.Disqualified += DisqualificationDueToLapTimeHandlerDisqualified;

            DisqualificationDueToRaceTimeHandler disqualificationDueToRaceTimeHandler = new DisqualificationDueToRaceTimeHandler(this, raceSettings);
            disqualificationDueToRaceTimeHandler.Disqualified += DisqualificationDueToRaceTimeHandlerDisqualified;

            LapAppender.Finished += LapAppenderFinished;
            LapAppender.LapAdded += LapAppenderLapAdded;
            FindAndSetCurrentLane();
        }

        private void DisqualificationDueToRaceTimeHandlerDisqualified(object sender, EventArgs e)
        {
            DisqualifyCurrentLane();
        }

        private void DisqualificationDueToLapTimeHandlerDisqualified(object sender, EventArgs e)
        {
            DisqualifyCurrentLane();
        }

        private void LapAppenderLapAdded(LaneId laneId)
        {
            try
            {
                RaiseEvent(LapAdded);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void LapAppenderFinished(LaneId laneId)
        {
            try
            {
                RaiseEvent(Finished);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void CheckToAddLapWithLapTime(DateTime? timeStamp)
        {
            Debug.WriteLine($"BelongsLapDetectionToPrevious(): {BelongsLapDetectionToPrevious()}");
            Debug.WriteLine($"IsLapValidDueMinSecs(): {IsLapValidDueMinSecs()}");
            if (!BelongsLapDetectionToPrevious())
            {
                if (IsLapValidDueMinSecs())
                {
                    if (CurrentLane.Lap >= 0)
                        AddLapTime();
                    LapAppender.AddLapWithLapTime(timeStamp);
                    CurrentLane.LastTimeALapWasDetected = DateTime.Now;
                }
                else
                {
                    RaiseEventWithLaneChanged(LapNotAddedDueMinSeconds);
                }
            }
            else
            {
                CurrentLane.LastTimeALapWasDetected = DateTime.Now;
            }
        }

        private bool BelongsLapDetectionToPrevious()
        {
            return CurrentLane.Lap >= 0 && 
                   MilliSecondsSinceLastDetection < _raceSettings.MilliSecForIgnoringDetections;
        }

        private void AddLapTime()
        {
            try
            {
                RaceModel.LapTimeAvgCalculator.AddLapTime(LapAppender.CalcLapTimeNet(DateTime.Now));
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private bool IsLapValidDueMinSecs()
        {
            return CurrentLane.Lap == -1 || IsNormalLapAndValidDueMinSecs;
        }

        private bool IsNormalLapAndValidDueMinSecs
        {
            get
            {
                return CurrentLane.Lap > -1 && MilliSecondsSinceLastDetection >= _raceSettings.SecondsForValidLap * 1000;
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
                    RaceModel.CalcPositionsOfAllLanes();
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
                CheckDisqualificationDuePenalties();
            }
        }

        private void CheckDisqualificationDuePenalties()
        {
            if (RaceModel.Race.Type == Race.TypeEnum.Race &&
                _raceSettings.AutoDisqualificationRaceActivated && 
                CurrentLane.PenaltyCount >= _raceSettings.AutoDisqualificationRaceAfterPenalties)
            {
                DisqualifyCurrentLane();
            }
        }

        public void UndoPenaltyFor()
        {
            if (IsLaneInStatusForUndoingPenalty)
            {
                if (IsLaneDisqualifiedDuePenalties)
                    CurrentLane.Status = Lane.LaneStatusEnum.Started;
                if (CurrentLane.PenaltyCount > 0)
                    CurrentLane.PenaltyCount--;
                RaiseEvent(LaneChanged);
            }
        }

        private bool IsLaneInStatusForUndoingPenalty
        {
            get
            {
                bool ret = (RaceModel.StatusHandler.IsRaceStartedOrInCountDown || RaceModel.StatusHandler.IsRacePaused) &&
                           (CurrentLane.IsStartedOrInitialized || IsLaneDisqualifiedDuePenalties);
                return ret;
            }
        }

        private bool IsLaneDisqualifiedDuePenalties
        {
            get
            {
                bool ret = CurrentLane.IsDisqualified && 
                           _raceSettings.AutoDisqualificationRaceActivated &&
                           CurrentLane.PenaltyCount >= _raceSettings.AutoDisqualificationRaceAfterPenalties;
                return ret;
            }
        }

        internal int SecondsSinceLastAddedLap
        {
            get
            {
                TimeSpan timespan = CurrentLane.RaceTimeNet;
                if (CurrentLane.LastTimeALapWasAdded.HasValue)
                    timespan = DateTime.Now - CurrentLane.LastTimeALapWasAdded.Value - CurrentLane.PauseTimeSpan;
                return (int)timespan.TotalSeconds;
            }
        }

        internal int MilliSecondsSinceLastDetection
        {
            get
            {
                TimeSpan timespan = CurrentLane.RaceTimeNet;
                if (CurrentLane.LastTimeALapWasDetected.HasValue)
                    timespan = DateTime.Now - CurrentLane.LastTimeALapWasDetected.Value;
                return (int)timespan.TotalMilliseconds;
            }
        }

        private void DisqualifyCurrentLane()
        {
            CurrentLane.Status = Lane.LaneStatusEnum.Disqualified;
            CurrentLane.RaceTimeNet = RaceModel.Race.RacingTime.NetTimeSpanFromStart;
            CurrentLane.RaceTime = RaceModel.Race.RacingTime.GrossTimeSpanFromStart;
            RaceModel.CalcPositionsOfAllLanes();
            RaiseEventWithLaneChanged(Disqualified);
        }

        internal Lane CurrentLane { get; private set; }

        internal RaceModel RaceModel { get; private set; }

        private void AddPenaltyForced()
        {
            CurrentLane.PenaltyCount++;
        }

        private void FindAndSetCurrentLane()
        {
            CurrentLane = RaceModel.RaceHandler.GetLaneById(_laneId);
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

        private bool CurrentLaneIsStartedOrInitialized
        {
            get { return CurrentLane != null && CurrentLane.IsStartedOrInitialized; }
        }

        internal void CalcCurrentLaneStatus()
        {
            RaceModel.Race.CalcLaneStatus(CurrentLane);
        }

        internal bool LaneIsInRaceAndRaceIsInStartedOrCountDownOrPaused
        {
            get
            {
                return CurrentLaneIsStartedOrInitialized &&
                       (RaceModel.StatusHandler.IsRaceStartedOrInCountDown || RaceModel.StatusHandler.IsRacePaused);
            }
        }

        internal bool LaneIsInRaceAndRaceIsInStartedOrCountDown
        {
            get { return CurrentLaneIsStartedOrInitialized && RaceModel.StatusHandler.IsRaceStartedOrInCountDown; }
        }

        internal LapAppender LapAppender { get; private set; }
    }
}
