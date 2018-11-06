using System;
using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Sound;
using Microsoft.DirectX.DirectSound;
using Elreg.Log;
using Elreg.RaceOptionsService;
using System.IO;
using Elreg.HelperClasses;

namespace Elreg.RaceSoundService
{
    public class ActionSoundsService
    {
        public Device Device { get; private set; }        
        public SoundMixer SoundMixer { get; private set; }
        private readonly SoundOptionsService _soundOptionsService;
        private readonly DriversService _driversService;
        private readonly BufferDescription _bufferDescription;
        private readonly Dictionary<ActionSoundType, Queue<ActionSound>> _globalActionSoundsOfTypes =
                new Dictionary<ActionSoundType, Queue<ActionSound>>();
        private readonly Dictionary<ActionSoundType, Dictionary<string, Queue<ActionSound>>> _driverActionSoundsOfTypes =
                new Dictionary<ActionSoundType, Dictionary<string, Queue<ActionSound>>>();
        private readonly SpecialSoundHandler _specialSoundHandler;
        private static readonly object Locker = new object();

        public static event EventHandler<SurroundSoundEventArgs> SoundOptionsChanged;

        public ActionSoundsService(SoundOptionsService soundOptionsService, DriversService driversService, 
                                   Device device, BufferDescription bufferDescription, SoundMixer soundMixer, IRaceModel raceModel)
        {
            _specialSoundHandler = new SpecialSoundHandler(raceModel, this, driversService);
            _soundOptionsService = soundOptionsService;
            _driversService = driversService;
            Device = device;
            _bufferDescription = bufferDescription;
            SoundMixer = soundMixer;
            CreateBuffers();
            AttachEventHandlers();
        }

        public Queue<BufferSound> GetSoundOptionBufferQueue(ActionSoundType type, Lane lane)
        {
            Queue<BufferSound> soundOptionBufferQueue = new Queue<BufferSound>();
            lock (Locker)
            {
                IEnumerable<ActionSound> actionSounds = GetActionSoundsOfTypes(type, lane);
                foreach (ActionSound actionSound in actionSounds)
                    AddSoundToQueue(lane, soundOptionBufferQueue, actionSound);
            }
            return soundOptionBufferQueue;
        }

        public BufferDescription BufferDescription
        {
            get { return _bufferDescription; }
        }

        public BufferSound GetBufferOf(string fileName, bool varyFrequency)
        {
            BufferSound bufferSound = null;
            try
            {
                if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName))
                {
                    SecondaryBuffer secondaryBuffer = CreateSecondaryBufferOf(fileName);
                    bufferSound = new BufferSound(secondaryBuffer, varyFrequency);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
            return bufferSound;
        }

        private SecondaryBuffer CreateSecondaryBufferOf(string fileName)
        {
            SecondaryBuffer secondaryBuffer = null;
            try
            {
                secondaryBuffer = new SecondaryBuffer(fileName, _bufferDescription, Device);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
            return secondaryBuffer;
        }

        private void AddSoundToQueue(Lane lane, Queue<BufferSound> soundOptionBufferQueue, ActionSound actionSound)
        {
            try
            {
                _specialSoundHandler.AddSpecialSounds(soundOptionBufferQueue, actionSound, lane);
                if (actionSound.BufferSound != null)
                    soundOptionBufferQueue.Enqueue(actionSound.BufferSound);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AttachEventHandlers()
        {
            _soundOptionsService.SoundsChanged += OptionsServiceSoundsChanged;
            _driversService.SoundsChanged += OptionsServiceSoundsChanged;
            RaceSettingsService.SoundOptionsChanged += RaceSettingsServiceSoundOptionsChanged;
        }

        private void RaceSettingsServiceSoundOptionsChanged(object sender, SurroundSoundEventArgs e)
        {
            try
            {
                _bufferDescription.Control3D = e.IsSurround;
                _bufferDescription.ControlPan = !e.IsSurround;

                CreateBuffers();

                if (SoundOptionsChanged != null)
                    SoundOptionsChanged(this, e);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void OptionsServiceSoundsChanged(object sender, EventArgs e)
        {
            try
            {
                CreateBuffers();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void CreateBuffers()
        {
            try
            {
                _specialSoundHandler.CreateBuffers();
                CreateGlobalActionSoundsDict();
                CreateDriverActionSoundsDict();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private IEnumerable<ActionSound> GetActionSoundsOfTypes(ActionSoundType type, Lane lane)
        {
            Queue<ActionSound> actionSounds = new Queue<ActionSound>();
            Queue<ActionSound> foundActionSounds;

            if (ExistDriverActionSounds(type, lane, out foundActionSounds) || _globalActionSoundsOfTypes.TryGetValue(type, out foundActionSounds))
                actionSounds = foundActionSounds;

            return actionSounds;
        }

        private bool ExistDriverActionSounds(ActionSoundType type, Lane lane, out Queue<ActionSound> actionSounds)
        {
            bool exists = false;
            actionSounds = null;
            Dictionary<string, Queue<ActionSound>> driverActionSounds;

            if (_driverActionSoundsOfTypes.TryGetValue(type, out driverActionSounds))
            {
                string userName = lane.Driver.Name;
                if (driverActionSounds.TryGetValue(userName, out actionSounds))
                    exists = true;
            }
            return exists;
        }

        private void CreateGlobalActionSoundsDict()
        {
            _globalActionSoundsOfTypes.Clear();
            AddGlobalActionSoundsToDict(_soundOptionsService.SoundOptionsDisqualified, ActionSoundType.Disqualified);
            AddGlobalActionSoundsToDict(_soundOptionsService.SoundOptionsLap, ActionSoundType.Lap);
            AddGlobalActionSoundsToDict(_soundOptionsService.SoundOptionsLapDetectedNotAdded, ActionSoundType.LapDetectedNotAdded);
            AddGlobalActionSoundsToDict(_soundOptionsService.SoundOptionsPenalty, ActionSoundType.Penalty);
            AddGlobalActionSoundsToDict(_soundOptionsService.SoundOptionsFinished, ActionSoundType.Finished);
        }

        private void AddGlobalActionSoundsToDict(SoundOptionList soundOptionList, ActionSoundType actionSoundType)
        {
            Queue<ActionSound> actionSounds = GetActionSoundsFrom(soundOptionList);
            _globalActionSoundsOfTypes.Add(actionSoundType, actionSounds);
        }

        private void CreateDriverActionSoundsDict()
        {
            _driverActionSoundsOfTypes.Clear();
            Dictionary<string, Queue<ActionSound>> driverActionSounds = new Dictionary<string, Queue<ActionSound>>();

            foreach (Driver driver in _driversService.Drivers)
            {
                if (driver.SoundOptionsLap.Activated)
                {
                    Queue<ActionSound> actionSounds = GetActionSoundsFrom(driver.SoundOptionsLap);
                    driverActionSounds.Add(driver.Name, actionSounds);
                }
            }
            _driverActionSoundsOfTypes.Add(ActionSoundType.Lap, driverActionSounds);
        }

        private Queue<ActionSound> GetActionSoundsFrom(SoundOptionList soundOptionList)
        {
            Queue<ActionSound> actionSounds = new Queue<ActionSound>();
            if (soundOptionList.Activated)
            {
                foreach (SoundOption soundOption in soundOptionList.SoundOptions)
                {
                    ActionSound actionSound = new ActionSound
                                                  {
                                                      Specialsound = (Specialsound) soundOption.SpecialSound,
                                                      BufferSound = GetActionBuffer(soundOption, soundOptionList.VaryFrequency),
                                                      VaryFrequency = soundOptionList.VaryFrequency
                                                  };
                    actionSounds.Enqueue(actionSound);
                }
            }
            return actionSounds;
        }

        private BufferSound GetActionBuffer(SoundOption soundOption, bool varyFrequency)
        {
            string soundFilename = SystemHelper.GetAbsolutePath(soundOption.SoundPath);
            return GetBufferOf(soundFilename, varyFrequency);
        }


    }
}
