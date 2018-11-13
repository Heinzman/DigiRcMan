using System;
using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Races;
using Elreg.Exceptions;

namespace Elreg.DomainModels.RaceModel
{
    public class RaceDataHandler : IRaceDataHandler
    {
        private readonly Race _race;
        private readonly List<InitialLane> _initialLanes;

        public event EventHandler RaceChanged;
        public event EventHandler RaceFinished;
        public event EventHandler RaceStarted;
        public event EventHandler RaceStopped;


        public RaceDataHandler(Race race, List<InitialLane> initialLanes)
            : this(race)
        {
            _race = race;
            _initialLanes = initialLanes;

            if (initialLanes == null || initialLanes.Count == 0)
                throw new LcException("There are no initial lanes");
            InitRace();
            InitLanes();
        }

        public RaceDataHandler(Race race)
        {
            _race = race;
        }

        public void SetLastTimeALapWasAdded(LaneId laneId, DateTime timeStamp)
        {
            Lane currentLane = FindAndSetCurrentLane(laneId);
            currentLane.LastTimeALapWasAdded = timeStamp;
        }

        public void Restart()
        {
            _race.Status = Race.StatusEnum.Restarted;
            _race.RacingTime.Restart();
            RestartLanes();
            RaiseEventRaceChanged();
       }

        public void SetupContest()
        {
            _race.RacingTime.Setup();
        }

        public void Start()
        {
            _race.Status = Race.StatusEnum.Started;
            _race.RacingTime.Start();
            StartLanes();
            RaiseEventRaceChanged();
            RaceStarted?.Invoke(this, null);
        }

        public void Finish()
        {
            _race.Status = Race.StatusEnum.Finished;
            _race.RacingTime.Stop();
            RaiseEventRaceChanged();
            RaceFinished?.Invoke(this, null);
        }

        public void Stop()
        {
            if (AreLanesFinishedExceptOneLane())
                Finish();
            else
            {
                _race.Status = Race.StatusEnum.Stopped;
                _race.RacingTime.Stop();
                RaiseEventRaceChanged();
                RaceStopped?.Invoke(this, null);
            }
        }

        public void PauseByKeyboard()
        {
            _race.Status = Race.StatusEnum.PausedByKeyboard;
            Pause();
        }

        public void PauseByArduino()
        {
            _race.Status = Race.StatusEnum.PausedByArduino;
            Pause();
        }

        public void PauseBeforeStart()
        {
            _race.Status = Race.StatusEnum.PausedBeforeStart;
            Pause();
        }

        private void Pause()
        {
            _race.RacingTime.Pause();
            PauseLanes();
            RaiseEventRaceChanged();
        }

        public void StartCountDown()
        {
            _race.Status = Race.StatusEnum.StartCountDown;
            RaiseEventRaceChanged();
        }

        public void RestartCountDown()
        {
            _race.Status = Race.StatusEnum.RestartCountDown;
            RaiseEventRaceChanged();
        }

        public void AddLapFor(LaneId laneId)
        {
            Lane currentLane = FindAndSetCurrentLane(laneId);
            currentLane.AddLap();
        }

        public void RemoveLapFor(LaneId laneId)
        {
            Lane currentLane = FindAndSetCurrentLane(laneId);
            currentLane.RemoveLap();
        }

        public Lane GetLaneById(LaneId laneId)
        {
            return FindAndSetCurrentLane(laneId);
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

        private Lane FindAndSetCurrentLane(LaneId laneId)
        {
            return _race.Lanes.Find(lane => lane.Id == laneId);
        }

        private void StartLanes()
        {
            foreach (Lane lane in _race.Lanes)
            {
                lane.Status = Lane.LaneStatusEnum.Started;
            }
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
            RaceChanged?.Invoke(this, null);
        }

    }
}
