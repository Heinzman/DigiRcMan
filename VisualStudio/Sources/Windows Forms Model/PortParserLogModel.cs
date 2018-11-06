using System;
using Heinzman.BusinessObjects.DerivedEventArgs;
using Heinzman.BusinessObjects.Interfaces;
using Heinzman.PortDataParser;

namespace Heinzman.DomainModels
{
    public class PortParserLogModel
    {
        private readonly IPortParser _portParser;

        public PortParserLogModel(IPortParser portParser)
        {
            _portParser = portParser;
            _portParser.DataReceived += PortParserLogReceived;
        }

        public event EventHandler<PortParserEventArgs> LogReceived;

        private void PortParserLogReceived(object sender, PortParserEventArgs e)
        {
            if (LogReceived != null)
                LogReceived(this, e);
        }
    }
}