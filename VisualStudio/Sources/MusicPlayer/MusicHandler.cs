using System;
using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Races;
using Elreg.DomainModels.RaceModel;
using Elreg.Log;
using Elreg.RaceControlService;
using Elreg.RaceSoundService;

namespace Elreg.MusicPlayer
{
    public class MusicHandler : ILaneBaseObserver
    {
        private readonly RaceModel _raceModel;
        private readonly SoundMixerService _soundMixerService;
        private readonly Player _racePlayer;
        private readonly Player _pausePlayer;
        private readonly Player _mainPlayer;
        private readonly HymnPlayer _hymnPlayer;
        private IPlayer _currentPlayer;
        private readonly List<IPlayer> _players;
        private RaceStatus _raceStatus = RaceStatus.Undefined;
        private bool _currentPlayerChanged;

        private enum RaceStatus
        {
            Undefined,
            PreStarted,
            Started,
            Paused,
            Finished
        }

        public MusicHandler(RaceModel raceModel, SoundMixerService soundMixerService, RaceKeyController raceKeyController)
        {
            _raceModel = raceModel;
            _soundMixerService = soundMixerService;
            _raceModel.Attach(this);
            _racePlayer = new Player(ServiceHelper.MainMusicPath, soundMixerService.MusicRaceVolume);
            _pausePlayer = new Player(ServiceHelper.PauseMusicPath, soundMixerService.MusicPauseVolume);
            _mainPlayer = new Player(ServiceHelper.MainMusicPath, soundMixerService.MusicMainVolume);
            _hymnPlayer = new HymnPlayer(raceModel, soundMixerService.MusicHymnVolume);
            _hymnPlayer.SongStopped += HymnPlayerSongStopped;
            soundMixerService.VolumeChanged += SoundMixerServiceVolumeChanged;
            AttachEvents(raceKeyController);
            _players = new List<IPlayer> { _racePlayer, _pausePlayer, _mainPlayer, _hymnPlayer };
        }

        public void SetMainPlayerAndPlay()
        {
            _currentPlayer = _mainPlayer;
            _raceStatus = RaceStatus.PreStarted;
            _currentPlayer.Play();
        }

        public void LaneChanged(LaneId laneId) {}

        public void RaceStatusChanged(object sender, EventArgs e)
        {
            try
            {
                SetCurrentPlayerAndPlay();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AttachEvents(RaceKeyController raceKeyController)
        {
            raceKeyController.PlayNextSong += RaceKeyControllerPlayNextSong;
            raceKeyController.TurnDownActionSound += RaceKeyControllerTurnDownActionSound;
            raceKeyController.TurnUpActionSound += RaceKeyControllerTurnUpActionSound;
            raceKeyController.TurnDownMusic += RaceKeyControllerTurnDownMusic;
            raceKeyController.TurnUpMusic += RaceKeyControllerTurnUpMusic;
        }

        private void RaceKeyControllerTurnUpMusic(object sender, EventArgs e)
        {
            try
            {
                if (_currentPlayer == _mainPlayer)
                    _soundMixerService.TurnUpMusicMain();
                else if (_currentPlayer == _pausePlayer)
                    _soundMixerService.TurnUpMusicPause();
                else if (_currentPlayer == _racePlayer)
                    _soundMixerService.TurnUpMusicRace();
                else if (_currentPlayer == _hymnPlayer)
                    _soundMixerService.TurnUpMusicHymn();
                RefreshMusicVolumes();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceKeyControllerTurnDownMusic(object sender, EventArgs e)
        {
            try
            {
                if (_currentPlayer == _mainPlayer)
                    _soundMixerService.TurnDownMusicMain();
                else if (_currentPlayer == _pausePlayer)
                    _soundMixerService.TurnDownMusicPause();
                else if (_currentPlayer == _racePlayer)
                    _soundMixerService.TurnDownMusicRace();
                else if (_currentPlayer == _hymnPlayer)
                    _soundMixerService.TurnDownMusicHymn();
                RefreshMusicVolumes();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceKeyControllerTurnUpCarSound(object sender, EventArgs e)
        {
            try
            {
                _soundMixerService.TurnUpCarSound();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceKeyControllerTurnDownCarSound(object sender, EventArgs e)
        {
            try
            {
                _soundMixerService.TurnDownCarSound();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceKeyControllerTurnUpActionSound(object sender, EventArgs e)
        {
            try
            {
                _soundMixerService.TurnUpActionSound();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceKeyControllerTurnDownActionSound(object sender, EventArgs e)
        {
            try
            {
                _soundMixerService.TurnDownActionSound();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SetCurrentPlayerAndPlay()
        {
            SetCurrentPlayer();
            if (_currentPlayerChanged)
                PlayCurrentPlayer();
        }

        private void PlayCurrentPlayer()
        {
            foreach (IPlayer player in _players)
                player.Pause();
            _currentPlayer.Play();
        }

        private void SetCurrentPlayer()
        {
            if (WasJustNowRacePaused)
            {
                _currentPlayer = _pausePlayer;
                _raceStatus = RaceStatus.Paused;
                _currentPlayerChanged = true;
            }
            else if (WasJustNowRaceStarted)
            {
                _currentPlayer = _racePlayer;
                _raceStatus = RaceStatus.Started;
                _currentPlayerChanged = true;
            }
            else if (WasJustNowRaceFinished)
            {
                if (_raceModel.Race.Type == Race.TypeEnum.Race)
                    _currentPlayer = _hymnPlayer;
                else
                    _currentPlayer = _mainPlayer;
                _raceStatus = RaceStatus.Finished;
                _currentPlayerChanged = true;
            }
            else if (WasJustNowRaceStopped)
            {
                _currentPlayer = _mainPlayer;
                _raceStatus = RaceStatus.PreStarted;
                _currentPlayerChanged = true;
            }
            else
                _currentPlayerChanged = false;
        }

        private void RaceKeyControllerPlayNextSong(object sender, EventArgs e)
        {
            try
            {
                _currentPlayer.PlayNext();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private bool WasJustNowRacePaused
        {
            get { return _raceStatus != RaceStatus.Paused && _raceModel.StatusHandler.IsRacePaused; }
        }

        private bool WasJustNowRaceStarted
        {
            get { return _raceStatus != RaceStatus.Started && _raceModel.StatusHandler.IsRaceStartedOrInCountDown; }
        }

        private bool WasJustNowRaceFinished
        {
            get { return _raceStatus != RaceStatus.Finished && _raceStatus != RaceStatus.PreStarted && _raceModel.StatusHandler.IsRaceFinished; }
        }

        private bool WasJustNowRaceStopped
        {
            get { return _raceStatus != RaceStatus.PreStarted && _raceStatus != RaceStatus.Finished && (_raceModel.StatusHandler.IsRaceStopped || _raceModel.StatusHandler.IsRaceInitialized); }
        }

        private void SoundMixerServiceVolumeChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshMusicVolumes();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RefreshMusicVolumes()
        {
            _racePlayer.SetAudioVolume(_soundMixerService.MusicRaceVolume);
            _pausePlayer.SetAudioVolume(_soundMixerService.MusicPauseVolume);
            _mainPlayer.SetAudioVolume(_soundMixerService.MusicMainVolume);
            _hymnPlayer.SetAudioVolume(_soundMixerService.MusicHymnVolume);
        }

        private void HymnPlayerSongStopped(object sender, EventArgs e)
        {
            try
            {
                SetMainPlayerAndPlay();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

    }
}
