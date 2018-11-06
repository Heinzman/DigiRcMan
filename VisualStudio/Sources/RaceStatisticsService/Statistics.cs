using System.Collections.Generic;

namespace Elreg.RaceStatisticsService
{
    public class Statistics
    {
        public List<StatisticRecord> StatisticRecords { get; set; }

        public Statistics()
        {
            StatisticRecords = new List<StatisticRecord>();
        }
    }
}
