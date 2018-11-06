using System;
using System.IO;
using System.Text;
using Heinzman.BusinessObjects;
using Heinzman.BusinessObjects.Interfaces;
using Heinzman.BusinessObjects.Options;
using System.IO.Ports;
using System.Windows.Forms;
using Heinzman.Exceptions;

namespace Heinzman.MockObjects
{
    public class MockSerialPort : ISerialPort
    {
        private bool _isOpen;
        private string _fileContent;
        private string _dataToSend = string.Empty;
        private int _fileContentIndex;
        private readonly Timer _timer = new Timer();
        private bool _dataExists;

        private const int Datalength = 27;
        //private const string FILENAME = @"\TestData\car2.txt";
        private const string Filename = @"\TestData\car1_4.txt";
        //private const string FILENAME = @"\TestData\Car 1-3 Only speed.txt";
        //private const string FILENAME = @"\TestData\car2 many laps.txt";

        public event SerialDataReceivedEventHandler DataReceived;

        public MockSerialPort()
        {
            LoadTestData();
            ConvertTestData();
            InitTimer();
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
                CalcDataToSend();
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

        public void DiscardInBuffer() { }
        public void DiscardOutBuffer()
        {
            throw new NotImplementedException();
        }

        private void InitTimer()
        {
            _timer.Enabled = false;
            _timer.Interval = 63;
            _timer.Tick += TimerTick;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            _dataExists = true;
            if (DataReceived != null)
                DataReceived(this, null);
        }

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

        private void CalcDataToSend()
        {
            if (_fileContentIndex + Datalength > _fileContent.Length)
                _fileContentIndex = 0;
            _dataToSend = _fileContent.Substring(_fileContentIndex, Datalength);
            _fileContentIndex += Datalength;
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

        private void ConvertTestData()
        {
            _fileContent = _fileContent.Replace("\n", "").Replace("\r", "");
        }

        private string FileName
        {
            get { return Application.StartupPath + Filename; }
        }


    }
}
