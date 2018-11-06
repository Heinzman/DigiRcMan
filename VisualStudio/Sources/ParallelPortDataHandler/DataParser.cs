using System;
using Elreg.BusinessObjects.Interfaces;
using Elreg.Log;

namespace Elreg.ParallelPortDataHandler
{
    public class DataParser : IParallelPortObserver
    {
        private bool _isPinSwitchedOn;
        private bool _wasPinSwitchedOn;
        private int _portValue;
        private int _inputPin = 15;
        private bool _isPinValueInverted;
        private int _bitValue;

        private const int Pin15Bit = 8;
        private const int Pin13Bit = 16;
        private const int Pin12Bit = 32;
        private const int Pin10Bit = 64;
        private const int Pin11Bit = 128;

        public delegate void PinValueChangedHandler(object sender, bool pinValue);
        public event PinValueChangedHandler PinValueChanged;

        public DataParser(IParallelPortReader portReader)
        {
            portReader.Attach(this);
            InitValues();
        }

        public void ParallelPortDataReceived(object sender, int portValue)
        {
            try
            {
                _portValue = portValue;
                CalcPinValue();
                if (HasPinValueChanged)
                {
                    _wasPinSwitchedOn = _isPinSwitchedOn;
                    RaiseEventPortDataReceived();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public bool IsPinSwitchedOn
        {
            get { return _isPinSwitchedOn; }
        }

        public int InputPin
        {
            get { return _inputPin; }
            set { _inputPin = value; }
        }

        private void InitValues()
        {
            _portValue = 0;
            _isPinSwitchedOn = false;
            _wasPinSwitchedOn = _isPinSwitchedOn;
        }

        private void CalcPinValue()
        {
            DetermineBitValueOfInputPin();
            int value = 1;
            if (_isPinValueInverted)
                value = 0;
            _isPinSwitchedOn = (_portValue & _bitValue) == value;
        }

        private bool HasPinValueChanged
        {
            get { return _wasPinSwitchedOn != _isPinSwitchedOn; }
        }

        private void RaiseEventPortDataReceived()
        {
            if (PinValueChanged != null)
                PinValueChanged(this, _isPinSwitchedOn);
        }

        private void DetermineBitValueOfInputPin()
        {
            _bitValue = 0;
            _isPinValueInverted = true;

            switch (_inputPin)
            {
                case 15:
                    _bitValue = Pin15Bit;
                    break;
                case 13:
                    _bitValue = Pin13Bit;
                    break;
                case 12:
                    _bitValue = Pin12Bit;
                    break;
                case 11:
                    _bitValue = Pin11Bit;
                    _isPinValueInverted = false;
                    break;
                case 10:
                    _bitValue = Pin10Bit;                   
                    break;
            }
        }

    }
}
