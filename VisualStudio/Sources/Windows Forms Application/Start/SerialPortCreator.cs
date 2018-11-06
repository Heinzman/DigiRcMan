using System;
using Heinzman.BusinessObjects.Interfaces;
using Heinzman.BusinessObjects.Options;
using Heinzman.MockObjects;
using Heinzman.MockObjects.MockSerialPort;
using Heinzman.SerialPortReader.SerialPorts;

namespace Heinzman.WindowsFormsApplication.Start
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
            if (Properties.Settings.Default.UseMockSerialPort)
                CreateMockSerialPort();
            else
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
