namespace Elreg.BusinessObjects.Interfaces
{
    public interface ILaneBaseObserver
    {
        void LaneChanged(LaneId laneId);
        void RaceStatusChanged(object sender, System.EventArgs e);
    }
}
