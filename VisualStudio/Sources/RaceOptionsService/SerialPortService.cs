using Elreg.BusinessObjects.Options;

namespace Elreg.RaceOptionsService
{
    public class SerialPortService : ServiceBase<SerialPortSettings>
    {
        public SerialPortSettings SerialPortSettings
        {
            get { return Object; }
        }

        protected override string Filename
        {
            get { return "SerialPortSettings.xml"; }
        }
    }
}
