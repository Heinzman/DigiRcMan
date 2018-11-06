using System;
using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.LoggingData;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.Races;
using Elreg.DomainModels.RaceModel;

namespace Elreg.DomainModels.RaceReplay
{
    public class RaceReplayRaceModel : IRaceModel
    {
        private readonly RaceModel.RaceModel _raceModel;
        private RaceReplayData _raceReplayData;

        public event EventHandler RaceStopped;

        public ILapTimeAvgCalculator LapTimeAvgCalculator { get; set; }

        public event EventHandler RaceFinished;
        public event EventHandler RaceRestarted;
        public event EventHandler RaceInitialized;
        public event EventHandler RacePaused;
        public event EventHandler RaceStarted;

        public RaceReplayRaceModel(RaceModel.RaceModel raceModel)
        {
            _raceModel = raceModel;
            RaceReplayData = new RaceReplayData();
            RaceHandler = new RaceDataHandlerDummy();
        }

        public IRaceDataHandler RaceHandler { get; private set; }

        public IStatusHandler StatusHandler { get { return _raceModel.StatusHandler; } }

        public Race Race { get { return RaceReplayData.Race; } }

        public List<InitialLane> InitialLanes { get { return new List<InitialLane>();} }

        public void Attach(ILaneBaseObserver raceObserver)
        {
        }

        public void Detach(ILaneBaseObserver raceObserver)
        {
        }

        public void Attach(IRaceObserver raceObserver)
        {
        }

        public void Detach(IRaceObserver raceObserver)
        {
        }

        public void Attach(IRaceLapObserver raceLapObserver)
        {
        }

        public void Detach(IRaceLapObserver raceLapObserver)
        {
        }

        public void Attach(IRaceStatusObserver raceObserver)
        {
        }

        public RaceSettings RaceSettings 
        { 
            get { return _raceModel.RaceSettings; } 
            set { }
        }

        public void OnRaceFinished(EventArgs e)
        {
            EventHandler handler = RaceFinished;
            if (handler != null) handler(this, e);
        }

        public void OnRaceStopped(EventArgs e)
        {
            EventHandler handler = RaceStopped;
            if (handler != null) handler(this, e);
        }

        public void OnRaceStarted(EventArgs e)
        {
            EventHandler handler = RaceStarted;
            if (handler != null) handler(this, e);
        }

        public void OnRaceRestarted(EventArgs e)
        {
            EventHandler handler = RaceRestarted;
            if (handler != null) handler(this, e);
        }

        public void OnRacePaused(EventArgs e)
        {
            EventHandler handler = RacePaused;
            if (handler != null) handler(this, e);
        }

        public void OnRaceInitialized(EventArgs e)
        {
            EventHandler handler = RaceInitialized;
            if (handler != null) handler(this, e);
        }

        public ICountDownModel CountDownModel { get; private set; }

        public List<Lane> LanesWithActivatedSound { get { return new List<Lane>();} }

        public void PauseRaceByArduino()
        {
        }

        public void RestartRaceByKeyboardOrArduinoCheckCountDown()
        {
        }

        public void RaiseEventChanged()
        {
        }

        public void StartRocket(LaneId laneId)
        {
        }

        public void SetAttackedByRocket(LaneId laneId)
        {
        }

        public RaceReplayData RaceReplayData
        {
            get { return _raceReplayData; }
            set
            {
                _raceReplayData = value;
                RaceHandler = new RaceDataHandler(RaceReplayData.Race);
            }
        }

        public int GetLapNumberOf(Lane lane)
        {
            return RaceReplayData.Race.GetLapNumberOf(lane);
        }

        public TimeSpan GetNetTimeSpanFromStart()
        {
            if (RaceReplayData.Race != null)
                return RaceReplayData.Race.RacingTime.NetTimeSpanFromStart;
            else
                return new TimeSpan();
        }
    }
}
