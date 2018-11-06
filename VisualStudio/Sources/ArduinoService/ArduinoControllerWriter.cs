using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;

namespace Elreg.ArduinoService
{
    public class ArduinoControllerWriter
    {
        private readonly ISerialPortWriter _serialPortWriter;
        private int _dataByte;
        private LaneId _laneId;

        private const int DelayModeStart = 225;
        private const int CtrlModeStart = 226;
        private const int MaxSpeedStart = 227;

        public ArduinoControllerWriter(ISerialPortWriter serialPortWriter)
        {
            _serialPortWriter = serialPortWriter;
        }

        public void SendTurboActivatedOn(LaneId laneId)
        {
            _laneId = laneId;
            _dataByte = 2;
            SendData(CtrlModeStart);
        }

        public void SendTurboActivatedOff(LaneId laneId)
        {
            _laneId = laneId;
            _dataByte = 1;
            SendData(CtrlModeStart);
        }

        public void SendIsArduinoControlled(LaneId laneId)
        {
            _laneId = laneId;
            _dataByte = 16;
            SendData(CtrlModeStart);
        }

        public void SendIsVcuControlled(LaneId laneId)
        {
            _laneId = laneId;
            _dataByte = 8;
            SendData(CtrlModeStart);
        }

        public void SendMaxSpeed(LaneId laneId, uint maxSpeed)
        {
            _laneId = laneId;
            _dataByte = (int)maxSpeed;
            SendData(MaxSpeedStart);
        }

        private void SendData(int startByte)
        {
            int ctrlByte = (int)_laneId << 5;
            int data = ctrlByte | _dataByte;
            List<int> intValues = new List<int> { startByte, data };
            _serialPortWriter.Write(intValues);
        }
    }
}
