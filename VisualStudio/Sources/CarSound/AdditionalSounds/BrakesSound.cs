using Elreg.RaceSoundService;
using Microsoft.DirectX;

namespace Elreg.CarSound.AdditionalSounds
{
    public class BrakesSound : AdditionalSound
    {
        public BrakesSound(Vector3 position, CarSoundsService carSoundsService) : base(position, carSoundsService)
        {}

        public BrakesSound(int stereoPan, CarSoundsService carSoundsService)
            : base(stereoPan, carSoundsService)
        {}

        protected override int UnmutedVolume
        {
            get { return SoundMixer.CarBrakesVolumeAdapted + base.UnmutedVolume; }
        }

        protected override Microsoft.DirectX.DirectSound.SecondaryBuffer RandomSecondaryBuffer
        {
            get { return CarSoundsService.RandomBrakesSecondaryBuffer; }
        }
    }
}
