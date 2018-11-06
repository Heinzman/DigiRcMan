using System;
using Elreg.BusinessObjects.Lanes;

namespace Elreg.BusinessObjects.Races.Types
{
    [Serializable]
    public class Training : BaseRaceType
    {
        public Training(Race race) : base(race) { }

        public override bool IsStartCountDownActivated
        {
            get { return Race.RaceSettings.StartCountDownTrainingActivated; }
        }

        public override bool IsRestartCountDownActivated
        {
            get { return Race.RaceSettings.RestartCountDownTrainingActivated; }
        }

        public override int StartCountDownInitNo
        {
            get { return Race.RaceSettings.StartCountDownTrainingInitNo; }
        }

        public override int RestartCountDownInitNo
        {
            get { return Race.RaceSettings.RestartCountDownTrainingInitNo; }
        }

        public override Race.TypeEnum Type
        {
            get { return Race.TypeEnum.Training; }
        }

        public override bool IsRaceFinished
        {
            get
            {
                bool finished = false;
#if IsProtectedVersion
                foreach (Lane lane in Race.Lanes)
                {
                    int count = lane.Lap + 20;
                    if (count > 34)
                    {
                        finished = true;
                        break;
                    }
                }
#endif
                return finished;
            }           
        }
    }
}
