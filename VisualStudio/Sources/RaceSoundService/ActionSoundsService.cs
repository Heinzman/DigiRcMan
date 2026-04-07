using Elreg.BusinessObjects;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Sound;
using Elreg.HelperClasses;
using Elreg.Log;
using Elreg.RaceOptionsService;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;

namespace Elreg.RaceSoundService
{
    public class ActionSoundsService
    {
        public SoundMixer SoundMixer { get; private set; }
        private readonly SoundOptionsService _soundOptionsService;
        private readonly DriversService _driversService;
        private readonly Dictionary<ActionSoundType, Queue<ActionSound>> _globalActionSoundsOfTypes =
                new Dictionary<ActionSoundType, Queue<ActionSound>>();
        private readonly Dictionary<ActionSoundType, Dictionary<string, Queue<ActionSound>>> _driverActionSoundsOfTypes =
                new Dictionary<ActionSoundType, Dictionary<string, Queue<ActionSound>>>();
        private readonly SpecialSoundHandler _specialSoundHandler;
        private static readonly object Locker = new object();

        public static event EventHandler<SurroundSoundEventArgs> SoundOptionsChanged;

        public ActionSoundsService(SoundOptionsService soundOptionsService, DriversService driversService, 
                                   SoundMixer soundMixer, IRaceModel raceModel)
        {
            _specialSoundHandler = new SpecialSoundHandler(raceModel, this, driversService);
            _soundOptionsService = soundOptionsService;
            _driversService = driversService;
            SoundMixer = soundMixer;
            CreateBuffers();
            AttachEventHandlers();
        }

        public Queue<AudioFileReader> GetSoundOptionBufferQueue(ActionSoundType type, Lane lane)
        {
            Queue<AudioFileReader> soundOptionBufferQueue = new Queue<AudioFileReader>();
            lock (Locker)
            {
                IEnumerable<ActionSound> actionSounds = GetActionSoundsOfTypes(type, lane);
                foreach (ActionSound actionSound in actionSounds)
                    AddSoundToQueue(lane, soundOptionBufferQueue, actionSound);
            }
            return soundOptionBufferQueue;
        }

        public AudioFileReader GetAudioFileReaderOf(string fileName)
        {
            AudioFileReader audioFileReader = null;
            try
            {
                if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName))
                {
                    audioFileReader = new AudioFileReader(fileName);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
            return audioFileReader;
        }

        private void AddSoundToQueue(Lane lane, Queue<AudioFileReader> soundOptionBufferQueue, ActionSound actionSound)
        {
            try
            {
                _specialSoundHandler.AddSpecialSounds(soundOptionBufferQueue, actionSound, lane);
                if (actionSound.AudioFileReader != null)
                    soundOptionBufferQueue.Enqueue(actionSound.AudioFileReader);
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
                                                      AudioFileReader = GetActionAudioFileReader(soundOption),
                                                      VaryFrequency = soundOptionList.VaryFrequency
                                                  };
                    actionSounds.Enqueue(actionSound);
                }
            }
            return actionSounds;
        }

        private AudioFileReader GetActionAudioFileReader(SoundOption soundOption)
        {
            string soundFilename = SystemHelper.GetAbsolutePath(soundOption.SoundPath);
            return GetAudioFileReaderOf(soundFilename);
        }


    }
}
