using System;

namespace Elreg.BusinessObjects.PortActions
{
    public class LapDetectionAction : ICloneable
    {
        public bool Car1 { get; set; }
        public bool Car2 { get; set; }
        public bool Car3 { get; set; }
        public bool Car4 { get; set; }
        public bool Car5 { get; set; }
        public bool Car6 { get; set; }
        public DateTime TimeStamp { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return "C1: " + Car1 + " C2: " + Car2 + " C3: " + Car3 + " C4: " + Car4 + " C5: " + Car5 + " C6: " + Car6 + " TimeStam: " + TimeStamp;
        }
    }
}