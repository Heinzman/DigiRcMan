using System;
using Elreg.BusinessObjects.DerivedEventArgs;

namespace Elreg.BusinessObjects.Interfaces
{
    public interface ISerialPortParser
    {
        event EventHandler<PortParserEventArgs> DataReceived;
        event EventHandler<PortParserMockEventArgs> GetControllersData;
        event EventHandler StartStopRequested;
        event EventHandler ImAliveDetected;
    }
}