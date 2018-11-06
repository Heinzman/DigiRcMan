using System;
using System.Collections.Generic;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Races;

namespace Elreg.BusinessObjects.Championships
{
    [Serializable]
    public class RaceResult : IRaceResult
    {
        public RaceResult()
        {
            RaceResultLanes = new List<RaceResultLane>();
        }

        public void Create(IEnumerable<Lane> lanes, Race.TypeEnum raceType)
        {
            RaceResultLanes = new List<RaceResultLane>();
            CopyDataToRaceResultLanes(lanes);
            CreationDateTime = DateTime.Now;
            RaceType = raceType;
            CreateName();
        }

        public Race.TypeEnum RaceType { get; set; }

        public DateTime CreationDateTime { get; set; }

        public List<RaceResultLane> RaceResultLanes { get; set; }

        public string Name { get; set; }

        private void CopyDataToRaceResultLanes(IEnumerable<Lane> lanes)
        {
            foreach (Lane lane in lanes)
                CreateRaceResultLaneOf(lane);
        }

        private void CreateRaceResultLaneOf(Lane lane)
        {
            var raceResultLane = new RaceResultLane
                                     {
                                         Position = lane.Position,
                                         BestLapTime = lane.BestLapTime,
                                         Car = lane.Car,
                                         Driver = lane.Driver,
                                         Laps = lane.Lap,
                                         Penalties = lane.PenaltyCount,
                                         Id = lane.Id,
                                         RaceTimeNet = lane.RaceTimeNet,
                                         RaceTime = lane.RaceTime,
                                         IsDisqualified = lane.IsDisqualified
                                     };
            RaceResultLanes.Add(raceResultLane);
        }

        private void CreateName()
        {
            string type = RaceType.ToString();
            Name = type + "_" + CreationDateTime.ToString("yyyyMMdd_HHmmss");
        }
    }
}