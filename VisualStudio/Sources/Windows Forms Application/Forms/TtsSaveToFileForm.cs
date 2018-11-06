using System;
using System.Windows.Forms;
using Elreg.ComputerSpeech;
using Elreg.Log;
using Elreg.ResourcesService;
using Elreg.WinFormsPresentationFramework;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class TtsSaveToFileForm : Controls.Forms.Form
    {
        private readonly string _initialDirectory;
        private readonly string _driverName;
        private string _fileName;
        private string _fileSaveFilter = @"Sound File|*.wav|All Files|*.*";

        public TtsSaveToFileForm(string initialDirectory, string driverName = null)
        {
            _initialDirectory = initialDirectory;
            _driverName = driverName;
            InitializeComponent();
            AdjustCultureStrings();
        }

        public string FileName
        {
            get { return _fileName; }
        }

        private string TextToSpeak
        {
            get { return txtTextToSpeak.Text; }
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

        private void BtnSpeakClick(object sender, EventArgs e)
        {
            try
            {
                var speaker = new Speaker(TextToSpeak);
                speaker.Speak();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnSaveAsWavClick(object sender, EventArgs e)
        {
            try
            {
                if (DetermineFileName())
                {
                    var speaker = new Speaker(TextToSpeak);
                    speaker.SaveTo(FileName);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private bool DetermineFileName()
        {
            _fileName = string.Empty;
            bool ret = false;
            saveFileDialog1.FileName = TextToSpeak + ".wav";
            saveFileDialog1.Filter = _fileSaveFilter;
            saveFileDialog1.InitialDirectory = _initialDirectory;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _fileName = saveFileDialog1.FileName;
                ret = true;
            }
            return ret;
        }

        private void TtsSaveToFileFormLoad(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(_driverName))
                    txtTextToSpeak.Text = _driverName;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AdjustCultureStrings()
        {
            Text = LanguageManager.GetString("TtsSaveToFileFormCaption");
            btnSpeak.Text = LanguageManager.GetString("TtsSaveToFileFormBtnSpeak");
            btnSaveAsWav.Text = LanguageManager.GetString("TtsSaveToFileFormBtnSaveAsWav");
            btnClose.Text = LanguageManager.GetString("TtsSaveToFileFormBtnClose");
            _fileSaveFilter = LanguageManager.GetString("TtsSaveToFileFormFileSaveFilter");
        }

        protected override string RegkeyPath
        {
            get { return Constants.RegkeyPath; }
        }

    }
}