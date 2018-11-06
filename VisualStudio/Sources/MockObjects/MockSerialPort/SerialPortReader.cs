using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Options;
using Elreg.Log;

namespace Elreg.UnitTests.MockObjects.MockSerialPort
{
    public class SerialPortReader : ISerialPortReader
    {
        private string _fileContent = string.Empty;
        private readonly System.Timers.Timer _timer = new System.Timers.Timer();
        private string _dataToSend = string.Empty;
        private int _fileContentIndex;

        private const int Datalength = 30;
        private const string Filename = @"\TestData\scx aufbereitet.txt";

        public delegate void DataReceivedHandler(object sender, string line, DateTime timeStamp);
        public event DataReceivedHandler DataReceived;

        public delegate void StatusChangedHandler(object sender, SerialPortReaderStatus status);
        public event StatusChangedHandler StatusChanged;

        public void InvokeStatusChanged(SerialPortReaderStatus status)
        {
            StatusChangedHandler handler = StatusChanged;
            if (handler != null) handler(this, status);
        }

        public SerialPortReader()
        {
            _timer.Enabled = false;
            _timer.Interval = 50;
            _timer.Elapsed += TimerElapsed;
        }

        public event Delegates.DataReceivedAsTextHandler DataReceivedAsText;

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

        public void Start()
        {
            ReadFile();
            _timer.Enabled = true;
        }

        public void Stop()
        {
            _timer.Enabled = false;
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

        private void ReadFile()
        {
            if (File.Exists(FileName))
            {
                StreamReader myFile = new StreamReader(FileName, System.Text.Encoding.Default);
                _fileContent = myFile.ReadToEnd();
                myFile.Close();
            }
            else
                MessageBox.Show(FileName + @" not found.");
        }

        private string FileName
        {
            get { return Application.StartupPath + Filename; }
        }

        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                CalcDataToSend();
                SendEventDataReceived();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CalcDataToSend()
        {
            if (_fileContentIndex + Datalength > _fileContent.Length)
                _fileContentIndex = 0;
            _dataToSend = _fileContent.Substring(_fileContentIndex, Datalength);
            _fileContentIndex += Datalength;
        }

        private void SendEventDataReceived()
        {
            if (DataReceived != null && !string.IsNullOrEmpty(_dataToSend))
                DataReceived(this, _dataToSend, DateTime.Now);
        }

    }
}
