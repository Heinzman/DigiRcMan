using System.IO.Ports;
using Elreg.BusinessObjects.Options;

namespace Elreg.BusinessObjects.Interfaces
{
    public interface ISerialPort
    {
        event SerialDataReceivedEventHandler DataReceived;
        void Open();
        void Close();
        bool IsOpen { get; }
        string[] GetPortNames();
        int BytesToRead { get; }
        int Read(ref byte[] buffer, int offset, int count);
        string PortName { set; get; }
        void Assign(SerialPortSettings serialPortSettings);
        void Write(byte[] buffer, int offset, int count);
        void DiscardInBuffer();
        void DiscardOutBuffer();
    }
}
