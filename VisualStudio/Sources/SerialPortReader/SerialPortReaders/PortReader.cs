using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO.Ports;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Options;
using Elreg.Log;

namespace Elreg.SerialPortReader.SerialPortReaders
{
    public class PortReader : ISerialPortReader
    {
        public delegate void DataReceivedHandler(object sender, string line, DateTime timeStampOfLapAddition);
        public event DataReceivedHandler DataReceived;

        public event Delegates.DataReceivedAsTextHandler DataReceivedAsText;

        public delegate void StatusChangedHandler(object sender, SerialPortReaderStatus status);
        public event StatusChangedHandler StatusChanged;

        public PortReader(ISerialPort serialPort)
        {
            SerialPort = serialPort;
            SerialPort.DataReceived += SerialPortDataReceived;
        }

        public void Start()
        {
            try
            {
                SetStatus(SerialPortReaderStatus.Connecting);
                if (SerialPort.IsOpen)
                    SerialPort.Close();

                SerialPort.Open();
                SetStatus(SerialPortReaderStatus.Started);
            }
            catch (Exception)
            {
                Stop();
                throw;
            }
        }

        public void Stop()
        {
            SerialPort.Close();
            SetStatus(SerialPortReaderStatus.Stopped);
        }

        public List<string> GetPortNames()
        {
            List<string> portNames = new List<string>();
            portNames.AddRange(SerialPort.GetPortNames());
            return portNames;
        }

        public void Attach(ISerialPortObserver serialPortObserver)
        {
            DataReceived += serialPortObserver.SerialPortDataReceived;
            StatusChanged += serialPortObserver.SerialPortStatusChanged;
        }

        public void Detach(ISerialPortObserver serialPortObserver)
        {
            DataReceived -= serialPortObserver.SerialPortDataReceived;
            StatusChanged -= serialPortObserver.SerialPortStatusChanged;
        }

        public void Assign(SerialPortSettings serialPortSettings)
        {
            SerialPort.Assign(serialPortSettings);
        }

        public string PortName
        {
            get { return SerialPort.PortName; }
            set { SerialPort.PortName = value; }
        }

        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                DateTime timeStamp = DateTime.Now;
                int bytes = SerialPort.BytesToRead;
                byte[] buffer = new byte[bytes];
                SerialPort.Read(ref buffer, 0, bytes);
                DebugPrintReceivedString(buffer);
                ReceivedData = ByteArrayToHexString(buffer);
                if (ReceivedData.Length > 0)
                {
                    SendEventDataReceived(timeStamp);
                    SendEventDataReceivedAsText(buffer);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SendEventDataReceivedAsText(byte[] buffer)
        {
            if (DataReceivedAsText != null)
            {
                ASCIIEncoding enc = new ASCIIEncoding();
                string text = enc.GetString(buffer);
                DataReceivedAsText(this, text);
            }
        }

        private void DebugPrintReceivedString(byte[] buffer)
        {
            string text = Encoding.ASCII.GetString(buffer);
            Debug.Write(text);
        }

        private void SendEventDataReceived(DateTime timeStamp)
        {
            if (DataReceived != null)
                DataReceived(this, ReceivedData, timeStamp);
        }

        private void SendEventStatusChanged()
        {
            if (StatusChanged != null)
                StatusChanged(this, Status);
        }

        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }

        private void SetStatus(SerialPortReaderStatus status)
        {
            Status = status;
            SendEventStatusChanged();
        }

        protected ISerialPort SerialPort { get; set; }

        private SerialPortReaderStatus Status { get; set; }

        private string ReceivedData { get; set; }
    }
}
