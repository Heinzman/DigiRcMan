using System;

namespace Elreg.BusinessObjects.Interfaces
{
    public interface IRaceObserver : IRaceLapObserver
    {
        void RaceChanged(object sender, EventArgs e);
        void PenaltyAdded(LaneId laneId);
        void Disqualified(LaneId laneId);
        void RaceStatusChanged(object sender, EventArgs e);
        void LaneChanged(LaneId laneid);
    }
}
