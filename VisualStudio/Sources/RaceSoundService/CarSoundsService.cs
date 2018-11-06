using System;
using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Sound;
using Elreg.Log;
using Elreg.RaceOptionsService;
using Microsoft.DirectX.DirectSound;
using System.IO;

namespace Elreg.RaceSoundService
{
    public class CarSoundsService
    {
        public Device Device { get; private set; }
        public SoundMixer SoundMixer { get; private set; }
        private readonly BufferDescription _bufferDescription;
        private readonly List<string> _brakesSoundFiles = new List<string>();
        private readonly List<string> _wheelSpinSoundFiles = new List<string>();
        private readonly List<string> _pitstopSoundFiles = new List<string>();
        private readonly List<string> _rocketStartSoundFiles = new List<string>();
        private readonly List<string> _rocketExplosionSoundFiles = new List<string>();
        private readonly List<string> _rocketWarningSoundFiles = new List<string>();
        private readonly List<string> _engineDamageSoundFiles = new List<string>();
        private readonly List<SecondaryBuffer> _brakesSecondaryBuffers = new List<SecondaryBuffer>();
        private readonly List<SecondaryBuffer> _wheelSpinSecondaryBuffers = new List<SecondaryBuffer>();
        private readonly List<SecondaryBuffer> _pitstopSecondaryBuffers = new List<SecondaryBuffer>();
        private readonly List<SecondaryBuffer> _rocketStartSecondaryBuffers = new List<SecondaryBuffer>();
        private readonly List<SecondaryBuffer> _rocketExplosionSecondaryBuffers = new List<SecondaryBuffer>();
        private readonly List<SecondaryBuffer> _rocketWarningSecondaryBuffers = new List<SecondaryBuffer>();
        private readonly List<SecondaryBuffer> _engineDamageSecondaryBuffers = new List<SecondaryBuffer>();

        public static event EventHandler<SurroundSoundEventArgs> SurroundSoundChanged;

        public CarSoundsService(Device device, BufferDescription bufferDescription, SoundMixer soundMixer)
        {
            Device = device;
            _bufferDescription = bufferDescription;
            SoundMixer = soundMixer;
            RaceSettingsService.SoundOptionsChanged += RaceSettingsServiceSoundOptionsChanged;
            GetAllWheelSpinSoundFiles();
            GetAllBrakesSoundFiles();
            GetAllPitstopSoundFiles();
            GetAllRocketStartSoundFiles();
            GetAllRocketExplosionSoundFiles();
            GetAllEngineDamageSoundFiles();
            GetAllRocketWarningSoundFiles();
            CreateSecondaryBuffers();
        }

        private void RaceSettingsServiceSoundOptionsChanged(object sender, SurroundSoundEventArgs e)
        {
            try
            {
                _bufferDescription.Control3D = e.IsSurround;
                _bufferDescription.ControlPan = !e.IsSurround;

                ClearAllSecondaryBuffers();
                CreateSecondaryBuffers();

                if (SurroundSoundChanged != null)
                    SurroundSoundChanged(this, e);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CreateSecondaryBuffers()
        {
            CreateBrakesSecondaryBuffers();
            CreateWheelSpinSecondaryBuffers();
            CreatePitstopSecondaryBuffers();
            CreateRocketStartSecondaryBuffers();
            CreateRocketExplosionSecondaryBuffers();
            CreateRocketWarningSecondaryBuffers();
            CreateEngineDamageSecondaryBuffers();
        }

        private void ClearAllSecondaryBuffers()
        {
            _brakesSecondaryBuffers.Clear();
            _wheelSpinSecondaryBuffers.Clear();
            _pitstopSecondaryBuffers.Clear();
            _rocketStartSecondaryBuffers.Clear();
            _rocketExplosionSecondaryBuffers.Clear();
            _rocketWarningSecondaryBuffers.Clear();
            _engineDamageSecondaryBuffers.Clear();
        }

        public SecondaryBuffer RandomPitstopSecondaryBuffer
        {
            get { return GetRandomSecondaryBuffer(_pitstopSecondaryBuffers); }
        }

        public SecondaryBuffer RandomRocketStartSecondaryBuffer
        {
            get { return GetRandomSecondaryBuffer(_rocketStartSecondaryBuffers); }
        }

        public SecondaryBuffer RandomRocketExplosionSecondaryBuffer
        {
            get { return GetRandomSecondaryBuffer(_rocketExplosionSecondaryBuffers); }
        }

        public SecondaryBuffer RandomEngineDamageSecondaryBuffer
        {
            get { return GetRandomSecondaryBuffer(_engineDamageSecondaryBuffers); }
        }

        public SecondaryBuffer RandomRocketWarningSecondaryBuffer
        {
            get { return GetRandomSecondaryBuffer(_rocketWarningSecondaryBuffers); }
        }

        public SecondaryBuffer RandomBrakesSecondaryBuffer
        {
            get { return GetRandomSecondaryBuffer(_brakesSecondaryBuffers); }
        }

        public SecondaryBuffer RandomWheelSpinSecondaryBuffer
        {
            get { return GetRandomSecondaryBuffer(_wheelSpinSecondaryBuffers); }
        }

        private SecondaryBuffer GetRandomSecondaryBuffer(IList<SecondaryBuffer> secondaryBuffers)
        {
            SecondaryBuffer secondaryBuffer = null;
            if (secondaryBuffers.Count > 0)
            {
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                int index = rnd.Next(secondaryBuffers.Count);
                secondaryBuffer = secondaryBuffers[index];
            }
            return secondaryBuffer;
        }

        public BufferDescription BufferDescription
        {
            get { return _bufferDescription; }
        }

        private void CreateBrakesSecondaryBuffers()
        {
            foreach (string brakesSoundFile in _brakesSoundFiles)
                CreateSecondaryBufferOf(brakesSoundFile, _brakesSecondaryBuffers);
        }

        private void CreateWheelSpinSecondaryBuffers()
        {
            foreach (string wheelSpinSoundFile in _wheelSpinSoundFiles)
                CreateSecondaryBufferOf(wheelSpinSoundFile, _wheelSpinSecondaryBuffers);
        }

        private void CreatePitstopSecondaryBuffers()
        {
            foreach (string pitstopSoundFile in _pitstopSoundFiles)
                CreateSecondaryBufferOf(pitstopSoundFile, _pitstopSecondaryBuffers);
        }

        private void CreateRocketStartSecondaryBuffers()
        {
            foreach (string rocketStartSoundFile in _rocketStartSoundFiles)
                CreateSecondaryBufferOf(rocketStartSoundFile, _rocketStartSecondaryBuffers);
        }

        private void CreateRocketExplosionSecondaryBuffers()
        {
            foreach (string rocketExplosionSoundFile in _rocketExplosionSoundFiles)
                CreateSecondaryBufferOf(rocketExplosionSoundFile, _rocketExplosionSecondaryBuffers);
        }

        private void CreateEngineDamageSecondaryBuffers()
        {
            foreach (string engineDamageSoundFile in _engineDamageSoundFiles)
                CreateSecondaryBufferOf(engineDamageSoundFile, _engineDamageSecondaryBuffers);
        }

        private void CreateRocketWarningSecondaryBuffers()
        {
            foreach (string rocketWarningSoundFile in _rocketWarningSoundFiles)
                CreateSecondaryBufferOf(rocketWarningSoundFile, _rocketWarningSecondaryBuffers);
        }

        private void GetAllWheelSpinSoundFiles()
        {
            string[] files = Directory.GetFiles(ServiceHelper.WheelSpinPath);
            foreach (string file in files)
                _wheelSpinSoundFiles.Add(file);
        }

        private void GetAllBrakesSoundFiles()
        {
            string[] files = Directory.GetFiles(ServiceHelper.BrakesPath);
            foreach (string file in files)
                _brakesSoundFiles.Add(file);
        }

        private void GetAllPitstopSoundFiles()
        {
            string[] files = Directory.GetFiles(ServiceHelper.PitstopPath);
            foreach (string file in files)
                _pitstopSoundFiles.Add(file);
        }

        private void GetAllRocketStartSoundFiles()
        {
            string[] files = Directory.GetFiles(ServiceHelper.RocketStartPath);
            foreach (string file in files)
                _rocketStartSoundFiles.Add(file);
        }

        private void GetAllRocketExplosionSoundFiles()
        {
            string[] files = Directory.GetFiles(ServiceHelper.RocketExplosionPath);
            foreach (string file in files)
                _rocketExplosionSoundFiles.Add(file);
        }

        private void GetAllEngineDamageSoundFiles()
        {
            string[] files = Directory.GetFiles(ServiceHelper.EngineDamagePath);
            foreach (string file in files)
                _engineDamageSoundFiles.Add(file);
        }

        private void GetAllRocketWarningSoundFiles()
        {
            string[] files = Directory.GetFiles(ServiceHelper.RocketWarningPath);
            foreach (string file in files)
                _rocketWarningSoundFiles.Add(file);
        }

        private void CreateSecondaryBufferOf(string fileName, List<SecondaryBuffer> secondaryBuffers)
        {
            SecondaryBuffer secondaryBuffer = CreateSecondaryBufferOf(fileName);
            CheckToAddToBufferList(secondaryBuffers, secondaryBuffer);
        }

        private void CheckToAddToBufferList(List<SecondaryBuffer> bufferList, SecondaryBuffer secondaryBuffer)
        {
            if (secondaryBuffer != null && bufferList != null)
                bufferList.Add(secondaryBuffer);
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
    }
}
