using System;
using System.Globalization;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.PortActions;
using Elreg.Log;

namespace Elreg.PortDataParser
{
    public class SerialPortParser : ISerialPortObserver, ISerialPortParser
    {
        private bool _actionDetected;
        private CarControllersAction _carControllersAction;
        private int _indexDetected;
        private LapDetectionAction _lapAction;
        private LapDetectionAction _lastLapAction;
        private string _lineFromReader = string.Empty;
        private string _textIgnored = string.Empty;
        private string _textOutstanding = string.Empty;
        private string _textParsedAndDetected = string.Empty;
        private string _textToParse = string.Empty;
        private DateTime _timeStamp;
        private bool _isUsbUsed;
        private int _countSerialPortDataReceived;

        private const int TextToParseLengthWithoutUsb = 27;
        private const uint DataIndexStartWithoutUsb = 2;
        private const int TextToParseLengthWithUsb = 30;
        private const uint DataIndexStartWithUsb = 3;

        private const string BytesForLapDetectionWithUsb = "AB FF DD";
        private const string BytesForLapDetectionWithoutUsb = "AB DD";
        private const string BytesForControllerWithoutUsb = "AB FF";
        private const string BytesForControllerWithUsb = "AB FF FF";

        private const int MaxCountForUsbDetermination = 100;

        public event EventHandler<PortParserEventArgs> DataReceived;
        public event EventHandler<PortParserMockEventArgs> GetControllersData
        {
            add {  }
            remove {  }
        }

        public SerialPortParser(ISerialPortReader portReader)
        {
            portReader.Attach(this);
        }

        private int IndexDetectedLap
        {
            get
            {
                string bytesForLapDetection;

                if (_isUsbUsed)
                    bytesForLapDetection = BytesForLapDetectionWithUsb;
                else
                    bytesForLapDetection = BytesForLapDetectionWithoutUsb;

                return _textToParse.IndexOf(bytesForLapDetection);
            }
        }

        private int IndexDetectedController
        {
            get
            {
                string bytesForController;

                if (_isUsbUsed)
                    bytesForController = BytesForControllerWithUsb;
                else
                    bytesForController = BytesForControllerWithoutUsb;

                return _textToParse.IndexOf(bytesForController);
            }
        }

        private uint DataIndexStart
        {
            get
            {
                if (_isUsbUsed)
                    return DataIndexStartWithUsb;
                else
                    return DataIndexStartWithoutUsb;
            }
        }

        private int TextToParseLength
        {
            get
            {
                if (_isUsbUsed)
                    return TextToParseLengthWithUsb;
                else
                    return TextToParseLengthWithoutUsb;
            }
        }

        private uint DataIndexOne
        {
            get { return DataIndexStart; }
        }

        private uint DataIndexTwo
        {
            get { return DataIndexStart + 1; }
        }

        private uint DataIndexThree
        {
            get { return DataIndexStart + 2; }
        }

        private uint DataIndexFour
        {
            get { return DataIndexStart + 3; }
        }

        private uint DataIndexFive
        {
            get { return DataIndexStart + 4; }
        }

        private uint DataIndexSix
        {
            get { return DataIndexStart + 5; }
        }

        private bool ActionMustBeRaised
        {
            get { return !IsLapActionDetected || LapActionIsValid && !LastActionWasSameLap; }
        }

        private bool LastActionWasSameLap
        {
            get
            {
                return WasLastLapActionDetected && IsLapActionDetected &&
                       _lapAction.Car1 == _lastLapAction.Car1 &&
                       _lapAction.Car2 == _lastLapAction.Car2 &&
                       _lapAction.Car3 == _lastLapAction.Car3 &&
                       _lapAction.Car4 == _lastLapAction.Car4 &&
                       _lapAction.Car5 == _lastLapAction.Car5 &&
                       _lapAction.Car6 == _lastLapAction.Car6;
            }
        }

        private bool LapActionIsValid
        {
            get
            {
                return IsLapActionDetected && (_lapAction.Car1 || _lapAction.Car2 ||
                                               _lapAction.Car3 || _lapAction.Car4 ||
                                               _lapAction.Car5 || _lapAction.Car6);
            }
        }

        private bool IsLapActionDetected
        {
            get { return _lapAction != null; }
        }

        private bool WasLastLapActionDetected
        {
            get { return _lastLapAction != null; }
        }

        public void SerialPortStatusChanged(object sender, SerialPortReaderStatus status)
        {
        }

        public void SerialPortDataReceived(object sender, string line, DateTime timeStamp)
        {
            try
            {
                ClearText();
                _timeStamp = timeStamp;
                _lineFromReader = line.Replace("\r", "").Replace("\n", "").ToUpper();
                UpdateTextToParse();
                CheckToDetermineUsbUsage();
                do
                {
                    DetectAction();
                    if (_actionDetected)
                    {
                        ObtainTextIgnored();
                        ShortenTextToParse();
                        ObtainTextOutstanding();
                        if (ActionMustBeRaised)
                        {
                            SetLastLapActionIfExists();
                            RaiseEventDataReceived();
                        }
                    }
                } while (_actionDetected);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CheckToDetermineUsbUsage()
        {
            if (_countSerialPortDataReceived++ > MaxCountForUsbDetermination)
            {
                _countSerialPortDataReceived = 0;
                DetermineUsbUsage();
            }
        }

        private void DetermineUsbUsage()
        {
            if (!_isUsbUsed && _textToParse.Contains(BytesForControllerWithUsb))
                _isUsbUsed = true;
            else if (_isUsbUsed)
            {
                int index = _textToParse.IndexOf(BytesForControllerWithoutUsb);
                if (index >= 0 && _textToParse.Length > index + 10)
                    _isUsbUsed = false;
            }
        }

        private void SetLastLapActionIfExists()
        {
            if (IsLapActionDetected)
                _lastLapAction = _lapAction;
        }

        private void ClearText()
        {
            _textParsedAndDetected = string.Empty;
        }

        private void UpdateTextToParse()
        {
            _textToParse += _lineFromReader;

            if (_textToParse.Contains("D"))
                _textToParse += "";
        }

        private void ShortenTextToParse()
        {
            if (_indexDetected >= 0)
                _textToParse = _textToParse.Substring(_indexDetected + TextToParseLength);
        }

        private void DetectAction()
        {
            _actionDetected = false;
            DetectLap();
            if (!_actionDetected)
                DetectController();
        }

        private void DetectLap()
        {
            _lapAction = null;
            _indexDetected = IndexDetectedLap;

            if (_indexDetected >= 0 && _textToParse.Length >= _indexDetected + TextToParseLength)
            {
                _actionDetected = true;
                _lapAction = new LapDetectionAction {TimeStamp = _timeStamp};
                _textParsedAndDetected = _textToParse.Substring(_indexDetected, TextToParseLength);
                string[] bytes = _textParsedAndDetected.Split(new[] {' '});

                if (bytes[DataIndexOne] == "CF")
                    _lapAction.Car1 = true;
                if (bytes[DataIndexTwo] == "CF")
                    _lapAction.Car2 = true;
                if (bytes[DataIndexThree] == "CF")
                    _lapAction.Car3 = true;
                if (bytes[DataIndexFour] == "CF")
                    _lapAction.Car4 = true;
                if (bytes[DataIndexFive] == "CF")
                    _lapAction.Car5 = true;
                if (bytes[DataIndexSix] == "CF")
                    _lapAction.Car6 = true;
            }
        }

        private void DetectController()
        {
            try
            {
                _carControllersAction = null;
                _indexDetected = IndexDetectedController;

                if (_indexDetected >= 0 && _textToParse.Length >= _indexDetected + TextToParseLength)
                {
                    _actionDetected = true;
                    _lastLapAction = null;
                    _carControllersAction = new CarControllersAction();
                    _textParsedAndDetected = _textToParse.Substring(_indexDetected, TextToParseLength);
                    string[] bytes = _textParsedAndDetected.Split(new[] { ' ' });

                    _carControllersAction.CarController1 = ParseCarController(bytes[DataIndexOne]);
                    _carControllersAction.CarController2 = ParseCarController(bytes[DataIndexTwo]);
                    _carControllersAction.CarController3 = ParseCarController(bytes[DataIndexThree]);
                    _carControllersAction.CarController4 = ParseCarController(bytes[DataIndexFour]);
                    _carControllersAction.CarController5 = ParseCarController(bytes[DataIndexFive]);
                    _carControllersAction.CarController6 = ParseCarController(bytes[DataIndexSix]);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ObtainTextIgnored()
        {
            _textIgnored = string.Empty;

            if (_indexDetected > 0)
                _textIgnored = _textToParse.Substring(0, _indexDetected);
        }

        private void ObtainTextOutstanding()
        {
            _textOutstanding = _textToParse;
        }

        private CarController ParseCarController(string byteString)
        {
            var carController = new CarController();
            byte hexByte;
            if (byte.TryParse(byteString, NumberStyles.HexNumber, null, out hexByte))
            {
                if (hexByte == 0x55)
                {
                    carController.Speed = 0;
                    carController.LaneChange = false;
                }
                else
                {
                    carController.Speed = (uint) ((hexByte & 31) >> 1);
                    if (carController.Speed > 12)
                        carController.Speed = 12;
                    carController.LaneChange = (hexByte & 32) == 0;
                }
            }
            return carController;
        }

        private void RaiseEventDataReceived()
        {
            if (DataReceived != null)
                DataReceived(this, new PortParserEventArgs(_textParsedAndDetected, _textIgnored, _textOutstanding,
                                                           _carControllersAction, _lapAction));
        }

    }
}