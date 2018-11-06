using System;
using System.Collections.Generic;

namespace Elreg.CarSound
{
    public class SpeedOfCarCalculator
    {
        private uint _currentSpeedOfCar;
        private uint _lastCalculatedSpeedOfCar;
        private static readonly object Locker = new object();

        private const int MaxQueueCount = 4;

        public SpeedOfCarCalculator()
        {
            SpeedOfCarQueue = new Queue<uint>();
        }

       public uint CurrentSpeedOfCar
        {
            get
            {
                uint currentSpeedOfCar;
                lock (Locker)
                    currentSpeedOfCar = _currentSpeedOfCar;
                return currentSpeedOfCar;
            }
            set 
            { 
                 lock (Locker)
                 {
                     _currentSpeedOfCar = value;
                     CalculateSpeedOfCar();
                 }
            }
        }

        public Queue<uint> SpeedOfCarQueue { get; private set; }

        public uint DeltaCurrentToLastCalcedSpeed { get; private set; }

        public uint AverageSpeedOfCarRounded { get; private set; }

        public uint CalculatedSpeedOfCar { get; private set; }

        public uint DeltaAverageToLastCalcedSpeed { get; private set; }

        public double DeltaAverageToCurrentSpeed { get; private set; }

        public double AverageSpeedOfCar { get; private set; }

        public double LastAverageSpeedOfCar { get; private set; }

        private void CalculateSpeedOfCar()
        {
            EnqueueSpeedOfCar();
            CalcAverageSpeedOfCar();
            CalcDeltaCurrentToLastCalcedSpeed();
            CalcDeltaAverageToLastCalcedSpeed();
            CalcDeltaAverageToCurrentSpeed();
            CalcCalculatedSpeedOfCar();
            _lastCalculatedSpeedOfCar = CalculatedSpeedOfCar;
        }

        private void CalcDeltaAverageToCurrentSpeed()
        {
            DeltaAverageToCurrentSpeed = Math.Abs(AverageSpeedOfCar - _currentSpeedOfCar);
        }

        private void CalcDeltaAverageToLastCalcedSpeed()
        {
            DeltaAverageToLastCalcedSpeed = (uint)Math.Abs((int)AverageSpeedOfCarRounded - (int)_lastCalculatedSpeedOfCar);
        }

        private void CalcDeltaCurrentToLastCalcedSpeed()
        {
            DeltaCurrentToLastCalcedSpeed = (uint)Math.Abs((int)_currentSpeedOfCar - (int)_lastCalculatedSpeedOfCar);
        }

        private void EnqueueSpeedOfCar()
        {
            lock (SpeedOfCarQueue)
            {
                SpeedOfCarQueue.Enqueue(_currentSpeedOfCar);
                if (SpeedOfCarQueue.Count > MaxQueueCount)
                    SpeedOfCarQueue.Dequeue();
            }
        }

        private void CalcCalculatedSpeedOfCar()
        {
            if (_lastCalculatedSpeedOfCar == 0 || DeltaAverageToCurrentSpeed > 0.7f)
                CalculatedSpeedOfCar = _currentSpeedOfCar;
            else
                CalculatedSpeedOfCar = AverageSpeedOfCarRounded;
    }

        private void CalcAverageSpeedOfCar()
        {
            uint sumOfSpeedOfCar = 0;
            Queue<uint> copyOfSpeedOfCarQueue;
            lock (SpeedOfCarQueue)
            {
                copyOfSpeedOfCarQueue = new Queue<uint>(SpeedOfCarQueue);
            }
            foreach (uint speedOfCar in copyOfSpeedOfCarQueue)
                sumOfSpeedOfCar += speedOfCar;

            LastAverageSpeedOfCar = AverageSpeedOfCar;
            AverageSpeedOfCar = sumOfSpeedOfCar / (double)copyOfSpeedOfCarQueue.Count;
            AverageSpeedOfCarRounded = (uint)Math.Round(AverageSpeedOfCar);
        }

    }
}
