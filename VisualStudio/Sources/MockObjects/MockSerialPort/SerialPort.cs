using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Options;
using Elreg.Exceptions;

namespace Elreg.UnitTests.MockObjects.MockSerialPort
{
    // ReSharper disable FunctionNeverReturns
    public class SerialPort : ISerialPort
    {
        private bool _isOpen;
        private string _fileContent;
        private string _dataToSend = string.Empty;
        private readonly System.Timers.Timer _timer = new System.Timers.Timer();
        private bool _dataExists;
        private readonly List<TimeStampedData> _timestampedDataList = new List<TimeStampedData>();

        private const int MilliSecsToSleep = 2;
        private const char Separator1 = '|';
        private const char Separator2 = ';';

        //private const string Filename = @"\TestData\Car 1-3 Only speed.txt";
        //private const string Filename = @"\TestData\car2.txt";
        //private const string Filename = @"\TestData\car1_4 for soundtest while lap added.txt";
        //private const string Filename = @"\TestData\car1_4.txt";
        //private const string Filename = @"\TestData\car1_4 with timestamp.txt";
        private const string Filename = @"\TestData\PortReaderLog_20110828_181811.txt";
        //private const string Filename = @"\TestData\Fast Laps of 4 Cars.txt";
        //private const string Filename = @"\TestData\car2 many laps.txt";

        public event SerialDataReceivedEventHandler DataReceived;

        public SerialPort()
        {
            LoadTestData();
            ConvertFileContentToList();
            Thread thread = new Thread(ReadDataFromFileContent);
            thread.Start();
        }

        private void ConvertFileContentToList()
        {
            string[] lines = _fileContent.Split(Separator2);
            foreach (string line in lines)
            {
                string[] words = line.Split(Separator1);
                if (words.Length == 2)
                {
                    TimeStampedData timeStampedData = new TimeStampedData {TimeStamp = DateTime.Parse(words[0]), Data = words[1]};
                    _timestampedDataList.Add(timeStampedData);
                }
            }
        }

        public void Open() 
        {
            _timer.Enabled = true;
            _isOpen = true;
        }

        public void Close()
        {
            _timer.Enabled = false;
            _isOpen = false;
        }

        public bool IsOpen
        {
            get { return _isOpen; }
        }

        public string[] GetPortNames() 
        {
            string[] portnames = new[] {"COM4"};
            return portnames;
        }

        public string PortName
        {
            set { }
            get { return "COM4"; }
        }

        public int BytesToRead
        {
            get { return 9; }
        }

        public int Read(ref byte[] buffer, int offset, int count)
        {
            if (_dataExists)
            {
                buffer = HexToByte();
                _dataExists = false;
                return 9;
            }
            else
            {
                return 0;
            }
        }

        public void Assign(SerialPortSettings serialPortSettings) { }

        public void Write(byte[] buffer, int offset, int count) { }

        public void DiscardInBuffer() { }

        public void DiscardOutBuffer() { }

        private byte[] HexToByte()
        {
            string msg = _dataToSend.Clone().ToString();
            msg = msg.Replace(" ", "");
            byte[] comBuffer = new byte[msg.Length / 2];
            for (int i = 0; i < msg.Length; i += 2)
            {
                if (i+2 <= msg.Length)
                    comBuffer[i / 2] = Convert.ToByte(msg.Substring(i, 2), 16);
            }
            return comBuffer;
        }

        private void LoadTestData()
        {
            if (File.Exists(FileName))
            {
                StreamReader myFile = new StreamReader(FileName, Encoding.Default);
                _fileContent = myFile.ReadToEnd();
                myFile.Close();
            }
            else
                throw new LcException(FileName + " not found.");
        }

        private string FileName
        {
            get { return Application.StartupPath + Filename; }
        }

        private void ReadDataFromFileContent()
        {
            do
            {
                DateTime startDateTime = DateTime.Now;
                DateTime startTimeStamp = DateTime.Now;
                if (_timestampedDataList.Count > 0)
                    startTimeStamp = _timestampedDataList[0].TimeStamp;

                foreach (TimeStampedData timeStampedData in _timestampedDataList)
                {
                    while (DateTime.Now - startDateTime < timeStampedData.TimeStamp - startTimeStamp)
                        Thread.Sleep(MilliSecsToSleep);
                    _dataToSend = timeStampedData.Data;
                    _dataExists = true;
                    if (DataReceived != null)
                        DataReceived(this, null);
                }
            } while (true);
        }
    }
}
