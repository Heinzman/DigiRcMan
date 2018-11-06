using System;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.PortActions;

namespace Elreg.RaceDataService
{
    public class PenaltyController
    {
        private readonly RaceProviderOptions _options;
        private readonly LaneId _laneId;
        private readonly ButtonAction _buttonAction;
        private CarController _carController;

        public PenaltyController(RaceProviderOptions options, LaneId laneId)
        {
            _options = options;
            _laneId = laneId;
            _buttonAction = new ButtonAction(3);
        }

        public event Delegates.LaneHandler PenaltyAdditionForLane;

        public void CalcPenaltyAddition(CarController carController)
        {
            if (carController != null)
            {
                _carController = carController;
                CalcPenaltyAddition();
            }
        }

        private void CalcPenaltyAddition()
        {
            if (IsButtonPressedDownBegin())
                _buttonAction.HandleButtonPressedDown();
            else if (IsButtonPressedEnd())
            {
                _buttonAction.HandleButtonUp();
                CheckPenaltyAdditionByTimeSpan();
            }
        }

        private void CheckPenaltyAdditionByTimeSpan()
        {
            TimeSpan timeSpanSinceFirst = DateTime.Now - _buttonAction.TimeStampBtnPressedDownFirst;

            if (timeSpanSinceFirst.TotalMilliseconds <= _options.MillisecsPressedSinglePeriodForPenalty * 3)
            {
                _buttonAction.Clear();
                RaiseEventPenaltyAdditionForLane();
            }
        }

        private bool IsButtonPressedDownBegin()
        {
            return (!_buttonAction.IsBtnPressedDown && _carController.LaneChange && _carController.Speed == 0);
        }

        private bool IsButtonPressedEnd()
        {
            return (_buttonAction.IsBtnPressedDown && !_carController.LaneChange && _carController.Speed == 0);
        }

        private void RaiseEventPenaltyAdditionForLane()
        {
            if (PenaltyAdditionForLane != null)
                PenaltyAdditionForLane(_laneId);
        }
    }
}