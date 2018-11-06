using System.Collections.Generic;
using Elreg.BusinessObjects.Interfaces;

namespace Elreg.ArduinoService
{
    public class ArduinoDelayModeWriter
    {
        private readonly ISerialPortWriter _serialPortWriter;
        private int _modeData;

        private const int DelayAccFactorStart = 228;
        private const int DelayBrakeFactorStart = 229;
        private const int MaxSpeedWithoutTurboStart = 231;

        public ArduinoDelayModeWriter(ISerialPortWriter serialPortWriter)
        {
            _serialPortWriter = serialPortWriter;
        }

        public void SendDelayAccelerationFactor(int delayAccelerationFactor)
        {
            _modeData = delayAccelerationFactor;
            SendModeData(DelayAccFactorStart);
        }

        public void SendDelayBrakeFactor(int delayBrakeFactor)
        {
            _modeData = delayBrakeFactor;
            SendModeData(DelayBrakeFactorStart);
        }


        public void SendMaxSpeedWithoutTurbo(uint maxSpeedWithoutTurbo)
        {
            _modeData = (int)maxSpeedWithoutTurbo;
            SendModeData(MaxSpeedWithoutTurboStart);
        }


        private void SendModeData(int startByte)
        {
            List<int> intValues = new List<int> { startByte, _modeData };
            _serialPortWriter.Write(intValues);
        }

    }
}
