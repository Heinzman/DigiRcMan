using System.Collections.Generic;
using Elreg.BusinessObjects.Interfaces;

namespace Elreg.ArduinoService
{
    public class ArduinoPwmDataWriter
    {
        private readonly ISerialPortWriter _serialPortWriter;
        private List<int> _pwmValues;

        private const int PwmDataConfigStart = 234;

        public ArduinoPwmDataWriter(ISerialPortWriter serialPortWriter)
        {
            _serialPortWriter = serialPortWriter;
        }

        public void Send(List<int> pwmValues)
        {
            _pwmValues = pwmValues;
            CalcAndSendData();
        }

        private void CalcAndSendData()
        {
            List<int> intValues = new List<int> { PwmDataConfigStart };
            intValues.AddRange(_pwmValues);
            _serialPortWriter.Write(intValues);
        }
    }
}
