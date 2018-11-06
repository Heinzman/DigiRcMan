using Elreg.BusinessObjectContracts;
using Elreg.BusinessObjects.Interfaces;
using Elreg.SerialPortReader.SerialPortReaders;

namespace Elreg.DigiRcMan.Start
{
    public class SerialPortReaderCreator
    {
        private readonly ISerialPort _serialPort;
        private readonly IPropertySettings _propertySettings;
        private ISerialPortReader _serialPortReader;
        private Type _type;

        private enum Type
        {
            Normal = 0,
            QueueBased = 1,
            Mocked = 2
        }

        public SerialPortReaderCreator(ISerialPort serialPort, IPropertySettings propertySettings)
        {
            _serialPort = serialPort;
            _propertySettings = propertySettings;
        }

        public ISerialPortReader DoWork()
        {
            DetermineProperties();
            switch (_type)
            {
                case Type.Normal:
                    CreateSerialPortReaderNormal();
                    break;
                case Type.QueueBased:
                    CreateSerialPortQueueBased();
                    break;
                case Type.Mocked:
                    CreateMockSerialPortReader();
                    break;
            }
            return _serialPortReader;
        }

        private void CreateMockSerialPortReader()
        {
            _serialPortReader = new UnitTests.MockObjects.MockSerialPort.SerialPortReader();
        }

        private void CreateSerialPortQueueBased()
        {
            _serialPortReader = new PortReaderQueue(_serialPort);
        }

        private void CreateSerialPortReaderNormal()
        {
            _serialPortReader = new PortReader(_serialPort);
        }

        private void DetermineProperties()
        {
            _type = Type.QueueBased;
        }

    }
}
