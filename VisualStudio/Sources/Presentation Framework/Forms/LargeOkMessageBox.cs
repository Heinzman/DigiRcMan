using System;
using Elreg.Log;
using Elreg.ResourcesService;

namespace Elreg.WinFormsPresentationFramework.Forms
{
    public partial class LargeOkMessageBox : System.Windows.Forms.Form
    {
        public LargeOkMessageBox()
        {
            InitializeComponent();
            TopMost = true;
            Form.SetCursor(this);
            AdjustCultureStrings();
        }

        public void ShowDialog(string text)
        {
            Text = text;
            ShowDialog();
        }

        private new string Text
        {
            set { label1.Text = value; }
        }

        public string RegKey { get { return string.Empty; } }

        public void ShowAndFocus()
        {
            Show();
            Focus();
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            try
            {
                Hide();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AdjustCultureStrings()
        {
            btnOk.Text = LanguageManager.GetString("LargeOkMessageBoxBtnOk");
        }

    }
}