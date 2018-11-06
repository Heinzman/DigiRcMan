using System;
using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.PortActions;
using Elreg.Log;
using Elreg.RaceOptionsService;

namespace Elreg.RaceDataService.RaceData
{
    public class ActionsCalculator
    {
        private CarController _carController;
        private LapDetectionSingleAction _lapDetectionSingleAction;
        private readonly PenaltyController _penaltyController;
        public LaneId LaneId { get; private set; }

        public static event Delegates.LaneAdditionHandler AddLapForLane;
        public static event Delegates.LaneHandler PenaltyAdditionForLane;
        public static event Delegates.GetLaneByIdHandler GetLaneById;

        public ActionsCalculator(RaceProviderService raceProviderService, LaneId laneId)
        {
            LaneId = laneId;
            _penaltyController = new PenaltyController(raceProviderService.RaceProviderOptions, laneId);
            _penaltyController.PenaltyAdditionForLane += PenaltyControllerPenaltyAdditionForLane;
        }

        public void DoWork(CarController carController, LapDetectionSingleAction lapDetectionSingleAction, List<uint> speedList)
        {
            _carController = carController;
            _lapDetectionSingleAction = lapDetectionSingleAction;

            CalcLapAddition();
            if (_carController != null)
            {
                CalcPenaltyAdditions();
            }
        }

        private void PenaltyControllerPenaltyAdditionForLane(LaneId laneId)
        {
            try
            {
                if (laneId == LaneId)
                    RaiseEventPenaltyAdditionForLane();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CalcLapAddition()
        {
            if (_lapDetectionSingleAction.Detected)
                RaiseEventAddLapForLane();
        }

        private void CalcPenaltyAdditions()
        {
            _penaltyController.CalcPenaltyAddition(_carController);
        }

        private void RaiseEventAddLapForLane()
        {
            if (AddLapForLane != null)
                AddLapForLane(LaneId, _lapDetectionSingleAction.TimeStamp);
        }

        private void RaiseEventPenaltyAdditionForLane()
        {
            if (PenaltyAdditionForLane != null)
                PenaltyAdditionForLane(LaneId);
        }

    }
}
