using Elreg.BusinessObjects.PortActions;

namespace Elreg.BusinessObjects.DerivedEventArgs
{
    public class ParserEventArgs : PortParserEventArgs
    {
        public LapDetectionAction LapAction { get; private set; }

        public ParserEventArgs(string comPortLine, string comPortDataIgnored, string comPortDataOutstanding,
                               CarControllersAction carControllersAction, LapDetectionAction lapDetectionAction,
                               LapDetectionAction lapAction)
            : base(comPortLine, comPortDataIgnored, comPortDataOutstanding,
                carControllersAction, lapDetectionAction)
        {
            LapAction = lapAction;
        }
    }

}
