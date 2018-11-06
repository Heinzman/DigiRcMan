using System;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.Log;

namespace Elreg.ArduinoService
{
    public class ArduinoReader : ISerialPortObserver, IArduinoReader
    {
        private readonly ISerialPortReader _serialPortReader;
        private LaneId _laneId;
        private bool _arduinoDataDetected;
        private int _indexDetected;
        private string _lineFromReader = string.Empty;
        private string _textParsedAndDetected = string.Empty;
        private string _textToParse = string.Empty;
        private bool _isButtonClicked;
        private bool _isPauseOrRestartRequested;

        private const int TextToParseLength = 2 * 3;

        public event Delegates.SsdControllerHandler UpperButtonClicked;
        public event Delegates.SsdControllerHandler PauseOrRestartRequested;

        public ArduinoReader(ISerialPortReader serialPortReader)
        {
            _serialPortReader = serialPortReader;
            _serialPortReader.Attach(this);
        }

        public void SerialPortDataReceived(object sender, string line, DateTime timeStamp)
        {
            try
            {
                ClearText();
                _lineFromReader = line.Replace("\r", "").Replace("\n", "").ToUpper();
                UpdateTextToParse();
                do
                {
                    _isButtonClicked = false;
                    _isPauseOrRestartRequested = false;
                    _arduinoDataDetected = false;
                    DetectArduinoData();
                    if (_arduinoDataDetected)
                    {
                        ObtainTextIgnored();
                        ShortenTextToParse();
                        ObtainTextOutstanding();
                        if (_isButtonClicked)
                            RaiseUpperButtonClicked();
                        if (_isPauseOrRestartRequested)
                            RaisePauseOrRestartRequested();
                    }
                } while (_arduinoDataDetected);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaisePauseOrRestartRequested()
        {
            if (PauseOrRestartRequested != null)
                PauseOrRestartRequested(this, _laneId);
        }

        private void RaiseUpperButtonClicked()
        {
            if (UpperButtonClicked != null)
                UpperButtonClicked(this, _laneId);
        }

        private void DetectArduinoData()
        {
            _indexDetected = _textToParse.IndexOf("E8");

            if (_indexDetected >= 0 && _textToParse.Length >= _indexDetected + TextToParseLength)
            {
                _arduinoDataDetected = true;
                _textParsedAndDetected = _textToParse.Substring(_indexDetected, TextToParseLength);
                string[] bytes = _textParsedAndDetected.Split(new[] { ' ' });

                if (bytes.Length > 1)
                {
                    int dataByte = int.Parse(bytes[1], System.Globalization.NumberStyles.HexNumber);

                    _isButtonClicked = (dataByte & 1) == 1;
                    _isPauseOrRestartRequested = (dataByte & 2) == 2;
                    _laneId = (LaneId) ((dataByte & 224) >> 5);
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

        private void ObtainTextIgnored()
        {
        }

        private void ObtainTextOutstanding()
        {
        }

        private void ShortenTextToParse()
        {
            if (_indexDetected >= 0)
            {
                if (_textToParse.Length >= _indexDetected + TextToParseLength)
                    _textToParse = _textToParse.Substring(_indexDetected + TextToParseLength);
                else
                    _textToParse = _textToParse.Substring(_indexDetected);
            }
        }

        public void SerialPortStatusChanged(object sender, SerialPortReaderStatus status)
        {
        }

    }
}
