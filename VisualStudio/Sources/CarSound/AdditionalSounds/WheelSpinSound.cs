using Elreg.RaceSoundService;
using Microsoft.DirectX;

namespace Elreg.CarSound.AdditionalSounds
{
    public class WheelSpinSound : AdditionalSound
    {
        public WheelSpinSound(Vector3 position, CarSoundsService carSoundsService)
            : base(position, carSoundsService)
        {}

        public WheelSpinSound(int stereoPan, CarSoundsService carSoundsService)
            : base(stereoPan, carSoundsService)
        {}

        protected override int UnmutedVolume
        {
            get { return SoundMixer.CarSpinWheelsVolumeAdapted + base.UnmutedVolume; }
        }

        protected override Microsoft.DirectX.DirectSound.SecondaryBuffer RandomSecondaryBuffer
        {
            get { return CarSoundsService.RandomWheelSpinSecondaryBuffer; }
        }

    }
}
