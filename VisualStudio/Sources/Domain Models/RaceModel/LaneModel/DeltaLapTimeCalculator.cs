using System;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;

namespace Elreg.DomainModels.RaceModel.LaneModel
{
    public class DeltaLapTimeCalculator
    {
        private readonly RaceModel _raceModel;
        private Lane _leadingLane;

        public DeltaLapTimeCalculator(RaceModel raceModel)
        {
            _raceModel = raceModel;
        }

        public void DoWork(Lane lane)
        {
            DetermineLeadingLane();

            if (lane == _leadingLane)
                lane.DeltaLapTimeToLeadingLane = null;
            else
                CalcDeltaLapTime(lane);
        }

        private void CalcDeltaLapTime(Lane lane)
        {
            TimeSpan deltaLapTime = new TimeSpan();
            LapTimeStamp leadingLapTimeStamp = _leadingLane.LapTimeStamps.FindLast(leadLap => leadLap.Lap == lane.Lap);
            LapTimeStamp lapTimeStamp = lane.LapTimeStamps.FindLast(currentLap => currentLap.Lap == lane.Lap);
            TimeSpan pausesTimeSpan = GetPausesTimeSpan(leadingLapTimeStamp, lapTimeStamp);

            if (leadingLapTimeStamp != null && lapTimeStamp != null)
                deltaLapTime += lapTimeStamp.TimeStamp - leadingLapTimeStamp.TimeStamp - pausesTimeSpan;

            //if ((!lane.DeltaLapTimeToLeadingLane.HasValue || deltaLapTime > lane.DeltaLapTimeToLeadingLane) && deltaLapTime.TotalMilliseconds > 0)
                lane.DeltaLapTimeToLeadingLane = deltaLapTime;
        }

        private TimeSpan GetPausesTimeSpan(LapTimeStamp leadingLapTimeStamp, LapTimeStamp lapTimeStamp)
        {
            TimeSpan timeSpan = new TimeSpan();
            foreach (RacingTime.PauseTime pauseTime in _raceModel.Race.RacingTime.Pauses)
            {
                if (pauseTime.Start > leadingLapTimeStamp.TimeStamp && pauseTime.Start < lapTimeStamp.TimeStamp)
                    timeSpan += pauseTime.TimeSpan;
            }
            return timeSpan;
        }

        private void DetermineLeadingLane()
        {
            foreach (Lane lane in _raceModel.Race.Lanes)
            {
                if (lane.Position == 1)
                {
                    _leadingLane = lane;
                    break;
                }
            }
        }



    }
}
