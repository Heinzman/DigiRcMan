using System;
using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Options;

namespace Elreg.UnitTests.MockObjects.MockSerialPort
{
    // ReSharper disable UnusedMember.Global
    public class SerialPortReaderMock : ISerialPortReader
    {
        private string _dataToSend;

        public delegate void DataReceivedHandler(object sender, string line, DateTime timeStamp);
        public event DataReceivedHandler DataReceived;

        public event Delegates.DataReceivedAsTextHandler DataReceivedAsText;

        public void OnDataReceivedAsText(string text)
        {
            Delegates.DataReceivedAsTextHandler handler = DataReceivedAsText;
            if (handler != null) handler(this, text);
        }

        public void Attach(ISerialPortObserver serialPortObserver)
        {
            DataReceived += serialPortObserver.SerialPortDataReceived;
        }

        public void Detach(ISerialPortObserver serialPortObserver)
        {
            DataReceived -= serialPortObserver.SerialPortDataReceived;
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }

        public void Assign(SerialPortSettings serialPortSettings) { }

        public List<string> GetPortNames()
        {
            return new List<string>();
        }

        public string PortName
        {
            get { return "COM4"; }
            set { }
        }

        public void SendData(string data)
        {
            _dataToSend = data;
            SendEventDataReceived();
        }

        private void SendEventDataReceived()
        {
            if (DataReceived != null && !string.IsNullOrEmpty(_dataToSend))
                DataReceived(this, _dataToSend, DateTime.Now);
        }

    }
}
