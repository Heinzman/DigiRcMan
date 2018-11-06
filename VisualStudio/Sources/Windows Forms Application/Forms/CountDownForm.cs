using System;
using System.Drawing;
using System.Windows.Forms;
using Elreg.DomainModels.RaceModel;
using Elreg.Log;
using Elreg.RaceControlService;
using Elreg.WindowsFormsPresenter;
using Elreg.WindowsFormsView;
using Elreg.WinFormsPresentationFramework;
using Form = Elreg.Controls.Forms.Form;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class CountDownForm : Form, ICountDownView
    {
        private readonly RaceKeyController _raceKeyController;
        private readonly CountDownPresenter _startingPresenter;

        public CountDownForm(RaceKeyController raceKeyController, RaceModel raceModel)
        {
            InitializeComponent();
            _startingPresenter = new CountDownPresenter(this, raceModel);
            _raceKeyController = raceKeyController;
        }

        #region ICountDownView Members

        public string CountDownText
        {
            set
            {
                SetControlPropertyThreadSafe(lblCount, "Text", value);
                SetControlPropertyThreadSafe(lblCount2, "Text", value);
                BeginInvoke(new VoidHandler(Refresh));
            }
        }

        public Font CountDownFont
        {
            get { return lblCount.Font; }
            set
            {
                SetControlPropertyThreadSafe(lblCount, "Font", value);
                SetControlPropertyThreadSafe(lblCount2, "Font", value);
            }
        }

        public System.Windows.Forms.Form Form
        {
            get { return this; }
        }

        #endregion

        private void StartingFormLoad(object sender, EventArgs e)
        {
            try
            {
                _startingPresenter.InitAfterLoad();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        protected override void LoadSettings()
        {
        }

        protected override void SaveSettings()
        {
        }

        protected override string RegkeyPath
        {
            get { return Constants.RegkeyPath; }
        }

        private void CountDownFormKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                _raceKeyController.HandleKey(e);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CountDownFormFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason != CloseReason.ApplicationExitCall)
                {
                    e.Cancel = true;
                    Visible = false;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

    }
}