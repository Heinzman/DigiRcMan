using System;
using System.IO.Ports;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Options;
using Elreg.Log;

namespace Elreg.SerialPortReader.SerialPorts
{
    public class SerialPortFacade : ISerialPort
    {
        private readonly SerialPort _serialPort = new SerialPort();

        public event SerialDataReceivedEventHandler DataReceived;

        public SerialPortFacade()
        {
            _serialPort.DataReceived += SerialPortDataReceived;
        }

        public void Open() 
        {
            _serialPort.Open();
        }

        public void Close()
        {
            _serialPort.Close();
        }

        public bool IsOpen
        {
            get { return _serialPort.IsOpen; }
        }

        public string[] GetPortNames() 
        {
            return SerialPort.GetPortNames();
        }

        public string PortName
        {
            set { _serialPort.PortName = value; }
            get { return _serialPort.PortName; }
        }

        public int BytesToRead
        {
            get { return _serialPort.BytesToRead; }
        }

        public int Read(ref byte[] buffer, int offset, int count)
        {
            return _serialPort.Read(buffer, offset, count);
        }

        public void Assign(SerialPortSettings serialPortSettings)
        {
            _serialPort.BaudRate = serialPortSettings.BaudRate;
            _serialPort.Parity = serialPortSettings.Parity;
            _serialPort.DataBits = serialPortSettings.DataBits;
            _serialPort.StopBits = serialPortSettings.StopBits;
            _serialPort.Handshake = serialPortSettings.Handshake;
            _serialPort.ReadTimeout = serialPortSettings.ReadTimeout;
            _serialPort.WriteTimeout = serialPortSettings.WriteTimeout;
            PortName = serialPortSettings.PortName;
        }

        public void Write(byte[] buffer, int offset, int count)
        {
            _serialPort.Write(buffer, offset, count);
        }

        public void DiscardInBuffer()
        {
            _serialPort.DiscardInBuffer();
        }

        public void DiscardOutBuffer()
        {
            _serialPort.DiscardOutBuffer();
        }

        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (DataReceived != null)
                    DataReceived(sender, e);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }
    }
}
