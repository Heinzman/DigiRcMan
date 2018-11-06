using System;
using Elreg.BusinessObjects.Options;
using Elreg.HelperClasses;
using Elreg.Log;
using Elreg.RaceOptionsService;
using Elreg.RaceSoundService;
using Elreg.ResourcesService;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsPresenter
{
    public class MaintainSoundsPresenter
    {
        private readonly SoundSettings _settings = new SoundSettings();
        private readonly IMaintainSoundsView _maintainSoundsView;
        private readonly SoundOptionsService _soundsService;
        private readonly ActionSoundsService _actionSoundsService;
        private readonly DriversService _driversService;
        private readonly RaceSettings _raceSettings;

        public MaintainSoundsPresenter(IMaintainSoundsView maintainSoundsView, SoundOptionsService soundsService, 
                                       ActionSoundsService actionSoundsService, DriversService driversService, RaceSettings raceSettings)
        {
            try
            {
                _maintainSoundsView = maintainSoundsView;
                _soundsService = soundsService;
                _actionSoundsService = actionSoundsService;
                _driversService = driversService;
                _raceSettings = raceSettings;
                AdjustCultureStrings();
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
                _soundsService.Reset();
                _maintainSoundsView.Close();
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
                SaveData();
                _maintainSoundsView.Close();
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
                Savior.Read(_settings, _maintainSoundsView.RegKey);
                FillUserControls();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AdjustCultureStrings()
        {
            _maintainSoundsView.Text = LanguageManager.GetString("MaintainSoundsFormCaption");
            _maintainSoundsView.CtlFinished.Caption = LanguageManager.GetString("MaintainSoundsFormCtlFinished");
            _maintainSoundsView.CtlLapDetectedNotAdded.Caption = LanguageManager.GetString("MaintainSoundsFormCtlLapDetectedNotAdded");
            _maintainSoundsView.CtlDisqualified.Caption = LanguageManager.GetString("MaintainSoundsFormCtlDisqualified");
            _maintainSoundsView.CtlLap.Caption = LanguageManager.GetString("MaintainSoundsFormCtlLap");
            _maintainSoundsView.CtlPenalty.Caption = LanguageManager.GetString("MaintainSoundsFormCtlPenalty");
            _maintainSoundsView.BtnOk.Text = LanguageManager.GetString("MaintainSoundsFormBtnOk");
            _maintainSoundsView.BtnCancel.Text = LanguageManager.GetString("MaintainSoundsFormBtnCancel");
        }

        private void SaveData()
        {
            _soundsService.Save();
            Savior.Save(_settings, _maintainSoundsView.RegKey);
        }

        private void FillUserControls()
        {
            _maintainSoundsView.CtlPenalty.Init(_soundsService.SoundOptionsPenalty, _settings, _actionSoundsService, _driversService, _raceSettings);
            _maintainSoundsView.CtlLap.Init(_soundsService.SoundOptionsLap, _settings, _actionSoundsService, _driversService, _raceSettings);
            _maintainSoundsView.CtlDisqualified.Init(_soundsService.SoundOptionsDisqualified, _settings, _actionSoundsService, 
                _driversService, _raceSettings);
            _maintainSoundsView.CtlLapDetectedNotAdded.Init(_soundsService.SoundOptionsLapDetectedNotAdded, _settings, 
                _actionSoundsService, _driversService, _raceSettings);
            _maintainSoundsView.CtlFinished.Init(_soundsService.SoundOptionsFinished, _settings, _actionSoundsService, _driversService, _raceSettings);
        }

    }
}