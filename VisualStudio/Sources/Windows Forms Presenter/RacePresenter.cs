using System;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects;
using System.Threading;
using Elreg.Log;

namespace Elreg.WindowsFormsPresenter
{
    public abstract class RacePresenter : IRaceObserver, IRaceStatusObserver
    {
        protected readonly IRaceModel RaceModel;

        protected RacePresenter(IRaceModel raceModel)
        {
            RaceModel = raceModel;
            AttachToModelAsObserver();
        }

        public void RaceChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateRace();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void RaceStatusChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateRaceStatus();
                UpdateAllLanesAndPositions(null);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void LapAdded(LaneId laneId)
        {
            try
            {
                UpdateAllLanesAndPositionsAsync();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void LapNotAddedDuePenaltyOrNoFuel(LaneId laneId)
        {
            try
            {
                UpdateAllLanesAndPositionsAsync();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void LapNotAddedDueMinSeconds(LaneId laneId)
        {
            try
            {
                UpdateAllLanesAndPositionsAsync();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void AutoDetectedLapAdded(LaneId laneId)
        {
            try
            {
                UpdateAllLanesAndPositionsAsync();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void PenaltyAdded(LaneId laneId){ }

        public void FalseStartDetected(LaneId laneId) { }

        public void PitInDetected(LaneId laneId) { }

        public void PitOutDetected(LaneId laneId) { }

        public void LowFuelDetected(LaneId laneId) { }

        public void NoFuelDetected(LaneId laneId) { }

        public void Disqualified(LaneId laneId)
        {
            try
            {
                UpdateAllLanesAndPositions(null);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void Finished(LaneId laneId)
        {
            try
            {
                UpdateAllLanesAndPositionsAsync();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void Refueled(LaneId laneId) { }

        public void PenaltiesDone(LaneId laneId) { }

        public void Refueling(LaneId laneId) { }

        public void LaneChanged(LaneId laneId)
        {
            try
            {
                ThreadPool.QueueUserWorkItem(HandleLaneChanged, laneId);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void RaceStarted(object sender, EventArgs e)
        {
            try
            {
                FillView();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void RaceRestarted(object sender, EventArgs e) { }

        public void RacePaused(object sender, EventArgs e) { }

        public void RaceBreaked(object sender, EventArgs e) { }

        public void RaceInitialized(object sender, EventArgs e)
        {
            try
            {
                FillView();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void RaceFinished(object sender, EventArgs e) { }

        public void RaceStopped(object sender, EventArgs e) { }

        public void RaceUnbreaked(object sender, EventArgs e) { }

        public void Detach()
        {
            try
            {
                RaceModel.Detach(this);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public virtual void FillView() { }

        protected virtual void UpdateRace() { }

        protected virtual void UpdateRaceStatus() { }

        protected virtual void UpdateLane(Lane lane) { }

        private void HandleLaneChanged(object objLaneId)
        {
            try
            {
                LaneId laneId = (LaneId)objLaneId;
                Lane lane = RaceModel.RaceHandler.GetLaneById(laneId);
                if (lane != null)
                    UpdateLane(lane);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void UpdateAllLanesAndPositionsAsync()
        {
            ThreadPool.QueueUserWorkItem(UpdateAllLanesAndPositions);
        }

        private void UpdateAllLanesAndPositions(object state)
        {
            try
            {
                UpdateAllLanes();
                UpdatePositions();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AttachToModelAsObserver()
        {
            RaceModel.Attach(this as IRaceObserver);
            RaceModel.Attach(this as IRaceStatusObserver);
        }

        private void UpdateAllLanes()
        {
            foreach (Lane lane in RaceModel.Race.Lanes)
                UpdateLane(lane);
        }

        protected virtual void UpdatePositions() { }

    }
}
