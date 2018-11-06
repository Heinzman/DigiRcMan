using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.HelperClasses;
using Elreg.Log;
using Elreg.RaceOptionsService;
using Elreg.ResourcesService;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsPresenter
{
    public class MaintainCarsPresenter
    {
        private readonly CarsService _carsService;
        private readonly Settings _settings = new Settings();
        private readonly IMaintainCarsView _maintainCarsView;
        private readonly BindingSource _bindingSource = new BindingSource();
        private readonly OpenFileDialog _openFileDialog = new OpenFileDialog();

        public MaintainCarsPresenter(IMaintainCarsView maintainCarsView, CarsService carsService)
        {
            try
            {
                _maintainCarsView = maintainCarsView;
                _carsService = carsService;
                AdjustCultureStrings();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void HandleCancel()
        {
            try
            {
                _carsService.Reset();
                _maintainCarsView.Close();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void HandleOk()
        {
            try
            {
                SaveAndRaiseEvent();
                _maintainCarsView.Close();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void HandleAccept()
        {
            try
            {
                SaveAndRaiseEvent();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void AddNewCar()
        {
            try
            {
                Car car = new Car { Id = _carsService.GetNextId() };
                _bindingSource.Add(car);
                _bindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void SetDefaultValues(DataGridViewRowEventArgs e)
        {
            try
            {
                e.Row.Cells["ColumnId"].Value = _carsService.GetNextId();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void FillData()
        {
            try
            {
                LoadSettings();
                BindData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void OpenFilePicture()
        {
            try
            {
                _openFileDialog.FileName = "";
                _openFileDialog.Filter = @"All Files|*.*|Bitmap Image|*.bmp|Jpeg Image|*.jpg";
                _openFileDialog.InitialDirectory = AbsolutePicturePath;

                if (_openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _maintainCarsView.TxtPicture.Text = SystemHelper.GetRelativeSubPath(_openFileDialog.FileName);
                    _maintainCarsView.TxtPicture.Focus();
                    _maintainCarsView.PictureBox.Image = null;
                    _maintainCarsView.PictureBox.Image = Image.FromFile(_openFileDialog.FileName);
                    var fileInfo = new FileInfo(_openFileDialog.FileName);
                    _settings.PictureFolder = SystemHelper.GetRelativeSubPath(fileInfo.DirectoryName);
                    SaveSettings();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SaveAndRaiseEvent()
        {
            SaveData();
            RaiseEventsDataChanged();
        }

        private void RaiseEventsDataChanged()
        {
            foreach (Car car in _carsService.Cars)
                car.RaiseEventDataChanged();
        }

        private void SaveData()
        {
            _carsService.Save();
            SaveSettings();
        }

        private void BindData()
        {
            _bindingSource.DataSource = _carsService.Cars;
            CreateDataBindings();
        }

        private string AbsolutePicturePath
        {
            get { return ServiceHelper.GetAbsolutePath(_settings.PictureFolder); }
        }

        private void CreateDataBindings()
        {
            _maintainCarsView.GrdCars.AutoGenerateColumns = false;
            _maintainCarsView.GrdCars.DataSource = _bindingSource;
            _maintainCarsView.BindingNavigatorCars.BindingSource = _bindingSource;
            _maintainCarsView.TxtName.DataBindings.Add("Text", _bindingSource, "Name");
            _maintainCarsView.TxtPicture.DataBindings.Add("Text", _bindingSource, "PictureFilename");
            _maintainCarsView.PictureBox.DataBindings.Add("Image", _bindingSource, "Image", true);
        }

        private void LoadSettings()
        {
            try
            {
                Savior.Read(_settings, _maintainCarsView.RegKey);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SaveSettings()
        {
            try
            {
                Savior.Save(_settings, _maintainCarsView.RegKey);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AdjustCultureStrings()
        {
            _maintainCarsView.Text = LanguageManager.GetString("MaintainCarsFormCaption");
            _maintainCarsView.GrpCars.Text = LanguageManager.GetString("MaintainCarsFormGrpCars");
            _maintainCarsView.GrpDetails.Text = LanguageManager.GetString("MaintainCarsFormGrpDetails");
            _maintainCarsView.GridColumnName.HeaderText = LanguageManager.GetString("MaintainCarsFormGridColumnName");
            _maintainCarsView.LblName.Text = LanguageManager.GetString("MaintainCarsFormLblName");
            _maintainCarsView.LblPicture.Text = LanguageManager.GetString("MaintainCarsFormLblPicture");
            _maintainCarsView.BtnAccept.Text = LanguageManager.GetString("MaintainCarsFormBtnAccept");
            _maintainCarsView.BtnOk.Text = LanguageManager.GetString("MaintainCarsFormBtnOK");
            _maintainCarsView.BtnCancel.Text = LanguageManager.GetString("MaintainCarsFormBtnCancel");
        }

        private class Settings
        {
            public Settings()
            {
                PictureFolder = ServiceHelper.RelPicsPath;
            }

            public string PictureFolder { get; set; }
        }

    }
}