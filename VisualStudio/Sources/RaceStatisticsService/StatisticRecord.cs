using System;
using System.Xml.Serialization;
using Elreg.BusinessObjects.Races;

namespace Elreg.RaceStatisticsService
{
    [Serializable]
    public class StatisticRecord
    {
        public string TrackName { get; set; }
        public string EventName { get; set; }
        public int? CarId { get; set; }
        public string CarName { get; set; }
        public int? DriverId { get; set; }
        public string DriverName { get; set; }
        public Race.TypeEnum RaceType { get; set; }

        [XmlIgnore]
        public TimeSpan? LapTime { get; set; }

        [XmlElement("LapTime", DataType = "duration")]
        public string XmlLapTime
        {
            get { return LapTime.ToString(); }
            set
            {
                TimeSpan lapTime;
                if (TimeSpan.TryParse(value, out lapTime))
                    LapTime = lapTime;
                else
                    LapTime = null;
            }
        }

        public DateTime TimeStamp { get; set; }
    }
}
