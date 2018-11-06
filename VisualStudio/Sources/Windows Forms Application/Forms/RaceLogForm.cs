using System;
using System.Windows.Forms;
using Elreg.DomainModels.RaceModel;
using Elreg.Log;
using Elreg.WindowsFormsView;
using Elreg.WindowsFormsPresenter;
using Elreg.RaceControlService;
using Elreg.WinFormsPresentationFramework;
using Form = Elreg.Controls.Forms.Form;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class RaceLogForm : Form, IRaceLogView
    {
        private readonly RaceLogPresenter _raceLogPresenter;
        private string _race;
        private readonly RaceKeyController _raceKeyController;

        private delegate void UpdateDisplayHandler();

        public RaceLogForm(RaceKeyController raceKeyController, RaceModel raceModel)
        {
            InitializeComponent();
            _raceKeyController = raceKeyController;
            _raceLogPresenter = new RaceLogPresenter(this, raceModel);
        }

        public void DisplayRace(string race)
        {
            _race = race;
            BeginInvoke(new UpdateDisplayHandler(UpdateDisplay));
        }

        protected override string RegkeyPath
        {
            get { return Constants.RegkeyPath; }
        }

        private void UpdateDisplay()
        {
            try
            {
                txtConsole.Clear();
                txtConsole.Text = _race;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceLogFormFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _raceLogPresenter.Detach();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceLogFormKeyDown(object sender, KeyEventArgs e)
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

    }
}
