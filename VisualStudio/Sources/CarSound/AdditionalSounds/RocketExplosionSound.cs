using Elreg.RaceSoundService;
using Microsoft.DirectX;

namespace Elreg.CarSound.AdditionalSounds
{
    public class RocketExplosionSound : AdditionalSound
    {
        public RocketExplosionSound(Vector3 position, CarSoundsService carSoundsService)
            : base(position, carSoundsService)
        { }

        public RocketExplosionSound(int stereoPan, CarSoundsService carSoundsService)
            : base(stereoPan, carSoundsService)
        { }

        protected override int UnmutedVolume
        {
            get { return SoundMixer.RocketExplosionVolumeAdapted + base.UnmutedVolume; }
        }

        protected override Microsoft.DirectX.DirectSound.SecondaryBuffer RandomSecondaryBuffer
        {
            get { return CarSoundsService.RandomRocketExplosionSecondaryBuffer; }
        }

    }
}
