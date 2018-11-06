using System;
using System.Collections.Generic;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.Sound;
using Elreg.Log;
using Elreg.RaceSoundService;
using Microsoft.DirectX.DirectSound;

namespace Elreg.RaceActionSound
{
    public class SoundListHandler : IDisposable
    {
        private readonly IRaceModel _raceModel;
        private readonly int _stereoPan;
        private readonly Queue<Queue<BufferSound>> _bufferSounds = new Queue<Queue<BufferSound>>();
        private BufferSound _currentBufferSound;
        private Queue<BufferSound> _currentBufferSoundOfOneAction;
        private System.Timers.Timer _timer;
        private readonly Random _random = new Random(Guid.NewGuid().GetHashCode());
        private bool _nextSoundOfOneActionLoaded;
        private double _frequencyFactor = 1;
        private readonly Device _device;
        private readonly SoundMixer _soundMixer;
        private SecondaryBuffer _currentSecondaryBuffer;
        private bool _isInWork;
        private bool _isDisposed;
        private readonly RaceSettings _raceSettings;
        private readonly object _isInWorkLock = new object();

        private const int TimerIntervalBetweenActions = 2;

        public SoundListHandler(IRaceModel raceModel, int stereoPan, Device device, SoundMixer soundMixer)
            : this(raceModel, device, soundMixer)
        {
            _stereoPan = stereoPan;
        }

        private SoundListHandler(IRaceModel raceModel, Device device, SoundMixer soundMixer)
        {
            _raceModel = raceModel;
            _raceSettings = _raceModel.RaceSettings;
            _device = device;
            _soundMixer = soundMixer;
            InitTimer();
        }

        public SoundListHandler(RaceSettings raceSettings, int stereoPan, Device device, SoundMixer soundMixer)
            : this(raceSettings, device, soundMixer)
        {
            _stereoPan = stereoPan;
        }

        private SoundListHandler(RaceSettings raceSettings, Device device, SoundMixer soundMixer)
        {
            _raceSettings = raceSettings;
            _device = device;
            _soundMixer = soundMixer;
            InitTimer();
        }

        public void AddSoundsOfOneAction(Queue<BufferSound> buffersOfOneAction)
        {
            _bufferSounds.Enqueue(buffersOfOneAction);
        }

        public Queue<Queue<BufferSound>> BufferSounds
        {
            get { return _bufferSounds; }
        }

        private void InitTimer()
        {
            _timer = new System.Timers.Timer { Interval = TimerIntervalBetweenActions };
            _timer.Elapsed += TimerElapsed;
            _timer.Start();
        }

        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                lock (_isInWorkLock)
                {
                    if (!_isInWork)
                        DoWork();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void DoWork()
        {
            try
            {
                _isInWork = true;

                if (ShouldPlayNextSound)
                    PlayNextSoundFromQueue();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
            finally
            {
                _isInWork = false;
            }
        }

        private void PlayNextSoundFromQueue()
        {
            ObtainCurrentBuffer();
            if (_currentBufferSound != null)
            {
                CloneSecondaryBuffer();
                if (_currentBufferSound.VaryFrequency)
                {
                    if (_nextSoundOfOneActionLoaded)
                        RandomizeFrequencyFactor();
                }
                else
                    ResetFrequencyFactor();
                SetFrequency();
                _currentSecondaryBuffer.Pan = _stereoPan;
                _currentSecondaryBuffer.Volume = SoundVolume;
                _currentSecondaryBuffer.Play(0, BufferPlayFlags.Default);
            }
        }

        private int SoundVolume
        {
            get
            {
                int soundVolume = _soundMixer.ActionSoundVolumeAdapted;
                if (_raceModel != null && 
                    !(_raceModel.StatusHandler.IsRaceStartedOrInCountDown || _raceModel.StatusHandler.IsRaceFinished))
                    soundVolume += _soundMixer.ActionFadeVolumeAdapted;
                return SoundHelper.LimitVolume(soundVolume);
            }
        }

        private void CloneSecondaryBuffer()
        {
            _currentSecondaryBuffer = _currentBufferSound.SecondaryBuffer.Clone(_device);
        }

        private void ObtainCurrentBuffer()
        {
            _nextSoundOfOneActionLoaded = false;
            _currentBufferSound = null;
            _currentSecondaryBuffer = null;
            if ((_currentBufferSoundOfOneAction == null || _currentBufferSoundOfOneAction.Count == 0) &&
                    _bufferSounds != null && _bufferSounds.Count > 0)
            {
                _currentBufferSoundOfOneAction = _bufferSounds.Dequeue();
                _nextSoundOfOneActionLoaded = true;
            }
            if (_currentBufferSoundOfOneAction != null && _currentBufferSoundOfOneAction.Count > 0)
                _currentBufferSound = _currentBufferSoundOfOneAction.Dequeue();
        }

        private bool IsSoundPlaying
        {
            get { return _currentSecondaryBuffer != null && _currentSecondaryBuffer.Status.Playing; }
        }

        private bool ShouldPlayNextSound
        {
            get { return !IsSoundPlaying || IsSoundNearlyEnded; }
        }

        private bool IsSoundNearlyEnded
        {
            get
            {
                bool isSoundNearlyEnded = true;
                if (_currentSecondaryBuffer != null)
                {
                    int playPosition = _currentSecondaryBuffer.PlayPosition;
                    int bufferBytes = _currentSecondaryBuffer.Caps.BufferBytes;
                    isSoundNearlyEnded = playPosition > bufferBytes - _raceSettings.BufferBytesToCutFromActionSounds;
                }
                return isSoundNearlyEnded;
            }
        }

        private void RandomizeFrequencyFactor()
        {
            const int maxRandomValue = 1000;

            int rndInt = _random.Next(maxRandomValue) - maxRandomValue / 2;
            _frequencyFactor = 1 + (double)rndInt / 10000;           
        }

        private void ResetFrequencyFactor()
        {
            _frequencyFactor = 1;
        }

        private void SetFrequency()
        {
            if (_currentSecondaryBuffer != null)
            {
                int frequency = (int)Math.Ceiling(_currentSecondaryBuffer.Frequency * _frequencyFactor);
                _currentSecondaryBuffer.Frequency = frequency;
            }
        }

        ~SoundListHandler()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    if (_timer != null)
                        _timer.Elapsed -= TimerElapsed;
                }
            }
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
