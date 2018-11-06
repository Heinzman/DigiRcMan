using System;
using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.Log;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsPresenter.RaceGrid.LapTime
{
    public class LapTimeHandler : IRaceLapObserver, IRaceStatusObserver
    {
        private readonly IRaceModel _raceModel;
        private readonly IRaceGridView _raceGridView;
        private readonly IRaceGridPresenter _presenter;
        private readonly bool _isResetTimerActivated;
        private readonly Dictionary<LaneId, ILaneLapTime> _laneLapTimeList = new Dictionary<LaneId, ILaneLapTime>();

        public LapTimeHandler(IRaceModel raceModel, IRaceGridView raceGridView, IRaceGridPresenter raceGridPresenter,
                              bool isResetTimerActivated = true)
        {
            _raceModel = raceModel;
            _raceGridView = raceGridView;
            _presenter = raceGridPresenter;
            _isResetTimerActivated = isResetTimerActivated;
            AttachToRaceModelEvents();

            AddLaneLapTime(LaneId.Lane1);
            AddLaneLapTime(LaneId.Lane2);
            AddLaneLapTime(LaneId.Lane3);
            AddLaneLapTime(LaneId.Lane4);
            AddLaneLapTime(LaneId.Lane5);
            AddLaneLapTime(LaneId.Lane6);
        }

        private void AddLaneLapTime(LaneId laneId)
        {
            _laneLapTimeList.Add(laneId, new LaneLapTime(laneId, _raceModel, _raceGridView, _presenter, _isResetTimerActivated));
        }

        public void Reset()
        {
            foreach (ILaneLapTime laneLapTime in _laneLapTimeList.Values)
                laneLapTime.Reset();
        }

        public void ResetBackgroundColors()
        {
            foreach (ILaneLapTime laneLapTime in _laneLapTimeList.Values)
                laneLapTime.ResetBackgroundColor();
        }

        public void LapAdded(LaneId laneId)
        {
            try
            {
                ILaneLapTime laneLapTime = GetLaneLapTimeBy(laneId);
                laneLapTime.HandleLapAdded();
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
                ILaneLapTime laneLapTime = GetLaneLapTimeBy(laneId);
                laneLapTime.HandleLapNotAddedDuePenaltyOrNoFuel();
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
                ILaneLapTime laneLapTime = GetLaneLapTimeBy(laneId);
                laneLapTime.HandleLapNotAddedDueMinSeconds();
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
                ILaneLapTime laneLapTime = GetLaneLapTimeBy(laneId);
                laneLapTime.HandleAutoDetectedLapAdded();
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
                ILaneLapTime laneLapTime = GetLaneLapTimeBy(laneId);
                laneLapTime.HandleFinished();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void RaceStarted(object sender, EventArgs e) { }

        public void RaceRestarted(object sender, EventArgs e)
        {
            try
            {
                foreach (ILaneLapTime laneLapTime in _laneLapTimeList.Values)
                    laneLapTime.HandleRaceRestarted();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void RacePaused(object sender, EventArgs e)
        {
            try
            {
                foreach (ILaneLapTime laneLapTime in _laneLapTimeList.Values)
                    laneLapTime.HandleRacePaused();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void RaceBreaked(object sender, EventArgs e) { }
        public void RaceInitialized(object sender, EventArgs e) { }
        public void RaceFinished(object sender, EventArgs e) { }
        public void RaceStopped(object sender, EventArgs e) { }
        public void RaceUnbreaked(object sender, EventArgs e) { }

        private ILaneLapTime GetLaneLapTimeBy(LaneId laneId)
        {
            ILaneLapTime laneLapTime;
            if (_laneLapTimeList.TryGetValue(laneId, out laneLapTime))
                return laneLapTime;
            else
                return new LaneLapTimeNullObject();
        }

        private void AttachToRaceModelEvents()
        {
            _raceModel.Attach(this as IRaceLapObserver);
            _raceModel.Attach(this as IRaceStatusObserver);
        }

    }
}
