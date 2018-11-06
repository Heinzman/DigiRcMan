using System;
using System.IO;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.Sound;
using Elreg.HelperClasses;
using Elreg.Log;
using Elreg.RaceOptionsService;
using Elreg.RaceSoundService;
using Elreg.ResourcesService;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsPresenter
{
    public class MaintainDriversPresenter
    {
        private readonly IMaintainDriversView _maintainDriversView;
        private readonly OpenFileDialog _openFileDialog = new OpenFileDialog();
        private readonly ActionSoundsService _actionSoundsService;
        private readonly DriversService _driversService;
        private readonly RaceSettings _raceSettings;
        private readonly Settings _settings = new Settings();
        private readonly SoundSettings _userSoundSettings = new SoundSettings(); 
        private readonly BindingSource _bindingSource = new BindingSource();

        public MaintainDriversPresenter(IMaintainDriversView maintainDriversView, DriversService driversService, ActionSoundsService actionSoundsService, RaceSettings raceSettings)
        {
            try
            {
                _maintainDriversView = maintainDriversView;
                _driversService = driversService;
                _actionSoundsService = actionSoundsService;
                _raceSettings = raceSettings;
                _bindingSource.PositionChanged += BindingSource1PositionChanged;
                _bindingSource.DataSourceChanged += BindingSource1CurrentChanged;
                AdjustCultureStrings();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public string WavDirectory
        {
            get { return _settings.WavNamePath; }
        }

        public void OpenHymnFilename()
        {
            try
            {
                _openFileDialog.FileName = string.Empty;
                _openFileDialog.Filter = @"Mp3-Dateien (*.mp3)|*.mp3";
                _openFileDialog.InitialDirectory = _settings.HymnFilenamePath;

                if (_openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileInfo = new FileInfo(_openFileDialog.FileName);
                    _maintainDriversView.TxtHymnFilename.Text = SystemHelper.GetRelativeSubPath(_openFileDialog.FileName);
                    _maintainDriversView.TxtHymnFilename.Focus();
                    _settings.HymnFilenamePath = fileInfo.DirectoryName;
                    SaveSettings();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void OpenFileWavName()
        {
            try
            {
                _openFileDialog.FileName = string.Empty;
                _openFileDialog.Filter = @"Wavedateien (*.wav)|*.wav";
                _openFileDialog.InitialDirectory = _settings.WavNamePath;

                if (_openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileInfo = new FileInfo(_openFileDialog.FileName);
                    _maintainDriversView.TxtWavName.Text = SystemHelper.GetRelativeSubPath(_openFileDialog.FileName);
                    _maintainDriversView.TxtWavName.Focus();
                    _settings.WavNamePath = fileInfo.DirectoryName;
                    SaveSettings();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void FillData()
        {
            try
            {
                LoadSettings(); 
                BindData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void HandleOk()
        {
            try
            {
                _bindingSource.EndEdit();
                SaveData();
                _maintainDriversView.Close();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void HandleCancel()
        {
            try
            {
                _driversService.Reset();
                _maintainDriversView.Close();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void HandleCreatedWavFileByTts(string fileName)
        {
            try
            {
                if (!string.IsNullOrEmpty(fileName))
                {
                    string soundFileName = SystemHelper.GetRelativeSubPath(fileName);
                    _maintainDriversView.TxtWavName.Text = soundFileName;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void SetDefaultValues(DataGridViewRowEventArgs e)
        {
            try
            {
                e.Row.Cells["ColumnId"].Value = _driversService.GetNextId();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void AddNewDriver()
        {
            try
            {
                Driver driver = new Driver { Id = _driversService.GetNextId() };
                _bindingSource.Add(driver);
                _bindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BindingSource1PositionChanged(object sender, EventArgs e)
        {
            try
            {
                InitSoundOptionControl();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void InitSoundOptionControl()
        {
            var driver = _bindingSource.Current as Driver;
            if (driver != null)
            {
                SoundOptionList soundOptionList = driver.SoundOptionsLap;
                _maintainDriversView.CtlLap.Init(soundOptionList, _userSoundSettings, _actionSoundsService, _driversService, _raceSettings);
            }
        }

        private void BindData()
        {
            _bindingSource.DataSource = _driversService.Drivers;
            CreateDataBindings();
        }

        private void BindingSource1CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                InitSoundOptionControl();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CreateDataBindings()
        {
            _maintainDriversView.GrdDrivers.AutoGenerateColumns = false;
            _maintainDriversView.GrdDrivers.DataSource = _bindingSource;
            _maintainDriversView.BindingNavigatorDrivers.BindingSource = _bindingSource;
            _maintainDriversView.TxtWavName.DataBindings.Add("Text", _bindingSource, "SoundFilename");
            _maintainDriversView.TxtHymnFilename.DataBindings.Add("Text", _bindingSource, "HymnFilename");
            _maintainDriversView.TxtName.DataBindings.Add("Text", _bindingSource, "Name");
            _maintainDriversView.ChkActivated.DataBindings.Add("Checked", _bindingSource, "Activated");
        }

        private void SaveData()
        {
            _driversService.Save();
            SaveSettings();
        }

        private void LoadSettings()
        {
            try
            {
                Savior.Read(_settings, _maintainDriversView.RegKey);
                Savior.Read(_userSoundSettings, _maintainDriversView.RegKey);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SaveSettings()
        {
            try
            {
                Savior.Save(_settings, _maintainDriversView.RegKey);
                Savior.Save(_userSoundSettings, _maintainDriversView.RegKey);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AdjustCultureStrings()
        {
            _maintainDriversView.Text = LanguageManager.GetString("MaintainDriversFormCaption");
            _maintainDriversView.GrpDrivers.Text = LanguageManager.GetString("MaintainDriversFormGrpDrivers");
            _maintainDriversView.GrpDetails.Text = LanguageManager.GetString("MaintainDriversFormGrpDetails");
            _maintainDriversView.GridColumnName.HeaderText = LanguageManager.GetString("MaintainDriversFormGridColumnName");
            _maintainDriversView.LblName.Text = LanguageManager.GetString("MaintainDriversFormLblName");
            _maintainDriversView.LblWavName.Text = LanguageManager.GetString("MaintainDriversFormLblWavName");
            _maintainDriversView.LblHymn.Text = LanguageManager.GetString("MaintainDriversFormLblHymn");
            _maintainDriversView.BtnCreateWav.Text = LanguageManager.GetString("MaintainDriversFormBtnCreateWav");
            _maintainDriversView.BtnOk.Text = LanguageManager.GetString("MaintainDriversFormBtnOk");
            _maintainDriversView.BtnCancel.Text = LanguageManager.GetString("MaintainDriversFormBtnCancel");
        }

        private class Settings
        {
            public string WavNamePath;
            public string HymnFilenamePath;

            public Settings()
            {
                WavNamePath = ServiceHelper.DriversPath;
                HymnFilenamePath = ServiceHelper.HymnMusicPath;
            }
        }
    }
}