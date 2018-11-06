using System;
using Elreg.BusinessObjects;

namespace Elreg.RaceConsolidationService
{
    public class RaceData
    {
        public DateTime TimeStamp { get; set; }
        public RaceEvent RaceEvent { get; set; }
        public string Driver { get; set; }
        public string Event { get; set; }
        public string Fuel { get; set; }
        public string Laps { get; set; }
        public TimeSpan LapTime { get; set; }
        public string Penalties { get; set; }
        public string Position { get; set; }
    }
}
