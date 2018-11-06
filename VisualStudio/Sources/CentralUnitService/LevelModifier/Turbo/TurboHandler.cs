using System;
using System.Diagnostics;
using Heinzman.BusinessObjects;
using Heinzman.CentralUnitService.Settings;

namespace Heinzman.CentralUnitService.LevelModifier.Turbo
{
    public class TurboHandler : ITurboHandler
    {
        private readonly TurboSettings _turboSettings;
        private LaneController _laneController;
        private readonly ButtonAction _buttonAction;

        public bool IsTurboActivated { get; private set; }

        public bool IsButtonSuppressed { get; private set; }

        public TurboHandler(TurboSettings turboSettings)
        {
            _turboSettings = turboSettings;
            _buttonAction = new ButtonAction(_turboSettings.NumberOfClicksForTurbo);
        }
        
        public void DoWork(LaneController laneController)
        {
            _laneController = laneController;
            CalcTurboActivation();
            CalcIsButtonSuppressed();
        }

        private void CalcTurboActivation()
        {
             CalcTurboStart();
             CalcTurboEnd();
        }

        private void CalcIsButtonSuppressed()
        {
            bool isButtonSuppressed = false;
            if (!IsTurboActivated)
            {
                TimeSpan timeSpanSinceLast = DateTime.Now - _buttonAction.TimeStampBtnPressedDownLast;
                //Debug.WriteLine("timeSpanSinceLast: " + timeSpanSinceLast + " " + DateTime.Now.Ticks);
                //Debug.WriteLine("_turboSettings.MillisecsPressedSinglePeriodForTurbo: " + _turboSettings.MillisecsPressedSinglePeriodForTurbo);
                //Debug.WriteLine("----");
                if (timeSpanSinceLast.TotalMilliseconds < _turboSettings.MillisecsPressedSinglePeriodForTurbo/2)
                    isButtonSuppressed = true;
            }
            IsButtonSuppressed = isButtonSuppressed;
        }

        private void CalcTurboStart()
        {
            if (IsButtonPressedDownBegin())
                _buttonAction.HandleButtonPressedDown();
            else if (IsButtonPressedEnd())
            {
                _buttonAction.HandleButtonUp();
                CheckTurboStartByTimeSpan();
            }
        }

        private void CalcTurboEnd()
        {
            if (_laneController.VirtualController.CurrentLevel != ControllerLevel.L15)
                IsTurboActivated = false;
        }

        //private void HandleButtonPressedEnd()
        //{
        //    _buttonAction.IsBtnPressedDown = false;

        //    TimeSpan secsSinceFirstPressedBegin = DateTime.Now - _buttonAction.TimeStampBtnPressedDownFirstTime;

        //    if (_buttonAction.BtnClickedCount >= _turboSettings.NumberOfClicksForTurbo)
        //        CheckTurboStartByTimeSpan();
        //}

        private void CheckTurboStartByTimeSpan()
        {
            TimeSpan timeSpanSinceFirst = DateTime.Now - _buttonAction.TimeStampBtnPressedDownFirst;
            //Debug.WriteLine("timeSpanSinceFirst: " + timeSpanSinceFirst.TotalMilliseconds + " " + DateTime.Now.Ticks);
            //Debug.WriteLine("_turboSettings.MillisecsPressedSinglePeriodForTurbo * _turboSettings.NumberOfClicksForTurbo: " + _turboSettings.MillisecsPressedSinglePeriodForTurbo * _turboSettings.NumberOfClicksForTurbo);
            //Debug.WriteLine("----");

            if (timeSpanSinceFirst.TotalMilliseconds <= _turboSettings.MillisecsPressedSinglePeriodForTurbo * _turboSettings.NumberOfClicksForTurbo)
                IsTurboActivated = true;
        }

        //private void HandleButtonPressedDownBegin()
        //{
        //    _buttonAction.SetTimeStampBtnPressedDown()
        //    //else 
        //    //    HandleSecondsBtnPressedBegin();

        //    _buttonAction.TimeStampBtnPressedDown = DateTime.Now;
        //    _buttonAction.IsBtnPressedDown = true;
        //}

        //private void HandleSecondsBtnPressedBegin()
        //{
        //    TimeSpan secsSincePreviousPressedBegin = DateTime.Now - _buttonAction.TimeStampBtnPressedDown;
        //    if (secsSincePreviousPressedBegin.TotalMilliseconds > _turboSettings.MillisecsPressedSinglePeriodForTurbo)
        //    {
        //        _buttonAction.BtnClickedCount = 0;
        //        _buttonAction.TimeStampBtnPressedDownFirstTime = DateTime.Now;
        //    }
        //}

        private bool IsButtonPressedDownBegin()
        {
            //Debug.WriteLine("_laneController.VirtualController.IsButtonPressed: " + _laneController.VirtualController.IsButtonPressed);
            //Debug.WriteLine("_laneController.VirtualController.CurrentLevel: " + _laneController.VirtualController.CurrentLevel);
            //Debug.WriteLine("----");
            return (!_buttonAction.IsBtnPressedDown && 
                     _laneController.VirtualController.IsButtonPressed && 
                     _laneController.VirtualController.CurrentLevel == ControllerLevel.L15);
        }

        private bool IsButtonPressedEnd()
        {
            return (_buttonAction.IsBtnPressedDown &&
                     !_laneController.VirtualController.IsButtonPressed);
        }

    }
}