using System.Collections.Generic;

namespace Elreg.BusinessObjects.DerivedEventArgs
{
    public class CarSoundEventArgs : System.EventArgs
    {
        public CarSoundEventArgs(LaneId laneId, uint speedOfCar, uint averageSpeedOfCar, uint calculatedSpeedOfCar,
                                 double currentFrequencyFactor, double destinatedFrequencyFactor,
                                 double lastFrequencyFactor, bool isEngineIdle, Queue<uint> speedOfCarQueue,
                                 uint deltaCurrentToLastCalcedSpeed, uint deltaAverageToLastCalcedSpeed,
                                 double deltaAverageToCurrentSpeed)
        {
            LaneId = laneId;
            SpeedOfCar = speedOfCar;
            AverageSpeedOfCar = averageSpeedOfCar;
            CalculatedSpeedOfCar = calculatedSpeedOfCar;
            CurrentFrequencyFactor = currentFrequencyFactor;
            DestinatedFrequencyFactor = destinatedFrequencyFactor;
            LastFrequencyFactor = lastFrequencyFactor;
            IsEngineIdle = isEngineIdle;
            SpeedOfCarQueue = speedOfCarQueue;
            DeltaCurrentToLastCalcedSpeed = deltaCurrentToLastCalcedSpeed;
            DeltaAverageToLastCalcedSpeed = deltaAverageToLastCalcedSpeed;
            DeltaAverageToCurrentSpeed = deltaAverageToCurrentSpeed;
        }

        public Queue<uint> SpeedOfCarQueue { get; set; }

        public uint DeltaCurrentToLastCalcedSpeed { get; set; }

        public uint SpeedOfCar { get; set; }

        public uint AverageSpeedOfCar { get; set; }

        public uint CalculatedSpeedOfCar { get; set; }

        public LaneId LaneId { get; set; }

        public double CurrentFrequencyFactor { get; set; }

        public double DestinatedFrequencyFactor { get; set; }

        public double LastFrequencyFactor { get; set; }

        public bool IsEngineIdle { get; set; }

        public uint DeltaAverageToLastCalcedSpeed { get; set; }

        public double DeltaAverageToCurrentSpeed { get; set; }
    }
}