using Elreg.BusinessObjectContracts;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Options;
using Elreg.SerialPortReader.SerialPorts;
using Elreg.UnitTests.MockObjects.MockSerialPort;

namespace Elreg.DigiRcMan.Start
{
    public class SerialPortCreator
    {
        private readonly SerialPortSettings _serialPortSettings;
        private ISerialPort _serialPort;

        public SerialPortCreator(SerialPortSettings serialPortSettings)
        {
            _serialPortSettings = serialPortSettings;
        }

        public ISerialPort DoWork()
        {
            CreateSerialPortEventBased();
            return _serialPort;
        }

        private void CreateSerialPortEventBased()
        {
            _serialPort = new SerialPortFacade();
            _serialPort.Assign(_serialPortSettings);
        }

        private void CreateMockSerialPort()
        {
            _serialPort = new SerialPort();
        }

    }
}
