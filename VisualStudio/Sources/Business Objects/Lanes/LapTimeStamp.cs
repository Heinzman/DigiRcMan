using System;

namespace Elreg.BusinessObjects.Lanes
{
    public class LapTimeStamp
    {
        public int Lap { get; set; }
        public DateTime TimeStamp { get; set; }

        public LapTimeStamp(int lap)
        {
            Lap = lap;
            TimeStamp = DateTime.Now;
        }
    }
}
