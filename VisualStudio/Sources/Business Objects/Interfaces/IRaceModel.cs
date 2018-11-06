using System;
using System.Collections.Generic;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.Races;

namespace Elreg.BusinessObjects.Interfaces
{
    public interface IRaceModel
    {
        IRaceDataHandler RaceHandler { get; }
        IStatusHandler StatusHandler { get; }
        Race Race { get; }
        List<InitialLane> InitialLanes { get; }
        void Attach(ILaneBaseObserver raceObserver);
        void Detach(ILaneBaseObserver raceObserver);
        void Attach(IRaceObserver raceObserver);
        void Detach(IRaceObserver raceObserver);
        void Attach(IRaceLapObserver raceLapObserver);
        void Detach(IRaceLapObserver raceLapObserver);
        void Attach(IRaceStatusObserver raceObserver);
        RaceSettings RaceSettings { get; set; }
        ILapTimeAvgCalculator LapTimeAvgCalculator { get; set; }
        event EventHandler RaceFinished;
        event EventHandler RaceStopped;
        event EventHandler RaceStarted;
        event EventHandler RaceRestarted;
        event EventHandler RacePaused;
        event EventHandler RaceInitialized;
        ICountDownModel CountDownModel { get; }
        List<Lane> LanesWithActivatedSound { get; }
        void PauseRaceByArduino();
        void RestartRaceByKeyboardOrArduinoCheckCountDown();
        void RaiseEventChanged();
        int GetLapNumberOf(Lane lane);
        TimeSpan GetNetTimeSpanFromStart();
    }
}
