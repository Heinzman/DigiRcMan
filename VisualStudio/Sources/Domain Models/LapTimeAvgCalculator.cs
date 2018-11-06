using System;
using System.Collections.Generic;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Options;

namespace Elreg.DomainModels
{
    public class LapTimeAvgCalculator : ILapTimeAvgCalculator
    {
        private readonly RaceSettings _raceSettings;
        private readonly List<TimeSpan> _lapTimes = new List<TimeSpan>();
        private List<TimeSpan> _tempLapTimes;
        private TimeSpan? _lapTimesAvg;
        private int _edgeItemsCount;

        private const int MinValuesCount = 4;

        public LapTimeAvgCalculator(RaceSettings raceSettings)
        {            
            _raceSettings = raceSettings;
            Reset();
        }

        public void Reset()
        {
            _lapTimesAvg = null;
            _lapTimes.Clear();
        }

        public void AddLapTime(TimeSpan? lapTime)
        {
            if (lapTime.HasValue && lapTime > new TimeSpan(0, 0, _raceSettings.SecondsForValidLap))
            {
                _lapTimes.Add(lapTime.Value);
                CalcLapTimeAvg();
            }
        }

        public TimeSpan LapTimesAvg
        {
            get
            {
                if (_lapTimesAvg == null)
                    _lapTimesAvg = new TimeSpan(0, 0, _raceSettings.SecondsForValidLap);
                return (TimeSpan)_lapTimesAvg;
            }
            private set { _lapTimesAvg = value; }
        }

        private void CalcLapTimeAvg()
        {
            if (_lapTimes != null && _lapTimes.Count >= MinValuesCount)
            {
                SortLapTimes();
                RemoveEdges();
                CalcAverage();
            }
        }

        private void SortLapTimes()
        {
            SortLapTimes(_lapTimes, out _tempLapTimes);
        }

        private void SortLapTimes(List<TimeSpan> lapTimes, out List<TimeSpan> tempLapTimes)
        {
            tempLapTimes = new List<TimeSpan>(lapTimes);
            tempLapTimes.Sort();
        }

        private void RemoveEdges()
        {
            if (_tempLapTimes.Count >= MinValuesCount)
            {
                CalcEdgeItemsCount();
                _tempLapTimes.RemoveRange(0, _edgeItemsCount);
                _tempLapTimes.RemoveRange(_tempLapTimes.Count - _edgeItemsCount, _edgeItemsCount);
            }
        }

        private void CalcEdgeItemsCount()
        {
            decimal tenthOfTempLapTimes = (decimal)_tempLapTimes.Count / 10;
            _edgeItemsCount = (int)Math.Ceiling(tenthOfTempLapTimes);
        }

        private void CalcAverage()
        {
            LapTimesAvg = CalcAverage(_tempLapTimes);
        }

        private TimeSpan CalcAverage(ICollection<TimeSpan> tempLapTimes)
        {
            TimeSpan sumOfLapTimes = new TimeSpan();
            foreach (TimeSpan lapTime in tempLapTimes)
                sumOfLapTimes += lapTime;
            return TimeSpan.FromTicks(sumOfLapTimes.Ticks / tempLapTimes.Count);
        }


    }
}
