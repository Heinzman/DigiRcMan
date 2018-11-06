using System;
using System.Collections.Generic;
using System.Drawing;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Races;
using Elreg.RaceOptionsService;
using Elreg.RaceStatisticsService;
using Elreg.WinFormsPresentationFramework;
using Elreg.WinFormsPresentationFramework.DataTransferObjects;

namespace Elreg.DomainModels
{
    public class StatisticsModel
    {
        private Statistics _statistics;
        private readonly StatisticLogger _statisticLogger;
        private readonly Dictionary<string, List<StatisticRecord>> _statisticRecordsGroups = new Dictionary<string, List<StatisticRecord>>();
        private readonly CarsService _carsService;
        private readonly DriversService _driversService;
        private List<string> _eventNames;
        private List<string> _trackNames;
        private StatisticsFilterDto _statisticsFilterDto;
        private List<StatisticRecord> _filteredStatisticRecords;

        public StatisticsModel(StatisticLogger statisticLogger)
        {
            _statisticLogger = statisticLogger;
            _carsService = new CarsService();
            _driversService = new DriversService();
            ParseStatisticLog();
        }

        private void ParseStatisticLog()
        {
            StatisticParser statisticParser = new StatisticParser(_statisticLogger.FileName);
            _statistics = statisticParser.DoWork();
        }

        public List<string> EventNames
        {
            get
            {
                if (_eventNames == null)
                {
                    _eventNames = new List<string>();
                    foreach (StatisticRecord statisticRecord in _statistics.StatisticRecords)
                    {
                        if (!_eventNames.Exists(s => s == statisticRecord.EventName))
                            _eventNames.Add(statisticRecord.EventName);
                    }
                }
                return _eventNames;
            }
        }

        public List<string> TrackNames
        {
            get
            {
                if (_trackNames == null)
                {
                    _trackNames = new List<string>();
                    foreach (StatisticRecord statisticRecord in _statistics.StatisticRecords)
                    {
                        if (!_trackNames.Exists(s => s == statisticRecord.TrackName))
                            _trackNames.Add(statisticRecord.TrackName);
                    }
                }
                return _trackNames;
            }
        }

        public List<string> RaceTypes
        {
            get
            {
                List<string> raceTypes = new List<string>(Enum.GetNames(typeof(Race.TypeEnum)));
                return raceTypes;
            }
        }

        public IEnumerable<KeyValuePair<StatisticsGroupByEnum, string>> GroupBys
        {
            get
            {
                List<KeyValuePair<StatisticsGroupByEnum, string>> groupBys =
                    new List<KeyValuePair<StatisticsGroupByEnum, string>>
                        {
                            new KeyValuePair<StatisticsGroupByEnum, string>(StatisticsGroupByEnum.Driver, "Driver"),
                            new KeyValuePair<StatisticsGroupByEnum, string>(StatisticsGroupByEnum.Car, "Car")
                        };
                return groupBys;
            }
        }

        public IEnumerable<KeyValuePair<StatisticsSortByEnum, string>> SortBys
        {
            get
            {
                List<KeyValuePair<StatisticsSortByEnum, string>> sortBys = 
                    new List<KeyValuePair<StatisticsSortByEnum, string>>
                        {
                            new KeyValuePair<StatisticsSortByEnum, string>(StatisticsSortByEnum.BestLapTime, "Best Lap Time"),
                            new KeyValuePair<StatisticsSortByEnum, string>(StatisticsSortByEnum.AvgLapTime, "Avg Lap Time")
                        };
                return sortBys;
            }
        }

        public void CalcStatisticRecords(StatisticsFilterDto statisticsFilterDto)
        {
            _statisticsFilterDto = statisticsFilterDto;
            _statisticLogger.Activated = false;
            StatisticRecordDtos = new List<StatisticRecordDto>();
            ConvertStatisticRecordsToDtos();
            _statisticLogger.Activated = true;
        }

        private void ConvertStatisticRecordsToDtos()
        {
            FilterStatisticRecords();
            if (_statisticsFilterDto.GroupBy == StatisticsGroupByEnum.Car)
                GroupByCar();
            else
                GroupByDriver();
            SortGroups();
            FillStatisticRecordDtos();
            SortStatisticRecordDtos();
        }

        private void FilterStatisticRecords()
        {
            _filteredStatisticRecords = new List<StatisticRecord>();
            foreach (StatisticRecord statisticRecord in _statistics.StatisticRecords)
            {
                if ((_statisticsFilterDto.EventNameKey == null || _statisticsFilterDto.EventNameKey == statisticRecord.EventName) &&
                    (_statisticsFilterDto.TrackNameKey == null || _statisticsFilterDto.TrackNameKey == statisticRecord.TrackName) &&
                    (_statisticsFilterDto.RaceTypeKey == null || _statisticsFilterDto.RaceTypeKey == statisticRecord.RaceType.ToString()))
                {
                    _filteredStatisticRecords.Add(statisticRecord);
                }
            }
        }

        private void GroupByCar()
        {
            _statisticRecordsGroups.Clear();
            foreach (StatisticRecord statisticRecord in _filteredStatisticRecords)
            {
                List<StatisticRecord> statisticRecords;
                if (!_statisticRecordsGroups.TryGetValue(statisticRecord.CarName, out statisticRecords))
                {
                    statisticRecords = new List<StatisticRecord>();
                    _statisticRecordsGroups.Add(statisticRecord.CarName, statisticRecords);
                }
                statisticRecords.Add(statisticRecord);
            }
        }

        private void SortStatisticRecordDtos()
        {
            if (_statisticsFilterDto.SortBy == StatisticsSortByEnum.AvgLapTime)
                StatisticRecordDtos.Sort(SortByAvgLapTimes);
            else
                StatisticRecordDtos.Sort(SortByBestLapTimes);
        }

        private void FillStatisticRecordDtos()
        {
            StatisticRecordDtos.Clear();
            foreach (var driverName in _statisticRecordsGroups.Keys)
            {
                List<StatisticRecord> statisticRecords = _statisticRecordsGroups[driverName];
                StatisticRecord bestStatisticRecord = statisticRecords[0];
                TimeSpan? avgLapTime = CalcAvgLapTimeOf(statisticRecords);
                StatisticRecordDto statisticRecordDto = new StatisticRecordDto
                                                            {
                                                                DriverName = GetDriverName(bestStatisticRecord),
                                                                CarImage = GetImage(bestStatisticRecord),
                                                                CarName = bestStatisticRecord.CarName,
                                                                BestLapTime = bestStatisticRecord.LapTime,
                                                                BestLapTimeString = Format(bestStatisticRecord.LapTime),
                                                                TrackName = bestStatisticRecord.TrackName,
                                                                EventName = bestStatisticRecord.EventName,
                                                                RaceType = bestStatisticRecord.RaceType.ToString(),
                                                                AvgLapTime = avgLapTime,
                                                                AvgLapTimeString = Format(avgLapTime)
                                                            };
                StatisticRecordDtos.Add(statisticRecordDto);
            }
        }

        private string GetDriverName(StatisticRecord statisticRecord)
        {
            string driverName = null;
            if (statisticRecord.DriverId.HasValue)
            {
                Driver driver = _driversService.Drivers.Find(d => d.Id == statisticRecord.DriverId.Value);
                if (driver != null)
                    driverName = driver.Name;
            }
            if (string.IsNullOrEmpty(driverName))
                driverName = statisticRecord.DriverName;
            return driverName;
        }

        private Image GetImage(StatisticRecord statisticRecord)
        {
            Image image = null;
            if (statisticRecord.CarId.HasValue)
                image = GetImageById(statisticRecord.CarId.Value);
            if (image == null)
                image = GetImageByName(statisticRecord.CarName);
            return image;
        }

        private Image GetImageById(int carId)
        {
            Image image = null;
            Car car = _carsService.Cars.Find(c => c.Id == carId);
            if (car != null)
                image = car.Image;
            return image;
        }

        private Image GetImageByName(string carName)
        {
            Image image = null;
            Car car = _carsService.Cars.Find(c => c.Name == carName);
            if (car != null)
                image = car.Image;
            return image;
        }

        private string Format(TimeSpan? timeSpan)
        {
            string value = "--.---";
            string format = "ss.fff";
            if (timeSpan != null && timeSpan.Value != new TimeSpan())
            {
                if (timeSpan >= new TimeSpan(1, 0, 0))
                    format = "hh:mm:ss.fff";
                else if (timeSpan >= new TimeSpan(0, 1, 0))
                    format = "mm:ss.fff";
                value = (DateTime.Today + (TimeSpan)timeSpan).ToString(format);
            }
            else
                value = value + " ";
            return value;
        }

        private TimeSpan? CalcAvgLapTimeOf(List<StatisticRecord> statisticRecords)
        {
            TimeSpan? avgLapTime = new TimeSpan();
            int count = statisticRecords.Count / 3;
            if (count < 1)
                count = 1;

            int i = 0;
            foreach (StatisticRecord statisticRecord in statisticRecords)
            {
                avgLapTime += statisticRecord.LapTime ?? new TimeSpan();
                if (++i >= count)
                    break;
            }
            long ticks = avgLapTime.Value.Ticks / count;
            TimeSpan timespan = new TimeSpan(ticks);    
            return timespan;
        }

        private void SortGroups()
        {
            foreach (var group in _statisticRecordsGroups.Values)
                group.Sort(SortByLapTimes);
        }

        private void GroupByDriver()
        {
            _statisticRecordsGroups.Clear();
            foreach (StatisticRecord statisticRecord in _filteredStatisticRecords)
            {
                List<StatisticRecord> statisticRecords;
                if (!_statisticRecordsGroups.TryGetValue(statisticRecord.DriverName, out statisticRecords))
                {
                    statisticRecords = new List<StatisticRecord>();
                    _statisticRecordsGroups.Add(statisticRecord.DriverName, statisticRecords);
                }
                statisticRecords.Add(statisticRecord);
            }
        }

        private int SortByBestLapTimes(StatisticRecordDto record1, StatisticRecordDto record2)
        {
            int returnValue = -1;
            if (record2.BestLapTime < record1.BestLapTime)
                returnValue = 1;
            else if (record2.BestLapTime == record1.BestLapTime)
                returnValue = 0;
            return returnValue;
        }

        private int SortByAvgLapTimes(StatisticRecordDto record1, StatisticRecordDto record2)
        {
            int returnValue = -1;
            if (record2.AvgLapTime < record1.AvgLapTime)
                returnValue = 1;
            else if (record2.AvgLapTime == record1.AvgLapTime)
                returnValue = 0;
            return returnValue;
        }

        private int SortByLapTimes(StatisticRecord record1, StatisticRecord record2)
        {
            int returnValue = -1;
            if (record2.LapTime < record1.LapTime)
                returnValue = 1;
            else if (record2.LapTime == record1.LapTime)
                returnValue = 0;
            return returnValue;
        }

        public List<StatisticRecordDto> StatisticRecordDtos { get; private set; }

    }
}
