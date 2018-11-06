using System;
using Heinzman.BusinessObjects;
using Heinzman.CentralUnitService.Settings;

namespace Heinzman.CentralUnitService.LevelModifier.Delayer
{
    public class SimpleDelayHandler : IDelayHandler
    {
        private readonly DelaySettings _delaySettings;
        protected ControllerLevel ExpectedLevel;
        private ControllerLevel _calculatedLevel;
        protected ControllerLevel PreviousCalculatedLevel = ControllerLevel.L0;
        private bool _timerStarted;
        private float _currentFuelPercent;
        private int _previousSignDeltaExpPrev;
        private DateTime _timerExpirationTime;
        private bool _isTurboActivated;
        private int _signDeltaExpPrev;

        protected SimpleDelayHandler(DelaySettings delaySettings)
        {
            _delaySettings = delaySettings;
        }

        public ControllerLevel DoWork(ControllerLevel expectedLevel, float currentFuelPercent, bool isTurboActivated)
        {
            ExpectedLevel = expectedLevel;
            _currentFuelPercent = currentFuelPercent;
            _isTurboActivated = isTurboActivated;
            CalcControllerLevel();
            return _calculatedLevel;
        }

        private void CalcControllerLevel()
        {
            int deltaExpPrev = CalcDeltaExpPrev();
            _signDeltaExpPrev = Math.Sign(deltaExpPrev);

            if (_isTurboActivated || ShouldNotBeDelayed)
                _calculatedLevel = ExpectedLevel;
            else
                CalcLevel(deltaExpPrev);

            PreviousCalculatedLevel = _calculatedLevel;
            _previousSignDeltaExpPrev = _signDeltaExpPrev;
        }

        protected virtual int CalcDeltaExpPrev()
        {
            return ExpectedLevel - PreviousCalculatedLevel;
        }

        private void CalcLevel(int deltaExpPrev)
        {
            if (!_timerStarted && deltaExpPrev != 0 ||
                _timerStarted && _signDeltaExpPrev != _previousSignDeltaExpPrev)
            {
                RestartTimer();
            }

            if (_timerStarted && IsTimerElapsed)
            {
                if (_signDeltaExpPrev > 0)
                    _calculatedLevel++;
                else if (_signDeltaExpPrev < 0)
                    _calculatedLevel--;
                else
                    _calculatedLevel = PreviousCalculatedLevel;
                _timerStarted = false;
            }
            else
                _calculatedLevel = PreviousCalculatedLevel;
        }

        private bool IsTimerElapsed
        {
            get { return DateTime.Now > _timerExpirationTime; }
        }

        private void RestartTimer()
        {
            _timerExpirationTime = DateTime.Now.AddMilliseconds(DelayMilliSecs);
            _timerStarted = true;
        }

        private float DelayMilliSecs
        {
            get
            {
                float delayMilliSecs;
                if (_signDeltaExpPrev > 0)
                {
                    delayMilliSecs = _delaySettings.MilliSecsAccelerationDelayAtFullTank *
                                     (_currentFuelPercent - _delaySettings.PercentFuelForZeroDelay) /
                                     (100 - _delaySettings.PercentFuelForZeroDelay);
                }
                else
                {
                    delayMilliSecs = _delaySettings.MilliSecsBrakeDelayAtFullTank *
                                     (_currentFuelPercent - _delaySettings.PercentFuelForZeroDelay) /
                                     (100 - _delaySettings.PercentFuelForZeroDelay);
                }
                //Debug.WriteLine("delayMilliSecs: " + delayMilliSecs);
                return delayMilliSecs;
            }
        }

        private bool ShouldNotBeDelayed
        {
            get { return !_delaySettings.IsActivated || _currentFuelPercent < _delaySettings.PercentFuelForZeroDelay; }
        }
    }
}
