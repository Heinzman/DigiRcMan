using Heinzman.BusinessObjects.Interfaces;
using Heinzman.BusinessObjects.Races;

namespace Heinzman.DomainModels.RaceModel
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
            get { return Race != null && Race.Status == Race.StatusEnum.Started; }
        }

        public bool IsRaceStartedOrInCountDown
        {
            get { return IsRaceStarted || IsRaceInCountDown; }
        }

        public bool IsRacePaused
        {
            get { return IsRacePausedByKeyboard || IsRacePausedByParallelPort; }
        }

        public bool IsRaceStartedOrInRestartCountDown
        {
            get { return IsRaceStarted || IsRaceInRestartCountDown; }
        }

        public bool IsRacePausedByKeyboard
        {
            get { return Race != null && Race.Status == Race.StatusEnum.PausedByKeyboard; }
        }

        public bool IsRacePausedOrBreaked
        {
            get { return IsRacePaused || IsRaceBreaked; }
        }

        public bool IsRacePausedOrInRestartCountDown
        {
            get { return IsRacePaused || IsRaceInRestartCountDown; }
        }

        public bool IsRacePausedByParallelPort
        {
            get { return Race != null && Race.Status == Race.StatusEnum.PausedByParallelPort; }
        }

        public bool IsRaceFinished
        {
            get { return Race != null && Race.Status == Race.StatusEnum.Finished; }
        }

        public bool IsRaceWaitingForStart
        {
            get { return Race != null && Race.Status == Race.StatusEnum.WaitingForStartByParallelPort; }
        }

        public bool IsRaceInCountDown
        {
            get { return IsRaceInStartCountDown || IsRaceInRestartCountDown; }
        }

        public bool IsRaceBreaked
        {
            get { return Race != null && Race.Status == Race.StatusEnum.Breaked; }
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
