using System;
using System.Windows.Forms;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Sound;
using Elreg.Log;
using NAudio.Wave;

namespace Elreg.RaceSound
{
    public class PauseSoundHandler : IRaceStatusObserver
    {
        private readonly IRaceModel _raceModel;
        private readonly SoundMixer _soundMixer;
        private WaveOutEvent _waveOutEvent;
        private AudioFileReader _audioFileReader;

        private const string SoundPausepath = @"\Sounds\Custom\";
        private const string SoundPause = "Pause.wav";

        public PauseSoundHandler(IRaceModel raceModel, SoundMixer soundMixer)
        {
            _raceModel = raceModel;
            _soundMixer = soundMixer;
            AttachToModelAsObserver();
        }

        public void Init()
        {
            try
            {
                InitWaveOutEvent();
                CreateSoundBuffer();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AttachToModelAsObserver()
        {
            _raceModel.Attach(this);
        }

        private void InitWaveOutEvent()
        {
            _waveOutEvent = new WaveOutEvent();
        }

        private void CreateSoundBuffer()
        {
            try
            {
                DisposeAudioFileReader();
                _audioFileReader = new AudioFileReader(PauseSoundPath);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void DisposeAudioFileReader()
        {
            try
            {
                if (_audioFileReader != null)
                {
                    _audioFileReader.Dispose();
                    _audioFileReader = null;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public string PauseSoundPath
        {
            get { return Application.StartupPath + FilePathPause; }
        }

        private void PlaySound()
        {
            try
            {
                if (_audioFileReader != null && _waveOutEvent != null)
                {
                    _audioFileReader.Volume = _soundMixer.CountDownVolumeAdapted;
                    _audioFileReader.Position = 0;
                    _waveOutEvent.Init(_audioFileReader);
                    _waveOutEvent.Play();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private string FilePathPause
        {
            get { return SoundPausepath + SoundPause; }
        }

        public void RaceStarted(object sender, EventArgs e) { }

        public void RaceRestarted(object sender, EventArgs e) { }

        public void RacePaused(object sender, EventArgs e)
        {
            if (_raceModel.StatusHandler.IsRacePausedByKeyboardOrArduino)
                PlaySound();
        }

        public void RaceBreaked(object sender, EventArgs e) { }

        public void RaceInitialized(object sender, EventArgs e)
        {
            try
            {
                CreateSoundBuffer();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void RaceFinished(object sender, EventArgs e) { }

        public void RaceStopped(object sender, EventArgs e) { }

        public void RaceUnbreaked(object sender, EventArgs e) { }
    }
}
