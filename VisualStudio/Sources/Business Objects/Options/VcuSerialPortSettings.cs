using System.IO.Ports;

namespace Elreg.BusinessObjects.Options
{
    public class VcuSerialPortSettings : SerialPortSettings
    {
        public VcuSerialPortSettings()
        {
            BaudRate = 115200;
            Parity = Parity.None;
            DataBits = 8;
            StopBits = StopBits.One;
            Handshake = Handshake.None;
            ReadTimeout = 500;
            PortName = "COM5";
            WriteTimeout = 500;
        }

    }
}