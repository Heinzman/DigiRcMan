using System.Collections.Generic;
using Heinzman.BusinessObjects;
using Heinzman.BusinessObjects.Lanes;
using Heinzman.BusinessObjects.Races;
using Heinzman.RaceRecovery;

namespace Heinzman.DomainModels.RaceControl
{
    public class RaceRecovery
    {
        private readonly ApplicationSettingsService _applicationSettingsService;
        private readonly RaceModel.RaceModel _raceModel;
        private bool? _isRaceInProgress;
        private Race.StatusEnum _lastRaceStatus = Race.StatusEnum.Undefined;

        public RaceRecovery(ApplicationSettingsService applicationSettingsService, RaceModel.RaceModel raceModel)
        {
            _applicationSettingsService = applicationSettingsService;
            _raceModel = raceModel;
        }

        public bool WasRaceCrashedInLastAppRun
        {
            get
            {
                return !_applicationSettingsService.ApplicationSettings.IsAppClosedNormally &&
                       _applicationSettingsService.ApplicationSettings.IsRaceInProgress;
            }
        }

        private bool HasRaceInProgressChanged
        {
            get { return _isRaceInProgress != null; }
        }

        private bool IsRaceInAStartedStatus
        {
            get { return IsInStartedStatus(_raceModel.Race.Status); }
        }

        private bool IsLastRaceInAStartedStatus
        {
            get { return IsInStartedStatus(_lastRaceStatus); }
        }

        public void SaveFlagAppClosedNormally(bool isAppClosedNormally)
        {
            _applicationSettingsService.ApplicationSettings.IsAppClosedNormally = isAppClosedNormally;
            _applicationSettingsService.Save();
        }

        public void ClearFlagRaceInProgress()
        {
            _applicationSettingsService.ApplicationSettings.IsRaceInProgress = false;
            _applicationSettingsService.Save();
        }

        public void RestoreCrashedRace()
        {
            var raceRecoveryService = new RaceRecoveryService();
            Race race = raceRecoveryService.Race;
            List<InitialLane> initialLanes = raceRecoveryService.InitialLanes;

            _raceModel.RestoreRace(race, initialLanes);
            PauseRace();
        }

        public void CheckToSetFlagIsRaceInProgress()
        {
            DetermineIsRaceInProgress();
            if (HasRaceInProgressChanged)
            {
                if (_isRaceInProgress != null)
                    _applicationSettingsService.ApplicationSettings.IsRaceInProgress = (bool) _isRaceInProgress;
                _applicationSettingsService.Save();
            }
        }

        private void DetermineIsRaceInProgress()
        {
            _isRaceInProgress = null;
            if (_raceModel.Race.IsCompetition)
            {
                if (IsRaceInAStartedStatus && !IsLastRaceInAStartedStatus)
                    _isRaceInProgress = true;
                else if (!IsRaceInAStartedStatus && IsLastRaceInAStartedStatus)
                    _isRaceInProgress = false;
            }
            _lastRaceStatus = _raceModel.Race.Status;
        }

        private bool IsInStartedStatus(Race.StatusEnum status)
        {
            return status == Race.StatusEnum.Started ||
                   status == Race.StatusEnum.RestartCountDown ||
                   status == Race.StatusEnum.PausedByKeyboard;
        }

        private void PauseRace()
        {
            if (_raceModel.IsPauseByParallelPortPossible)
                _raceModel.PauseRaceByParallelPort();
            else
                _raceModel.PauseRaceByKeyboard();
        }
    }
}