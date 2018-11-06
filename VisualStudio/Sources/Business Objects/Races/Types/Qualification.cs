using System;
using Elreg.BusinessObjects.Lanes;

namespace Elreg.BusinessObjects.Races.Types
{
    [Serializable]
    public class Qualification : BaseRaceType
    {
        private readonly TimeSpan _qualificationTimeSpan;
        private readonly int _breakSeconds;
        private int _breakCount;

        public Qualification(Race race) : base(race)
        {
            int qualiSeconds = (int)(Race.RaceSettings.QualificationMinutes * 60);
            _qualificationTimeSpan = new TimeSpan(0, 0, qualiSeconds);

            _breakSeconds = (int)(qualiSeconds / (Race.RaceSettings.QualificationBreaks + 1));
        }

        public override bool IsStartCountDownActivated
        {
            get { return Race.RaceSettings.StartCountDownQualiActivated; }
        }

        public override bool IsRestartCountDownActivated
        {
            get { return Race.RaceSettings.RestartCountDownQualiActivated; }
        }

        public override int StartCountDownInitNo
        {
            get { return Race.RaceSettings.StartCountDownQualiInitNo; }
        }

        public override int RestartCountDownInitNo
        {
            get { return Race.RaceSettings.RestartCountDownQualiInitNo; }
        }

        public override Race.TypeEnum Type
        {
            get { return Race.TypeEnum.Qualification; }
        }

        public override bool IsRaceFinished
        {
            get
            {
                bool finished = Race.RaceSettings.QualificationTimeBasedActivated && 
                                Race.RacingTime.NetTimeSpanFromStart >= _qualificationTimeSpan;
#if IsProtectedVersion
                if (!finished)
                {
                    bool hasMaxLaps = false;
                    foreach (Lane lane in Race.Lanes)
                    {
                        int count = lane.Lap + 76;
                        if (count > 90)
                        {
                            hasMaxLaps = true;
                            break;
                        }
                    }
                    finished = hasMaxLaps;
                }
#endif
                if (!finished)
                {
                    bool isLaneInRace = false;
                    foreach (Lane lane in Race.Lanes)
                    {
                        if (lane.Status != Lane.LaneStatusEnum.Finished && lane.Status != Lane.LaneStatusEnum.Disqualified)
                        {
                            isLaneInRace = true;
                            break;
                        }
                    }
                    finished = !isLaneInRace;
                }
                return finished;
            }
        }

        public override bool ShouldRaceBeBreaked
        {
            get
            {
                bool ret = false;
                if (_breakCount < Race.RaceSettings.QualificationBreaks)
                {
                    if (Race.RacingTime.NetTimeSpanFromStart.TotalSeconds >= _breakSeconds*(_breakCount+1))
                    {
                        _breakCount++;
                        ret = true;
                    }
                }
                return ret;
            }
        }

        public override void CalcLaneStatus(Lane lane)
        {
            if (Race.RaceSettings.QualificationLapBasedActivated)
            {
                if (lane.IsStarted && lane.Lap >= Race.RaceSettings.QualificationMaxLaps)
                    lane.Status = Lane.LaneStatusEnum.Finished;
                else if (lane.IsFinished && lane.Lap < Race.RaceSettings.QualificationMaxLaps)
                    lane.Status = Lane.LaneStatusEnum.Started;
            }
        }

        public override bool IsLaneJustFinished(Lane lane)
        {
            return lane.Status == Lane.LaneStatusEnum.Started &&
                   Race.RaceSettings.QualificationLapBasedActivated &&
                   lane.Lap == Race.RaceSettings.QualificationMaxLaps;
        }

    }
}
