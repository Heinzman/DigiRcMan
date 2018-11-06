using System;
using System.Collections.Generic;
using Elreg.BusinessObjects.Lanes;

namespace Elreg.BusinessObjects.Championships
{
    [Serializable]
    public class Championship
    {
        public Championship()
        {
            RaceResults = new List<RaceResult>();
            ChampionshipLanes = new List<ChampionshipLane>();
            CreationDateTime = DateTime.Now;
            CreateName();
        }

        public Championship(List<RaceResult> raceResults) : this()
        {
            RaceResults = raceResults;
        }

        public List<ChampionshipLane> ChampionshipLanes { get; set; }

        public DateTime CreationDateTime { get; set; }

        public List<RaceResult> RaceResults { get; set; }

        public string Name { get; set; }

        private void CreateName()
        {
            Name = "Championship_" + CreationDateTime.ToString("yyyyMMdd_HHmmss");
        }

    }
}