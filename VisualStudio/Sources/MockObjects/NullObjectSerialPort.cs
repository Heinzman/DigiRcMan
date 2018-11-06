using System.IO.Ports;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Options;

namespace Elreg.UnitTests.MockObjects
{
    public class NullObjectSerialPort : ISerialPort
    {
        event SerialDataReceivedEventHandler ISerialPort.DataReceived
        {
            add { }
            remove { }
        }

        public void Open() 
        {
        }

        public void Close()
        {
        }

        public bool IsOpen
        {
            get { return true; }
        }

        public string[] GetPortNames() 
        {
            string[] portnames = new[] {"COM4"};
            return portnames;
        }

        public string PortName
        {
            set { }
            get { return "COM4"; }
        }

        public int BytesToRead
        {
            get { return 9; }
        }

        public int Read(ref byte[] buffer, int offset, int count)
        {
                return 9;
        }

        public void Assign(SerialPortSettings serialPortSettings) { }

        public void Write(byte[] buffer, int offset, int count) { }

        public void DiscardInBuffer() { }

        public void DiscardOutBuffer() { }
    }
}
