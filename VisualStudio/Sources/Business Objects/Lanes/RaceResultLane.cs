using System;
using System.Xml.Serialization;

namespace Elreg.BusinessObjects.Lanes
{
    [Serializable]
    public class RaceResultLane
    {
        public RaceResultLane()
        {
            Laps = 0;
            Position = 0;
            Penalties = 0;
            Points = 0;
        }

        public LaneId Id { get; set; }

        public int Points { get; set; }

        public int Penalties { get; set; }

        public int Position { get; set; }

        public int Laps { get; set; }

        [XmlIgnore]
        public TimeSpan? BestLapTime { get; set; }

        [XmlElement("BestLapTime", DataType = "duration")]
        public string XmlBestLapTime
        {
            get { return BestLapTime.ToString(); }
            set 
            {
                TimeSpan bestLapTime;
                if (TimeSpan.TryParse(value, out bestLapTime))
                    BestLapTime = bestLapTime;
                else
                    BestLapTime = null;
            }
        }

        public Driver Driver { get; set; }

        public Car Car { get; set; }

        [XmlIgnore]
        public TimeSpan RaceTimeNet { get; set; }

        [XmlElement("RaceTimeNet", DataType = "duration")]
        public string XmlRaceTimeNet
        {
            get { return RaceTimeNet.ToString(); }
            set
            {
                TimeSpan raceTimeNet;
                if (TimeSpan.TryParse(value, out raceTimeNet))
                    RaceTimeNet = raceTimeNet;
                else
                    RaceTimeNet = new TimeSpan();
            }
        }

        [XmlIgnore]
        public TimeSpan RaceTime { get; set; }

        [XmlElement("RaceTime", DataType = "duration")]
        public string XmlRaceTime
        {
            get { return RaceTime.ToString(); }
            set
            {
                TimeSpan raceTime;
                if (TimeSpan.TryParse(value, out raceTime))
                    RaceTimeNet = raceTime;
                else
                    RaceTimeNet = new TimeSpan();
            }
        }

        public bool IsDisqualified { get; set; }
    }
}
