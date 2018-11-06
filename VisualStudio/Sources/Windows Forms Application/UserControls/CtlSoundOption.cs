using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.Sound;
using Elreg.DomainModels;
using Elreg.HelperClasses;
using Elreg.Log;
using Elreg.RaceOptionsService;
using Elreg.RaceSoundService;
using Elreg.ResourcesService;
using Elreg.WindowsFormsApplication.Forms;
using Elreg.WindowsFormsApplication.Properties;
using Elreg.WindowsFormsPresenter;
using Elreg.WindowsFormsView;
using Elreg.WinFormsPresentationFramework;

namespace Elreg.WindowsFormsApplication.UserControls
{
    public partial class CtlSoundOption : UserControl, ISoundOptionView
    {
        private readonly List<KeyValuePair<int, string>> _specialSounds = new List<KeyValuePair<int, string>>();
        private SoundSettings _settings = new SoundSettings();
        private string _soundFileName;
        private SoundOptionPresenter _soundOptionPresenter;
        private string _fileOpenFilter = @"Sound File|*.wav|All Files|*.*";

        public CtlSoundOption()
        {
            InitializeComponent();
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
            chkActivate.Text = LanguageManager.GetString("CtlSoundOptionChkActivate");
            chkChangeFrequency.Text = LanguageManager.GetString("CtlSoundOptionChkChangeFrequency");
            ColumnSpecialSound.HeaderText = LanguageManager.GetString("CtlSoundOptionColumnSpecialSound");
            ColumnFileName.HeaderText = LanguageManager.GetString("CtlSoundOptionColumnFileName");
            ColumnFileFind.HeaderText = LanguageManager.GetString("CtlSoundOptionColumnFileFind");
            ColumnCreateWav.HeaderText = LanguageManager.GetString("CtlSoundOptionColumnCreateWav");
            ColumnPlayWav.HeaderText = LanguageManager.GetString("CtlSoundOptionColumnPlayWav");
            _fileOpenFilter = LanguageManager.GetString("CtlSoundOptionFileOpenFilter");
            toolStripButtonPlaysounds.Text = LanguageManager.GetString("CtlSoundOptionToolStripButtonPlaySounds");
            ColumnFileFind.Text = LanguageManager.GetString("CtlSoundOptionColumnFileFindButton");
            ColumnCreateWav.Text = LanguageManager.GetString("CtlSoundOptionColumnCreateWavButton");
            ColumnPlayWav.Text = LanguageManager.GetString("CtlSoundOptionColumnPlayWavButton");
        }

        public string Caption
        {
            get { return toolStripLabelCaption.Text; }
            set { toolStripLabelCaption.Text = value; }
        }

        public void Init(SoundOptionList soundOptionList, SoundSettings settings, ActionSoundsService actionSoundsService, 
            DriversService driversService, RaceSettings raceSettings)
        {
            _settings = settings;
            _soundOptionPresenter = new SoundOptionPresenter(this, actionSoundsService, driversService, raceSettings);
            dataGridView1.AutoGenerateColumns = false;
            bindingSource1.DataSource = soundOptionList.SoundOptions;
            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
            chkActivate.DataBindings.Clear();
            chkActivate.DataBindings.Add("Checked", soundOptionList, "Activated");
            chkChangeFrequency.DataBindings.Clear();
            chkChangeFrequency.DataBindings.Add("Checked", soundOptionList, "VaryFrequency");
        }

        public BindingSource BindingSource
        {
            get { return bindingSource1; }
        }

        public CheckBox ChkChangeFrequency
        {
            get { return chkChangeFrequency; }
        }

        private void FillColumnSpecialSounds()
        {
            CreateListSpecialSounds();
            bindingSourceSpecialSound.DataSource = _specialSounds;
            ColumnSpecialSound.DataSource = bindingSourceSpecialSound;
            ColumnSpecialSound.DisplayMember = "Value";
            ColumnSpecialSound.ValueMember = "Key";
        }

        private void CreateListSpecialSounds()
        {
            foreach (Specialsound specialsound in Enum.GetValues(typeof (Specialsound)))
                if (specialsound != Specialsound.None)
                    AddSpecialSoundToList(specialsound);

            _specialSounds.Sort((k1, k2) => String.CompareOrdinal(k1.Value, k2.Value));

            const Specialsound specialSound = Specialsound.None;
            string displayName = TextToSpeechCreatorModel.GetCultureSpecialSoundName(specialSound.ToString());
            _specialSounds.Insert(0, new KeyValuePair<int, string>((int)specialSound, displayName));
        }

        private void AddSpecialSoundToList(Specialsound specialSound)
        {
            string displayName = TextToSpeechCreatorModel.GetCultureSpecialSoundName(specialSound.ToString());
            _specialSounds.Add(new KeyValuePair<int, string>((int)specialSound, displayName));
        }

        private void DataGridView1CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (IsAFileFindButton(e))
                {
                    if (GetSoundFileName())
                        dataGridView1[ColumnFileName.Index, e.RowIndex].Value = _soundFileName;
                }
                else if (IsACreateWavButton(e))
                {
                    if (GetCreatedWavFileName())
                        if (dataGridView1[ColumnFileName.Index, e.RowIndex].Value == null)
                            dataGridView1[ColumnFileName.Index, e.RowIndex].Value = _soundFileName;
                }
                else if (IsAPlayWavButton(e))
                    _soundOptionPresenter.PlaySoundOfCurrentRow();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private bool GetCreatedWavFileName()
        {
            bool ret = false;
            var ttsSaveToFileForm = new TtsSaveToFileForm(AbsoluteSoundsPath);
            ttsSaveToFileForm.ShowDialog();

            if (!string.IsNullOrEmpty(ttsSaveToFileForm.FileName))
            {
                _soundFileName = SystemHelper.GetRelativeSubPath(ttsSaveToFileForm.FileName);
                ret = true;
            }
            return ret;
        }

        private string AbsoluteSoundsPath
        {
            get { return ServiceHelper.GetAbsolutePath(_settings.RelSoundsFolder); }
        }

        private bool IsAFileFindButton(DataGridViewCellEventArgs e)
        {
            return e.ColumnIndex == ColumnFileFind.Index && e.RowIndex >= 0;
        }

        private bool IsACreateWavButton(DataGridViewCellEventArgs e)
        {
            return e.ColumnIndex == ColumnCreateWav.Index && e.RowIndex >= 0;
        }

        private bool IsAPlayWavButton(DataGridViewCellEventArgs e)
        {
            return e.ColumnIndex == ColumnPlayWav.Index && e.RowIndex >= 0;
        }

        private bool GetSoundFileName()
        {
            bool ret = false;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = _fileOpenFilter;
            openFileDialog1.InitialDirectory = AbsoluteSoundsPath;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileInfo = new FileInfo(openFileDialog1.FileName);
                _settings.RelSoundsFolder = SystemHelper.GetRelativeSubPath(fileInfo.DirectoryName);
                _soundFileName = SystemHelper.GetRelativeSubPath(openFileDialog1.FileName);
                ret = true;
            }
            return ret;
        }

        private void ChkActivateCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool enabled = chkActivate.Checked;

                if (enabled)
                    bindingNavigator1.BackgroundImage = Resources.glossymetal_green;
                else
                    bindingNavigator1.BackgroundImage = Resources.glossymetal;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ToolStripButtonPlaysoundsClick(object sender, EventArgs e)
        {
            try
            {
                _soundOptionPresenter.PlayAllSounds();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CtlSoundOptionLoad(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                FillColumnSpecialSounds();
                GuiHelper.SetColoredImageForCheckboxes(Controls);
                LanguageManager.LanguageChanged += LanguageManagerLanguageChanged;
                AdjustCultureStrings();
            }
        }

    }
}