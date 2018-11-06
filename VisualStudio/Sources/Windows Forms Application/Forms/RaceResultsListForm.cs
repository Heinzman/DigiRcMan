using System;
using System.Windows.Forms;
using Elreg.Log;
using Elreg.WindowsFormsPresenter;
using Elreg.WindowsFormsView;
using Form = Elreg.WinFormsPresentationFramework.Forms.Form;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class RaceResultsListForm : WinFormsPresentationFramework.Forms.Form, IRaceResultsListView
    {
        private readonly RaceResultsListPresenter _raceRaceResultsListPresenter;

        public RaceResultsListForm(IRaceControlView raceControlView)
        {
            InitializeComponent();
            TopMost = true;
            _raceRaceResultsListPresenter = new RaceResultsListPresenter(this, raceControlView);
        }

        #region IRaceResultsListView Members

        public ListBox ListBoxRaceResults
        {
            get { return listBox1; }
        }

        public Button BtnRefresh
        {
            get { return btnRefresh; }
        }

        public Button BtnClose
        {
            get { return btnClose; }
        }

        public override void InvokeShowAndFocus()
        {
            _raceRaceResultsListPresenter.AdjustCultureStrings();
            _raceRaceResultsListPresenter.FillData();
            base.InvokeShowAndFocus();
        }

        #endregion

        private void ListBox1SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _raceRaceResultsListPresenter.ShowSelectedRaceResult();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnCloseClick(object sender, EventArgs e)
        {
            try
            {
                SaveSettings();
                Hide();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnRefreshClick(object sender, EventArgs e)
        {
            try
            {
                _raceRaceResultsListPresenter.FillData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceResultsListFormActivated(object sender, EventArgs e)
        {
            try
            {
                _raceRaceResultsListPresenter.SetFormToFullOpacity();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceResultsListFormDeactivate(object sender, EventArgs e)
        {
            try
            {
                _raceRaceResultsListPresenter.SetFormToHalfOpacity();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }
    }
}