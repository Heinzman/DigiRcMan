namespace Elreg.WinFormsPresentationFramework.DataTransferObjects
{
    public class StatisticsFilterDto
    {
        public string EventNameKey { get; set; }
        public string TrackNameKey { get; set; }
        public string RaceTypeKey { get; set; }
        public StatisticsGroupByEnum GroupBy { get; set; }
        public StatisticsSortByEnum SortBy { get; set; }
    }
}
