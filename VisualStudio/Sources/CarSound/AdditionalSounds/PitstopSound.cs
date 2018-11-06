using Elreg.RaceSoundService;
using Microsoft.DirectX;

namespace Elreg.CarSound.AdditionalSounds
{
    public class PitstopSound : AdditionalSound
    {
        public PitstopSound(Vector3 position, CarSoundsService carSoundsService)
            : base(position, carSoundsService)
        { }

        public PitstopSound(int stereoPan, CarSoundsService carSoundsService)
            : base(stereoPan, carSoundsService)
        { }

        protected override int UnmutedVolume
        {
            get { return SoundMixer.CarPitstopVolumeAdapted + base.UnmutedVolume; }
        }

        protected override Microsoft.DirectX.DirectSound.SecondaryBuffer RandomSecondaryBuffer
        {
            get { return CarSoundsService.RandomPitstopSecondaryBuffer; }
        }

    }
}
