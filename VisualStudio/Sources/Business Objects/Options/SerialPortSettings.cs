using System.IO.Ports;

namespace Elreg.BusinessObjects.Options
{
    public class SerialPortSettings
    {
        public SerialPortSettings()
        {
            BaudRate = 115200;
            Parity = Parity.None;
            DataBits = 8;
            StopBits = StopBits.Two;
            Handshake = Handshake.None;
            ReadTimeout = 500;
            PortName = "COM1";
            WriteTimeout = 500;
        }

        public int WriteTimeout { get; set; }

        public string PortName { get; set; }

        public int ReadTimeout { get; set; }

        public Handshake Handshake { get; set; }

        public StopBits StopBits { get; set; }

        public int DataBits { get; set; }

        public Parity Parity { get; set; }

        public int BaudRate { get; set; }
    }
}