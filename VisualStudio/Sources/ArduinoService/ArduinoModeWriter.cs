using System.Collections.Generic;
using Elreg.BusinessObjects.Interfaces;

namespace Elreg.ArduinoService
{
    public class ArduinoModeWriter
    {
        private readonly ISerialPortWriter _serialPortWriter;
        private int _modeData;

        private const int GlobalModeStart = 224;
        private const int GlobalMode2Start = 230;

        public ArduinoModeWriter(ISerialPortWriter serialPortWriter)
        {
            _serialPortWriter = serialPortWriter;
        }

        public void SendGlobalTurboOn()
        {
            _modeData = 2;
            SendGlobalModeData();
        }

        public void SendGlobalTurboOff()
        {
            _modeData = 1;
            SendGlobalModeData();
        }

        public void SendDebugModeOn()
        {
            _modeData = 8;
            SendGlobalModeData();
        }

        public void SendDebugModeOff()
        {
            _modeData = 4;
            SendGlobalModeData();
        }

        public void SendPrintStatus()
        {
            _modeData = 16;
            SendGlobalModeData();
        }

        public void SendResetAll()
        {
            _modeData = 32;
            SendGlobalModeData();
        }

        public void SendGlobalToggleModeOn()
        {
            _modeData = 2;
            SendGlobalMode2Data();
        }

        public void SendGlobalToggleModeOff()
        {
            _modeData = 1;
            SendGlobalMode2Data();
        }

        public void SendGlobalPauseOn()
        {
            _modeData = 8;
            SendGlobalMode2Data();
        }

        public void SendGlobalPauseOff()
        {
            _modeData = 4;
            SendGlobalMode2Data();
        }

        private void SendGlobalMode2Data()
        {
            SendModeData(GlobalMode2Start);
        }

        private void SendGlobalModeData()
        {
            SendModeData(GlobalModeStart);
        }

        private void SendModeData(int startByte)
        {
            List<int> intValues = new List<int> { startByte, _modeData };
            _serialPortWriter.Write(intValues);
        }

        public void SendPrintSsdCtrlValues()
        {
            _modeData = 3;
            SendGlobalModeData();
        }
    }
}
