using System;
using System.Collections.Generic;
using Elreg.CarSound.AdditionalSoundCalculator;
using Elreg.CarSound.Interfaces;
using Elreg.DomainModels.Logs;
using Elreg.HelperClasses;
using Elreg.Log;
using Elreg.RaceActionSound;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.Sound;
using Elreg.CarSound.AdditionalSounds;
using Elreg.Logger;
using Elreg.RaceSound;
using Elreg.RaceSound.Sound3D;
using Elreg.RaceSoundService;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;
using Elreg.DomainModels;
using IBrakesSoundProvider = Elreg.CarSound.Interfaces.IBrakesSoundProvider;

namespace Elreg.CarSound
{
    public class RaceCarSoundPlayer : IRaceCarSoundPlayer, ILanePitstopObserver, IBrakesSoundProvider, IWheelSpinSoundProvider, IFrequencyProvider, IDisposable, ILaneObserver
    {
        private LaneId _laneId;
        private SecondaryBuffer _bufferIdleEngine;
        private SecondaryBuffer _bufferRunningEngine;
        private int _originalEngineFrequency;
        private readonly List<double> _frequencyFactors = new List<double>();
        private double _destinatedFrequencyFactor;
        private double _lastFrequencyFactor;
        private string _soundIdleFilename;
        private string _soundEngineFilename;
        private System.Threading.Timer _frequencyTimer;
        private Car _car;
        private readonly int _stereoPan;
        private readonly SpeedOfCarCalculator _speedOfCarCalculator = new SpeedOfCarCalculator();
        private readonly Vector3 _position;
        private readonly IRaceModel _raceModel;
        private RaceSettings _raceSettings;
        private PitstopSound _pitstopSound;
        private BrakesSound _brakesSound;
        private RocketStartSound _rocketStartSound;
        private RocketExplosionSound _rocketExplosionSound;
        private RocketWarningSound _rocketWarningSound;
        private EngineDamageSound _engineDamageSound;
        private WheelSpinSound _wheelSpinSound;
        private CarSoundsService _carSoundsService;
        private readonly System.Timers.Timer _volumeTimer = new System.Timers.Timer();
        private int _volumeTimerCount;
        private int _fadeVolumeByActionSound;
        private BrakesHandler _brakesHandler;
        private WheelSpinHandler _wheelSpinHandler;
        private GearHandler _gearHandler;
        private readonly SoundType _soundType = SoundType.Stereo;
        private bool _isDisposed;
        private bool _wasEngineRunning;
        private VolumeStatus _volumeStatus;
        private bool _wasEngineIdle;

        private const int FrequencyTimerInterval = 10;
        private const int VolumeTimerInterval = 10;
        private const int VolumeTimerMaxCountsForFade = 100;
        private const int VolumeDeltaForFade = 100;

        public event EventHandler<CarSoundEventArgs> CarSoundPlayed;

        private enum Index
        {
            Speed0 = 0,
            Speed12 = 12
        }

        public RaceCarSoundPlayer(LaneId laneId, CarSoundsService carSoundsService, string soundIdleFilename,
                                  string soundEngineFilename, Car car, Vector3 position, RaceSettings raceSettings, IRaceModel raceModel)
        {
            _position = position;
            _raceModel = raceModel;
            _soundType = SoundType.DolbySurround;
            InitRaceCarSoundPlayer(laneId, carSoundsService, soundIdleFilename, soundEngineFilename, car, raceSettings);
        }

        public RaceCarSoundPlayer(LaneId laneId, CarSoundsService carSoundsService, string soundIdleFilename,
                                  string soundEngineFilename, Car car, int stereoPan, RaceSettings raceSettings, IRaceModel raceModel)
        {
            _stereoPan = stereoPan;
            _raceModel = raceModel;
            _soundType = SoundType.Stereo;
            InitRaceCarSoundPlayer(laneId, carSoundsService, soundIdleFilename, soundEngineFilename, car, raceSettings);
        }

        private void InitRaceCarSoundPlayer(LaneId laneId, CarSoundsService carSoundsService, string soundIdleFilename,
                                  string soundEngineFilename, Car car, RaceSettings raceSettings)
        {
            _laneId = laneId;
            _carSoundsService = carSoundsService;
            _soundIdleFilename = soundIdleFilename;
            _soundEngineFilename = soundEngineFilename;
            _car = car;
            _raceSettings = raceSettings;
            _car.DataChanged += CarDataChanged;
            InitCarSoundLoggerOnlyForLane1();
            InitSoundBuffers();
            InitAdditionalCarSounds();
            CalcAndFillFrequencyFactors();
            _volumeStatus = VolumeStatus.Undefined;
            CurrentFrequencyFactor = FreqFactorInitial;
            _destinatedFrequencyFactor = FreqFactorInitial;
            _lastFrequencyFactor = FreqFactorInitial;
            AttachEvents();
            MuteInstantlySound();
            _brakesHandler = new BrakesHandler(this);
            _wheelSpinHandler = new WheelSpinHandler(this);
            _gearHandler = new GearHandler(this);
            InitTimers();
        }

        public uint SpeedOfCar
        {
            set
            {
                uint speed = value;
                if (_volumeStatus == VolumeStatus.Muting || _volumeStatus == VolumeStatus.Muted)
                    speed = 0;
                SpeedOfCarCalculator.CurrentSpeedOfCar = speed;
            }
        }

        public LaneId LaneId
        {
            get { return _laneId; }
        }

        public void MuteSound()
        {
            if (_volumeStatus == VolumeStatus.UnMuted)
            {
                _volumeStatus = VolumeStatus.Muting;
                _volumeTimerCount = 0;
                _volumeTimer.Start();
            }
        }

        public void UnmuteSounds()
        {
            _volumeStatus = VolumeStatus.UnMuted;
            _volumeTimer.Stop();
            _fadeVolumeByActionSound = (int)Volume.Max;
        }

        public void Clear()
        {
            _volumeTimer.Stop();
            _frequencyTimer.Dispose();
            _bufferIdleEngine.Volume = (int)Volume.Min;
            _bufferRunningEngine.Volume = (int)Volume.Min;
            _pitstopSound.Volume = (int)Volume.Min;
            _rocketStartSound.Volume = (int)Volume.Min;
            _rocketExplosionSound.Volume = (int)Volume.Min;
            _engineDamageSound.Volume = (int)Volume.Min;
            _rocketWarningSound.Volume = (int)Volume.Min;
            _brakesSound.Volume = (int)Volume.Min;
            _wheelSpinSound.Volume = (int)Volume.Min;
        }

        private void SetInitalVolumes()
        {
            _bufferIdleEngine.Volume = SoundVolumeOfIdleEngine;
            _bufferRunningEngine.Volume = SoundVolumeOfRunningEngine;
        }

        public void MuteInstantlySound()
        {
            _volumeStatus = VolumeStatus.Muted;
            _bufferIdleEngine.Volume = (int)Volume.Min;
            _bufferRunningEngine.Volume = (int)Volume.Min;
            _pitstopSound.Volume = (int)Volume.Min;
            _rocketStartSound.Volume = (int)Volume.Min;
            _rocketExplosionSound.Volume = (int)Volume.Min;
            _engineDamageSound.Volume = (int)Volume.Min;
            _rocketWarningSound.Volume = (int)Volume.Min;
            BrakesSound.Volume = (int)Volume.Min;
            _wheelSpinSound.Volume = (int)Volume.Min; 
        }

        public double CurrentFrequencyFactor { get; private set; }

        public float FreqFactorInitial
        {
            get { return _car.FreqFactorInitial; }
        }

        public double FrequencyFactorOfMaxSpeed
        {
            get { return FreqFactorInitial + FreqFactorPerSpeed * (int)Index.Speed12; }
        }

        public double OriginalEngineFrequency
        {
            get { return _originalEngineFrequency; }
        }

        private void InitAdditionalCarSounds()
        {
            if (_soundType == SoundType.DolbySurround)
            {
                _pitstopSound = new PitstopSound(_position, _carSoundsService);
                _brakesSound = new BrakesSound(_position, _carSoundsService);
                _wheelSpinSound = new WheelSpinSound(_position, _carSoundsService);
                _rocketStartSound = new RocketStartSound(_position, _carSoundsService);
                _rocketExplosionSound = new RocketExplosionSound(_position, _carSoundsService);
                _rocketWarningSound = new RocketWarningSound(_position, _carSoundsService);
                _engineDamageSound = new EngineDamageSound(_position, _carSoundsService);
            }
            else
            {
                _pitstopSound = new PitstopSound(_stereoPan, _carSoundsService);
                _brakesSound = new BrakesSound(_stereoPan, _carSoundsService);
                _wheelSpinSound = new WheelSpinSound(_stereoPan, _carSoundsService);
                _rocketStartSound = new RocketStartSound(_stereoPan, _carSoundsService);
                _rocketExplosionSound = new RocketExplosionSound(_stereoPan, _carSoundsService);
                _rocketWarningSound = new RocketWarningSound(_stereoPan, _carSoundsService);
                _engineDamageSound = new EngineDamageSound(_stereoPan, _carSoundsService);
            }
        }

        private void AttachEvents()
        {
            _raceModel.Attach(this as ILanePitstopObserver);
            _raceModel.Attach(this as ILaneObserver);
            if (_soundType == SoundType.DolbySurround)
                SoundListHandler.SoundPlaying3DChanged += SoundListHandlerSoundPlaying3DChanged;
            else
                SoundListHandler.SoundPlayingStereoChanged += SoundListHandlerSoundPlayingStereoChanged;
        }

        private void DetachEvents()
        {
            _raceModel.Detach(this as ILanePitstopObserver);
            _raceModel.Detach(this as ILaneObserver);
            SoundListHandler.SoundPlaying3DChanged -= SoundListHandlerSoundPlaying3DChanged;
            SoundListHandler.SoundPlayingStereoChanged -= SoundListHandlerSoundPlayingStereoChanged;
        }

        private void SoundListHandlerSoundPlayingStereoChanged(object sender, ActionSoundPlayedStereoEventArgs e)
        {
            try
            {
                bool isOwnCar = e.ForEveryBody || e.StereoPan == _stereoPan;
                HandleUnmutedVolume(e.IsPlaying, isOwnCar);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SoundListHandlerSoundPlaying3DChanged(object sender, ActionSoundPlayed3DEventArgs e)
        {
            try
            {
                bool isOwnCar = e.ForEveryBody ||
                                Math.Abs(e.Position.X - _position.X) < SystemHelper.Epsilon &&
                                Math.Abs(e.Position.Y - _position.Y) < SystemHelper.Epsilon &&
                                Math.Abs(e.Position.Z - _position.Z) < SystemHelper.Epsilon;
                HandleUnmutedVolume(e.IsPlaying, isOwnCar);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void HandleUnmutedVolume(bool isPlaying, bool isOwnCar)
        {
            if (_volumeStatus == VolumeStatus.UnMuted)
            {
                if (isPlaying)
                {
                    _fadeVolumeByActionSound += SoundMixer.CarFadeAllVolumeAdapted;
                    if (isOwnCar)
                        _fadeVolumeByActionSound += SoundMixer.CarFadeOwnVolumeAdapted;
                }
                else
                    _fadeVolumeByActionSound = (int)Volume.Max; 
                CalcAndSetIdleEngineVolume();
                CalcAndSetRunningEngineVolume();
            }
        }

        private void InitCarSoundLoggerOnlyForLane1()
        {
            if (_laneId == LaneId.Lane1)
                LoggerModel.Inst.CarSoundLogger = new CarSoundLogger(this);
        }

        private void PlaySound()
        {
            if (HasMuteVolumeStatus)
                SpeedOfCarCalculator.CurrentSpeedOfCar = 0;
            CalcAndSetEngineFrequency();

            if (IsEngineIdle)
            {
                CalcAndSetIdleEngineVolume();
                if (!_wasEngineIdle)
                {
                    _wasEngineIdle = true;
                    _wasEngineRunning = false;
                    _bufferRunningEngine.Stop();
                    _bufferIdleEngine.Play(0, BufferPlayFlags.Looping);
                }
            }
            else
            {
                CalcAndSetRunningEngineVolume();
                if (!_wasEngineRunning)
                {
                    _wasEngineRunning = true;
                    _wasEngineIdle = false;
                    _bufferIdleEngine.Stop();
                    _bufferRunningEngine.Play(0, BufferPlayFlags.Looping);
                }
            }
            RaiseEventCarSoundPlayed();
            _lastFrequencyFactor = CurrentFrequencyFactor;
        }

        private bool HasMuteVolumeStatus
        {
            get { return _volumeStatus == VolumeStatus.Muting || _volumeStatus == VolumeStatus.Muted; }
        }

        private void CalcAndSetIdleEngineVolume()
        {
            if (HasMuteVolumeStatus)
                _bufferIdleEngine.Volume = (int)Volume.Min;
            else
                _bufferIdleEngine.Volume = SoundHelper.LimitVolume(SoundVolumeOfIdleEngine);
        }

        private void CalcAndSetRunningEngineVolume()
        {
            if (_volumeStatus == VolumeStatus.UnMuted)
            {
                double frequencyFactorOfMaxSpeed = FreqFactorInitial + FreqFactorPerSpeed*(int) Index.Speed12;
                double ratio = CurrentFrequencyFactor/frequencyFactorOfMaxSpeed;
                int volumeOfSpeed = (int)Math.Ceiling(ratio * _raceSettings.VolumeToAddToMaxSpeed) - _raceSettings.VolumeToAddToMaxSpeed;
                int volume = SoundVolumeOfRunningEngine + volumeOfSpeed;
                _bufferRunningEngine.Volume = SoundHelper.LimitVolume(volume);
            }
        }

        private void InitSoundBuffers()
        {
            _bufferIdleEngine = CreateSecondaryBuffer(_soundIdleFilename);
            _bufferRunningEngine = CreateSecondaryBuffer(_soundEngineFilename);

            if (_soundType == SoundType.DolbySurround)
            {
                AssignBuffer3DToSecondaryBuffer(_bufferIdleEngine);
                AssignBuffer3DToSecondaryBuffer(_bufferRunningEngine);
            }
            else
            {
                _bufferIdleEngine.Pan = _stereoPan;
                _bufferRunningEngine.Pan = _stereoPan;
            }
            SetInitalVolumes();
            _originalEngineFrequency = _bufferRunningEngine.Frequency;

        }

        private SecondaryBuffer CreateSecondaryBuffer(string soundFilename)
        {
            SecondaryBuffer secondaryBuffer = new SecondaryBuffer(_carSoundsService.BufferDescription, _carSoundsService.Device);
            try
            {
                secondaryBuffer = new SecondaryBuffer(soundFilename, _carSoundsService.BufferDescription, _carSoundsService.Device);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
            return secondaryBuffer;
        }

        private void AssignBuffer3DToSecondaryBuffer(SecondaryBuffer secondaryBuffer)
        {
            Sound3DHelper.AssignBuffer3DTo(secondaryBuffer, _position); 
        }

        private void CalcAndSetEngineFrequency()
        {
            int engineFrequency;
            CalcFrequencyFactors();
            if (_raceSettings.GearShiftingSound)
                engineFrequency = _gearHandler.Calc();
            else
                engineFrequency = (int)Math.Ceiling(_originalEngineFrequency * CurrentFrequencyFactor);
            _bufferRunningEngine.Frequency = engineFrequency;
        }

        private void InitTimers()
        {
            _volumeTimer.Elapsed += VolumeTimerElapsed;
            _volumeTimer.Interval = VolumeTimerInterval;

            _frequencyTimer = new System.Threading.Timer(FrequencyTimerElapsedNew, null, FrequencyTimerInterval, FrequencyTimerInterval);
        }

        private void VolumeTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (_volumeStatus == VolumeStatus.Muting)
                {
                    _bufferRunningEngine.Volume = SoundHelper.LimitVolume(_bufferRunningEngine.Volume - VolumeDeltaForFade);
                    _bufferIdleEngine.Volume = SoundHelper.LimitVolume(_bufferIdleEngine.Volume - VolumeDeltaForFade);
                    _pitstopSound.Volume = SoundHelper.LimitVolume(_pitstopSound.Volume - VolumeDeltaForFade);
                    BrakesSound.Volume = SoundHelper.LimitVolume(BrakesSound.Volume - VolumeDeltaForFade);
                    _wheelSpinSound.Volume = SoundHelper.LimitVolume(_wheelSpinSound.Volume - VolumeDeltaForFade);
                    _rocketStartSound.Volume = SoundHelper.LimitVolume(_rocketStartSound.Volume - VolumeDeltaForFade);
                    _rocketExplosionSound.Volume = SoundHelper.LimitVolume(_rocketExplosionSound.Volume - VolumeDeltaForFade);
                    _rocketWarningSound.Volume = SoundHelper.LimitVolume(_rocketWarningSound.Volume - VolumeDeltaForFade);
                    _engineDamageSound.Volume = SoundHelper.LimitVolume(_engineDamageSound.Volume - VolumeDeltaForFade);

                    if (_volumeTimerCount++ > VolumeTimerMaxCountsForFade)
                    {
                        _volumeStatus = VolumeStatus.Muted;
                        _volumeTimer.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void FrequencyTimerElapsedNew(object data)
        {
            if (_raceSettings.CarSoundsActivated)
            {
                if (HasMuteVolumeStatus)
                {
                    _brakesHandler.StopSound();
                    _wheelSpinHandler.StopSound();
                }
                else
                {
                    _brakesHandler.PlayOrStopSound();
                    _wheelSpinHandler.PlayOrStopSound();
                }
                PlaySound();
            }
            else
            {
                _bufferRunningEngine.Stop();
                _bufferIdleEngine.Stop();
                _brakesHandler.StopSound();
                _wheelSpinHandler.StopSound();
            }
        }

        public bool HasDestinatedFrequencyFactor
        {
            get
            {
                return CurrentFrequencyFactor > _destinatedFrequencyFactor - FreqFactorDec
                       && CurrentFrequencyFactor < _destinatedFrequencyFactor + FreqFactorInc;
            }
        }

        private void CalcAndFillFrequencyFactors()
        {
            _frequencyFactors.Clear();
            _frequencyFactors.Add(FreqFactorInitial);
            _frequencyFactors.Add(FreqFactorInitial + FreqFactorPerSpeed * 1);
            _frequencyFactors.Add(FreqFactorInitial + FreqFactorPerSpeed * 2);
            _frequencyFactors.Add(FreqFactorInitial + FreqFactorPerSpeed * 3);
            _frequencyFactors.Add(FreqFactorInitial + FreqFactorPerSpeed * 4);
            _frequencyFactors.Add(FreqFactorInitial + FreqFactorPerSpeed * 5);
            _frequencyFactors.Add(FreqFactorInitial + FreqFactorPerSpeed * 6);
            _frequencyFactors.Add(FreqFactorInitial + FreqFactorPerSpeed * 7);
            _frequencyFactors.Add(FreqFactorInitial + FreqFactorPerSpeed * 8);
            _frequencyFactors.Add(FreqFactorInitial + FreqFactorPerSpeed * 9);
            _frequencyFactors.Add(FreqFactorInitial + FreqFactorPerSpeed * 10);
            _frequencyFactors.Add(FreqFactorInitial + FreqFactorPerSpeed * 11);
            _frequencyFactors.Add(FreqFactorInitial + FreqFactorPerSpeed * 12);
        }

        private void CalcFrequencyFactors()
        {
            CalcDestinatedFrequencyFactor();
            CalcCurrentFrequencyFactor();
        }

        private void CalcDestinatedFrequencyFactor()
        {
            _destinatedFrequencyFactor = FreqFactorInitial + FreqFactorPerSpeed * SpeedOfCarCalculator.AverageSpeedOfCar;
        }

        private void CalcCurrentFrequencyFactor()
        {
            if (_destinatedFrequencyFactor > _lastFrequencyFactor)
                CurrentFrequencyFactor = _lastFrequencyFactor + FreqFactorInc;
            else if (_destinatedFrequencyFactor < _lastFrequencyFactor)
                CurrentFrequencyFactor = _lastFrequencyFactor - FreqFactorDec;
            else
                CurrentFrequencyFactor = _destinatedFrequencyFactor;

            if (CurrentFrequencyFactor >= _frequencyFactors[(int)SpeedOfCarCalculator.CalculatedSpeedOfCar] - FreqFactorDec &&
                    CurrentFrequencyFactor <= _frequencyFactors[(int)SpeedOfCarCalculator.CalculatedSpeedOfCar] + FreqFactorInc)
                CurrentFrequencyFactor = _destinatedFrequencyFactor;
        }

        public bool IsEngineIdle
        {
            get
            {
                double frequencyFactor0 = _frequencyFactors[(int)Index.Speed0];
                return CurrentFrequencyFactor > frequencyFactor0 - FreqFactorDec
                       && CurrentFrequencyFactor < frequencyFactor0 + FreqFactorInc;
            }
        }

        private void RaiseEventCarSoundPlayed()
        {
            if (CarSoundPlayed != null)
            {
                CarSoundEventArgs carSoundEventArgs = new CarSoundEventArgs(_laneId, SpeedOfCarCalculator.CurrentSpeedOfCar,
                    SpeedOfCarCalculator.AverageSpeedOfCarRounded,SpeedOfCarCalculator.CalculatedSpeedOfCar,
                    CurrentFrequencyFactor, _destinatedFrequencyFactor, _lastFrequencyFactor, IsEngineIdle,
                    SpeedOfCarCalculator.SpeedOfCarQueue, SpeedOfCarCalculator.DeltaCurrentToLastCalcedSpeed,
                    SpeedOfCarCalculator.DeltaAverageToLastCalcedSpeed, SpeedOfCarCalculator.DeltaAverageToCurrentSpeed);
                CarSoundPlayed(this, carSoundEventArgs);
            }
        }

        private float FreqFactorPerSpeed
        {
            get { return _car.FreqFactorPerSpeed; }
        }

        private float FreqFactorDec
        {
            get { return _car.FreqFactorDec; }
        }

        private float FreqFactorInc
        {
            get { return _car.FreqFactorInc; }
        }

        private int SoundVolumeOfRunningEngine
        {
            get
            {
                int volume = SoundMixer.CarSoundVolumeAdapted + SoundMixer.CarEngineVolumeAdapted +
                             _car.SoundVolumeOverall + _car.SoundVolumeEngine + _fadeVolumeByActionSound +
                             SoundHelper.GetLoudspeakerVolume(SoundMixer, _soundType, _position);
                return SoundHelper.LimitVolume(volume);
            }
        }

        private int SoundVolumeOfIdleEngine
        {
            get
            {
                int volume = SoundMixer.CarSoundVolumeAdapted + SoundMixer.CarIdleVolumeAdapted + 
                            _car.SoundVolumeOverall + _car.SoundVolumeIdle + _fadeVolumeByActionSound +
                            SoundHelper.GetLoudspeakerVolume(SoundMixer, _soundType, _position); 
                return SoundHelper.LimitVolume(volume);
            }
        }

        private void CarDataChanged(object sender, EventArgs e)
        {
            try
            {
                CalcAndFillFrequencyFactors();
                SetInitalVolumes();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void LaneChanged(LaneId laneId) { }

        public void RaceStatusChanged(object sender, EventArgs e) { }

        public void PitInDetected(LaneId laneId) { }

        public void Refueled(LaneId laneId)
        {
            if (laneId == _laneId)
                StopPitstopSound();
        }

        public void PenaltiesDone(LaneId laneId) { }

        public void Refueling(LaneId laneId)
        {
            if (laneId == _laneId)
                _pitstopSound.Start();
        }

        public void PitOutDetected(LaneId laneId)
        {
            if (laneId == _laneId)
                StopPitstopSound();
        }

        private void StopPitstopSound()
        {
            _pitstopSound.Stop();
        }

        private SoundMixer SoundMixer
        {
            get { return _carSoundsService.SoundMixer; }
        }

        public BrakesSound BrakesSound
        {
            get { return _brakesSound; }
        }

        public SpeedOfCarCalculator SpeedOfCarCalculator
        {
            get { return _speedOfCarCalculator; }
        }

        public WheelSpinSound WheelSpinSound
        {
            get { return _wheelSpinSound; }
        }

        ~RaceCarSoundPlayer()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    if (_volumeTimer != null)
                        _volumeTimer.Elapsed -= VolumeTimerElapsed;
                    if (_frequencyTimer != null)
                        _frequencyTimer.Dispose();
                    if (_car != null)
                        _car.DataChanged -= CarDataChanged;
                    DetachEvents();
                }
            }
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void EngineDamaged(LaneId laneId)
        {
            if (laneId == _laneId)
                _engineDamageSound.StartForced();
        }

        public void EngineFixed(LaneId laneId) { }

        public void CarDamagedByRocket(LaneId laneId)
        {
            if (laneId == _laneId)
                _rocketExplosionSound.StartForced();
        }

        public void RocketExplodedDueDefending(LaneId laneId)
        {
            if (laneId == _laneId)
                _rocketExplosionSound.StartForced();
        }

        public void RocketDamageFixed(LaneId laneId) { }

        public void RocketStarted(LaneId laneId)
        {
            if (laneId == _laneId)
                _rocketStartSound.StartForced();
        }

        public void AttackedByRocket(LaneId laneId)
        {
            if (laneId == _laneId)
                _rocketWarningSound.StartForced();
        }
    }
}
