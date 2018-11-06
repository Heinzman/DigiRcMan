using System;
using System.Windows.Forms;
using Elreg.Log;
using Elreg.ResourcesService;

namespace Elreg.WinFormsPresentationFramework.Forms
{
    public partial class LargeMessageBox : System.Windows.Forms.Form
    {
        private readonly string _text;
        private readonly IWin32Window _ownerWindow;

        public LargeMessageBox(string text)
        {
            _text = text;
            InitializeComponent();
            TopMost = true;
            Form.SetCursor(this);
            Load += LargeMessageBoxLoad;
            AdjustCultureStrings();
        }

        public LargeMessageBox(string text, IWin32Window ownerWindow) : this(text)
        {
            _ownerWindow = ownerWindow;
        }

        private new string Text
        {
            set { label1.Text = value; }
        }

        public new DialogResult DialogResult { get; private set; }

        public string RegKey { get { return string.Empty; } }

        public void ShowAndFocus()
        {
            BeginInvoke(new Controls.Forms.Form.ShowOwnerHandler(Show), _ownerWindow);
            Focus();
        }

        private void BtnNoClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.No;
                Hide();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnYesClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Yes;
                Hide();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void LargeMessageBoxLoad(object sender, EventArgs e)
        {
            try
            {
                Text = _text;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AdjustCultureStrings()
        {
            btnYes.Text = LanguageManager.GetString("LargeMessageBoxBtnYes");
            btnNo.Text = LanguageManager.GetString("LargeMessageBoxBtnNo");
        }

    }
}