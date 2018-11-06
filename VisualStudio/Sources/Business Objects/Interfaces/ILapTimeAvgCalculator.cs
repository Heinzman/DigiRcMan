using System;

namespace Elreg.BusinessObjects.Interfaces
{
    public interface ILapTimeAvgCalculator
    {
        void Reset();
        void AddLapTime(TimeSpan? lapTime);
        TimeSpan LapTimesAvg { get; }
    }
}