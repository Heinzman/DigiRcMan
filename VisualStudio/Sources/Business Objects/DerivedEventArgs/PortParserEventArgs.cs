using Elreg.BusinessObjects.PortActions;

namespace Elreg.BusinessObjects.DerivedEventArgs
{
    public class PortParserEventArgs : System.EventArgs
    {
        public string ComPortDataIgnored { get; private set; }

        public string ComPortDataOutstanding { get; private set; }

        public CarControllersAction CarControllersAction { get; set; }

        public LapDetectionAction LapDetectionAction { get; set; }

        public string ComPortLine { get; private set; }

        public PortParserEventArgs(string comPortLine, string comPortDataIgnored, string comPortDataOutstanding,
                                      CarControllersAction carControllersAction, LapDetectionAction lapDetectionAction)
        {
            ComPortLine = comPortLine;
            ComPortDataIgnored = comPortDataIgnored;
            ComPortDataOutstanding = comPortDataOutstanding;
            CarControllersAction = carControllersAction;
            LapDetectionAction = lapDetectionAction;
        }

        public PortParserEventArgs() : this(string.Empty, string.Empty, string.Empty, null, null)
        {
        }

    }

}
