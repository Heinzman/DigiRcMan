using System;
using Elreg.BusinessObjects.Races;
using Newtonsoft.Json;

namespace Elreg.BusinessObjects.LoggingData
{
    public class RaceReplayData
    {
        [JsonProperty("Evt")]
        public RaceEvent RaceEvent { get; set; }

        [JsonProperty("Desc")]
        public string EventDescription { get; set; }

        [JsonProperty("R")]
        public Race Race { get; set; }

        [JsonProperty("Id")]
        public LaneId? LaneIdOfEvent { get; set; }

        [JsonProperty("Tm")]
        public DateTime Timestamp { get; set; }

    }
}
