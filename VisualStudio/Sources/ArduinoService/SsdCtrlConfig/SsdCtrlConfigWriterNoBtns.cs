using Elreg.BusinessObjects.Interfaces;

namespace Elreg.ArduinoService.SsdCtrlConfig
{
    public class SsdCtrlConfigWriterNoBtns : SsdCtrlConfigWriter
    {
        public SsdCtrlConfigWriterNoBtns(ISerialPortWriter serialPortWriter) : base(serialPortWriter)
        {
            ButtonFlags = 0;
        }

    }
}
