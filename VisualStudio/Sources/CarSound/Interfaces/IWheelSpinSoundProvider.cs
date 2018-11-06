using Elreg.CarSound.AdditionalSounds;

namespace Elreg.CarSound.Interfaces
{
    public interface IWheelSpinSoundProvider : IAdditionalSoundProvider
    {
        WheelSpinSound WheelSpinSound { get; }
    }
}
