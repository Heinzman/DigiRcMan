using System;
using Elreg.BusinessObjects.Interfaces;

namespace Elreg.UnitTests.MockObjects
{
    public class MockLapTimeAvgCalculator : ILapTimeAvgCalculator
    {
        public void Reset()
        {
        }

        public void AddLapTime(TimeSpan? lapTime)
        {
        }

        public TimeSpan LapTimesAvg
        {
            get { return new TimeSpan(); }
        }
    }
}
