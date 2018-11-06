using System.Collections.Generic;
using Elreg.BusinessObjects.Options;

namespace Elreg.BusinessObjects.Interfaces
{
    public interface ISerialPortReader
    {
        event Delegates.DataReceivedAsTextHandler DataReceivedAsText;
        void Attach(ISerialPortObserver serialPortObserver);
        void Detach(ISerialPortObserver serialPortObserver);
        void Start();
        void Stop();
        void Assign(SerialPortSettings serialPortSettings);
        List<string> GetPortNames();
        string PortName { set; get; }
    }
}
