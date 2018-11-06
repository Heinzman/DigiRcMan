using Elreg.RaceSoundService;
using Microsoft.DirectX;

namespace Elreg.CarSound.AdditionalSounds
{
    public class RocketWarningSound : AdditionalSound
    {
        public RocketWarningSound(Vector3 position, CarSoundsService carSoundsService)
            : base(position, carSoundsService)
        { }

        public RocketWarningSound(int stereoPan, CarSoundsService carSoundsService)
            : base(stereoPan, carSoundsService)
        { }

        protected override int UnmutedVolume
        {
            get { return SoundMixer.RocketWarningVolumeAdapted + base.UnmutedVolume; }
        }

        protected override Microsoft.DirectX.DirectSound.SecondaryBuffer RandomSecondaryBuffer
        {
            get { return CarSoundsService.RandomRocketWarningSecondaryBuffer; }
        }

    }
}
