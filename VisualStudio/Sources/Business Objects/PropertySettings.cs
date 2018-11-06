using Elreg.BusinessObjectContracts;

namespace Elreg.BusinessObjects
{
    public class PropertySettings : IPropertySettings
    {
        public bool Tracing { get; set; }
        public bool TraceAutoFlush { get; set; }
        public bool MusicActivated { get; set; }
        public bool SoundActivated { get; set; }
        public bool StartTestCase { get; set; }
        public bool AlwaysShowExceptionMessages { get; set; }
        public bool UseMockVcuSerialPortReader { get; set; }
        public bool AutoPauseAfterStart { get; set; }
    }
}