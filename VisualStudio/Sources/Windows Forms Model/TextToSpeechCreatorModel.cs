using System;
using System.Collections.Generic;
using System.IO;
using Heinzman.BusinessObjects;
using Heinzman.ComputerSpeech;
using Heinzman.Exceptions;
using Heinzman.HelperClasses;
using Heinzman.Log;
using Heinzman.PresentationFramework.DataTransferObjects;
using Heinzman.RaceOptionsService;
using Heinzman.RaceSound;
using Heinzman.RaceSoundService;
using Heinzman.ResourcesService;

namespace Heinzman.DomainModels
{
    public class TextToSpeechCreatorModel
    {
        public List<TextToSpeechCreationRow> SpecialSoundList { get; private set; }
        public List<TextToSpeechCreationRow> DriverSoundList { get; private set; }
        public List<TextToSpeechCreationRow> CountDownSoundList { get; private set; }
        private SerializerService<List<TextToSpeechCreationRow>> _serializerServiceCountDown;
        private SerializerService<List<TextToSpeechCreationRow>> _serializerServiceSpecialSounds;
        private SerializerService<List<TextToSpeechCreationRow>> _serializerServiceDrivers;
        private bool _createNumbers;
        private readonly DriversService _driversService;

        private const int MaxLaneCount = 6;

        private delegate string PositionFunc(int position);

        public TextToSpeechCreatorModel(DriversService driversService)
        {
            _driversService = driversService;
        }

        public static string GetCultureSpecialSoundName(string specialSound)
        {
            string resourceName = "SpecialSound" + specialSound;
            string displayName = LanguageManager.GetString(resourceName);
            if (string.IsNullOrEmpty(displayName))
                displayName = specialSound;
            return displayName;
        }

        public void CreateCountDownSoundList()
        {
            _serializerServiceCountDown = new SerializerService<List<TextToSpeechCreationRow>>(ConfigTextToSpeechPath, @"CountDown.xml");
            List<TextToSpeechCreationRow> savedCountDownSoundList = _serializerServiceCountDown.Object;
            CountDownSoundList = new List<TextToSpeechCreationRow>();

            Dictionary<string, string> countDownStrings = new Dictionary<string, string>
                                                              {
                                                                  {"Five", CountDownSoundHandler.FilePathFive},
                                                                  {"Four", CountDownSoundHandler.FilePathFour},
                                                                  {"Three", CountDownSoundHandler.FilePathThree},
                                                                  {"Two", CountDownSoundHandler.FilePathTwo},
                                                                  {"One", CountDownSoundHandler.FilePathOne}
                                                              };
            foreach (string countDown in countDownStrings.Keys)
            {
                string displayName = countDown;
                string path;
                if (countDownStrings.TryGetValue(countDown, out path))
                {
                    string textToSpeak = LanguageManager.GetString("TextToSpeechCountDown" + countDown);
                    textToSpeak = GetSavedTextToSpeak(savedCountDownSoundList, displayName, textToSpeak);
                    AddWavCreationRowToList(CountDownSoundList, displayName, path, textToSpeak);
                }
                else
                    throw new LcException("Could not get path of " + countDown);
            }
        }

        public void CreateDriverSoundList()
        {
            _serializerServiceDrivers = new SerializerService<List<TextToSpeechCreationRow>>(ConfigTextToSpeechPath, @"Drivers.xml");
            List<TextToSpeechCreationRow> savedDriversList = _serializerServiceDrivers.Object;
            DriverSoundList = new List<TextToSpeechCreationRow>();

            foreach (Driver driver in _driversService.Drivers)
            {
                string displayName = driver.Name;
                string textToSpeak = displayName;
                string path = SystemHelper.GetAbsolutePath(driver.SoundFilename);
                textToSpeak = GetSavedTextToSpeak(savedDriversList, displayName, textToSpeak);
                AddWavCreationRowToList(DriverSoundList, displayName, path, textToSpeak);
            }
        }

        public void CreateSpecialSoundList()
        {
            _serializerServiceSpecialSounds = new SerializerService<List<TextToSpeechCreationRow>>(ConfigTextToSpeechPath, @"SpecialSounds.xml");
            List<TextToSpeechCreationRow> savedSpecialSoundList = _serializerServiceSpecialSounds.Object;
            SpecialSoundList = new List<TextToSpeechCreationRow>();
            AddValuesFromEnumToSpecialList(savedSpecialSoundList);
            AddPositionsToSpecialList(savedSpecialSoundList);
            AddFinalPositionsToSpecialList(savedSpecialSoundList);
        }

        private void AddFinalPositionsToSpecialList(IEnumerable<TextToSpeechCreationRow> savedSpecialSoundList)
        {
            PositionFunc positionFunc = SpecialSoundHandler.GetFinalPositionFilenameOf;
            const string positionFileName = SpecialSoundHandler.SoundFinalPositionsFileName;
            AddPositions(positionFunc, positionFileName, savedSpecialSoundList);
        }

        private void AddPositionsToSpecialList(IEnumerable<TextToSpeechCreationRow> savedSpecialSoundList)
        {
            PositionFunc positionFunc = SpecialSoundHandler.GetPositionFilenameOf;
            const string positionFileName = SpecialSoundHandler.SoundPositionsFileName;
            AddPositions(positionFunc, positionFileName, savedSpecialSoundList);
        }

        private void AddPositions(PositionFunc positionFunc, string positionFileName, IEnumerable<TextToSpeechCreationRow> savedSpecialSoundList)
        {
            for (int position = 1; position <= MaxLaneCount; position++)
            {
                string path = positionFunc(position);
                string specialSoundName = positionFileName + position;
                string textToSpeak = GetCultureSpecialSoundName(specialSoundName);
                HandleSpecialSoundAndAddToList(specialSoundName, textToSpeak, savedSpecialSoundList, path);
            }
        }

        private void HandleSpecialSoundAndAddToList(string displayName, string textToSpeak, IEnumerable<TextToSpeechCreationRow> savedSpecialSoundList, string path)
        {
            textToSpeak = GetSavedTextToSpeak(savedSpecialSoundList, displayName, textToSpeak);
            AddWavCreationRowToList(SpecialSoundList, displayName, path, textToSpeak);
        }

        private void AddValuesFromEnumToSpecialList(IEnumerable<TextToSpeechCreationRow> savedSpecialSoundList)
        {
            foreach (Specialsound specialsound in Enum.GetValues(typeof(Specialsound)))
            {
                if (IsToAddToList(specialsound))
                {
                    string path = SpecialSoundHandler.SpecialSoundsPath + specialsound + ".wav";
                    string displayName = GetCultureSpecialSoundName(specialsound.ToString());
                    string textToSpeak = displayName;
                    HandleSpecialSoundAndAddToList(displayName, textToSpeak, savedSpecialSoundList, path);
                }
            }
        }

        private bool IsToAddToList(Specialsound specialsound)
        {
            return specialsound != Specialsound.None &&
                   specialsound != Specialsound.DriverName &&
                   specialsound != Specialsound.PositionIfChanged &&
                   specialsound != Specialsound.FinishApplause &&
                   specialsound != Specialsound.FuelLevel &&
                   specialsound != Specialsound.WarningFuelPenalty &&
                   specialsound != Specialsound.Position &&
                   specialsound != Specialsound.FinalPosition &&
                   specialsound != Specialsound.LapCount;
        }

        public void CreateWavs(bool createNumbers)
        {
            _createNumbers = createNumbers;
            CheckToCreateNumbers();
            CheckToCreateCountdown();
            CheckToCreateSpecialSounds();
            CheckToCreateDrivers();
        }

        private void CheckToCreateDrivers()
        {
            if (AreAnyDriverItemsChecked)
            {
                BackupDriverFolder();
                CreateDrivers();
            }
        }

        private bool AreAnyDriverItemsChecked
        {
            get { return AreAnyItemsCheckedOf(DriverSoundList); }
        }

        private void BackupDriverFolder()
        {
            BackupWavFiles(ServiceHelper.DriversPath);
        }

        private void CheckToCreateSpecialSounds()
        {
            if (AreAnySpecialSoundItemsChecked)
            {
                BackupSpecialSoundFolder();
                CreateSpecialSound();
            }
        }

        private bool AreAnySpecialSoundItemsChecked
        {
            get { return AreAnyItemsCheckedOf(SpecialSoundList); }
        }

        private void BackupSpecialSoundFolder()
        {
            BackupWavFiles(SpecialSoundHandler.SpecialSoundsPath);
            BackupWavFiles(SpecialSoundHandler.SoundFinalPositionsPath);
            BackupWavFiles(SpecialSoundHandler.SoundPositionsPath);
        }

        private void CreateSpecialSound()
        {
            IterateAllRowsAndCreateSoundOf(SpecialSoundList);
        }

        public void Save()
        {
            _serializerServiceCountDown.Save(CountDownSoundList);
            _serializerServiceDrivers.Save(DriverSoundList);
            _serializerServiceSpecialSounds.Save(SpecialSoundList);
        }

        private string ConfigTextToSpeechPath
        {
            get { return ServiceHelper.ConfigTextToSpeechPath + LanguageManager.LanguagePath; }
        }

        private string GetSavedTextToSpeak(IEnumerable<TextToSpeechCreationRow> savedSoundList, string displayName, string textToSpeak)
        {
            foreach (TextToSpeechCreationRow textToSpeechCreationRow in savedSoundList)
            {
                if (textToSpeechCreationRow.DisplayName == displayName)
                {
                    textToSpeak = textToSpeechCreationRow.Text;
                    break;
                }
            }
            return textToSpeak;
        }

        private void AddWavCreationRowToList(List<TextToSpeechCreationRow> soundList, string name, string path, string text)
        {
            TextToSpeechCreationRow textToSpeechCreationRow = new TextToSpeechCreationRow { DisplayName = name, Path = path, Text = text };
            soundList.Add(textToSpeechCreationRow);
        }

        private void CheckToCreateCountdown()
        {
            if (AreAnyCountDownItemsChecked)
            {
                BackupCountdownFolder();
                CreateCountdown();
            }
        }

        private bool AreAnyCountDownItemsChecked
        {
            get { return AreAnyItemsCheckedOf(CountDownSoundList); }
        }

        private bool AreAnyItemsCheckedOf(IEnumerable<TextToSpeechCreationRow> soundList)
        {
            bool isChecked = false;
            foreach (TextToSpeechCreationRow wavCreationRow in soundList)
            {
                if (wavCreationRow.IsToCreate)
                {
                    isChecked = true;
                    break;
                }
            }
            return isChecked;
        }

        private void BackupCountdownFolder()
        {
            BackupWavFiles(CountDownSoundHandler.CountDownSoundPath);
        }

        private void CreateCountdown()
        {
            IterateAllRowsAndCreateSoundOf(CountDownSoundList);
        }

        private void CreateDrivers()
        {
            IterateAllRowsAndCreateSoundOf(DriverSoundList);
        }

        private void IterateAllRowsAndCreateSoundOf(IEnumerable<TextToSpeechCreationRow> soundList)
        {
            foreach (TextToSpeechCreationRow wavCreationRow in soundList)
            {
                if (wavCreationRow.IsToCreate)
                    CreateAndSaveSound(wavCreationRow.Text, wavCreationRow.Path);
            }
        }

        private void CheckToCreateNumbers()
        {
            if (_createNumbers)
            {
                BackupNumbersFolder();
                CreateNumbers();
            }
        }

        private void BackupNumbersFolder()
        {
            BackupWavFiles(SpecialSoundHandler.SoundNumbersPath);
        }

        private void BackupWavFiles(string sourceDir)
        {
            string archiveDirName = "Archive_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string backupDir = sourceDir + archiveDirName;

            Directory.CreateDirectory(backupDir);

            string[] files = Directory.GetFiles(sourceDir, "*.wav");
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                if (fileName != null)
                    File.Copy(Path.Combine(sourceDir, fileName), Path.Combine(backupDir, fileName), true);
            }
        }

        private void CreateNumbers()
        {
            for (int number = 1; number < 99; number++)
                CreateSoundOf(number);
            for (int number = 100; number <= 900; number += 100)
                CreateSoundOf(number);
        }

        private void CreateSoundOf(int number)
        {
            string fileName = SpecialSoundHandler.SoundNumbersPath + number + ".wav";
            string textToSpeak = number.ToString();
            CreateAndSaveSound(textToSpeak, fileName);
        }

        private void CreateAndSaveSound(string textToSpeak, string fileName)
        {
            try
            {
                var speaker = new Speaker(textToSpeak);
                speaker.SaveTo(fileName);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }
    }
}
