using System;

namespace Elreg.BusinessObjects.PortActions
{
    public class LapDetectionSingleAction
    {
        public bool Detected { get; set; }
        public DateTime? TimeStamp { get; set; }

        public LapDetectionSingleAction()
        {
            Detected = false;
            TimeStamp = null;
        }
    }
}