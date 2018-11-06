namespace Elreg.BusinessObjects.Interfaces
{
    public interface IRaceDataProvider
    {
        event Delegates.LaneAdditionHandler AddLapForLane;
        event Delegates.LaneHandler PenaltyAdditionForLane;
        event Delegates.GetLaneByIdHandler GetLaneById;
    }
}