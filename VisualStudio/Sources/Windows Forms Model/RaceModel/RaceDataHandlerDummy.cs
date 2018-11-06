using System;
using Heinzman.BusinessObjects;
using Heinzman.BusinessObjects.Interfaces;
using Heinzman.BusinessObjects.Lanes;

namespace Heinzman.DomainModels.RaceModel
{
    public class RaceDataHandlerDummy : IRaceDataHandler
    {
        public event EventHandler RaceChanged;
        public event EventHandler RaceFinished;
        public event EventHandler RaceStarted;
        public event EventHandler RaceStopped;

        public void SetLastTimeALapAlsoIrregularWasAdded(LaneId laneId, DateTime timeStamp) {}

        public void SetLastTimeAutoDetectedLapWasAdded(LaneId laneId, DateTime timeStamp) {}

        public void Break() { }

        public void Unbreak(bool isPausedByParallelPort) { }

        public void SetTimeAutoDetectedZerothLapWasAdded(LaneId id, DateTime timeStampLapWasDetected) { }

        public void Restart() { }

        public void Start() 
        {
            if (RaceChanged != null)
                RaceChanged(this, null);
            if (RaceStarted != null)
                RaceStarted(this, null);
        }

        public void Stop()
        {
            if (RaceStopped != null)
                RaceStopped(this, null);
        }

        public void WaitForStartByParallelPort() { }

        public void PauseByKeyboard() { }

        public void PauseByParallelPort() {}

        public void AddLapFor(LaneId laneId) {}

        public void AddLapAlsoIrregularFor(LaneId laneId) { }

        public void RemoveLapFor(LaneId laneId) { }

        public void SubtractFuelFor(LaneId laneId, int litres) { }

        public Lane GetLaneById(LaneId laneId) 
        {
            return null;
        }

        public void ResetLanes() { }

        public void StartCountDown() { }

        public void RestartCountDown() { }

        public void Finish()
        {
            if (RaceFinished != null)
                RaceFinished(this, null);
        }

    }
}
