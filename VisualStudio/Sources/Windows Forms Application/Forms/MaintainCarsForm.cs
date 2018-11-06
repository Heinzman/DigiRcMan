using System;
using System.Windows.Forms;
using Elreg.Log;
using Elreg.RaceOptionsService;
using Elreg.WindowsFormsPresenter;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class MaintainCarsForm : WinFormsPresentationFramework.Forms.Form, IMaintainCarsView
    {
        private readonly MaintainCarsPresenter _maintainCarsPresenter;

        public MaintainCarsForm(CarsService carsService)
        {
            InitializeComponent();
            _maintainCarsPresenter = new MaintainCarsPresenter(this, carsService);
            InitControls();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            try
            {
                _maintainCarsPresenter.HandleCancel();
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
                _maintainCarsPresenter.HandleOk();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnAcceptClick(object sender, EventArgs e)
        {
            try
            {
                _maintainCarsPresenter.HandleAccept();
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
                _maintainCarsPresenter.FillData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnOpenFilePictureClick(object sender, EventArgs e)
        {
            try
            {
                _maintainCarsPresenter.OpenFilePicture();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public TextBox TxtName
        {
            get { return txtName; }
        }

        public TextBox TxtPicture
        {
            get { return txtPicture; }
        }

        public PictureBox PictureBox
        {
            get { return pictureBox1; }
        }

        public DataGridView GrdCars
        {
            get { return grdCars; }
        }

        public BindingNavigator BindingNavigatorCars
        {
            get { return bindingNavigatorCars; }
        }

        public GroupBox GrpCars
        {
            get { return grpCars; }
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

        public Label LblPicture
        {
            get { return lblPicture; }
        }

        public Button BtnAccept
        {
            get { return btnAccept; }
        }

        public Button BtnOk
        {
            get { return btnOK; }
        }

        public Button BtnCancel
        {
            get { return btnCancel; }
        }

        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            try
            {
                _maintainCarsPresenter.AddNewCar();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void GrdCarsDefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                _maintainCarsPresenter.SetDefaultValues(e);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }
    }
}