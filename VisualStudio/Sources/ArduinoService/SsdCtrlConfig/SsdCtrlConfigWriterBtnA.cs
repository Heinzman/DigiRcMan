using Elreg.BusinessObjects.Interfaces;

namespace Elreg.ArduinoService.SsdCtrlConfig
{
    public class SsdCtrlConfigWriterBtnA : SsdCtrlConfigWriter
    {
        public SsdCtrlConfigWriterBtnA(ISerialPortWriter serialPortWriter)
            : base(serialPortWriter)
        {
            ButtonFlags = 16;
        }

    }
}
