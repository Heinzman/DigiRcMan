using System;
using System.Windows.Forms;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Sound;
using Elreg.Log;
using Elreg.ResourcesService;
using Microsoft.DirectX.DirectSound;

namespace Elreg.RaceSound
{
    public class PauseSoundHandler : IRaceStatusObserver
    {
        private readonly IRaceModel _raceModel;
        private readonly SoundMixer _soundMixer;
        private readonly Device _device;
        private BufferDescription _bufferDescription;
        private SecondaryBuffer _buffer;

        private const string SoundPausepath = @"\Sounds\Custom\";
        private const string SoundPause = "Pause.wav";

        public PauseSoundHandler(IRaceModel raceModel, Device device, SoundMixer soundMixer)
        {
            _raceModel = raceModel;
            _soundMixer = soundMixer;
            _device = device;
            AttachToModelAsObserver();
        }

        public void Init()
        {
            try
            {
                InitBufferDescription();
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

        private void InitBufferDescription()
        {
            _bufferDescription = new BufferDescription
                                     {
                                         Flags = BufferDescriptionFlags.ControlVolume | BufferDescriptionFlags.ControlFrequency |
                                                 BufferDescriptionFlags.ControlPan,
                                         GlobalFocus = true
                                     };
        }

        private void CreateSoundBuffer()
        {
            try
            {
                _buffer = new SecondaryBuffer(PauseSoundPath, _bufferDescription, _device);
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
                if (_buffer != null)
                {
                    _buffer.Volume = _soundMixer.CountDownVolumeAdapted;
                    _buffer.Play(0, BufferPlayFlags.Default);
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
