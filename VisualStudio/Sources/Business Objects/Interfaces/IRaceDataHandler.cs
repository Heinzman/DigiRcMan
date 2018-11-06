using System;
using Elreg.BusinessObjects.Lanes;

namespace Elreg.BusinessObjects.Interfaces
{
    public interface IRaceDataHandler
    {
        Lane GetLaneById(LaneId laneId);
        void Restart();
        void Start();
        void Stop();
        void PauseByKeyboard();
        void PauseByArduino();
        void PauseBeforeStart();
        void AddLapFor(LaneId laneId);
        void RemoveLapFor(LaneId laneId);
        void ResetLanes();
        void StartCountDown();
        void RestartCountDown();
        void Finish();
        event EventHandler RaceChanged;
        event EventHandler RaceFinished;
        event EventHandler RaceStarted;
        event EventHandler RaceStopped;
        void SetLastTimeALapWasAdded(LaneId laneId, DateTime timeStamp);
        void SetupContest();
    }
}
