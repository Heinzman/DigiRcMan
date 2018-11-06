using System;
using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Sound; 
using Elreg.Log;
using Elreg.RaceOptionsService;
using System.Windows.Forms;
using Elreg.HelperClasses;
using Elreg.ResourcesService;

namespace Elreg.RaceSoundService
{
    public class SpecialSoundHandler
    {
        private readonly DriversService _driversService;
        private readonly IRaceModel _raceModel;
        private readonly Dictionary<string, BufferSound> _driverBuffers = new Dictionary<string, BufferSound>();
        private readonly Dictionary<int, BufferSound> _numberBuffers = new Dictionary<int, BufferSound>();
        private readonly Dictionary<int, BufferSound> _positionBuffers = new Dictionary<int, BufferSound>();
        private readonly Dictionary<int, BufferSound> _finalPositionBuffers = new Dictionary<int, BufferSound>();
        private readonly Dictionary<int, BufferSound> _finishApplauseBuffers = new Dictionary<int, BufferSound>();
        private readonly Dictionary<Specialsound, BufferSound> _specialSoundBuffers = new Dictionary<Specialsound, BufferSound>();
        private readonly ActionSoundsService _actionSoundsService;
        private readonly List<int> _numberIndexList = new List<int>();

        private const int MaxNumber = 99;
        private const string RelativeSoundNumbersPath = @"\Sounds\Numbers\";
        private const string RelativeSoundPositionsPath = @"\Sounds\Positions\";
        private const string RelativeSoundFinalPositionsPath = @"\Sounds\FinalPositions\";
        private const string RelativeSoundFinishApplausePath = @"\Sounds\Applause\";
        private const string RelativeSpecialSoundsPath = @"\Sounds\SpecialSounds\";
        public const string SoundPositionsFileName = "Position";
        public const string SoundFinalPositionsFileName = "FinalPosition";
        private const string SoundFinishApplauseFileName = "Applause";

        private delegate string GetFilenameOfFunc(int position);

        public SpecialSoundHandler(IRaceModel raceModel, ActionSoundsService actionSoundsService, DriversService driversService)
        {
            _actionSoundsService = actionSoundsService;
            _driversService = driversService;
            _raceModel = raceModel;
        }

        public SpecialSoundHandler(ActionSoundsService actionSoundsService, DriversService driversService)
        {
            _actionSoundsService = actionSoundsService;
            _driversService = driversService;
            _raceModel = null;
        }

        public void CreateBuffers()
        {
            try
            {
                CreateDriverBuffers();
                CreateNumberBuffers();
                CreatePositionBuffers();
                CreateFinalPositionBuffers();
                CreateFinishApplauseBuffers(); 
                CreateSpecialSoundBuffers();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CreateSpecialSoundBuffers()
        {
            _specialSoundBuffers.Clear();
            
            foreach (Specialsound specialsound in Enum.GetValues(typeof(Specialsound)))
                CreateSpecialSoundBuffer(specialsound);
        }

        private void CreateSpecialSoundBuffer(Specialsound specialsound)
        {
            try
            {
                if (specialsound != Specialsound.None)
                    AddSpecialSoundToList(specialsound);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AddSpecialSoundToList(Specialsound specialsound)
        {
            string fileName = SpecialSoundsPath + specialsound + ".wav";
            BufferSound bufferSound = _actionSoundsService.GetBufferOf(fileName, false);
            _specialSoundBuffers.Add(specialsound, bufferSound);
        }

        public void AddSpecialSounds(Queue<BufferSound> soundOptionBufferQueue, ActionSound actionSound, Lane lane)
        {
            IEnumerable<BufferSound> bufferSounds = GetBuffersOfSpecialSound(actionSound.Specialsound, lane);
            foreach (BufferSound bufferSound in bufferSounds)
            {
                if (bufferSound != null)
                {
                    bufferSound.VaryFrequency = actionSound.VaryFrequency;
                    soundOptionBufferQueue.Enqueue(bufferSound);
                }
            }
        }

        private void CreateDriverBuffers()
        {
            _driverBuffers.Clear();
            foreach (Driver driver in _driversService.Drivers)
                CreateDriverBufferOf(driver);
        }

        private void CreateDriverBufferOf(Driver driver)
        {
            try
            {
                string soundFilename = SystemHelper.GetAbsolutePath(driver.SoundFilename);
                BufferSound bufferSound = _actionSoundsService.GetBufferOf(soundFilename, false);
                if (bufferSound != null)
                    _driverBuffers.Add(driver.Name, bufferSound);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CreateNumberBuffers()
        {
            FillNumberIndexList();
            _numberBuffers.Clear();
            foreach (int i in _numberIndexList)
                CreateNumberBufferOfIndex(i);
        }

        private void CreateNumberBufferOfIndex(int i)
        {
            try
            {
                string fileName = GetNumberFilenameOf(i);
                GetAndAddBuffer(i, fileName, _numberBuffers);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CreatePositionBuffers()
        {
            CreateBuffersOf(_positionBuffers, GetPositionFilenameOf);
        }

        private void CreateFinalPositionBuffers()
        {
            CreateBuffersOf(_finalPositionBuffers, GetFinalPositionFilenameOf);
        }

        private void CreateFinishApplauseBuffers()
        {
            CreateBuffersOf(_finishApplauseBuffers, GetFinishApplauseFilenameOf);
        }

        private void CreateBuffersOf(Dictionary<int, BufferSound> buffers, GetFilenameOfFunc getFilenameOfFunc)
        {            
            buffers.Clear();
            foreach (LaneId laneId in Enum.GetValues(typeof (LaneId)))
                CreateBuffer(buffers, getFilenameOfFunc, laneId);
        }

        private void CreateBuffer(Dictionary<int, BufferSound> buffers, GetFilenameOfFunc getFilenameOfFunc, LaneId laneId)
        {
            try
            {
                int position = (int)laneId + 1;
                string fileName = getFilenameOfFunc(position);
                GetAndAddBuffer(position, fileName, buffers);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void GetAndAddBuffer(int position, string fileName, Dictionary<int, BufferSound> buffers)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                BufferSound bufferSound = _actionSoundsService.GetBufferOf(fileName, false);
                if (bufferSound != null)
                    buffers.Add(position, bufferSound);
            }
        }

        private void FillNumberIndexList()
        {
            _numberIndexList.Clear();
            for (int i = 0; i < MaxNumber; i++)
                _numberIndexList.Add(i);
            _numberIndexList.Add(100);
            _numberIndexList.Add(200);
            _numberIndexList.Add(300);
            _numberIndexList.Add(400);
            _numberIndexList.Add(500);
            _numberIndexList.Add(600);
            _numberIndexList.Add(700);
            _numberIndexList.Add(800);
            _numberIndexList.Add(900);
        }

        private IEnumerable<BufferSound> GetBuffersOfSpecialSound(Specialsound specialSound, Lane lane)
        {
            List<BufferSound> bufferSounds;
            if (specialSound == Specialsound.DriverName)
                bufferSounds = GetDriverBuffersOf(lane);
            else if (specialSound == Specialsound.LapCount)
                bufferSounds = GetLapBuffersOf(lane);
            else if (specialSound == Specialsound.Position)
                bufferSounds = GetPositionBuffersOf(lane);
            else if (specialSound == Specialsound.FinalPosition)
                bufferSounds = GetFinalPositionBuffersOf(lane);
            else if (specialSound == Specialsound.FinishApplause)
                bufferSounds = GetFinishApplauseBuffersOf(lane);
            else if (specialSound == Specialsound.DriverNameWithPositionIfChanged)
                bufferSounds = DriverNameWithPositionIfChangedOf(lane);
            else 
                bufferSounds = GeBufferOf(specialSound);
            return bufferSounds;
        }

        private List<BufferSound> GeBufferOf(Specialsound specialSound)
        {
            List<BufferSound> bufferSounds = new List<BufferSound>();
            BufferSound bufferSound;

            if (_specialSoundBuffers.TryGetValue(specialSound, out bufferSound) && bufferSound != null)
                bufferSounds.Add(bufferSound);

            return bufferSounds;
        }

        private List<BufferSound> DriverNameWithPositionIfChangedOf(Lane lane)
        {
            List<BufferSound> buffers = GetDriverBuffersOf(lane);

            if ((_raceModel == null || (_raceModel.Race != null && _raceModel.Race.IsCompetition)) && 
                lane.Lap >= 2 && lane.Position != lane.PositionOfLastLap)
            {
                List<BufferSound> positionBuffers = GetPositionBuffersOf(lane);
                buffers.AddRange(positionBuffers);
            }
            return buffers;
        }

        private List<BufferSound> GetDriverBuffersOf(Lane lane)
        {
            List<BufferSound> bufferSounds = new List<BufferSound>();
            BufferSound bufferSound;

            if (_driverBuffers.TryGetValue(lane.Driver.Name, out bufferSound))
                bufferSounds.Add(bufferSound);

            return bufferSounds;
        }

        private List<BufferSound> GetLapBuffersOf(Lane lane)
        {
            int lap = lane.Lap;
            if (_raceModel != null)
                lap = _raceModel.Race.GetLapNumberOf(lane);
            return GetNumerBufferOf(lap);
        }

        private List<BufferSound> GetNumerBufferOf(int count)
        {
            List<BufferSound> bufferSounds = new List<BufferSound>();
            int preHundred = count % 100;

            if (count < 100 || preHundred == 0)
            {
                BufferSound bufferSound;
                _numberBuffers.TryGetValue(count, out bufferSound);
                bufferSounds.Add(bufferSound);
            }
            else
            {
                int postHundred = count - preHundred;
                BufferSound bufferSound;
                _numberBuffers.TryGetValue(postHundred, out bufferSound);
                bufferSounds.Add(bufferSound);

                _numberBuffers.TryGetValue(preHundred, out bufferSound);
                bufferSounds.Add(bufferSound);
            }
            return bufferSounds;
        }

        private string GetNumberFilenameOf(int number)
        {
            return SoundNumbersPath + number + ".wav";
        }

        private List<BufferSound> GetPositionBuffersOf(Lane lane)
        {
            int position = lane.Position;
            return GetPositionBufferOf(position, _positionBuffers);
        }

        private List<BufferSound> GetFinalPositionBuffersOf(Lane lane)
        {
            int position = lane.Position;
            return GetPositionBufferOf(position, _finalPositionBuffers);
        }

        private List<BufferSound> GetFinishApplauseBuffersOf(Lane lane)
        {
            int position = lane.Position;
            return GetPositionBufferOf(position, _finishApplauseBuffers);
        }

        private List<BufferSound> GetPositionBufferOf(int position, Dictionary<int, BufferSound> buffers)
        {
            List<BufferSound> bufferSounds = new List<BufferSound>();
            BufferSound bufferSound;

            if (buffers.TryGetValue(position, out bufferSound))
                bufferSounds.Add(bufferSound);
            return bufferSounds;
        }

        public static string GetPositionFilenameOf(int position)
        {
            return SoundPositionsPath + SoundPositionsFileName + position + ".wav";
        }

        public static string GetFinalPositionFilenameOf(int position)
        {
            return SoundFinalPositionsPath + SoundFinalPositionsFileName + position + ".wav";
        }

        private string GetFinishApplauseFilenameOf(int position)
        {
            return SoundFinishApplausePath + SoundFinishApplauseFileName + position + ".wav";
        }

        public static string SoundNumbersPath
        {
            get { return Application.StartupPath + RelativeSoundNumbersPath + LanguageManager.LanguagePath; }
        }

        public static string SoundPositionsPath
        {
            get { return Application.StartupPath + RelativeSoundPositionsPath + LanguageManager.LanguagePath; }
        }

        public static string SoundFinalPositionsPath
        {
            get { return Application.StartupPath + RelativeSoundFinalPositionsPath + LanguageManager.LanguagePath; }
        }

        private static string SoundFinishApplausePath
        {
            get { return Application.StartupPath + RelativeSoundFinishApplausePath; }
        }

        public static string SpecialSoundsPath
        {
            get { return Application.StartupPath + RelativeSpecialSoundsPath + LanguageManager.LanguagePath; }
        }


    }
}
