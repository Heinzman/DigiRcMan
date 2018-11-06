using Elreg.BusinessObjects.PortActions;

namespace Elreg.BusinessObjects.DerivedEventArgs
{
    public class PortParserMockEventArgs : System.EventArgs
    {
        public CarControllersAction CarControllersAction { get; set; }

        public LapDetectionAction LapDetectionAction { get; set; }

    }

}
