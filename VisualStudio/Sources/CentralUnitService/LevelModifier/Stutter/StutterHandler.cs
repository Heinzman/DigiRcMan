using System;
using Heinzman.BusinessObjects;
using Heinzman.CentralUnitService.Settings;

namespace Heinzman.CentralUnitService.LevelModifier.Stutter
{
    public class StutterHandler : IStutterHandler
    {
        private readonly StutterSettings _stutterSettings;
        private bool _isTurboActivated;
        private float _currentFuelPercent;
        private ControllerLevel _expectedLevel;
        private ControllerLevel _calculatedLevel;
        private DateTime _timerExpirationTime;
        private bool _isStuttering;
        private bool _timerStarted;
        private readonly Random _random = new Random();

        public StutterHandler(StutterSettings stutterSettings)
        {
            _stutterSettings = stutterSettings;
        }

        public ControllerLevel DoWork(ControllerLevel expectedLevel, float currentFuelPercent, bool isTurboActivated)
        {
            _expectedLevel = expectedLevel;
            _currentFuelPercent = currentFuelPercent;
            _isTurboActivated = isTurboActivated;
            CalcControllerLevel();
            return _calculatedLevel;
        }

        private void CalcControllerLevel()
        {
            _calculatedLevel = _expectedLevel;

            if (_stutterSettings.IsActivated && !_isTurboActivated &&
                _currentFuelPercent <= _stutterSettings.PercentFuelForStuttering && _expectedLevel > ControllerLevel.L5)
            {
                CalcLevel();
            }
        }

        private void CalcLevel()
        {
            if (IsTimerElapsed)
                _timerStarted = false;

            if (_timerStarted)
            {
                if (_isStuttering)
                    CalcRandomLevel();
            }
            else
            {
                _isStuttering = !_isStuttering;
                RestartTimer();
            }
        }

        private void CalcRandomLevel()
        {
            int maxLevelsToReduce = 4;
            if (_expectedLevel > ControllerLevel.L9)
                maxLevelsToReduce = 6;
            int levelsToReduce = _random.Next(2, maxLevelsToReduce);
            ControllerLevel calculatedLevel = _expectedLevel - levelsToReduce;

            if (calculatedLevel < _stutterSettings.MinControllerLevel)
                _calculatedLevel = _stutterSettings.MinControllerLevel;
            else
                _calculatedLevel = calculatedLevel;
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

        private int DelayMilliSecs
        {
            get
            {
                int minMilliSecs = _stutterSettings.MilliSecsMinDurationNonStuttering;
                int maxMilliSecs = _stutterSettings.MilliSecsMaxDurationNonStuttering;

                if (_isStuttering)
                {
                    minMilliSecs = _stutterSettings.MilliSecsMinDurationStuttering;
                    maxMilliSecs = _stutterSettings.MilliSecsMaxDurationStuttering;
                }
                return _random.Next(minMilliSecs, maxMilliSecs); 
            }
        }
    }
}
