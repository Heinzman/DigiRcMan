using Elreg.BusinessObjects.Interfaces;

namespace Elreg.ArduinoService.SsdCtrlConfig
{
    public class SsdCtrlConfigWriterBtnAAndB : SsdCtrlConfigWriter
    {
        public SsdCtrlConfigWriterBtnAAndB(ISerialPortWriter serialPortWriter)
            : base(serialPortWriter)
        {
            ButtonFlags = 48;
        }

    }
}
