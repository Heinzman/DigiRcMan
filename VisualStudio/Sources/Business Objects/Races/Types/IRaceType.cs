using Elreg.BusinessObjects.Lanes;

namespace Elreg.BusinessObjects.Races.Types
{
    public interface IRaceType
    {
        Race.TypeEnum Type { get; }
        int GetLapNumberOf(Lane lane);
        bool IsStartCountDownActivated { get;}
        bool IsRestartCountDownActivated { get; }
        int StartCountDownInitNo { get; }
        int RestartCountDownInitNo { get; }
        bool IsLaneJustFinished(Lane lane);
        void OrderByPosition();
        void CalcLaneStatus(Lane lane);
        bool IsRaceFinished { get; }
        bool ShouldRaceBeBreaked { get; }
        bool ShouldRaceResultBeShown { get; }
    }
}