using System;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.Log;
using Elreg.MouseKeyboardLibrary;

namespace Elreg.VirtualControllerService
{
    public class MouseVirtualController : IVirtualController
    {
        private readonly MouseHook _mouseHook = new MouseHook();
        private int _yOfpreviousLevel;

        private const int PointsforNextLevel = 20;

        public ControllerLevel CurrentLevel { get; set; }
        public bool IsButtonPressed { get; set; }

        public MouseVirtualController()
        {
            _mouseHook.MouseDown += MouseHookMouseDown;
            _mouseHook.MouseUp += MouseHookMouseUp;
            _mouseHook.MouseMove += MouseHookMouseMove;
            _mouseHook.Start();
        }

        private void MouseHookMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                int deltaY = _yOfpreviousLevel - e.Y;
                decimal deltaLevel = deltaY / PointsforNextLevel;

                if (Math.Abs(deltaLevel) >= 1)
                {
                    int level = (int)CurrentLevel + (int)deltaLevel;
                    if (level <= (int)ControllerLevel.L0)
                        CurrentLevel = ControllerLevel.L0;
                    else if (level >= (int)ControllerLevel.L15)
                        CurrentLevel = ControllerLevel.L15;
                    else
                        CurrentLevel = (ControllerLevel)level;
                    _yOfpreviousLevel = e.Y;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void MouseHookMouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                    IsButtonPressed = false;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void MouseHookMouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                    IsButtonPressed = true;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

    }
}
