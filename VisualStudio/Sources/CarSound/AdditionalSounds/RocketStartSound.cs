using Elreg.RaceSoundService;
using Microsoft.DirectX;

namespace Elreg.CarSound.AdditionalSounds
{
    public class RocketStartSound : AdditionalSound
    {
        public RocketStartSound(Vector3 position, CarSoundsService carSoundsService)
            : base(position, carSoundsService)
        { }

        public RocketStartSound(int stereoPan, CarSoundsService carSoundsService)
            : base(stereoPan, carSoundsService)
        { }

        protected override int UnmutedVolume
        {
            get { return SoundMixer.RocketStartVolumeAdapted + base.UnmutedVolume; }
        }

        protected override Microsoft.DirectX.DirectSound.SecondaryBuffer RandomSecondaryBuffer
        {
            get { return CarSoundsService.RandomRocketStartSecondaryBuffer; }
        }

    }
}
