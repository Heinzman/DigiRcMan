using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Options;
using Elreg.Log;

namespace Elreg.SerialPortReader.SerialPortReaders
{
    // ReSharper disable FunctionNeverReturns
    public class PortReaderQueue : ISerialPortReader
    {
        private readonly Queue<TimeStampedData> _queue = new Queue<TimeStampedData>();
        private Thread _thread;

        private const int ThreadSleepMilliSecs = 2;

        public delegate void DataReceivedHandler(object sender, string line, DateTime timeStampOfLapAddition);
        public event DataReceivedHandler DataReceived;

        public delegate void StatusChangedHandler(object sender, SerialPortReaderStatus status);
        public event StatusChangedHandler StatusChanged;

        public event Delegates.DataReceivedAsTextHandler DataReceivedAsText;

        public PortReaderQueue(ISerialPort serialPort)
        {
            SerialPort = serialPort;
            SerialPort.DataReceived += SerialPortDataReceived;
        }

        private void StartThread()
        {
            _thread = new Thread(ThreadRun);
            _thread.Start();
        }

        private void StopThread()
        {
            if (_thread != null && _thread.IsAlive)
                _thread.Abort();
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
                StartThread();
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
            StopThread();
        }

        public List<string> GetPortNames()
        {
            List<string> portNames = new List<string>();
            portNames.AddRange(SerialPort.GetPortNames());
            return portNames;
        }

        public void InvokeDataReceivedAsText(string text)
        {
            Delegates.DataReceivedAsTextHandler handler = DataReceivedAsText;
            if (handler != null) handler(this, text);
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
                string data = ByteArrayToHexString(buffer);
                if (data.Length > 0)
                    EnqueueData(data, timeStamp);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void EnqueueData(string data, DateTime timeStamp)
        {
            lock (((ICollection)_queue).SyncRoot)
            {
                TimeStampedData timeStampedData = new TimeStampedData {Data = data, TimeStamp = timeStamp};
                _queue.Enqueue(timeStampedData);
            }
        }

        private void ThreadRun()
        {
            do
            {
                lock (((ICollection)_queue).SyncRoot)
                {
                    if (_queue.Count > 0)
                    {
                        TimeStampedData timeStampedData = _queue.Dequeue();
                        SendEventDataReceived(timeStampedData);
                    }
                }
                Thread.Sleep(ThreadSleepMilliSecs);
            } while (true);
        }

        private void SendEventDataReceived(TimeStampedData timeStampedData)
        {
            if (DataReceived != null)
                DataReceived(this, timeStampedData.Data, timeStampedData.TimeStamp);
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

        private ISerialPort SerialPort { get; set; }

        private SerialPortReaderStatus Status { get; set; }

    }
}
