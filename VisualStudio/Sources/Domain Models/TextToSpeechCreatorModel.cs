using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.ComputerSpeech;
using Elreg.Exceptions;
using Elreg.HelperClasses;
using Elreg.Log;
using Elreg.RaceOptionsService;
using Elreg.RaceSound;
using Elreg.RaceSoundService;
using Elreg.ResourcesService;
using Elreg.WinFormsPresentationFramework.DataTransferObjects;

namespace Elreg.DomainModels
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
        private const int TimeoutInMilliSecs = 30000;
        private const int MinFileSizeInBytes = 2048;
        private const int MilliSecToSleep = 100;

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
            ICollection<TextToSpeechCreationRow> savedSpecialSoundList = _serializerServiceSpecialSounds.Object;
            SpecialSoundList = new List<TextToSpeechCreationRow>();
            AddValuesFromEnumToSpecialList(savedSpecialSoundList);
            AddPositionsToSpecialList(savedSpecialSoundList);
            AddFinalPositionsToSpecialList(savedSpecialSoundList);
        }

        private void AddFinalPositionsToSpecialList(ICollection<TextToSpeechCreationRow> savedSpecialSoundList)
        {
            PositionFunc positionFunc = SpecialSoundHandler.GetFinalPositionFilenameOf;
            const string positionFileName = SpecialSoundHandler.SoundFinalPositionsFileName;
            AddPositions(positionFunc, positionFileName, savedSpecialSoundList);
        }

        private void AddPositionsToSpecialList(ICollection<TextToSpeechCreationRow> savedSpecialSoundList)
        {
            PositionFunc positionFunc = SpecialSoundHandler.GetPositionFilenameOf;
            const string positionFileName = SpecialSoundHandler.SoundPositionsFileName;
            AddPositions(positionFunc, positionFileName, savedSpecialSoundList);
        }

        private void AddPositions(PositionFunc positionFunc, string positionFileName, ICollection<TextToSpeechCreationRow> savedSpecialSoundList)
        {
            for (int position = 1; position <= MaxLaneCount; position++)
            {
                string path = positionFunc(position);
                string specialSoundName = positionFileName + position;
                string textToSpeak = GetCultureSpecialSoundName(specialSoundName);
                if (savedSpecialSoundList != null) 
                    HandleSpecialSoundAndAddToList(specialSoundName, textToSpeak, savedSpecialSoundList, path);
            }
        }

        private void HandleSpecialSoundAndAddToList(string displayName, string textToSpeak, IEnumerable<TextToSpeechCreationRow> savedSpecialSoundList, string path)
        {
            textToSpeak = GetSavedTextToSpeak(savedSpecialSoundList, displayName, textToSpeak);
            AddWavCreationRowToList(SpecialSoundList, displayName, path, textToSpeak);
        }

        private void AddValuesFromEnumToSpecialList(ICollection<TextToSpeechCreationRow> savedSpecialSoundList)
        {
            foreach (Specialsound specialsound in Enum.GetValues(typeof(Specialsound)))
            {
                if (IsToAddToList(specialsound))
                {
                    string path = SpecialSoundHandler.SpecialSoundsPath + specialsound + ".wav";
                    string displayName = GetCultureSpecialSoundName(specialsound.ToString());
                    string textToSpeak = displayName;
                    if (savedSpecialSoundList != null) 
                        HandleSpecialSoundAndAddToList(displayName, textToSpeak, savedSpecialSoundList, path);
                }
            }
        }

        private bool IsToAddToList(Specialsound specialsound)
        {
            return specialsound != Specialsound.None &&
                   specialsound != Specialsound.DriverName &&
                   specialsound != Specialsound.DriverNameWithPositionIfChanged &&
                   specialsound != Specialsound.FinishApplause &&
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
                    CreateAndSaveAndValidateSound(wavCreationRow.Text, wavCreationRow.Path);
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
            CreateAndSaveAndValidateSound(textToSpeak, fileName);
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

        private void CreateAndSaveAndValidateSound(string textToSpeak, string fileName)
        {
            try
            {
                if (TryToCreateAndSaveSound(textToSpeak, fileName))
                    NormalizeSoundfile(fileName);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void NormalizeSoundfile(string fileName)
        {
            try
            {
                string normailzerToolPath = Application.StartupPath + @"\Batches\normalize";
                string parameter = "-q \"" + fileName + "\"";
                Process.Start(normailzerToolPath, parameter);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private bool TryToCreateAndSaveSound(string textToSpeak, string fileName)
        {
            DateTime startTime = DateTime.Now;
            bool isValidationOk = false;
            do
            {
                CreateAndSaveSound(textToSpeak, fileName);
                isValidationOk = ValidateCreated(fileName);
                if (!isValidationOk)
                    Thread.Sleep(MilliSecToSleep);
            } while (!isValidationOk && !IsTimedOut(startTime));

            if (!isValidationOk)
            {
                string msg = "'" + textToSpeak + "' couldn't be created and saved in\n'" + fileName + "'.";
                throw new Exception(msg);
            }
            return isValidationOk;
        }

        private bool ValidateCreated(string fileName)
        {
            bool isValidationOk = false;
            FileInfo fileInfo = new FileInfo(fileName);
            if (fileInfo.Exists)
                isValidationOk = fileInfo.Length > MinFileSizeInBytes;
            return isValidationOk;
        }

        private bool IsTimedOut(DateTime startTime)
        {
            TimeSpan timeSpan = DateTime.Now - startTime;
            return timeSpan.TotalMilliseconds > TimeoutInMilliSecs;
        }
    }
}
