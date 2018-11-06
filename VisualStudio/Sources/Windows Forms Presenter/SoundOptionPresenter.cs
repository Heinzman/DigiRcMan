using System;
using System.Collections.Generic;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.Sound;
using Elreg.DomainModels;
using Elreg.Log;
using Elreg.RaceOptionsService;
using Elreg.RaceSoundService;
using Elreg.ResourcesService;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsPresenter
{
    public class SoundOptionPresenter
    {
        private readonly ISoundOptionView _soundOptionView;
        private readonly SoundOptionModel _soundOptionModel;

        public SoundOptionPresenter(ISoundOptionView soundOptionView, ActionSoundsService actionSoundsService, 
                                    DriversService driversService, RaceSettings raceSettings)
        {
            try
            {
                _soundOptionView = soundOptionView;
                _soundOptionModel = new SoundOptionModel(actionSoundsService, driversService, raceSettings);
                LanguageManager.LanguageChanged += LanguageManagerLanguageChanged;
                AdjustCultureStrings();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void PlaySoundOfCurrentRow()
        {
            try
            {
                _soundOptionView.BindingSource.EndEdit();
                SoundOption soundOption = _soundOptionView.BindingSource.Current as SoundOption;
                if (soundOption != null)
                {
                    bool varyFrequency = _soundOptionView.ChkChangeFrequency.Checked;
                    _soundOptionModel.PlaySoundOf(soundOption, varyFrequency);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void PlayAllSounds()
        {
            try
            {
                _soundOptionView.BindingSource.EndEdit();
                var soundOptions = _soundOptionView.BindingSource.DataSource as List<SoundOption>;
                if (soundOptions != null)
                {
                    bool varyFrequency = _soundOptionView.ChkChangeFrequency.Checked;
                    _soundOptionModel.PlaySoundOf(soundOptions, varyFrequency);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void LanguageManagerLanguageChanged(object sender, EventArgs e)
        {
            try
            {
                AdjustCultureStrings();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AdjustCultureStrings()
        {
            // todo grpZerothLap.Text = LanguageManager.GetString("RaceSettingsFormGrpZerothLap");
        }

    }
}
