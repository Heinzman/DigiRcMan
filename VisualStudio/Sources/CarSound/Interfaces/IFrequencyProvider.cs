namespace Elreg.CarSound.Interfaces
{
    public interface IFrequencyProvider
    {
        double CurrentFrequencyFactor { get; }
        float FreqFactorInitial { get; }
        double FrequencyFactorOfMaxSpeed { get; }
        double OriginalEngineFrequency { get; }
    }
}
