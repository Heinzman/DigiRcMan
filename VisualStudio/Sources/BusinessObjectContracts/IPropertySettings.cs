namespace Elreg.BusinessObjectContracts
{
    public interface IPropertySettings
    {
        bool Tracing { get; set; }
        bool TraceAutoFlush { get; set; }
        bool MusicActivated { get; set; }
        bool SoundActivated { get; set; }
        bool StartTestCase { get; set; }
        bool AlwaysShowExceptionMessages { get; set; }
        bool UseMockVcuSerialPortReader { get; set; }
        bool AutoPauseAfterStart { get; set; }
    }
}