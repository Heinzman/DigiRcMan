using System;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.LoggingData;
using Newtonsoft.Json;

namespace Elreg.DomainModels.Logs
{
    public class RaceReplayLoggerModel : IRaceReplayLoggerModel
    {
        private readonly IRaceModel _raceModel;

        public RaceReplayLoggerModel(IRaceModel raceModel)
        {
            _raceModel = raceModel;
        }

        public string CreateTextToLogOf(LaneId? laneId, RaceEvent raceEvent)
        {
            RaceReplayData raceReplayData = new RaceReplayData();

            raceReplayData.LaneIdOfEvent = laneId;
            raceReplayData.RaceEvent = raceEvent;
            raceReplayData.EventDescription = GetEventDescription(laneId, raceEvent);
            raceReplayData.Timestamp = DateTime.Now;
            raceReplayData.Race = _raceModel.Race;

            string text = JsonConvert.SerializeObject(raceReplayData);

            return text;
        }

        public string CreateTextToLog(RaceEvent raceEvent)
        {
            return CreateTextToLogOf(null, raceEvent);
        }

        //private Race Clone(Race race)
        //{
        //    Race clonedRace = race.Clone() as Race;
        //    if (clonedRace != null)
        //    {
        //        foreach (Lane lane in race.Lanes)
        //        {
        //            Lane clonedLane = lane.Clone() as Lane;
        //            if (clonedLane != null)
        //            {
        //                if (clonedLane.RocketLaneData != null)
        //                {
        //                    if (clonedLane.RocketLaneData.TargetLaneId != null)
        //                        clonedLane.RocketLaneData.TargetLaneId.RocketLaneData = null;
        //                    if (clonedLane.RocketLaneData.TargetLaneIdAtAttackingStart != null)
        //                        clonedLane.RocketLaneData.TargetLaneIdAtAttackingStart.RocketLaneData = null;
        //                }
        //                clonedRace.Lanes.Add(clonedLane);
        //            }
        //        }
        //    }
        //    return clonedRace;
        //}

        //private static T DeepClone<T>(T obj)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        var formatter = new BinaryFormatter();
        //        formatter.Serialize(ms, obj);
        //        ms.Position = 0;
        //        return (T)formatter.Deserialize(ms);
        //    }
        //}

        private string GetEventDescription(LaneId? laneId, RaceEvent raceEvent)
        {
            string eventDescription = string.Empty;
            if (laneId.HasValue)
            {
                Lane lane = _raceModel.RaceHandler.GetLaneById(laneId.Value);
                eventDescription = lane.Driver.Name + ": ";
            }
            eventDescription += GetRaceEventDesc(raceEvent);
            return eventDescription;
        }

        private static string GetRaceEventDesc(RaceEvent raceEvent)
        {
            string eventDescription = string.Empty;
            switch (raceEvent)
            {
                case RaceEvent.InvalidLapDueMinLapTime:
                    eventDescription = "Invalid lap due to min laptime";
                    break;
                case RaceEvent.LaneDisqualified:
                    eventDescription = "Disqualified";
                    break;
                case RaceEvent.LaneFinished:
                    eventDescription = "Finished";
                    break;
                case RaceEvent.LapAdded:
                    eventDescription = "Lap added";
                    break;
                case RaceEvent.PenaltyAdded:
                    eventDescription = "Penalty added";
                    break;
                case RaceEvent.RaceFinished:
                    eventDescription = "Race finished";
                    break;
                case RaceEvent.RacePaused:
                    eventDescription = "Race paused";
                    break;
                case RaceEvent.RaceRestarted:
                    eventDescription = "Race restarted";
                    break;
                case RaceEvent.RaceStarted:
                    eventDescription = "Race started";
                    break;
                case RaceEvent.RaceStopped:
                    eventDescription = "Race stopped";
                    break;
                case RaceEvent.RestartCountDown:
                case RaceEvent.StartCountDown:
                    eventDescription = "Race Countdown";
                    break;
            }
            return eventDescription;
        }
    }
}
