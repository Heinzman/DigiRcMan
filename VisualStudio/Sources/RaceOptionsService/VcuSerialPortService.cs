using Elreg.BusinessObjects.Options;

namespace Elreg.RaceOptionsService
{
    public class VcuSerialPortService : ServiceBase<VcuSerialPortSettings>
    {
        public VcuSerialPortSettings VcuSerialPortSettings
        {
            get { return Object; }
        }

        protected override string Filename
        {
            get { return "VcuSerialPortSettings.xml"; }
        }
    }
}
