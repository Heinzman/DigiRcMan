using Heinzman.BusinessObjects;
using Heinzman.BusinessObjects.Options;
using Heinzman.BusinessObjects.Races;

namespace Heinzman.DomainModels.RaceModel
{
    public class CountDownHelper
    {
        private readonly RaceModel _raceModel;

        public CountDownHelper(RaceModel raceModel)
        {
            _raceModel = raceModel;
        }

        internal bool IsStartCountDownActivated
        {
            get
            {
                return Race.Type == Race.TypeEnum.Competition && RaceSettings.StartCountDownRaceActivated ||
                       Race.Type == Race.TypeEnum.Qualification && RaceSettings.StartCountDownQualiActivated ||
                       Race.Type == Race.TypeEnum.Training && RaceSettings.StartCountDownTrainingActivated;
            }
        }

        internal bool IsRestartCountDownActivated
        {
            get
            {
                return Race.Type == Race.TypeEnum.Competition && RaceSettings.RestartCountDownRaceActivated ||
                       Race.Type == Race.TypeEnum.Qualification && RaceSettings.RestartCountDownQualiActivated ||
                       Race.Type == Race.TypeEnum.Training && RaceSettings.RestartCountDownTrainingActivated;
            }
        }

        internal int StartCountDownInitNo
        {
            get
            {
                int startCountDownInitNo = RaceSettings.StartCountDownRaceInitNo;
                if (Race.Type == Race.TypeEnum.Qualification)
                    startCountDownInitNo = RaceSettings.StartCountDownQualiInitNo;
                else if (Race.Type == Race.TypeEnum.Qualification)
                    startCountDownInitNo = RaceSettings.StartCountDownTrainingInitNo;
                return startCountDownInitNo;
            }
        }

        internal int RestartCountDownRaceInitNo
        {
            get
            {
                int restartCountDownInitNo = RaceSettings.RestartCountDownRaceInitNo;
                if (Race.Type == Race.TypeEnum.Qualification)
                    restartCountDownInitNo = RaceSettings.RestartCountDownQualiInitNo;
                else if (Race.Type == Race.TypeEnum.Qualification)
                    restartCountDownInitNo = RaceSettings.RestartCountDownTrainingInitNo;
                return restartCountDownInitNo;
            }
        }

        private RaceSettings RaceSettings
        { 
            get { return _raceModel.RaceSettings; }
        }

        private Race Race
        {
            get { return _raceModel.Race; }
        }

    }
}
