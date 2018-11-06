using System;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.Log;
using Elreg.MouseKeyboardLibrary;

namespace Elreg.VirtualControllerService
{
    public class KeyboardVirtualController : IVirtualController
    {
        private readonly Keys _keyAccelerate;
        private readonly Keys _keyLaneChange;
        private readonly KeyboardHook _keyboardHook = new KeyboardHook();
        private int _steps;
        private bool _isAccelerating;
        private System.Timers.Timer _timer;
        private readonly int _maxSteps;
        private const int StepsForNextLevel = 7;

        public ControllerLevel CurrentLevel { get; set; }
        public bool IsButtonPressed { get; set; }

        public KeyboardVirtualController(Keys keyAccelerate, Keys keyLaneChange)
        {
            _maxSteps = ((int)ControllerLevel.L15)*StepsForNextLevel;
            _keyAccelerate = keyAccelerate;
            _keyLaneChange = keyLaneChange;
            _keyboardHook.KeyDown += KeyboardHookKeyDown;
            _keyboardHook.KeyUp += KeyboardHookKeyUp;
            _keyboardHook.Start();
            InitTimer();
        }

        private void InitTimer()
        {
            _timer = new System.Timers.Timer { Interval = 10 };
            _timer.Elapsed += TimerElapsed;
            _timer.Start();
        }

        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                CalcCurrentLevel();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CalcCurrentLevel()
        {
            if (_isAccelerating && _steps < _maxSteps)
                _steps += 2;
            else if (!_isAccelerating && _steps > 0)
                _steps -= 3;

            decimal level = _steps / StepsForNextLevel;
            int currentLevel = (int)Math.Floor(level);
            CurrentLevel = (ControllerLevel)currentLevel;
        }

        private void KeyboardHookKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == _keyLaneChange)
                    IsButtonPressed = false;
                if (e.KeyData == _keyAccelerate)
                    _isAccelerating = false;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void KeyboardHookKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == _keyLaneChange)
                    IsButtonPressed = true;
                if (e.KeyData == _keyAccelerate)
                    _isAccelerating = true;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

    }
}
