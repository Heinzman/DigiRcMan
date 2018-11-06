using Heinzman.BusinessObjects.Interfaces;
using Heinzman.SerialPortReader.SerialPortReaders;

namespace Heinzman.WindowsFormsApplication.Start
{
    public class SerialPortReaderCreator
    {
        private readonly ISerialPort _serialPort;
        private readonly IPortDataWriter _dataWriter;
        private ISerialPortReader _serialPortReader;
        private Type _type;

        private enum Type
        {
            Normal = 0,
            QueueBased = 1,
            Mocked = 2,
            MockedForCentralUnit = 3
        }

        public SerialPortReaderCreator(ISerialPort serialPort, IPortDataWriter dataWriter)
        {
            _serialPort = serialPort;
            _dataWriter = dataWriter;
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
                case Type.MockedForCentralUnit:
                    CreateMockSerialPortReaderByDataWriter();
                    break;
            }
            return _serialPortReader;
        }

        private void CreateMockSerialPortReaderByDataWriter()
        {
            _serialPortReader = new MockObjects.MockSerialPort.SerialPortReaderByDataWriter(_dataWriter);
        }

        private void CreateMockSerialPortReader()
        {
            _serialPortReader = new MockObjects.MockSerialPort.SerialPortReader();
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
            if (Properties.Settings.Default.UseMockSerialPortReader)
                _type = Type.Mocked;
            else
                _type = Type.QueueBased;
        }

    }
}
