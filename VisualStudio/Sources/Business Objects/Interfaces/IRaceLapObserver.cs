namespace Elreg.BusinessObjects.Interfaces
{
    public interface IRaceLapObserver
    {
        void LapAdded(LaneId laneId);
        void LapNotAddedDueMinSeconds(LaneId laneId);
        void Finished(LaneId laneId);
    }
}
