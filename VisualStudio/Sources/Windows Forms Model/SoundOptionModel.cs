using System;
using System.Collections.Generic;
using System.IO;
using Heinzman.BusinessObjects;
using Heinzman.BusinessObjects.Lanes;
using Heinzman.BusinessObjects.Options;
using Heinzman.BusinessObjects.Sound;
using Heinzman.HelperClasses;
using Heinzman.RaceActionSound;
using Heinzman.RaceOptionsService;
using Heinzman.RaceSound.Sound3D;
using Heinzman.RaceSoundService;
using Microsoft.DirectX.DirectSound;

namespace Heinzman.DomainModels
{
    public class SoundOptionModel
    {
        private readonly ActionSoundsService _actionSoundsService;
        private readonly DriversService _driversService;
        private readonly RaceSettings _raceSettings;
        private Lane _randomLane;
        private readonly Random _random = new Random();
        private Queue<BufferSound> _soundOptionBufferQueue;

        public SoundOptionModel(ActionSoundsService actionSoundsService, DriversService driversService, RaceSettings raceSettings)
        {
            _actionSoundsService = actionSoundsService;
            _driversService = driversService;
            _raceSettings = raceSettings;
        }

        public void PlaySoundOf(SoundOption soundOption, bool varyFrequency)
        {
            _soundOptionBufferQueue = new Queue<BufferSound>();
            EnqueueSoundOption(soundOption, varyFrequency);
            AddSoundToHandler();
        }

        public void PlaySoundOf(IEnumerable<SoundOption> soundOptions, bool varyFrequency)
        {
            _soundOptionBufferQueue = new Queue<BufferSound>();
            foreach (SoundOption soundOption in soundOptions)
                EnqueueSoundOption(soundOption, varyFrequency);
            AddSoundToHandler();
        }

        private void AddSoundToHandler()
        {
            SoundListHandler soundListHandler;
            if (Is3D)
                soundListHandler = new SoundListHandler(_raceSettings, Sound3DVector.CenterPosition, _actionSoundsService.Device, _actionSoundsService.SoundMixer);
            else
                soundListHandler = new SoundListHandler(_raceSettings, 0, _actionSoundsService.Device, _actionSoundsService.SoundMixer);
            soundListHandler.AddSoundsOfOneAction(_soundOptionBufferQueue);
        }

        private void EnqueueSoundOption(SoundOption soundOption, bool varyFrequency)
        {
            ActionSound actionSound = new ActionSound
                                          {
                                              Specialsound = (Specialsound)soundOption.SpecialSound,
                                              BufferSound = GetActionBuffer(soundOption, varyFrequency),
                                              VaryFrequency = varyFrequency
                                          };
            RaceSettings raceSettings = new RaceSettings();
            SpecialSoundHandler specialSoundHandler = 
                new SpecialSoundHandler(raceSettings, _actionSoundsService, _driversService);
            specialSoundHandler.CreateBuffers();
            CreateRandomLane();
            specialSoundHandler.AddSpecialSounds(_soundOptionBufferQueue, actionSound, _randomLane);
            if (actionSound.BufferSound != null)
                _soundOptionBufferQueue.Enqueue(actionSound.BufferSound);
        }

        private void CreateRandomLane()
        {
            _randomLane = new Lane
                              {
                                  Driver = GetRandomDriver(),
                                  Lap = GetRandomLap(),
                                  CurrentFuelLevelInLitres = GetRandomfuelLevel(),
                                  Position = GetRandomPosition()
                              };
            CreateRandomPenalties();
        }

        private void CreateRandomPenalties()
        {
            const int maxRandomValue = 3;
            if (_random.Next(maxRandomValue) > 1)
                _randomLane.PenaltyQueue.Enqueue(new Penalty(3));
        }

        private float GetRandomfuelLevel()
        {
            const int maxRandomValue = 100;
            return _random.Next(maxRandomValue);
        }

        private int GetRandomPosition()
        {
            const int maxRandomValue = 6;
            int rnd = _random.Next(maxRandomValue);
            return rnd + 1;
        }

        private int GetRandomLap()
        {
            const int maxRandomValue = 100;
            return _random.Next(maxRandomValue);
        }

        private Driver GetRandomDriver()
        {
            int maxRandomValue = _driversService.Drivers.Count;
            int rnd = _random.Next(maxRandomValue);
            return _driversService.Drivers[rnd];
        }

        private BufferSound GetActionBuffer(SoundOption soundOption, bool varyFrequency)
        {
            string soundFilename = SystemHelper.GetAbsolutePath(soundOption.SoundPath);
            return GetBufferOf(soundFilename, varyFrequency);
        }

        private BufferSound GetBufferOf(string fileName, bool varyFrequency)
        {
            BufferSound bufferSound = null;
            if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName))
            {
                SecondaryBuffer secondaryBuffer = new SecondaryBuffer(fileName, _actionSoundsService.BufferDescription, _actionSoundsService.Device);
                bufferSound = new BufferSound(secondaryBuffer, varyFrequency);
            }
            return bufferSound;
        }

        private bool Is3D
        {
            get { return _raceSettings.SurroundActivated; }
        }

    }
}
