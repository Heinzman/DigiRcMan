using System;

namespace Elreg.BusinessObjects.Interfaces
{
    public interface ISerialPortObserver
    {
        void SerialPortDataReceived(object sender, string line, DateTime timeStamp);
        void SerialPortStatusChanged(object sender, SerialPortReaderStatus status);
    }
}
