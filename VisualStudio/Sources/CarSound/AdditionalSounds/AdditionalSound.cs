using System;
using Elreg.BusinessObjects.Sound;
using Elreg.Log;
using Elreg.RaceSound;
using Elreg.RaceSound.Sound3D;
using Elreg.RaceSoundService;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;

namespace Elreg.CarSound.AdditionalSounds
{
    public abstract class AdditionalSound
    {
        private readonly Vector3 _position;
        private readonly int _stereoPan;
        protected readonly CarSoundsService CarSoundsService;
        private readonly SoundType _soundType;
        private SecondaryBuffer _clonedSecondaryBuffer;
        private static readonly object Locker = new object();

        protected AdditionalSound(Vector3 position, CarSoundsService carSoundsService)
            : this(carSoundsService)
        {
            _position = position;
            _soundType = SoundType.DolbySurround;
        }

        protected AdditionalSound(int stereoPan, CarSoundsService carSoundsService)
            : this(carSoundsService)
        {
            _stereoPan = stereoPan;
            _soundType = SoundType.Stereo;
        }

        private AdditionalSound(CarSoundsService carSoundsService)
        {
            CarSoundsService = carSoundsService;
        }

        public int Volume
        {
            get
            {
                int volume = 0;
                lock (Locker)
                {
                    if (_clonedSecondaryBuffer != null)
                        volume = _clonedSecondaryBuffer.Volume;
                }
                return volume;
            }
            set
            {
                lock (Locker)
                {
                    if (_clonedSecondaryBuffer != null)
                        _clonedSecondaryBuffer.Volume = SoundHelper.LimitVolume(value);
                }
            }
        }

        //public VolumeStatus VolumeStatus { private get; set; }

        protected virtual int UnmutedVolume
        {
            get { return SoundMixer.CarSoundVolumeAdapted + SoundHelper.GetLoudspeakerVolume(SoundMixer, _soundType, _position); }
        }

        protected SoundMixer SoundMixer
        {
            get { return CarSoundsService.SoundMixer; }
        }

        public void Stop()
        {
            try
            {
                lock (Locker)
                    StopSound();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void StopSound()
        {
            if (_clonedSecondaryBuffer != null)
            {
                _clonedSecondaryBuffer.Stop();
                _clonedSecondaryBuffer = null;
            }
        }

        public void Start()
        {
            try
            {
                lock (Locker)
                {
                    if (!IsClonedBufferPlaying())
                        PlayClonedBuffer();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void StartForced()
        {
            try
            {
                lock (Locker)
                {
                    StopSound();
                    PlayClonedBuffer();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void PlayClonedBuffer()
        {
            SecondaryBuffer secondaryBuffer = RandomSecondaryBuffer;
            if (secondaryBuffer != null)
            {
                _clonedSecondaryBuffer = secondaryBuffer.Clone(CarSoundsService.Device);
                if (_clonedSecondaryBuffer != null)
                {
                    _clonedSecondaryBuffer.Volume = SoundHelper.LimitVolume(UnmutedVolume);
                    if (_soundType == SoundType.DolbySurround)
                        Sound3DHelper.AssignBuffer3DTo(_clonedSecondaryBuffer, _position);
                    else
                        _clonedSecondaryBuffer.Pan = _stereoPan;
                    _clonedSecondaryBuffer.Play(0, BufferPlayFlags.Default);
                }
            }
        }

        private bool IsClonedBufferPlaying()
        {
            return _clonedSecondaryBuffer != null;
        }

        protected abstract SecondaryBuffer RandomSecondaryBuffer { get; }
    }
}
