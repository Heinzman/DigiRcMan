using Elreg.BusinessObjects.Lanes;

namespace Elreg.BusinessObjects.DerivedEventArgs
{
    public class LaneEventArgs : System.EventArgs
    {
        public LaneEventArgs(Lane lane)
        {
            Lane = lane;
        }

        public Lane Lane { get; set; }
    }
}