using System;
using System.Drawing;

namespace Elreg.WinFormsPresentationFramework.DataTransferObjects
{
    public class StatisticRecordDto
    {
        public string TrackName { get; set; }
        public string EventName { get; set; }
        public Image CarImage { get; set; }
        public string CarName { get; set; }
        public string DriverName { get; set; }
        public string RaceType { get; set; }
        public TimeSpan? BestLapTime { get; set; }
        public TimeSpan? AvgLapTime { get; set; }
        public string AvgLapTimeString { get; set; }
        public string BestLapTimeString { get; set; }
        public string TimeStamp { get; set; }
    }
}
