using System;
using System.Collections.Generic;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Races;

namespace Elreg.BusinessObjects.Interfaces
{
    public interface IRaceResult
    {
        void Create(IEnumerable<Lane> lanes, Race.TypeEnum raceType);
        Race.TypeEnum RaceType { get; set; }
        DateTime CreationDateTime { get; set; }
        List<RaceResultLane> RaceResultLanes { get; set; }
        string Name { get; set; }
    }
}