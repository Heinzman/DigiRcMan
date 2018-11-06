namespace Elreg.CarSound.Interfaces
{
    public interface IAdditionalSoundProvider
    {
        bool IsEngineIdle { get; }
        bool HasDestinatedFrequencyFactor { get; }
        SpeedOfCarCalculator SpeedOfCarCalculator { get; }
    }
}
