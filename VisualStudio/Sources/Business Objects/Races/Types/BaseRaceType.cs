using Elreg.BusinessObjects.Lanes;

namespace Elreg.BusinessObjects.Races.Types
{
    public abstract class BaseRaceType : IRaceType
    {
        protected readonly Race Race;

        protected BaseRaceType(Race race)
        {
            Race = race;
        }

        public abstract bool IsStartCountDownActivated { get; }

        public abstract bool IsRestartCountDownActivated { get; }

        public abstract int StartCountDownInitNo { get; }

        public abstract int RestartCountDownInitNo { get; }

        public abstract Race.TypeEnum Type { get; }

        public int GetLapNumberOf(Lane lane)
        {
            return lane.Lap;
        }

        public virtual bool IsLaneJustFinished(Lane lane)
        {
            return false;
        }

        public void OrderByPosition()
        {
            Race.Lanes.Sort(SortLanesByLapTime);
        }

        public virtual void CalcLaneStatus(Lane lane)
        {
            // nothing to do
        }

        public abstract bool IsRaceFinished { get; }

        public virtual bool ShouldRaceBeBreaked
        {
            get { return false; }
        }

        public bool ShouldRaceResultBeShown
        {
            get { return ExistSeveralLapsInRace(Race); }
        }

        public static bool ExistSeveralLapsInRace(Race race)
        {
            const int minLaps = 1;
            bool existSeveralLaps = false;

            foreach (Lane lane in race.Lanes)
            {
                if (lane.Lap >= minLaps)
                {
                    existSeveralLaps = true;
                    break;
                }
            }
            return existSeveralLaps;
        }

        private int SortLanesByLapTime(Lane lane1, Lane lane2)
        {
            int returnValue = -1;
            if (lane2.BestLapTime < lane1.BestLapTime || lane2.BestLapTime.HasValue && !lane1.BestLapTime.HasValue)
                returnValue = 1;
            else if (lane2.BestLapTime == lane1.BestLapTime)
                returnValue = lane1.Id.CompareTo(lane2.Id);
            return returnValue;
        }
    }
}