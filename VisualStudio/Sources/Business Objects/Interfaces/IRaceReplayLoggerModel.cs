namespace Elreg.BusinessObjects.Interfaces
{
    public interface IRaceReplayLoggerModel
    {
        string CreateTextToLogOf(LaneId? laneId, RaceEvent raceEvent);
        string CreateTextToLog(RaceEvent raceEvent);
    }
}