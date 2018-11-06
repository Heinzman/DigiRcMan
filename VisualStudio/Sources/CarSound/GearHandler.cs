using System;
using Elreg.CarSound.Interfaces;

namespace Elreg.CarSound
{
    public class GearHandler
    {
        private readonly IFrequencyProvider _frequencyProvider;
        private double _currentGearFrequencyFactor;
        private bool _isFirstGear;
        private int _freqFactorPercent;
        private int _currentFrequency;

        private const int ShiftTo2FreqPercent = 55;
        private const int ShiftTo1FreqPercent = 45;
        private const float Gear1FreqFactor = 1.9f;

        public GearHandler(IFrequencyProvider frequencyProvider)
        {
            _frequencyProvider = frequencyProvider;
        }

        private double CurrentFrequencyFactor
        {
            get { return _frequencyProvider.CurrentFrequencyFactor; }
        }

        private double FreqFactorInitial
        {
            get { return _frequencyProvider.FreqFactorInitial; }
        }

        private double FrequencyFactorOfMaxSpeed
        {
            get { return _frequencyProvider.FrequencyFactorOfMaxSpeed; }
        }

        private double OriginalEngineFrequency
        {
            get { return _frequencyProvider.OriginalEngineFrequency; }
        }

        public int Calc()
        {
            CalcFreqFactorPercent();
            CalcCurrentGear();
            CalcCurrentGearFrequencyFactor();
            CalcCurrentFrequency();
            return _currentFrequency;
        }

        private void CalcCurrentGearFrequencyFactor()
        {
            if (_isFirstGear)
                CalcCurrentGearFrequencyFactorforFirstGear();
            else
                CalcCurrentGearFrequencyFactorforSecondGear();
        }

        private void CalcCurrentGearFrequencyFactorforSecondGear()
        {
            _currentGearFrequencyFactor = (CurrentFrequencyFactor - FrequencyFactorOfMaxSpeed) * Gear1FreqFactor + FrequencyFactorOfMaxSpeed;
        }

        private void CalcCurrentGearFrequencyFactorforFirstGear()
        {
            _currentGearFrequencyFactor = (CurrentFrequencyFactor - FreqFactorInitial) * Gear1FreqFactor + FreqFactorInitial;
        }

        private void CalcFreqFactorPercent()
        {
            _freqFactorPercent = (int)((CurrentFrequencyFactor - FreqFactorInitial) / (FrequencyFactorOfMaxSpeed - FreqFactorInitial) * 100);
        }

        private void CalcCurrentGear()
        {
            if (_isFirstGear && _freqFactorPercent >= ShiftTo2FreqPercent)
                _isFirstGear = false;
            else if (!_isFirstGear && _freqFactorPercent <= ShiftTo1FreqPercent)
                _isFirstGear = true;
        }

        private void CalcCurrentFrequency()
        {
            _currentFrequency = (int)Math.Ceiling(OriginalEngineFrequency * _currentGearFrequencyFactor); 
        }

    }
}
