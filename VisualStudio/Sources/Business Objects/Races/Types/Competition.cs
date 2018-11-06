using System;
using Elreg.BusinessObjects.Lanes;

namespace Elreg.BusinessObjects.Races.Types
{
    [Serializable]
    public class Competition : IRaceType
    {
        private readonly Race _race;

        public Competition(Race race)
        {
            _race = race;
        }

        public Race.TypeEnum Type
        {
            get { return Race.TypeEnum.Race; }
        }

        public int GetLapNumberOf(Lane lane)
        {
            int lap;
            if (_race.RaceSettings != null && _race.RaceSettings.DescendingLapCount)
            {
                if (lane.Lap <= 0)
                    lap = _race.LapsToDrive;
                else
                    lap = _race.LapsToDrive - lane.Lap;
            }
            else
                lap = lane.Lap;
            return lap;
        }

        public bool IsStartCountDownActivated
        {
            get { return _race.RaceSettings.StartCountDownRaceActivated; }
        }

        public bool IsRestartCountDownActivated
        {
            get { return _race.RaceSettings.RestartCountDownRaceActivated; }
        }

        public int StartCountDownInitNo
        {
            get { return _race.RaceSettings.StartCountDownRaceInitNo; }
        }

        public int RestartCountDownInitNo
        {
            get { return _race.RaceSettings.RestartCountDownRaceInitNo; }
        }

        public bool IsLaneJustFinished(Lane lane)
        {
            return lane.Status == Lane.LaneStatusEnum.Started && lane.Lap == _race.RaceSettings.LapsToDrive;
        }

        public void OrderByPosition()
        {
            _race.Lanes.Sort(SortLanesByLaps);
        }

        public void CalcLaneStatus(Lane lane)
        {
            if (lane.IsStarted && lane.Lap >= _race.LapsToDrive)
            {
                lane.Status = Lane.LaneStatusEnum.Finished;
                lane.RaceTimeNet = _race.RacingTime.NetTimeSpanFromStart;
                lane.RaceTime = _race.RacingTime.GrossTimeSpanFromStart;
            }
            else if (lane.IsFinished && lane.Lap < _race.LapsToDrive)
                lane.Status = Lane.LaneStatusEnum.Started;

        }

        public bool IsRaceFinished
        {
            get
            {
                bool finished = true;
                foreach (Lane lane in _race.Lanes)
                {
                    if (lane.Status != Lane.LaneStatusEnum.Finished && lane.Status != Lane.LaneStatusEnum.Disqualified)
                    {
                        finished = false;
                        break;
                    }
                }
#if IsProtectedVersion
                if (!finished)
                {
                    bool hasMaxLaps = false;
                    foreach (Lane lane in _race.Lanes)
                    {
                        int count = 22 - lane.Lap;
                        if (count < 8)
                        {
                            hasMaxLaps = true;
                            break;
                        }
                    }
                    finished = hasMaxLaps;
                }
#endif
                return finished;
            }
        }

        public bool ShouldRaceBeBreaked
        {
            get { return false; }
        }

        public bool ShouldRaceResultBeShown
        {
            get { return BaseRaceType.ExistSeveralLapsInRace(_race); }
        }

        private int SortLanesByLaps(Lane lane1, Lane lane2)
        {
            int returnValue = -1;

            if (lane2.Id == lane1.Id)
                returnValue = 0;
            else if (lane2.IsDisqualified && !lane1.IsDisqualified)
                returnValue = -1;
            else if (!lane2.IsDisqualified && lane1.IsDisqualified)
                returnValue = 1;
            else if (lane2.IsDisqualified && lane1.IsDisqualified)
                returnValue = lane1.Id.CompareTo(lane2.Id);
            else if (lane2.Lap > lane1.Lap)
                returnValue = 1;
            else if (lane2.Lap == lane1.Lap)
            {
                if (lane2.IsFinished && lane1.IsFinished)
                {
                    if (lane2.RaceTime < lane1.RaceTime)
                        returnValue = 1;
                    else if (lane2.RaceTime == lane1.RaceTime)
                        returnValue = lane1.Id.CompareTo(lane2.Id);
                }
                else if (lane2.IsStarted && lane1.IsStarted)
                {
                    if (lane2.Lap == -1 && lane1.Lap == -1)
                    {
                        returnValue = lane1.Position.CompareTo(lane2.Position);
                    }
                    else
                    {
                        if (lane2.LastTimeALapWasAdded < lane1.LastTimeALapWasAdded)
                            returnValue = 1;
                        else if (lane2.LastTimeALapWasAdded == lane1.LastTimeALapWasAdded)
                            returnValue = lane1.Id.CompareTo(lane2.Id);
                    }
                }
                else if (lane2.IsStarted && lane1.IsFinished)
                    returnValue = -1;
                else if (lane2.IsFinished && lane1.IsStarted)
                    returnValue = 1;
                else
                    returnValue = lane1.Id.CompareTo(lane2.Id);
            }
            return returnValue;
        }

    }
}
