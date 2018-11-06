using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Races;

namespace Elreg.DomainModels.RaceModel
{
    public class StatusHandler : IStatusHandler
    {
        public Race Race { private get; set; }

        public bool IsRaceStartedOrPaused
        {
            get { return IsRaceStarted || IsRacePaused; }
        }

        public bool IsRaceStoppedOrFinished
        {
            get { return IsRaceStopped || IsRaceFinished; }
        }

        public bool IsRaceStopped
        {
            get { return Race != null && Race.Status == Race.StatusEnum.Stopped; }
        }

        public bool IsRaceInitialized
        {
            get { return Race != null && Race.Status == Race.StatusEnum.Initialized; }
        }

        public bool IsRaceReadyToStart
        {
            get { return IsRaceInitialized || IsRaceStoppedOrFinished; }
        }

        public bool IsRaceNotSetuped
        {
            get { return Race == null || Race.Status == Race.StatusEnum.Undefined; }
        }

        public bool IsRaceStarted
        {
            get { return Race != null && (Race.Status == Race.StatusEnum.Started || Race.Status == Race.StatusEnum.Restarted); }
        }

        public bool IsRaceStartedOrInCountDown
        {
            get { return IsRaceStarted || IsRaceInCountDown; }
        }

        public bool IsRacePaused
        {
            get { return IsRacePausedByKeyboardOrArduino || IsRacePausedBeforeStart; }
        }

        public bool IsRaceStartedOrInRestartCountDown
        {
            get { return IsRaceStarted || IsRaceInRestartCountDown; }
        }

        public bool IsRacePausedByKeyboardOrArduino
        {
            get { return Race != null && (Race.Status == Race.StatusEnum.PausedByKeyboard || Race.Status == Race.StatusEnum.PausedByArduino); }
        }

        public bool IsRacePausedBeforeStart
        {
            get { return Race != null && (Race.Status == Race.StatusEnum.PausedBeforeStart); }
        }

        public bool IsRacePausedOrInRestartCountDown
        {
            get { return IsRacePaused || IsRaceInRestartCountDown; }
        }

        public bool IsRaceFinished
        {
            get { return Race != null && Race.Status == Race.StatusEnum.Finished; }
        }

        public bool IsRaceInCountDown
        {
            get { return IsRaceInStartCountDown || IsRaceInRestartCountDown; }
        }

        public bool IsRaceInStartCountDown
        {
            get { return Race != null && Race.Status == Race.StatusEnum.StartCountDown; }
        }

        public bool IsRaceInRestartCountDown
        {
            get { return Race != null && Race.Status == Race.StatusEnum.RestartCountDown; }
        }

    }

}
