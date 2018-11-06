using System;
using System.Text;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Races;
using Elreg.Log;

namespace Elreg.Logger
{
    public class RaceLogger : LoggerBase, IRaceObserver
    {
        private string _action;
        private readonly StringBuilder _logTextBuilder = new StringBuilder();
        private readonly StringBuilder _extraTextBuilder = new StringBuilder();
        private Lane _lane;
        private string _driverInfo = string.Empty;
        private readonly IRaceModel _raceModel;
        private string _raceEventText;
        private string _timestamp;
        private const string LoggerNameConst = "RaceLog";
        private const int MaxLinesInChapterConst = 1;
        private const string Separator = "; ";
        private const string Assigner = ": ";

        public const string TimeStampTag = "TimeStamp";
        public const string LaptimeTag = "LapTime";
        public const string PenaltiesTag = "Penalties";
        public const string DriverTag = "Driver";
        public const string LapsTag = "Laps";
        public const string PositionTag = "Position";
        public const string EventIdTag = "EventId";

        public RaceLogger(IRaceModel raceModel) : base(true)
        {
            _raceModel = raceModel;
        }

        public new bool Activated
        {
            get { return base.Activated; }
            set 
            {
                if (!base.Activated && value)
                    StartLogging();
                else if (base.Activated && !value)
                {
                    _raceModel.Detach(this);
                }
                base.Activated = value; 
            }
        }

        public void RaceChanged(object sender, EventArgs e) {  }

        public void RaceStatusChanged(object sender, EventArgs e)
        {
            try
            {
                string logText = "Race Status: " + _raceModel.Race.Status;
                RaceEvent raceEvent = DetermineRaceEventBy(_raceModel.Race.Status);
                Log(logText, raceEvent);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private RaceEvent DetermineRaceEventBy(Race.StatusEnum status)
        {
            RaceEvent raceEvent = RaceEvent.Undefined;

            switch (status)
            {
                case Race.StatusEnum.Started:
                    raceEvent = RaceEvent.RaceStarted;
                    break;
                case Race.StatusEnum.Restarted:
                    raceEvent = RaceEvent.RaceRestarted;
                    break;
                case Race.StatusEnum.Stopped:
                    raceEvent = RaceEvent.RaceStopped;
                    break;
                case Race.StatusEnum.Finished:
                    raceEvent = RaceEvent.RaceFinished;
                    break;
                case Race.StatusEnum.PausedByKeyboard:
                case Race.StatusEnum.PausedByArduino:
                case Race.StatusEnum.PausedBeforeStart:
                    raceEvent = RaceEvent.RacePaused;
                    break;
            }
            return raceEvent;
        }

        public void LapAdded(LaneId laneId)
        {
            try
            {
                FindAndSetLane(laneId);
                AppendExtraTextOfLane();
                LogWithLane("Lap added", RaceEvent.LapAdded);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void LapNotAddedDueMinSeconds(LaneId laneId)
        {
            try
            {
                FindAndSetLane(laneId);
                AppendExtraTextOfLane();
                LogWithLane("Lap detected but not added due minimum lap time", RaceEvent.InvalidLapDueMinLapTime);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void PenaltyAdded(LaneId laneId)
        {
            try
            {
                FindAndSetLane(laneId);
                AppendExtraTextOfLane();
                LogWithLane("Penalty added", RaceEvent.PenaltyAdded);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void Disqualified(LaneId laneId)
        {
            try
            {
                FindAndSetLane(laneId);
                AppendExtraTextOfLane();
                LogWithLane("Disqualified", RaceEvent.LaneDisqualified);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void Finished(LaneId laneId)
        {
            try
            {
                FindAndSetLane(laneId);
                AppendExtraTextOfLane();
                LogWithLane("Finished", RaceEvent.LaneFinished);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void LaneChanged(LaneId laneId) {}

        public override string LoggerName
        {
            get { return LoggerNameConst; }
        }

        protected override int MaxLinesInChapter
        {
            get { return MaxLinesInChapterConst; }
        }

        protected override void StartLogging()
        {
            base.StartLogging();
            _raceModel.Attach(this);
        }

        private void LogWithLane(string action, RaceEvent raceEvent)
        {
            _driverInfo = DriverTag + Assigner + _lane.Driver.Name + Separator;
            Log(action, raceEvent);
        }

        private void Log(string action, RaceEvent raceEvent)
        {
            _timestamp = TimeStampTag + Assigner + TextLogger.TimeStamp + Separator;
            _action = action + Separator;
            _raceEventText = EventIdTag + Assigner + (int)raceEvent + Separator;
            CreateLogText();
            TextLogger.Log(_logTextBuilder.ToString());
            _driverInfo = string.Empty;
            _extraTextBuilder.Clear();
        }

        private void CreateLogText()
        {
            _logTextBuilder.Clear();
            _logTextBuilder.Append(_timestamp);
            _logTextBuilder.Append(_action);
            _logTextBuilder.Append(_raceEventText);
            _logTextBuilder.Append(_driverInfo);
            _logTextBuilder.Append(_extraTextBuilder);
        }

        private void FindAndSetLane(LaneId laneId)
        {
            _lane = _raceModel.RaceHandler.GetLaneById(laneId);
        }

        private void AppendExtraTextOfLane()
        {
            ClearExtraText();
            AppendExtraTextWithLaps();
            AppendExtraTextWithPenalties();
            AppendExtraTextWithLapTime();
            AppendExtraTextWithPosition();
        }

        private void AppendExtraTextWithLapTime()
        {
            _extraTextBuilder.Append(LaptimeTag);
            _extraTextBuilder.Append(Assigner);
            _extraTextBuilder.Append(Format(_lane.LapTimeNet));
            _extraTextBuilder.Append(Separator);
        }

        private void ClearExtraText()
        {
            _extraTextBuilder.Clear();
        }

        private void AppendExtraTextWithPenalties()
        {
            _extraTextBuilder.Append(PenaltiesTag);
            _extraTextBuilder.Append(Assigner);
            _extraTextBuilder.Append(_lane.PenaltyCount);
            _extraTextBuilder.Append(Separator);
        }

        private void AppendExtraTextWithLaps()
        {
            _extraTextBuilder.Append(LapsTag);
            _extraTextBuilder.Append(Assigner);
            _extraTextBuilder.Append(_lane.Lap);
            _extraTextBuilder.Append(Separator);
        }

        private void AppendExtraTextWithPosition()
        {
            _extraTextBuilder.Append(PositionTag);
            _extraTextBuilder.Append(Assigner);
            _extraTextBuilder.Append(_lane.Position + Separator);
        }

        private string Format(TimeSpan? timeSpan)
        {
            string formattedValue = string.Empty;

            if (timeSpan != null)
                formattedValue = (DateTime.MinValue + (TimeSpan)timeSpan).ToString("hh:mm:ss.fff");
            return formattedValue;
        }

    }
}
