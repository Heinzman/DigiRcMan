using System;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;

namespace Elreg.UnitTests.MockObjects
{
    public class MockRaceDataProvider : IRaceDataProvider
    {
        private const uint SpeedValueToDetectFalseStart = 3;

        public event Delegates.LaneAdditionHandler AddLapForLane;
        public event Delegates.LaneHandler PitstopInForLane;
        public event Delegates.LaneHandler PitstopOutForLane;
        public event Delegates.LaneHandler PenaltyAdditionForLane;
        public event Delegates.GetLaneByIdHandler GetLaneById;
        public event Delegates.LaneHandler RocketLaunchForLane;

        public uint SpeedToDetectFalseStart
        {
            get { return SpeedValueToDetectFalseStart; }
        }

        public void RaiseAddLapForLane(LaneId laneId)
        {
            if (AddLapForLane != null)
                AddLapForLane(laneId, DateTime.Now);
        }

        public void RaiseAddLapForLane(LaneId laneId, DateTime timeStamp)
        {
            if (AddLapForLane != null)
                AddLapForLane(laneId, timeStamp);
        }

        public void RaisePitstopInForLane(LaneId laneId)
        {
            if (PitstopInForLane != null)
                PitstopInForLane(laneId);
        }

        public void RaisePitstopOutForLane(LaneId laneId)
        {
            if (PitstopOutForLane != null)
                PitstopOutForLane(laneId);
        }

        public void RaisePenaltyAdditionForLane(LaneId laneId)
        {
            if (PenaltyAdditionForLane != null)
                PenaltyAdditionForLane(laneId);
        }

        public void RaiseGetLaneById(LaneId laneId)
        {
            Lane lane;
            if (GetLaneById != null)
                GetLaneById(laneId, out lane);
        }

        public void RaiseRocketLaunchForLane(LaneId laneId)
        {
            if (RocketLaunchForLane != null)
                RocketLaunchForLane(laneId);
        }

    }
}
