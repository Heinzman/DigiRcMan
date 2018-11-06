using System;
using Elreg.BusinessObjects;

namespace Elreg.GhostCarService.Replay
{
    [Serializable]
    public class ReplayOptions : ICloneable
    {
        public ReplayOptions()
        {
            DefaultSpeed = 6;
            IsLaneChangeActivated = false;
            IsLaneChangeSupressed = false;
            IsRecordedLapActivated = false;
            LaneId = LaneId.Lane1;
            SuppressLaneChangeFrom = 0;
            SuppressLaneChangeTo = 0;
            LaneChangeFrequency = GhostCarLaneChangeFrequency.Medium;
            RecordedLapData = null;
        }

        public uint DefaultSpeed { get; set; }

        public bool IsRecordedLapActivated { get; set; }

        public string RecordedLapFile { get; set; }

        public GhostCarLaneChangeFrequency LaneChangeFrequency { get; set; }

        public bool IsLaneChangeActivated { get; set; }

        public bool IsLaneChangeSupressed { get; set; }

        public decimal SuppressLaneChangeFrom { get; set; }

        public decimal SuppressLaneChangeTo { get; set; }

        public LaneId LaneId { get; set; }

        public RecordedLapData RecordedLapData { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
