using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Elreg.BusinessObjects.Lanes
{
    [Serializable]
    public class Lane : ICloneable
    {
        public enum LaneStatusEnum
        {
            Undefined = 1,
            Started = 2,
            Finished = 3,
            Disqualified = 4
        }

        private readonly InitialLane _laneInitalValues = new InitialLane();
        private DateTime _dateTimeOfPauseStart;

        public Lane()
        {
            LapTimeStamps = new List<LapTimeStamp>(); 
            Car = new Car();
            Driver = new Driver();
            Status = LaneStatusEnum.Undefined;
            SetInitialValues();
        }

        public Lane(InitialLane laneInitalValues) : this()
        {
            _laneInitalValues = laneInitalValues;
            Reset();
        }

        [JsonIgnore]
        public DateTime? LastTimeALapWasAdded { get; set; }

        [JsonIgnore]
        public DateTime? LastTimeALapWasDetected { get; set; }

        [JsonIgnore]
        public int Points { get; set; }

        public LaneId Id { get; set; }

        [JsonProperty("Ps")]
        public int Position { get; set; }

        [JsonIgnore]
        public int PositionOfLastLap { get; set; }

        public int Lap { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public TimeSpan? LapTime { get; set; }

        [JsonProperty("LTm")]
        public TimeSpan? LapTimeNet { get; set; }

        [XmlElement("LapTime", DataType = "duration")]
        [JsonIgnore]
        public string XmlLapTime
        {
            get { return LapTime.ToString(); }
            set
            {
                TimeSpan lapTime;
                if (TimeSpan.TryParse(value, out lapTime))
                    LapTime = lapTime;
                else
                    LapTime = null;
            }
        }

        [XmlIgnore]
        [JsonProperty("BTm")]
        public TimeSpan? BestLapTime { get; set; }

        [XmlElement("BestLapTime", DataType = "duration")]
        [JsonIgnore]
        public string XmlBestLapTime
        {
            get { return BestLapTime.ToString(); }
            set
            {
                TimeSpan bestLapTime;
                if (TimeSpan.TryParse(value, out bestLapTime))
                    BestLapTime = bestLapTime;
                else
                    BestLapTime = null;
            }
        }

        [JsonProperty("PCnt")]
        public int PenaltyCount { get; set; }

        [JsonProperty("Drv")]
        public Driver Driver { get; set; }

        public Car Car { get; set; }

        [JsonIgnore]
        public bool CalcLapTime { get; set; }

        [JsonIgnore]
        public TimeSpan PauseTimeSpan { get; set; }

        [JsonIgnore]
        public TimeSpan PauseTimeSpanOfRace { get; set; }

        [JsonProperty("Sts")]
        public LaneStatusEnum Status { get; set; }

        [JsonProperty("Tm")]
        public TimeSpan RaceTime { get; set; }

        [JsonProperty("TmN")]
        public TimeSpan RaceTimeNet { get; set; }

        [JsonIgnore]
        public bool IsStarted
        {
            get { return Status == LaneStatusEnum.Started; }
        }

        [JsonProperty("Ds")]
        public bool IsDisqualified
        {
            get { return Status == LaneStatusEnum.Disqualified; }
        }

        [JsonIgnore]
        public bool IsFinished
        {
            get { return Status == LaneStatusEnum.Finished; }
        }

        [JsonProperty("IsSIF")]
        public bool IsStartedOrInitializedOrFinished
        {
            get { return IsStarted || Status == LaneStatusEnum.Undefined || Status == LaneStatusEnum.Finished; }
        }

        [JsonProperty("IsSI")]
        public bool IsStartedOrInitialized
        {
            get { return IsStarted || Status == LaneStatusEnum.Undefined; }
        }

        [JsonIgnore]
        public bool IsStartedOrFinished
        {
            get { return IsStarted || Status == LaneStatusEnum.Finished; }
        }

        [JsonIgnore]
        public List<LapTimeStamp> LapTimeStamps { get; private set; }

        [JsonProperty("DltTm")]
        public TimeSpan? DeltaLapTimeToLeadingLane { get; set; }

        public void Reset()
        {
            SetInitialValues();
            CopyValuesFromInitialLane();
        }

        public void AddLap()
        {
            Lap += 1;
            LastTimeALapWasAdded = DateTime.Now;
            LapTimeStamps.Add(new LapTimeStamp(Lap));
        }

        public void RemoveLap()
        {
            LapTimeStamps.RemoveAll(lapTimeStamp => lapTimeStamp.Lap == Lap);
            Lap += -1;
        }

        public override string ToString()
        {
            return "ID: " + ((int) Id + 1) + "\t| " +
                   "Pos: " + Position + "\t| " +
                   "Driver: " + Driver.Name + "\t| " +
                   "DriverId: " + Driver.Id + "\t| " +
                   "Car: " + Car.Name + "\t| " +
                   "CarId: " + Car.Id + "\t| " +
                   "Lap: " + Lap + "\t| " +
                   "Lap Time: " + LapTime + "\t| " +
                   "Lap Time Net: " + LapTimeNet + "\t| " +
                   "Best Lap Time: " + BestLapTime + "\t| " +
                   "Penalties: " + PenaltyCount + "\t| " +
                   "Race Time: " + RaceTime + "\t| " +
                   "Status: " + Status + "\t| ";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public void Pause()
        {
            _dateTimeOfPauseStart = DateTime.Now;
        }

        public void Restart()
        {
            TimeSpan pauseTimeSpan = DateTime.Now - _dateTimeOfPauseStart;
            if (pauseTimeSpan.Ticks > 0)
                PauseTimeSpan = PauseTimeSpan.Add(pauseTimeSpan);
        }

        private void CopyValuesFromInitialLane()
        {
            Id = _laneInitalValues.Id;
            Position = GetInitialPositionFromLaneId();
            Driver = _laneInitalValues.Driver;
            Car = _laneInitalValues.Car;
        }

        private int GetInitialPositionFromLaneId()
        {
            return (int) Id + 1;
        }

        private void SetInitialValues()
        {
            LapTimeStamps.Clear();
            CalcLapTime = true;
            Lap = -1;
            LastTimeALapWasAdded = null;
            LastTimeALapWasDetected = null;
            LapTime = null;
            LapTimeNet = null;
            BestLapTime = null;
            Status = LaneStatusEnum.Undefined;
            Points = 0;
            PenaltyCount = 0;
            PauseTimeSpan = new TimeSpan();
            PauseTimeSpanOfRace = new TimeSpan();
            DeltaLapTimeToLeadingLane = null;
            RaceTimeNet = new TimeSpan();
            RaceTime = new TimeSpan();
            PositionOfLastLap = 1;
            Position = 1;
        }
    }
}