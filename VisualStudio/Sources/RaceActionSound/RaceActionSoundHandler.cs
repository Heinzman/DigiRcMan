using System;
using System.Collections.Generic;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.Sound;
using Elreg.BusinessObjects;
using Elreg.RaceSound.StereoSound;
using Elreg.Log;
using Elreg.RaceSoundService;

namespace Elreg.RaceActionSound
{
    public class RaceActionSoundHandler : IRaceObserver, IRaceStatusObserver
    {
        private readonly IRaceModel _raceModel;
        private readonly Dictionary<LaneId, SoundListHandler> _soundListHandlers = new Dictionary<LaneId, SoundListHandler>();
        private readonly ActionSoundsService _actionSoundsService;
        private readonly RaceSettings _raceSettings;
        private static readonly object Locker = new object();

        public RaceActionSoundHandler(IRaceModel raceModel, ActionSoundsService actionSoundsService, RaceSettings raceSettings)
        {
            _raceModel = raceModel;
            _actionSoundsService = actionSoundsService;
            _raceSettings = raceSettings;
            AttachToModelAsObserver();
            ActionSoundsService.SoundOptionsChanged += ActionSoundsOptionsServiceSoundOptionsChanged;
        }

        private void ActionSoundsOptionsServiceSoundOptionsChanged(object sender, BusinessObjects.DerivedEventArgs.SurroundSoundEventArgs e)
        {
            try
            {
                if (!_raceModel.StatusHandler.IsRaceNotSetuped && !_raceModel.StatusHandler.IsRaceStoppedOrFinished)
                    CreateSounds();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void RaceChanged(object sender, EventArgs e) { }

        public void RaceStatusChanged(object sender, EventArgs e) { }

        public void RaceStarted(object sender, EventArgs e) { }

        public void RaceRestarted(object sender, EventArgs e) { }

        public void RacePaused(object sender, EventArgs e)
        {
            
        }

        public void RaceBreaked(object sender, EventArgs e) { }

        public void RaceInitialized(object sender, EventArgs e)
        {
            try
            {
                CreateSounds();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void RaceFinished(object sender, EventArgs e) { }

        public void RaceStopped(object sender, EventArgs e) { }

        public void RaceUnbreaked(object sender, EventArgs e) { }

        public void LaneChanged(LaneId laneId) { }

        public void LapNotAddedDueMinSeconds(LaneId laneId) { }

        public void AutoDetectedLapAdded(LaneId laneId)
        {
            try
            {
                LapAdded(laneId);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void PenaltyAdded(LaneId laneId)
        {
            try
            {
                AddSoundBuffersToQueueIfInRace(ActionSoundType.Penalty, laneId);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void Disqualified(LaneId laneId)
        {
            try
            {
                if (IsLaneInRaceOrInitializedOrDisqualified(laneId))
                    AddSoundBuffersToQueueOf(ActionSoundType.Disqualified, laneId);
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
                if (IsLastLap(laneId))
                    AddSoundBuffersToQueueOf(ActionSoundType.Finished, laneId);
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
                if (IsLaneInRaceOrInitializedButNotLastLap(laneId))
                    AddSoundBuffersToQueueIfInRace(ActionSoundType.Lap, laneId);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void EngineFixed(LaneId laneId) { }

        public void CarDamagedByRocket(LaneId laneId) { }

        public void RocketExplodedDueDefending(LaneId laneId) { }

        public void RocketDamageFixed(LaneId laneId) { }

        public void RocketStarted(LaneId laneId) { }

        public void AttackedByRocket(LaneId laneId) { }

        private void AddSoundBuffersToQueueIfInRace(ActionSoundType actionSoundType, LaneId laneId)
        {
            if (IsLaneInRaceOrInitialized(laneId))
                AddSoundBuffersToQueueOf(actionSoundType, laneId);
        }

        private void AddSoundBuffersToQueueOf(ActionSoundType type, LaneId laneId)
        {
            try
            {
                Lane lane = _raceModel.RaceHandler.GetLaneById(laneId);
                Queue<BufferSound> bufferSoundsOfOneAction = _actionSoundsService.GetSoundOptionBufferQueue(type, lane);
                SoundListHandler soundListHandler = DetermineCurrentSoundListHandlerBy(laneId);
                soundListHandler.AddSoundsOfOneAction(bufferSoundsOfOneAction);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private SoundListHandler DetermineCurrentSoundListHandlerBy(LaneId laneId)
        {
            SoundListHandler soundListHandler;
            lock (Locker)
            {
                if (HasSingleSoundListHandler)
                    soundListHandler = _soundListHandlers[0];
                else
                    _soundListHandlers.TryGetValue(laneId, out soundListHandler);
            }
            return soundListHandler;
        }

        private void AttachToModelAsObserver()
        {
            _raceModel.Attach(this as IRaceObserver);
            _raceModel.Attach(this as IRaceStatusObserver);
        }

        private void CreateSounds()
        {
            _actionSoundsService.CreateBuffers();
            CreateSoundListHandlers();
        }

        private void CreateSoundListHandlers()
        {
            lock (Locker)
            {
                ClearSoundListHandlers();
                StereoCreator stereoCreator = new StereoCreator(_raceModel.LanesWithActivatedSound, AddSoundListHandlerStereo,
                                                                HasSingleSoundListHandler);
                stereoCreator.Create();
            }
        }

        private void ClearSoundListHandlers()
        {
            foreach (SoundListHandler soundListHandler in _soundListHandlers.Values)
                soundListHandler.Dispose();
            _soundListHandlers.Clear();
        }

        private void AddSoundListHandlerStereo(int stereoPan, LaneId laneId)
        {
            try
            {
                SoundListHandler soundListHandler = new SoundListHandler(_raceModel, stereoPan, _actionSoundsService.Device,
                                                                         _actionSoundsService.SoundMixer);
                _soundListHandlers.Add(laneId, soundListHandler);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private bool IsLaneInRaceOrInitialized(LaneId laneId)
        {
            Lane lane = _raceModel.RaceHandler.GetLaneById(laneId);
            return lane.IsStartedOrInitialized;
        }

        private bool IsLaneInRaceOrInitializedOrDisqualified(LaneId laneId)
        {
            Lane lane = _raceModel.RaceHandler.GetLaneById(laneId);
            return lane.IsStartedOrInitialized || lane.IsDisqualified;
        }

        private bool IsLaneInRaceOrInitializedButNotLastLap(LaneId laneId)
        {
            Lane lane = _raceModel.RaceHandler.GetLaneById(laneId);
            return lane.IsStartedOrInitialized && lane.Lap < _raceModel.RaceSettings.LapsToDrive;
        }

        private bool IsLastLap(LaneId laneId)
        {
            Lane lane = _raceModel.RaceHandler.GetLaneById(laneId);
            return lane.IsFinished && lane.Lap == _raceModel.RaceSettings.LapsToDrive;
        }

        private bool HasSingleSoundListHandler
        {
            get { return !_raceSettings.SplittedActionSoundsActivated; }
        }

    }
}
