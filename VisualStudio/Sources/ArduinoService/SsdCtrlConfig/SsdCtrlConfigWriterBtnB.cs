using Elreg.BusinessObjects.Interfaces;

namespace Elreg.ArduinoService.SsdCtrlConfig
{
    public class SsdCtrlConfigWriterBtnB : SsdCtrlConfigWriter
    {
        public SsdCtrlConfigWriterBtnB(ISerialPortWriter serialPortWriter)
            : base(serialPortWriter)
        {
            ButtonFlags = 32;
        }

    }
}
