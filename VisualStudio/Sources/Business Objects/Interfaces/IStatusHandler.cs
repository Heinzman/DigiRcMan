namespace Elreg.BusinessObjects.Interfaces
{
    public interface IStatusHandler
    {
        bool IsRaceStartedOrPaused { get; }
        bool IsRaceStopped { get; }
        bool IsRaceStoppedOrFinished { get; }
        bool IsRaceInitialized { get; }
        bool IsRaceReadyToStart { get; }
        bool IsRaceNotSetuped { get; }
        bool IsRaceStarted { get; }
        bool IsRaceStartedOrInCountDown { get; }
        bool IsRacePaused { get; }
        bool IsRaceStartedOrInRestartCountDown { get; }
        bool IsRacePausedBeforeStart { get; }
        bool IsRacePausedByKeyboardOrArduino { get; }
        bool IsRacePausedOrInRestartCountDown { get; }
        bool IsRaceFinished { get; }
        bool IsRaceInCountDown { get; }
        bool IsRaceInStartCountDown { get; }
        bool IsRaceInRestartCountDown { get; }
    }
}