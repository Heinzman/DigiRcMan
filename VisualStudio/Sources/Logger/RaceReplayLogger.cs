using System;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Races;
using Elreg.Log;

namespace Elreg.Logger
{
    public class RaceReplayLogger : LoggerBase, IRaceObserver
    {
        private readonly IRaceModel _raceModel;
        private readonly IRaceReplayLoggerModel _raceReplayLoggerModel;
        private Race.StatusEnum _previousRaceStatus = Race.StatusEnum.Undefined;

        private const int MaxLinesInChapterConst = 1;
        private const string LoggerNameConst = "RaceReplayLog";

        public RaceReplayLogger(IRaceModel raceModel, IRaceReplayLoggerModel raceReplayLoggerModel) : base(true)
        {
            _raceModel = raceModel;
            _raceReplayLoggerModel = raceReplayLoggerModel;
        }

        public new bool Activated
        {
            get { return base.Activated; }
            set
            {
                if (!base.Activated && value)
                {
                    _raceModel.Attach(this);
                    base.StartLogging();
                }
                else if (base.Activated && !value)
                {
                    _raceModel.Detach(this);
                }
                base.Activated = value;
            }
        }

        protected override int MaxLinesInChapter
        {
            get { return MaxLinesInChapterConst; }
        }

        public override string LoggerName
        {
            get { return LoggerNameConst; }
        }

        public void LaneChanged(LaneId laneId)
        {
        }

        public void RaceStatusChanged(object sender, EventArgs e)
        {
            if (_raceModel.Race.Status != _previousRaceStatus)
            {
                if (_raceModel.Race.Status == Race.StatusEnum.StartCountDown)
                {
                    StartLogging();
                    Log(RaceEvent.StartCountDown);
                }
                else if (_raceModel.Race.Status == Race.StatusEnum.Started)
                { 
                    if (_previousRaceStatus != Race.StatusEnum.StartCountDown)
                        StartLogging();
                    Log(RaceEvent.RaceStarted);
                }
                else if (_raceModel.Race.Status == Race.StatusEnum.RestartCountDown)
                {
                    Log(RaceEvent.RestartCountDown);
                }
                else if (_raceModel.Race.Status == Race.StatusEnum.Finished)
                {
                    Log(RaceEvent.RaceFinished);
                    StopLogging();
                }
                else if (_raceModel.Race.Status == Race.StatusEnum.Stopped)
                {
                    Log(RaceEvent.RaceStopped);
                    StopLogging();
                }
                else if (_raceModel.Race.Status == Race.StatusEnum.PausedByArduino ||
                         _raceModel.Race.Status == Race.StatusEnum.PausedByKeyboard ||
                         _raceModel.Race.Status == Race.StatusEnum.PausedBeforeStart)
                {
                    Log(RaceEvent.RacePaused);
                }

                _previousRaceStatus = _raceModel.Race.Status;
            }
        }

        public void LapAdded(LaneId laneId)
        {
            Log(laneId, RaceEvent.LapAdded);
        }

        private void Log(LaneId laneId, RaceEvent raceEvent)
        {
            try
            {
                string text = _raceReplayLoggerModel.CreateTextToLogOf(laneId, raceEvent);
                text += ",";
                TextLogger.Log(text);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void Log(RaceEvent raceEvent)
        {
            try
            {
                string text = _raceReplayLoggerModel.CreateTextToLog(raceEvent);
                text += ",";
                TextLogger.Log(text);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void LapNotAddedDueMinSeconds(LaneId laneId)
        {
            Log(laneId, RaceEvent.InvalidLapDueMinLapTime);
        }

        public void Finished(LaneId laneId)
        {
            Log(laneId, RaceEvent.LaneFinished);
        }

        public void RaceChanged(object sender, EventArgs e)
        {
        }

        public void PenaltyAdded(LaneId laneId)
        {
            Log(laneId, RaceEvent.PenaltyAdded);
        }

        public void Disqualified(LaneId laneId)
        {
            Log(laneId, RaceEvent.LaneDisqualified);
        }

    }
}
