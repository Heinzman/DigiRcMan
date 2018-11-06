using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.Races.Types;
using Newtonsoft.Json;

namespace Elreg.BusinessObjects.Races
{
    [Serializable]
    public class Race : ICloneable
    {
        private IRaceType _raceType;
        private StatusEnum _status;
        private static readonly object Locker = new object();

        public enum StatusEnum
        {
            Undefined = 0,
            Initialized = 1,
            StartCountDown = 3,
            Started = 4,
            PausedByKeyboard = 5,
            RestartCountDown = 8,
            Stopped = 9,
            Finished = 10,
            Restarted = 11,
            PausedByArduino = 12,
            PausedBeforeStart = 13
        }

        public enum TypeEnum
        {
            Training,
            Qualification,
            Race
        }

        public Race()
        {
            RacingTime = new RacingTime();
            Type = TypeEnum.Training;
            Status = StatusEnum.Undefined;
            Lanes = new List<Lane>();
            _raceType = new Competition(this);
        }

        public Race(RaceSettings raceSettings)
        {
            RacingTime = new RacingTime();
            Type = TypeEnum.Training;
            Status = StatusEnum.Undefined;
            Lanes = new List<Lane>();
            RaceSettings = raceSettings;
        }

        [JsonIgnore]
        public RaceSettings RaceSettings { get; set; }

        [JsonProperty("Lns")]
        public List<Lane> Lanes { get; private set; }

        [JsonProperty("Sts")]
        public StatusEnum Status
        {
            get
            {
                lock (Locker)
                    return _status;
            }
            set
            {
                lock (Locker)
                    _status = value;
            }
        }

        [JsonIgnore]
        public TypeEnum Type         
        { 
            get { return _raceType.Type; }

            set
            {
                switch (value)
                {
                    case TypeEnum.Training:
                        _raceType = new Training(this);
                        break;
                    case TypeEnum.Qualification:
                        _raceType = new Qualification(this);
                        break;
                    case TypeEnum.Race:
                        _raceType = new Competition(this);
                        break;
                }
            }
        }

        [XmlIgnore]
        [JsonIgnore]
        public int LapsToDrive
        {
            get { return RaceSettings.LapsToDrive; }
        }

        [JsonProperty("Rtm")]
        public RacingTime RacingTime { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public Lane WinnerLane
        {
            get 
            { 
                Lane winnerLane = null;
                if (Status == StatusEnum.Finished)
                    winnerLane = Lanes.Find(lane => lane.Position == 1);
                return winnerLane;
            }
        }

        [JsonIgnore]
        public bool IsCompetition
        {
            get { return _raceType is Competition; }
        }

        public int GetLapNumberOf(Lane lane)
        {
            return _raceType.GetLapNumberOf(lane);
        }

        [JsonIgnore]
        public bool IsStartCountDownActivated 
        {
            get { return _raceType.IsStartCountDownActivated; } 
        }

        [JsonIgnore]
        public bool IsRestartCountDownActivated
        {
            get { return _raceType.IsRestartCountDownActivated; }
        }

        [JsonIgnore]
        public int StartCountDownInitNo
        {
            get { return _raceType.StartCountDownInitNo; }
        }

        [JsonIgnore]
        public int RestartCountDownInitNo
        {
            get { return _raceType.RestartCountDownInitNo; }
        }

        public bool IsLaneJustFinished(Lane lane)
        {
            return _raceType.IsLaneJustFinished(lane);
        }

        public void OrderByPosition()
        {
            _raceType.OrderByPosition();
        }

        public void CalcLaneStatus(Lane lane)
        {
            _raceType.CalcLaneStatus(lane);
        }

        [JsonIgnore]
        public bool IsRaceFinished
        {
            get { return _raceType.IsRaceFinished; }
        }

        [JsonIgnore]
        public bool ShouldRaceBeBreaked
        {
            get { return _raceType.ShouldRaceBeBreaked; }
        }

        [JsonIgnore]
        public bool ShouldRaceResultBeShown
        {
            get { return _raceType.ShouldRaceResultBeShown; }
        }

        public object Clone()
        {
            Race race = MemberwiseClone() as Race;
            if (race != null)
            {
                race.Lanes = new List<Lane>();
                return race;
            }
            else
                return MemberwiseClone();
        }
    }
}