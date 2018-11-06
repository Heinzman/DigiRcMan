using System;
using System.Collections.Generic;
using Heinzman.BusinessObjects.Interfaces;

namespace Heinzman.DomainModels
{
    public class SpeedSumAvgCalculator : ISpeedSumAvgCalculator
    {
        private readonly List<uint> _speedSums = new List<uint>();
        private readonly List<uint> _speedSumsOfZerothLap = new List<uint>();
        private List<uint> _tempSpeedSums;
        private List<uint> _tempSpeedSumsOfZerothLap;
        private int _edgeItemsCount;
        private int? _speedSumAvg;

        public SpeedSumAvgCalculator()
        {
            Reset();
        }

        public void Reset()
        {
            SpeedSumAvg = null;
            _speedSums.Clear();
            SpeedSumAvgOfZerothLap = null;
            _speedSumsOfZerothLap.Clear();
        }

        public void AddSpeedSum(uint speedSum)
        {
            _speedSums.Add(speedSum);
            CalcSpeedSumAvg();
        }

        public void AddSpeedSumOfZerothLap(uint speedSum)
        {
            _speedSumsOfZerothLap.Add(speedSum);
            CalcSpeedSumAvgOfZerothLap();
        }

        public int? SpeedSumAvg
        {
            get { return _speedSumAvg; }
            set
            {
                if (value <= 0)
                    _speedSumAvg = null;
                else
                    _speedSumAvg = value;
            }
        }

        public int? SpeedSumAvgOfZerothLap { get; private set; }

        private void CalcSpeedSumAvg()
        {
            if (_speedSums != null && _speedSums.Count >= 4)
            {
                SortSpeedSums();
                RemoveEdges();
                CalcAverage();
            }
        }

        private void CalcSpeedSumAvgOfZerothLap()
        {
            if (_speedSumsOfZerothLap != null && _speedSumsOfZerothLap.Count >= 2)
            {
                SortSpeedSumsOfZerothLap();
                CalcAverageOfZerothLap();
            }
        }

        private void SortSpeedSums()
        {
            SortSpeedSums(_speedSums, out _tempSpeedSums);
        }

        private void SortSpeedSumsOfZerothLap()
        {
            SortSpeedSums(_speedSumsOfZerothLap, out _tempSpeedSumsOfZerothLap);
        }

        private void SortSpeedSums(IEnumerable<uint> speedSums, out List<uint> tempSpeedSums)
        {
            tempSpeedSums = new List<uint>(speedSums);
            tempSpeedSums.Sort();
        }

        private void RemoveEdges()
        {
            if (_tempSpeedSums.Count >= 4)
            {
                CalcEdgeItemsCount();
                _tempSpeedSums.RemoveRange(0, _edgeItemsCount);
                _tempSpeedSums.RemoveRange(_tempSpeedSums.Count - _edgeItemsCount, _edgeItemsCount);
            }
        }

        private void CalcEdgeItemsCount()
        {
            decimal tenthOfTempSpeedSums = (decimal)_tempSpeedSums.Count/10;
            _edgeItemsCount = (int)Math.Ceiling(tenthOfTempSpeedSums);
        }

        private void CalcAverage()
        {
            SpeedSumAvg = CalcAverage(_tempSpeedSums);
        }

        private void CalcAverageOfZerothLap()
        {
            SpeedSumAvgOfZerothLap = CalcAverage(_tempSpeedSumsOfZerothLap);
        }

        private int CalcAverage(ICollection<uint> tempSpeedSums)
        {
            int sumOfSpeedSums = 0;
            foreach (int speedSum in tempSpeedSums)
                sumOfSpeedSums += speedSum;
            return sumOfSpeedSums / tempSpeedSums.Count;
        }


    }
}
