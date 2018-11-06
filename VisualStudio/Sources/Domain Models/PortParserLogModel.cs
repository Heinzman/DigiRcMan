using System;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.Log;

namespace Elreg.DomainModels
{
    public class PortParserLogModel
    {
        private readonly ISerialPortParser _serialPortParser;

        public PortParserLogModel(ISerialPortParser serialPortParser)
        {
            _serialPortParser = serialPortParser;
            _serialPortParser.DataReceived += SerialPortParserLogReceived;
        }

        public event EventHandler<PortParserEventArgs> LogReceived;

        private void SerialPortParserLogReceived(object sender, PortParserEventArgs e)
        {
            try
            {
                if (LogReceived != null)
                    LogReceived(this, e);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }
    }
}