using System;
using System.Collections.Generic;
using Heinzman.BusinessObjects;
using Heinzman.BusinessObjects.Interfaces;
using Heinzman.BusinessObjects.Lanes;
using Heinzman.BusinessObjects.Races;
using Heinzman.Exceptions;

namespace Heinzman.DomainModels.RaceModel
{
    public class RaceDataHandler : IRaceDataHandler
    {
        private readonly Race _race;
        private readonly ISerialPortReader _serialPortReader;
        private Lane _currentLane;
        private readonly List<InitialLane> _initialLanes;

        public event EventHandler RaceChanged;
        public event EventHandler RaceFinished;
        public event EventHandler RaceStarted;
        public event EventHandler RaceStopped;

        public RaceDataHandler(Race race, ISerialPortReader serialPortReader, List<InitialLane> initialLanes)
            : this(race, serialPortReader)
        {
            _race = race;
            _initialLanes = initialLanes;

            if (initialLanes == null || initialLanes.Count == 0)
                throw new LcException("There are no initial lanes");
            InitRace();
            InitLanes();
        }

        public RaceDataHandler(Race race, ISerialPortReader serialPortReader)
        {
            _race = race;
            _serialPortReader = serialPortReader;
        }

        public void Restart()
        {
            SerialPortReaderEnabled = true;
            _race.Status = Race.StatusEnum.Started;
            _race.RacingTime.Restart();
            RestartLanes();
            RaiseEventRaceChanged();
       }

        public void Start()
        {
            SerialPortReaderEnabled = true; 
            _race.Status = Race.StatusEnum.Started;
            _race.RacingTime.Start();
            StartLanes();
            RaiseEventRaceChanged();
            if (RaceStarted != null)
                RaceStarted(this, null);
        }

        public void Finish()
        {
            _race.Status = Race.StatusEnum.Finished;
            SerialPortReaderEnabled = false;
            _race.RacingTime.Stop();
            RaiseEventRaceChanged();
            if (RaceFinished != null)
                RaceFinished(this, null);
        }

        public void Stop()
        {
            SerialPortReaderEnabled = false;
            if (AreLanesFinishedExceptOneLane())
                Finish();
            else
            {
                _race.Status = Race.StatusEnum.Stopped;
                _race.RacingTime.Stop();
                RaiseEventRaceChanged();
                if (RaceStopped != null)
                    RaceStopped(this, null);
            }
        }

        public void WaitForStartByParallelPort()
        {
            SerialPortReaderEnabled = false;
            _race.Status = Race.StatusEnum.WaitingForStartByParallelPort;
            _race.RacingTime.Stop();
            RaiseEventRaceChanged();
        }

        public void PauseByKeyboard()
        {
            _race.Status = Race.StatusEnum.PausedByKeyboard;
            _race.RacingTime.Pause();
            PauseLanes();
            RaiseEventRaceChanged();
        }

        public void StartCountDown()
        {
            SerialPortReaderEnabled = true;
            _race.Status = Race.StatusEnum.StartCountDown;
            RaiseEventRaceChanged();
        }

        public void RestartCountDown()
        {
            SerialPortReaderEnabled = true;
            _race.Status = Race.StatusEnum.RestartCountDown;
            RaiseEventRaceChanged();
        }

        public void PauseByParallelPort()
        {
            _race.Status = Race.StatusEnum.PausedByParallelPort;
            _race.RacingTime.Pause();
            PauseLanes();
            RaiseEventRaceChanged();
        }

        public void AddLapFor(LaneId laneId)
        {
            FindAndSetCurrentLane(laneId);
            _currentLane.AddLaps(1);
            SetInitalFalseStartDateTime(_currentLane);
        }

        public void AddLapAlsoIrregularFor(LaneId laneId)
        {
            FindAndSetCurrentLane(laneId);
            _currentLane.AddLapsAlsoIrregular(1);
        }

        public void SetLastTimeALapAlsoIrregularWasAdded(LaneId laneId, DateTime timeStamp)
        {
            FindAndSetCurrentLane(laneId);
            _currentLane.LastTimeALapAlsoIrregularWasAdded = timeStamp;
        }

        public void SetLastTimeAutoDetectedLapWasAdded(LaneId laneId, DateTime timeStamp)
        {
            FindAndSetCurrentLane(laneId);
            _currentLane.LastTimeAutoDetectedLapWasAdded = timeStamp;
        }

        public void Break()
        {
            _race.Status = Race.StatusEnum.Breaked;
            RaiseEventRaceChanged();
        }

        public void Unbreak(bool isPausedByParallelPort)
        {
            if (isPausedByParallelPort)
                _race.Status = Race.StatusEnum.PausedByParallelPort;
            else
                _race.Status = Race.StatusEnum.PausedByKeyboard;
            RaiseEventRaceChanged();
        }

        public void SetTimeAutoDetectedZerothLapWasAdded(LaneId laneId, DateTime timeStamp)
        {
            FindAndSetCurrentLane(laneId);
            _currentLane.TimeAutoDetectedZerothLapWasAdded = timeStamp;
        }

        public void RemoveLapFor(LaneId laneId)
        {
            FindAndSetCurrentLane(laneId);
            _currentLane.AddLaps(-1);
        }

        public void SubtractFuelFor(LaneId laneId, int litres)
        {
            FindAndSetCurrentLane(laneId);
            _currentLane.ConsumeFuelInLitres(litres);
        }

        public Lane GetLaneById(LaneId laneId)
        {
            FindAndSetCurrentLane(laneId);
            return _currentLane;
        }

        public void ResetLanes()
        {
            foreach (Lane lane in _race.Lanes)
                lane.Reset();
        }

        private bool AreLanesFinishedExceptOneLane()
        {
            bool isFinishedExceptOneLane = false;

            int finishedCount = 0;
            foreach (Lane lane in _race.Lanes)
                if (lane.IsFinished)
                    finishedCount++;

            if (finishedCount >= _race.Lanes.Count - 1)
                isFinishedExceptOneLane = true;

            return isFinishedExceptOneLane;
        }

        private void InitLanes()
        {
            foreach (InitialLane initialLane in _initialLanes)
                _race.Lanes.Add(new Lane(initialLane));
        }

        private void InitRace()
        {
            _race.Status = Race.StatusEnum.Initialized;
        }

        private void FindAndSetCurrentLane(LaneId laneId)
        {
            _currentLane = _race.Lanes.Find(lane => lane.Id == laneId);
        }

        private void StartLanes()
        {
            foreach (Lane lane in _race.Lanes)
            {
                lane.Start(_race.RacingTime.StartTime);
                SetInitalFalseStartDateTime(lane);
            }
        }

        private static void SetInitalFalseStartDateTime(Lane lane)
        {
            lane.LastFalseStartDateTime = null;
        }

        private void PauseLanes()
        {
            foreach (Lane lane in _race.Lanes)
                lane.Pause();
        }

        private void RestartLanes()
        {
            foreach (Lane lane in _race.Lanes)
                lane.Restart();
        }

        private void RaiseEventRaceChanged()
        {
            if (RaceChanged != null)
                RaceChanged(this, null);
        }

        private bool SerialPortReaderEnabled
        {
            set
            {
                if (_serialPortReader != null)
                    _serialPortReader.Enabled = value;
            }
        }

    }
}
