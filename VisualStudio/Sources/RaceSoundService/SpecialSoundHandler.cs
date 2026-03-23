using System;
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
using NAudio.Wave;

namespace Elreg.RaceSoundService
{
    public class SpecialSoundHandler
    {
        private readonly DriversService _driversService;
        private readonly IRaceModel _raceModel;
        private readonly Dictionary<string, AudioFileReader> _driverBuffers = new Dictionary<string, AudioFileReader>();
        private readonly Dictionary<int, AudioFileReader> _numberBuffers = new Dictionary<int, AudioFileReader>();
        private readonly Dictionary<int, AudioFileReader> _positionBuffers = new Dictionary<int, AudioFileReader>();
        private readonly Dictionary<int, AudioFileReader> _finalPositionBuffers = new Dictionary<int, AudioFileReader>();
        private readonly Dictionary<int, AudioFileReader> _finishApplauseBuffers = new Dictionary<int, AudioFileReader>();
        private readonly Dictionary<Specialsound, AudioFileReader> _specialSoundBuffers = new Dictionary<Specialsound, AudioFileReader>();
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
            AudioFileReader audioFileReader = _actionSoundsService.GetAudioFileReaderOf(fileName);
            _specialSoundBuffers.Add(specialsound, audioFileReader);
        }

        public void AddSpecialSounds(Queue<AudioFileReader> soundOptionBufferQueue, ActionSound actionSound, Lane lane)
        {
            IEnumerable<AudioFileReader> audioFileReaders = GetAudioFileReadersOfSpecialSound(actionSound.Specialsound, lane);
            foreach (AudioFileReader audioFileReader in audioFileReaders)
            {
                if (audioFileReader != null)
                {
                    soundOptionBufferQueue.Enqueue(audioFileReader);
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
                AudioFileReader audioFileReader = _actionSoundsService.GetAudioFileReaderOf(soundFilename);
                if (audioFileReader != null)
                    _driverBuffers.Add(driver.Name, audioFileReader);
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

        private void CreateBuffersOf(Dictionary<int, AudioFileReader> buffers, GetFilenameOfFunc getFilenameOfFunc)
        {            
            buffers.Clear();
            foreach (LaneId laneId in Enum.GetValues(typeof (LaneId)))
                CreateBuffer(buffers, getFilenameOfFunc, laneId);
        }

        private void CreateBuffer(Dictionary<int, AudioFileReader> buffers, GetFilenameOfFunc getFilenameOfFunc, LaneId laneId)
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

        private void GetAndAddBuffer(int position, string fileName, Dictionary<int, AudioFileReader> buffers)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                AudioFileReader audioFileReader = _actionSoundsService.GetAudioFileReaderOf(fileName);
                if (audioFileReader != null)
                    buffers.Add(position, audioFileReader);
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

        private IEnumerable<AudioFileReader> GetAudioFileReadersOfSpecialSound(Specialsound specialSound, Lane lane)
        {
            List<AudioFileReader> audioFileReaders;
            if (specialSound == Specialsound.DriverName)
                audioFileReaders = GetDriverAudioFileReadersOf(lane);
            else if (specialSound == Specialsound.LapCount)
                audioFileReaders = GetLapAudioFileReadersOf(lane);
            else if (specialSound == Specialsound.Position)
                audioFileReaders = GetPositionAudioFileReadersOf(lane);
            else if (specialSound == Specialsound.FinalPosition)
                audioFileReaders = GetFinalPositionAudioFileReadersOf(lane);
            else if (specialSound == Specialsound.FinishApplause)
                audioFileReaders = GetFinishApplauseAudioFileReadersOf(lane);
            else if (specialSound == Specialsound.DriverNameWithPositionIfChanged)
                audioFileReaders = DriverNameWithPositionIfChangedOf(lane);
            else 
                audioFileReaders = GetAudioFileReaderOf(specialSound);
            return audioFileReaders;
        }

        private List<AudioFileReader> GetAudioFileReaderOf(Specialsound specialSound)
        {
            List<AudioFileReader> audioFileReaders = new List<AudioFileReader>();
            AudioFileReader audioFileReader;

            if (_specialSoundBuffers.TryGetValue(specialSound, out audioFileReader) && audioFileReader != null)
                audioFileReaders.Add(audioFileReader);

            return audioFileReaders;
        }

        private List<AudioFileReader> DriverNameWithPositionIfChangedOf(Lane lane)
        {
            List<AudioFileReader> buffers = GetDriverAudioFileReadersOf(lane);

            if ((_raceModel == null || (_raceModel.Race != null && _raceModel.Race.IsCompetition)) && 
                lane.Lap >= 2 && lane.Position != lane.PositionOfLastLap)
            {
                List<AudioFileReader> positionBuffers = GetPositionAudioFileReadersOf(lane);
                buffers.AddRange(positionBuffers);
            }
            return buffers;
        }

        private List<AudioFileReader> GetDriverAudioFileReadersOf(Lane lane)
        {
            List<AudioFileReader> audioFileReaders = new List<AudioFileReader>();
            AudioFileReader audioFileReader;

            if (_driverBuffers.TryGetValue(lane.Driver.Name, out audioFileReader))
                audioFileReaders.Add(audioFileReader);

            return audioFileReaders;
        }

        private List<AudioFileReader> GetLapAudioFileReadersOf(Lane lane)
        {
            int lap = lane.Lap;
            if (_raceModel != null)
                lap = _raceModel.Race.GetLapNumberOf(lane);
            return GetNumberAudioFileReadersOf(lap);
        }

        private List<AudioFileReader> GetNumberAudioFileReadersOf(int count)
        {
            List<AudioFileReader> audioFileReaders = new List<AudioFileReader>();
            int preHundred = count % 100;

            if (count < 100 || preHundred == 0)
            {
                AudioFileReader audioFileReader;
                _numberBuffers.TryGetValue(count, out audioFileReader);
                audioFileReaders.Add(audioFileReader);
            }
            else
            {
                int postHundred = count - preHundred;
                AudioFileReader audioFileReader;
                _numberBuffers.TryGetValue(postHundred, out audioFileReader);
                audioFileReaders.Add(audioFileReader);

                _numberBuffers.TryGetValue(preHundred, out audioFileReader);
                audioFileReaders.Add(audioFileReader);
            }
            return audioFileReaders;
        }

        private string GetNumberFilenameOf(int number)
        {
            return SoundNumbersPath + number + ".wav";
        }

        private List<AudioFileReader> GetPositionAudioFileReadersOf(Lane lane)
        {
            int position = lane.Position;
            return GetPositionAudioFileReaderOf(position, _positionBuffers);
        }

        private List<AudioFileReader> GetFinalPositionAudioFileReadersOf(Lane lane)
        {
            int position = lane.Position;
            return GetPositionAudioFileReaderOf(position, _finalPositionBuffers);
        }

        private List<AudioFileReader> GetFinishApplauseAudioFileReadersOf(Lane lane)
        {
            int position = lane.Position;
            return GetPositionAudioFileReaderOf(position, _finishApplauseBuffers);
        }

        private List<AudioFileReader> GetPositionAudioFileReaderOf(int position, Dictionary<int, AudioFileReader> buffers)
        {
            List<AudioFileReader> audioFileReaders = new List<AudioFileReader>();
            AudioFileReader audioFileReader;

            if (buffers.TryGetValue(position, out audioFileReader))
                audioFileReaders.Add(audioFileReader);
            return audioFileReaders;
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
