using Elreg.RaceSoundService;
using Microsoft.DirectX;

namespace Elreg.CarSound.AdditionalSounds
{
    public class EngineDamageSound : AdditionalSound
    {
        public EngineDamageSound(Vector3 position, CarSoundsService carSoundsService)
            : base(position, carSoundsService)
        { }

        public EngineDamageSound(int stereoPan, CarSoundsService carSoundsService)
            : base(stereoPan, carSoundsService)
        { }

        protected override int UnmutedVolume
        {
            get { return SoundMixer.EngineDamageVolumeAdapted + base.UnmutedVolume; }
        }

        protected override Microsoft.DirectX.DirectSound.SecondaryBuffer RandomSecondaryBuffer
        {
            get { return CarSoundsService.RandomEngineDamageSecondaryBuffer; }
        }

    }
}
