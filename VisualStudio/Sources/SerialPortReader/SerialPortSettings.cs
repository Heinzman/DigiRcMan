using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace Heinzman.SerialPortReader
{
    public class SerialPortSettings
    {
        private int _baudRate = 115200;
        private Parity _parity = System.IO.Ports.Parity.None;
        private int _dataBits = 8;
        private StopBits _stopBits = System.IO.Ports.StopBits.Two;
        private Handshake _handshake = System.IO.Ports.Handshake.None;
        private int _readTimeout = 500;
        private int _writeTimeout = 500;
        private string _portName = "COM4";

        public int WriteTimeout
        {
            get { return _writeTimeout; }
            set { _writeTimeout = value; }
        }

        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }

        public int ReadTimeout
        {
            get { return _readTimeout; }
            set { _readTimeout = value; }
        }

        public Handshake Handshake
        {
            get { return _handshake; }
            set { _handshake = value; }
        }

        public StopBits StopBits
        {
            get { return _stopBits; }
            set { _stopBits = value; }
        }

        public int DataBits
        {
            get { return _dataBits; }
            set { _dataBits = value; }
        }

        public Parity Parity
        {
            get { return _parity; }
            set { _parity = value; }
        }

        public int BaudRate
        {
            get { return _baudRate; }
            set { _baudRate = value; }
        }
    }
}
