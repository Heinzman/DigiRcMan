using System;
using System.Windows.Forms;
using Elreg.BusinessObjects.Options;
using Elreg.Log;
using Elreg.RaceOptionsService;
using Elreg.RaceSoundService;
using Elreg.WindowsFormsPresenter;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class MaintainDriversForm : WinFormsPresentationFramework.Forms.Form, IMaintainDriversView
    {
        private readonly MaintainDriversPresenter _maintainDriversPresenter;

        public MaintainDriversForm(DriversService driversService, ActionSoundsService actionSoundsService, RaceSettings raceSettings)
        {
            InitializeComponent();
            _maintainDriversPresenter = new MaintainDriversPresenter(this, driversService, actionSoundsService, raceSettings);
            InitControls();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            try
            {
                _maintainDriversPresenter.HandleCancel();
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
                _maintainDriversPresenter.HandleOk();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void MaintainDriversFormLoad(object sender, EventArgs e)
        {
            try
            {
                _maintainDriversPresenter.FillData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnOpenFileWavNameClick(object sender, EventArgs e)
        {
            try
            {
                _maintainDriversPresenter.OpenFileWavName();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnOpenHymnFilenameClick(object sender, EventArgs e)
        {
            try
            {
                _maintainDriversPresenter.OpenHymnFilename();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public TextBox TxtHymnFilename
        {
            get { return txtHymnFilename; }
        }

        public TextBox TxtWavName
        {
            get { return txtWavName; }
        }

        public ISoundOptionView CtlLap
        {
            get { return ctlLap; }
        }

        public TextBox TxtName
        {
            get { return txtName; }
        }

        public CheckBox ChkActivated
        {
            get { return chkActivated; }
        }

        public BindingNavigator BindingNavigatorDrivers
        {
            get { return bindingNavigatorDrivers; }
        }

        public DataGridView GrdDrivers
        {
            get { return grdDrivers; }
        }

        public GroupBox GrpDrivers
        {
            get { return grpDrivers; }
        }

        public GroupBox GrpDetails
        {
            get { return grpDetails; }
        }

        public DataGridViewColumn GridColumnName
        {
            get { return ColumnName; }
        }

        public Label LblName
        {
            get { return lblName; }
        }

        public Label LblWavName
        {
            get { return lblWavName; }
        }

        public Button BtnCreateWav
        {
            get { return btnCreateWav; }
        }

        public Button BtnOk
        {
            get { return btnOK; }
        }

        public Button BtnCancel
        {
            get { return btnCancel; }
        }

        public Label LblHymn
        {
            get { return lblHymn; }
        }

        private void BtnCreateWavClick(object sender, EventArgs e)
        {
            try
            {
                string wavDirectory = _maintainDriversPresenter.WavDirectory;
                string driverName = TxtName.Text;
                var ttsSaveToFileForm = new TtsSaveToFileForm(wavDirectory, driverName);
                ttsSaveToFileForm.ShowDialog();

                _maintainDriversPresenter.HandleCreatedWavFileByTts(ttsSaveToFileForm.FileName);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void GrdDriversDefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                _maintainDriversPresenter.SetDefaultValues(e);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            try
            {
                _maintainDriversPresenter.AddNewDriver();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

    }
}