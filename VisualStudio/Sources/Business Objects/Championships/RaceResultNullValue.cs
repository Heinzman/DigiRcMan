using System;
using System.Collections.Generic;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Races;

namespace Elreg.BusinessObjects.Championships
{
    public class RaceResultNullValue : IRaceResult 
    {
        public void Create(IEnumerable<Lane> lanes, Race.TypeEnum raceType) { }

        public Race.TypeEnum RaceType 

        {
            get { return Race.TypeEnum.Training; }
            set {}
        }

        public DateTime CreationDateTime { get; set; }

        public List<RaceResultLane> RaceResultLanes
        {
            get { return new List<RaceResultLane>(); }
            set {}
        }

        public string Name
        {
            get { return string.Empty; }
            set {}
        }
    }
}
