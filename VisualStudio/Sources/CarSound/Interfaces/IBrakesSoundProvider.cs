using Elreg.CarSound.AdditionalSounds;

namespace Elreg.CarSound.Interfaces
{
    public interface IBrakesSoundProvider : IAdditionalSoundProvider
    {
        BrakesSound BrakesSound { get; }
    }
}
