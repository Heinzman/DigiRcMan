using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;

namespace Elreg.ArduinoService.SsdCtrlConfig
{
    public abstract class SsdCtrlConfigWriter
    {
        private readonly ISerialPortWriter _serialPortWriter;
        private int _levelAndButtonByte;
        private int _valueByte1;
        private int _valueByte2;
        private ControllerLevel _level;
        private int _value;
        protected int ButtonFlags;

        private const int SsdCtrlConfigStart = 233;

        protected SsdCtrlConfigWriter(ISerialPortWriter serialPortWriter)
        {
            _serialPortWriter = serialPortWriter;
        }

        public void Send(ControllerLevel level, int value)
        {
            _level = level;
            _value = value;
            CalcAndSendData();
        }

        private void CalcAndSendData()
        {
            _levelAndButtonByte = (int)_level | ButtonFlags;
            CalcValueBytes();
            SendData();
        }

        private void CalcValueBytes()
        {
            _valueByte1 = (_value & 768) >> 8;
            _valueByte2 = _value & 255;
        }

        private void SendData()
        {
            List<int> intValues = new List<int> { SsdCtrlConfigStart, _levelAndButtonByte, _valueByte1, _valueByte2 };
            _serialPortWriter.Write(intValues);
        }
    }
}
