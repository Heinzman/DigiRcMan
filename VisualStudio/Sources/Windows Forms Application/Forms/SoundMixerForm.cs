using System;
using System.Windows.Forms;
using Elreg.BusinessObjects.Sound;
using Elreg.Log;
using Elreg.RaceSoundService;
using Elreg.ResourcesService;
using Form = Elreg.WinFormsPresentationFramework.Forms.Form;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class SoundMixerForm : Form
    {
        private readonly SoundMixerService _soundMixerService;

        public SoundMixerForm(SoundMixerService soundMixerService)
        {
            InitializeComponent();
            _soundMixerService = soundMixerService;
            InitTrackbars(Controls);
            SetCursorForControls(Controls);
            AdjustCultureStrings();
        }

        private void InitTrackbars(Control.ControlCollection controls)
        {
            if (controls != null)
            {
                foreach (Control control in controls)
                {
                    TrackBar trackBar = control as TrackBar;
                    if (trackBar != null)
                    {
                        trackBar.Maximum = SoundMixer.MaximumVolume;
                        trackBar.Minimum = SoundMixer.MinimumVolume;
                    }
                    else
                        InitTrackbars(control.Controls);
                }
            }
        }

        private void SetCursorForControls(Control.ControlCollection controls)
        {
            if (controls != null)
            {
                foreach (Control control in controls)
                {
                    control.Cursor = LargeCursor;
                    SetCursorForControls(control.Controls);
                }
            }
        }

        private void TrackbarScroll(object sender, EventArgs e)
        {
            try
            {
                bindingSource1.EndEdit();
                _soundMixerService.RaiseEventVolumeChanged();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SoundMixerFormLoad(object sender, EventArgs e)
        {
            try
            {
                FillData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void FillData()
        {
            bindingSource1.DataSource = _soundMixerService.SoundMixer;
            CreateDataBindings();
        }

        private void CreateDataBindings()
        {
            tbCoundDown.DataBindings.Add("Value", bindingSource1, "CountDownVolume");
            tbActionSound.DataBindings.Add("Value", bindingSource1, "ActionSoundVolume");
            tbActionFade.DataBindings.Add("Value", bindingSource1, "ActionFadeVolume");
            tbMusicMain.DataBindings.Add("Value", bindingSource1, "MusicMainVolume");
            tbMusicRace.DataBindings.Add("Value", bindingSource1, "MusicRaceVolume");
            tbMusicPause.DataBindings.Add("Value", bindingSource1, "MusicPauseVolume");
            tbMusicHymn.DataBindings.Add("Value", bindingSource1, "MusicHymnVolume");
        }

        private void BtnCloseClick(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SoundMixerFormFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bindingSource1.EndEdit();
                _soundMixerService.Save();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AdjustCultureStrings()
        {
            Text = LanguageManager.GetString("SoundMixerFormCaption");
            btnClose.Text = LanguageManager.GetString("SoundMixerFormBtnClose");

            grpMusic.Text = LanguageManager.GetString("SoundMixerFormGrpMusic");
            lblMusicHymn.Text = LanguageManager.GetString("SoundMixerFormLblMusicHymn");
            lblMusicPause.Text = LanguageManager.GetString("SoundMixerFormLblMusicPause");
            lblMusicMain.Text = LanguageManager.GetString("SoundMixerFormLblMusicMain");
            lblMusicRace.Text = LanguageManager.GetString("SoundMixerFormLblMusicRace");

            grpActionSounds.Text = LanguageManager.GetString("SoundMixerFormGrpActionSounds");
            lblActionSoundAction.Text = LanguageManager.GetString("SoundMixerFormLblActionSoundAction");
            lblActionSoundFade.Text = LanguageManager.GetString("SoundMixerFormLblActionSoundFade");

            grpMisc.Text = LanguageManager.GetString("SoundMixerFormGrpMisc");
            lblMiscCountDown.Text = LanguageManager.GetString("SoundMixerFormLblMiscCountDown");
        }

    }
}
