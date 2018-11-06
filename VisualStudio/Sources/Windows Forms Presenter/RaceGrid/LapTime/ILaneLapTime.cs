namespace Elreg.WindowsFormsPresenter.RaceGrid.LapTime
{
    public interface ILaneLapTime
    {
        void HandleLapAdded();
        void HandleLapNotAddedDuePenaltyOrNoFuel();
        void HandleLapNotAddedDueMinSeconds();
        void HandleAutoDetectedLapAdded();
        void HandleFinished();
        void HandleRacePaused();
        void HandleRaceRestarted();
        void Reset();
        void ResetBackgroundColor();
    }
}