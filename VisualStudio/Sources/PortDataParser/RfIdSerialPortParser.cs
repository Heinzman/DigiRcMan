using System;
using System.Globalization;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.PortActions;
using Elreg.Log;

namespace Elreg.PortDataParser
{
    public class RfIdSerialPortParser : ISerialPortObserver, ISerialPortParser
    {
        private readonly RfIdSettings _rfIdSettings;
        private int _indexDetected;
        private LapDetectionAction _lapAction;
        private string _lineFromReader = string.Empty;
        private string _textIgnored = string.Empty;
        private string _textOutstanding = string.Empty;
        private string _textParsedAndDetected = string.Empty;
        private string _textToParse = string.Empty;
        private DateTime _timeStamp;
        private bool _isLapDetected;
        private bool _arduinoDataDetected;

        // Bsp: FF EE 01 20 A0 BC 30 0E
        // FF: Startindikator
        // EE: Mode LapDetection
        // 01: künstliche Id der RfId Karte
        // 20: Signalstärke
        // A0 BC 30 0E: 4-stellige RfId TagId  

        private const int TextToParseLength = 8 * 3 - 1; 

        private const int ByteForLapDetection = 238; // EE

        public event EventHandler<PortParserEventArgs> DataReceived;
        public event EventHandler<PortParserMockEventArgs> GetControllersData
        {
            add {  }
            remove {  }
        }
        public event EventHandler StartStopRequested;
        public event EventHandler ImAliveDetected;

        public RfIdSerialPortParser(ISerialPortReader portReader, RfIdSettings rfIdSettings)
        {
            _rfIdSettings = rfIdSettings;
            portReader.Attach(this);
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
                do
                {
                    _isLapDetected = false;

                    _arduinoDataDetected = false;
                    DetectArduinoData();
                    if (_arduinoDataDetected)
                    {
                        ObtainTextIgnored();
                        ShortenTextToParse();
                        ObtainTextOutstanding();
                        if (_isLapDetected)
                            RaiseLapDetected();
                    }
                } while (_arduinoDataDetected);
            }
            catch (Exception ex)
            {
                _textToParse = string.Empty;
                _textOutstanding = string.Empty;
                ErrorLog.LogError(false, ex);
            }
        }

        private void DetectArduinoData()
        {
            _indexDetected = _textToParse.IndexOf("FF");

            if (_indexDetected >= 0 && _textToParse.Length >= _indexDetected + TextToParseLength)
            {
                _arduinoDataDetected = true;
                _textParsedAndDetected = _textToParse.Substring(_indexDetected, TextToParseLength);
                string[] bytes = _textParsedAndDetected.Split(' ');

                if (bytes.Length > 7)
                {
                    int modeByte = int.Parse(bytes[1], NumberStyles.HexNumber);
                    int rfIdCardIdByte = int.Parse(bytes[2], NumberStyles.HexNumber);
                    string data = bytes[4] + " " + bytes[5] + " " + bytes[6] + " " + bytes[7];

                    if (modeByte == ByteForLapDetection)
                    {
                        int? carId = null;
                        foreach (var tagIdsOfCarId in _rfIdSettings.TagIdsOfCarIdList)
                        {
                            foreach (var tagId in tagIdsOfCarId.TagIds)
                            {
                                if (data == tagId)
                                {
                                    carId = tagIdsOfCarId.CarId;
                                    break;
                                }
                            }
                            if (carId.HasValue)
                                break;
                        }

                        if (carId.HasValue)
                        {
                            _isLapDetected = true;
                            _lapAction = new LapDetectionAction { TimeStamp = _timeStamp };
                            if (carId == 1)
                                _lapAction.Car1 = true;
                            else if (carId == 2)
                                _lapAction.Car2 = true;
                            else if (carId == 3)
                                _lapAction.Car3 = true;
                            else if (carId == 4)
                                _lapAction.Car4 = true;
                            else if (carId == 5)
                                _lapAction.Car5 = true;
                            else if (carId == 6)
                                _lapAction.Car6 = true;
                        }
                    }
                }
            }
        }

        private void ClearText()
        {
            _textParsedAndDetected = string.Empty;
        }

        private void UpdateTextToParse()
        {
            _textToParse += _lineFromReader;
        }

        private void ShortenTextToParse()
        {
            if (_indexDetected >= 0)
                _textToParse = _textToParse.Substring(_indexDetected + TextToParseLength);
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

        private void RaiseLapDetected()
        {
            DataReceived?.Invoke(this, new PortParserEventArgs(_textParsedAndDetected, _textIgnored, _textOutstanding,
                null, _lapAction));
        }

    }
}