using System;
using System.Collections.Generic;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Options;
using Elreg.Exceptions;
using Elreg.HelperClasses;
using Elreg.Log;
using Elreg.RaceSound.Interfaces;
using Elreg.RaceSound.Sound3D;
using Elreg.RaceSound.StereoSound;
using Elreg.RaceSoundService;
using Microsoft.DirectX;

namespace Elreg.CarSound
{
    public class RaceCarSoundHandler : ILaneBaseObserver
    {
        private readonly IRaceModel _raceModel;
        private readonly RaceSettings _raceSettings;
        private readonly List<IRaceCarSoundPlayer> _raceCarSoundPlayers = new List<IRaceCarSoundPlayer>();
        private readonly CarSoundsService _carSoundsService;

        public RaceCarSoundHandler(IRaceModel raceModel, RaceSettings raceSettings, CarSoundsService carSoundsService)
        {
            _raceModel = raceModel;
            _raceSettings = raceSettings;
            _carSoundsService = carSoundsService;
            AttachToModelAsObserver();
            CarSoundsService.SurroundSoundChanged += CarSoundsServiceSurroundSoundChanged;
        }

        private void CarSoundsServiceSurroundSoundChanged(object sender, BusinessObjects.DerivedEventArgs.SurroundSoundEventArgs e)
        {
            try
            {
                if (!_raceModel.StatusHandler.IsRaceNotSetuped && !_raceModel.StatusHandler.IsRaceStoppedOrFinished)
                {
                    CreateRaceCarSoundPlayers();
                    CheckToMuteOrUnmuteSounds();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private bool Is3D
        {
            get { return _raceSettings.SurroundActivated; }
        }

        public void RaceStatusChanged(object sender, EventArgs e)
        {
            try
            {
                CheckToMuteOrUnmuteSounds();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CheckToMuteOrUnmuteSounds()
        {
            if (_raceSettings.CarSoundsActivated)
            {
                if (IsRaceInactive)
                    MuteSoundsInstantly();
                else if (IsRaceActive)
                    UnmuteSounds();
            }
        }

        public void LaneChanged(LaneId laneId)
        {
            try
            {
                if (IsRaceActive && _raceSettings.CarSoundsActivated)
                {
                    Lane lane = _raceModel.RaceHandler.GetLaneById(laneId);
                    IRaceCarSoundPlayer raceCarSoundPlayer = GetRaceCarSound(lane);

                    if (lane.IsDisqualified)
                        raceCarSoundPlayer.MuteSound();
                    else
                        CalcCarSound(raceCarSoundPlayer, lane);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private bool IsRaceInactive
        {
            get { return !IsRaceActive; }
        }

        private bool IsRaceActive
        {
            get { return _raceModel.StatusHandler.IsRaceStartedOrInCountDown; }
        }

        private void MuteSoundsInstantly()
        {
            foreach (IRaceCarSoundPlayer raceCarSoundPlayer in _raceCarSoundPlayers)
                raceCarSoundPlayer.MuteInstantlySound();
        }

        private void UnmuteSounds()
        {
            foreach (IRaceCarSoundPlayer raceCarSoundPlayer in _raceCarSoundPlayers)
                raceCarSoundPlayer.UnmuteSounds();
        }

        private void CreateRaceCarSoundPlayers()
        {
            ClearCarSoundPlayers();
            if (Is3D)
            {
                IPosition3DCreator position3DCreator = new Position3DCreatorLinear(_raceModel.LanesWithActivatedSound, AddRaceCarSoundPlayer3D);
                position3DCreator.Create();
            }
            else
            {
                StereoCreator stereoCreator = new StereoCreator(_raceModel.LanesWithActivatedSound, AddRaceCarSoundPlayerStereo);
                stereoCreator.Create();
            }
        }

        private void ClearCarSoundPlayers()
        {
            foreach (IRaceCarSoundPlayer raceCarSoundPlayer in _raceCarSoundPlayers)
            {
                raceCarSoundPlayer.Clear();
                raceCarSoundPlayer.Dispose();
            }
            _raceCarSoundPlayers.Clear();
        }

        private void AddRaceCarSoundPlayer3D(Vector3 position, LaneId laneId)
        {
            try
            {
                Lane lane = _raceModel.RaceHandler.GetLaneById(laneId);
                if (SoundFilenamesAreNotNullOrEmpty(lane.Car))
                {
                    string soundIdleFilename = GetAbsoluteFileNameAndCheckExistance(lane.Car.SoundIdleFilename);
                    string soundEngineFilename = GetAbsoluteFileNameAndCheckExistance(lane.Car.SoundEngineFilename);

                    IRaceCarSoundPlayer raceCarSoundPlayer = new RaceCarSoundPlayer(laneId, _carSoundsService,
                                                                                    soundIdleFilename,
                                                                                    soundEngineFilename,
                                                                                    lane.Car, position,
                                                                                    _raceSettings, _raceModel);
                    _raceCarSoundPlayers.Add(raceCarSoundPlayer);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AddRaceCarSoundPlayerStereo(int stereoPan, LaneId laneId)
        {
            try
            {
                Lane lane = _raceModel.RaceHandler.GetLaneById(laneId);
                if (SoundFilenamesAreNotNullOrEmpty(lane.Car))
                {
                    string soundIdleFilename = GetAbsoluteFileNameAndCheckExistance(lane.Car.SoundIdleFilename);
                    string soundEngineFilename = GetAbsoluteFileNameAndCheckExistance(lane.Car.SoundEngineFilename);

                    IRaceCarSoundPlayer raceCarSoundPlayer = new RaceCarSoundPlayer(laneId, _carSoundsService,
                                                                                    soundIdleFilename,
                                                                                    soundEngineFilename,
                                                                                    lane.Car, stereoPan, 
                                                                                    _raceSettings, _raceModel);
                    _raceCarSoundPlayers.Add(raceCarSoundPlayer);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private bool SoundFilenamesAreNotNullOrEmpty(Car car)
        {
            return !string.IsNullOrEmpty(car.SoundIdleFilename) && !string.IsNullOrEmpty(car.SoundEngineFilename);
        }

        private string GetAbsoluteFileNameAndCheckExistance(string fileName)
        {
            string absoluteFileName = SystemHelper.GetAbsolutePath(fileName);
            if (!System.IO.File.Exists(absoluteFileName))
                throw new LcException(string.Format("File {0} does not exist.", absoluteFileName));
            return absoluteFileName;
        }

        private void AttachToModelAsObserver()
        {
            _raceModel.RaceFinished += RaceModelRaceFinished;
            _raceModel.RaceInitialized += RaceModelRaceInitialized;
            _raceModel.Attach(this);
        }

        private void RaceModelRaceInitialized(object sender, EventArgs e)
        {
            try
            {
                CreateRaceCarSoundPlayers();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceModelRaceFinished(object sender, EventArgs e)
        {
            try
            {
                MuteSoundsInstantly();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CalcCarSound(IRaceCarSoundPlayer raceCarSoundPlayer, Lane lane)
        {
            if (HasCarAndUserSound(lane) && raceCarSoundPlayer != null)
                raceCarSoundPlayer.SpeedOfCar = lane.CurrentSpeed;
        }

        private bool HasCarAndUserSound(Lane lane)
        {
            bool carSoundFilesNamesExist = !string.IsNullOrEmpty(lane.Car.SoundIdleFilename) &&
                                           !string.IsNullOrEmpty(lane.Car.SoundEngineFilename);
            return carSoundFilesNamesExist;
        }

        private IRaceCarSoundPlayer GetRaceCarSound(Lane lane)
        {
            return _raceCarSoundPlayers.Find(foundRaceCarSound => foundRaceCarSound.LaneId == lane.Id);
        }

    }
}
