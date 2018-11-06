using System;
using Elreg.Log;
using Elreg.RaceOptionsService;
using Elreg.ResourcesService;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class RaceSettingsForm : WinFormsPresentationFramework.Forms.Form, ISimpleView
    {
        private readonly RaceSettingsService _raceSettingsService;

        public RaceSettingsForm(RaceSettingsService raceSettingsService)
        {
            _raceSettingsService = raceSettingsService;
            InitializeComponent();
            InitControls();
            LanguageManager.LanguageChanged += LanguageManagerLanguageChanged;
            AdjustCultureStrings();
#if IsProtectedVersion
            udLapsToDrive.Maximum = 9 + 6;
#endif
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

        private void BtnCancelClick(object sender, EventArgs e)
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

        private void BtnOkClick(object sender, EventArgs e)
        {
            try
            {
                SaveData();
                Close();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SaveData()
        {
            DetermineChanges();
            UpdateRaceSettingsWithValues();
            _raceSettingsService.Save();
            LanguageManager.LanguageType = _raceSettingsService.RaceSettings.LanguageType;
        }

        private void DetermineChanges()
        {
            _raceSettingsService.HasSoundOptionsChanged = chkActivateSplittedActionSounds.Checked != _raceSettingsService.RaceSettings.SplittedActionSoundsActivated;
        }

        private void UpdateRaceSettingsWithValues()
        {
            _raceSettingsService.RaceSettings.TrackName = txtRaceTrackName.Text;
            _raceSettingsService.RaceSettings.EventName = txtEventName.Text;
            _raceSettingsService.RaceSettings.LapsToDrive = (int)udLapsToDrive.Value;
            _raceSettingsService.RaceSettings.DescendingLapCount = chkCountDescending.Checked;

            _raceSettingsService.RaceSettings.QualificationTimeBasedActivated = chkActivateQualiTimeBased.Checked;
            _raceSettingsService.RaceSettings.QualificationMinutes = udQualificationMinutes.Value;
            _raceSettingsService.RaceSettings.QualificationBreaks = (int)udQualificationBreakCount.Value;

            _raceSettingsService.RaceSettings.QualificationLapBasedActivated = chkActivateQualiLapBased.Checked;
            _raceSettingsService.RaceSettings.QualificationMaxLaps = (int)udQualificationMaxLaps.Value;

            _raceSettingsService.RaceSettings.SecondsForValidLap = (int)udSecondsForValidLap.Value;
            _raceSettingsService.RaceSettings.StartCountDownRaceInitNo = (int)udStartCountDownInitNoRace.Value;
            _raceSettingsService.RaceSettings.RestartCountDownRaceInitNo = (int)udRestartCountDownInitNoRace.Value;
            _raceSettingsService.RaceSettings.StartCountDownQualiInitNo = (int)udStartCountDownInitNoQuali.Value;
            _raceSettingsService.RaceSettings.RestartCountDownQualiInitNo = (int)udRestartCountDownInitNoQuali.Value;
            _raceSettingsService.RaceSettings.StartCountDownTrainingInitNo = (int)udStartCountDownInitNoTraining.Value;
            _raceSettingsService.RaceSettings.RestartCountDownTrainingInitNo = (int)udRestartCountDownInitNoTraining.Value;
            _raceSettingsService.RaceSettings.SplittedActionSoundsActivated = chkActivateSplittedActionSounds.Checked;
            _raceSettingsService.RaceSettings.StartCountDownRaceActivated = chkActivateStartCountDownRace.Checked;
            _raceSettingsService.RaceSettings.StartCountDownQualiActivated = chkActivateStartCountDownQuali.Checked;
            _raceSettingsService.RaceSettings.StartCountDownTrainingActivated = chkActivateStartCountDownTraining.Checked;
            _raceSettingsService.RaceSettings.RestartCountDownRaceActivated = chkActivateRestartCountDownRace.Checked;
            _raceSettingsService.RaceSettings.RestartCountDownQualiActivated = chkActivateRestartCountDownQuali.Checked;
            _raceSettingsService.RaceSettings.RestartCountDownTrainingActivated = chkActivateRestartCountDownTraining.Checked;
            _raceSettingsService.RaceSettings.AutoDisqualificationRaceActivated = chkActivateAutoDisqualificationRace.Checked;
            _raceSettingsService.RaceSettings.AutoDisqualificationRaceAfterPenalties = (int)udAutoDisqualificationRace.Value;

            _raceSettingsService.RaceSettings.DisqualificationLapSecsActivated = chkActivateDisqualificationLapSecs.Checked;
            _raceSettingsService.RaceSettings.DisqualificationLapSecsFactor = udDisqualificationLapSecsFactor.Value;

            _raceSettingsService.RaceSettings.DisqualificationRaceSecsActivated = chkActivateDisqualificationRaceSecs.Checked;
            _raceSettingsService.RaceSettings.DisqualificationRaceSecsFactor = udDisqualificationRaceSecsFactor.Value;

            _raceSettingsService.RaceSettings.BufferBytesToCutFromActionSounds = tbDistanceBetweenSounds.Value;

            _raceSettingsService.RaceSettings.PointsForPosition1 = (int)udPointsForPosition1.Value;
            _raceSettingsService.RaceSettings.PointsForPosition2 = (int)udPointsForPosition2.Value;
            _raceSettingsService.RaceSettings.PointsForPosition3 = (int)udPointsForPosition3.Value;
            _raceSettingsService.RaceSettings.PointsForPosition4 = (int)udPointsForPosition4.Value;
            _raceSettingsService.RaceSettings.PointsForPosition5 = (int)udPointsForPosition5.Value;
            _raceSettingsService.RaceSettings.PointsForPosition6 = (int)udPointsForPosition6.Value;

            Language language = cbxLanguage.SelectedItem as Language;
            if (language != null)
                _raceSettingsService.RaceSettings.LanguageType = language.LanguageType;
        }

        private void RaceSettingsFormLoad(object sender, EventArgs e)
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
            FillCbxLanguage();

            txtRaceTrackName.Text = _raceSettingsService.RaceSettings.TrackName;
            txtEventName.Text = _raceSettingsService.RaceSettings.EventName;
            udLapsToDrive.Value = _raceSettingsService.RaceSettings.LapsToDrive;
            chkCountDescending.Checked = _raceSettingsService.RaceSettings.DescendingLapCount;

            chkActivateQualiTimeBased.Checked = _raceSettingsService.RaceSettings.QualificationTimeBasedActivated;
            udQualificationMinutes.Value = _raceSettingsService.RaceSettings.QualificationMinutes;
            udQualificationBreakCount.Value = _raceSettingsService.RaceSettings.QualificationBreaks;

            chkActivateQualiLapBased.Checked = _raceSettingsService.RaceSettings.QualificationLapBasedActivated;
            udQualificationMaxLaps.Value = _raceSettingsService.RaceSettings.QualificationMaxLaps;

            udSecondsForValidLap.Value = _raceSettingsService.RaceSettings.SecondsForValidLap;
            chkActivateStartCountDownRace.Checked = _raceSettingsService.RaceSettings.StartCountDownRaceActivated;
            udStartCountDownInitNoRace.Value = _raceSettingsService.RaceSettings.StartCountDownRaceInitNo;
            chkActivateRestartCountDownRace.Checked = _raceSettingsService.RaceSettings.RestartCountDownRaceActivated;
            udRestartCountDownInitNoRace.Value = _raceSettingsService.RaceSettings.RestartCountDownRaceInitNo;
            chkActivateStartCountDownQuali.Checked = _raceSettingsService.RaceSettings.StartCountDownQualiActivated;
            udStartCountDownInitNoQuali.Value = _raceSettingsService.RaceSettings.StartCountDownQualiInitNo;
            chkActivateRestartCountDownQuali.Checked = _raceSettingsService.RaceSettings.RestartCountDownQualiActivated;
            udRestartCountDownInitNoQuali.Value = _raceSettingsService.RaceSettings.RestartCountDownQualiInitNo;
            chkActivateStartCountDownTraining.Checked = _raceSettingsService.RaceSettings.StartCountDownTrainingActivated;
            udStartCountDownInitNoTraining.Value = _raceSettingsService.RaceSettings.StartCountDownTrainingInitNo;
            chkActivateRestartCountDownTraining.Checked = _raceSettingsService.RaceSettings.RestartCountDownTrainingActivated;
            udRestartCountDownInitNoTraining.Value = _raceSettingsService.RaceSettings.RestartCountDownTrainingInitNo;
            chkActivateSplittedActionSounds.Checked = _raceSettingsService.RaceSettings.SplittedActionSoundsActivated;

            chkActivateAutoDisqualificationRace.Checked = _raceSettingsService.RaceSettings.AutoDisqualificationRaceActivated;
            udAutoDisqualificationRace.Value = _raceSettingsService.RaceSettings.AutoDisqualificationRaceAfterPenalties;

            chkActivateDisqualificationLapSecs.Checked = _raceSettingsService.RaceSettings.DisqualificationLapSecsActivated;
            udDisqualificationLapSecsFactor.Value = _raceSettingsService.RaceSettings.DisqualificationLapSecsFactor;

            chkActivateDisqualificationRaceSecs.Checked = _raceSettingsService.RaceSettings.DisqualificationRaceSecsActivated;
            udDisqualificationRaceSecsFactor.Value = _raceSettingsService.RaceSettings.DisqualificationRaceSecsFactor;

            cbxLanguage.SelectedValue = _raceSettingsService.RaceSettings.LanguageType;
            tbDistanceBetweenSounds.Value = _raceSettingsService.RaceSettings.BufferBytesToCutFromActionSounds;

            udPointsForPosition1.Value = _raceSettingsService.RaceSettings.PointsForPosition1;
            udPointsForPosition2.Value = _raceSettingsService.RaceSettings.PointsForPosition2;
            udPointsForPosition3.Value = _raceSettingsService.RaceSettings.PointsForPosition3;
            udPointsForPosition4.Value = _raceSettingsService.RaceSettings.PointsForPosition4;
            udPointsForPosition5.Value = _raceSettingsService.RaceSettings.PointsForPosition5;
            udPointsForPosition6.Value = _raceSettingsService.RaceSettings.PointsForPosition6;
        }

        private void FillCbxLanguage()
        {
            cbxLanguage.DataSource = LanguageManager.Languages;
            cbxLanguage.DisplayMember = "DisplayName";
            cbxLanguage.ValueMember = "LanguageType";
        }

        private void AdjustCultureStrings()
        {
            AdjustCultureStringsOfForm();
            AdjustCultureStringsTabControl();
            AdjustCultureStringsCommon();
            AdjustCultureStringsTraining();
            AdjustCultureStringsQuali();
            AdjustCultureStringsRace();
        }

        private void AdjustCultureStringsRace()
        {
            grpRace.Text = LanguageManager.GetString("RaceSettingsFormGrpRace");
            lblLapsToDrive.Text = LanguageManager.GetString("RaceSettingsFormLblLapsToDrive");
            chkCountDescending.Text = LanguageManager.GetString("RaceSettingsFormChkCountDescending");
            grpStartCountDownRace.Text = LanguageManager.GetString("RaceSettingsFormGrpStartCountDownRace");
            chkActivateStartCountDownRace.Text = LanguageManager.GetString("RaceSettingsFormChkActivateStartCountDownRace");
            lblStartCountDownRaceSecs.Text = LanguageManager.GetString("RaceSettingsFormLblStartCountDownRaceSecs");
            grpRestartCountDownRace.Text = LanguageManager.GetString("RaceSettingsFormGrpRestartCountDownRace");
            lblRestartCountDownRaceSecs.Text = LanguageManager.GetString("RaceSettingsFormLblRestartCountDownRaceSecs");
            chkActivateRestartCountDownRace.Text = LanguageManager.GetString("RaceSettingsFormChkActivateRestartCountDownRace");
            grpAutoDisqualificationRace.Text = LanguageManager.GetString("RaceSettingsFormGrpAutoDisqualificationRace");
            chkActivateAutoDisqualificationRace.Text = LanguageManager.GetString("RaceSettingsFormChkActivateAutoDisqualificationRace");
            lblAutoDisqualificationRace.Text = LanguageManager.GetString("RaceSettingsFormLblAutoDisqualificationRace");
        }

        private void AdjustCultureStringsQuali()
        {
            grpQualifying.Text = LanguageManager.GetString("RaceSettingsFormGrpQualifying");
            lblQualiMinutes.Text = LanguageManager.GetString("RaceSettingsFormLblQualiMinutes");
            lblQualiBreaks.Text = LanguageManager.GetString("RaceSettingsFormLblQualiBreaks");
            grpStartCountDownQuali.Text = LanguageManager.GetString("RaceSettingsFormGrpStartCountDownQuali");
            chkActivateStartCountDownQuali.Text = LanguageManager.GetString("RaceSettingsFormChkActivateStartCountDownQuali");
            lblStartCountDownQualiSecs.Text = LanguageManager.GetString("RaceSettingsFormLblStartCountDownQualiSecs");
            grpRestartCountDownQuali.Text = LanguageManager.GetString("RaceSettingsFormGrpRestartCountDownQuali");
            chkActivateRestartCountDownQuali.Text = LanguageManager.GetString("RaceSettingsFormChkActivateRestartCountDownQuali");
            lblRestartCountDownQualiSecs.Text = LanguageManager.GetString("RaceSettingsFormLblRestartCountDownQualiSecs");
        }

        private void AdjustCultureStringsTraining()
        {
            grpStartCountDownTraining.Text = LanguageManager.GetString("RaceSettingsFormGrpStartCountDownTraining");
            chkActivateStartCountDownTraining.Text = LanguageManager.GetString("RaceSettingsFormChkActivateStartCountDownTraining");
            lblStartCountDownTrainingSecs.Text = LanguageManager.GetString("RaceSettingsFormLblStartCountDownTrainingSecs");
            grpRestartCountDownTraining.Text = LanguageManager.GetString("RaceSettingsFormGrpRestartCountDownTraining");
            chkActivateRestartCountDownTraining.Text = LanguageManager.GetString("RaceSettingsFormChkActivateRestartCountDownTraining");
            lblRestartCountDownTrainingSecs.Text = LanguageManager.GetString("RaceSettingsFormLblRestartCountDownTrainingSecs");
        }

        private void AdjustCultureStringsCommon()
        {
            grpActivateSplittedActionSounds.Text = LanguageManager.GetString("RaceSettingsFormGrpActivateSplittedActionSounds");
            chkActivateSplittedActionSounds.Text = LanguageManager.GetString("RaceSettingsFormChkActivateSplittedActionSounds");
            grpMinLapTime.Text = LanguageManager.GetString("RaceSettingsFormGrpMinLapTime");
            lblMinLapTimeSecs.Text = LanguageManager.GetString("RaceSettingsFormLblMinLapTimeSecs");
            grpLanguage.Text = LanguageManager.GetString("RaceSettingsFormGrpLanguage");
            grpDistanceBetweenSounds.Text = LanguageManager.GetString("RaceSettingsFormGrpDistanceBetweenSounds");
        }

        private void AdjustCultureStringsTabControl()
        {
            tabPageCommon.Text = LanguageManager.GetString("RaceSettingsFormTabPageCommon");
            tabPageQuali.Text = LanguageManager.GetString("RaceSettingsFormTabPageQuali");
            tabPageRace.Text = LanguageManager.GetString("RaceSettingsFormTabPageRace");
            tabPageTraining.Text = LanguageManager.GetString("RaceSettingsFormTabPageTraining");
        }

        private void AdjustCultureStringsOfForm()
        {
            Text = LanguageManager.GetString("RaceSettingsFormCaption");
            btnOK.Text = LanguageManager.GetString("RaceSettingsFormBtnOk");
            btnCancel.Text = LanguageManager.GetString("RaceSettingsFormBtnCancel");
        }

        private void BtnSetDateAsEventNameClick(object sender, EventArgs e)
        {
            try
            {
                txtEventName.Text = DateTime.Today.ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void UdLapsToDriveValueChanged(object sender, EventArgs e)
        {
            CalcDisqualificationRaceSecs();
        }

        private void CalcDisqualificationRaceSecs()
        {
            var secs = udLapsToDrive.Value*udSecondsForValidLap.Value*udDisqualificationRaceSecsFactor.Value;

            lblDisqualificationRaceSecsCalced.Text = ((int)secs).ToString();
        }

        private void CalcDisqualificationLapSecs()
        {
            var secs = udSecondsForValidLap.Value * udDisqualificationLapSecsFactor.Value;

            lblDisqualificationLapSecsCalced.Text = ((int)secs).ToString();
        }

        private void UdDisqualificationLapSecsFactorValueChanged(object sender, EventArgs e)
        {
            CalcDisqualificationLapSecs();
        }

        private void UdDisqualificationRaceSecsFactorValueChanged(object sender, EventArgs e)
        {
            CalcDisqualificationRaceSecs();
        }

        private void UdSecondsForValidLapValueChanged(object sender, EventArgs e)
        {
            CalcDisqualificationLapSecs();
            CalcDisqualificationRaceSecs();
        }
    }
}