using System;
using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;

namespace Elreg.VirtualControllerService
{
    public class JoystickVirtualController : IVirtualController
    {
        private bool _isButtonPressed;
        private readonly Joystick _joystick;
        private ControllerLevel _currentLevel;

        public JoystickVirtualController(IntPtr hWnd, string deviceName)
        {
            _joystick = new Joystick(hWnd, deviceName);
        }

        public ControllerLevel CurrentLevel
        {
            get
            {
                CalcCurrentLevel();
                return _currentLevel;
            }
            set { _currentLevel = value; }
        }

        public bool IsButtonPressed
        {
            get
            {
                CalcButtonPressed();
                return _isButtonPressed;
            }
            set { _isButtonPressed = value; }
        }

        private void CalcButtonPressed()
        {
            _joystick.UpdateData();
            _isButtonPressed = false;
            if (_joystick.IsJoystickActiv)
            {
                foreach (KeyValuePair<int, bool> button in _joystick.ButtonList)
                {
                    if (button.Value)
                    {
                        _isButtonPressed = true;
                        break;
                    }
                }
            }
        }

        private void CalcCurrentLevel()
        {
            _joystick.UpdateData();
            _currentLevel = ControllerLevel.L0; 
            if (_joystick.IsJoystickActiv)
            {
                int value = _joystick.Rz;
                if (_joystick.Y < value)
                    value = _joystick.Y;

                if (value < 2048)
                    _currentLevel = ControllerLevel.L15;
                else if (value < 4096)
                    _currentLevel = ControllerLevel.L14;
                else if (value < 6144)
                    _currentLevel = ControllerLevel.L13;
                else if (value < 8.192)
                    _currentLevel = ControllerLevel.L12;
                else if (value < 10240)
                    _currentLevel = ControllerLevel.L11;
                else if (value < 12288)
                    _currentLevel = ControllerLevel.L10;
                else if (value < 14336)
                    _currentLevel = ControllerLevel.L9;
                else if (value < 16384)
                    _currentLevel = ControllerLevel.L8;
                else if (value < 18432)
                    _currentLevel = ControllerLevel.L7;
                else if (value < 20480)
                    _currentLevel = ControllerLevel.L6;
                else if (value < 22528)
                    _currentLevel = ControllerLevel.L5;
                else if (value < 24576)
                    _currentLevel = ControllerLevel.L4;
                else if (value < 26624)
                    _currentLevel = ControllerLevel.L3;
                else if (value < 28672)
                    _currentLevel = ControllerLevel.L2;
                else if (value < 30720)
                    _currentLevel = ControllerLevel.L1;
            }
        }
    }
}
