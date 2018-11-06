using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;
using Elreg.DomainModels;
using Elreg.Log;
using Elreg.RaceOptionsService;
using Elreg.ResourcesService;
using Elreg.WindowsFormsView;
using Elreg.WinFormsPresentationFramework.Forms;

namespace Elreg.WindowsFormsPresenter.InitUpdateLanes
{
    public class InitLanesPresenter : GridPresenter
    {
        private const string MsgNoLanes = "Es sind keine Fahrer ausgewählt.";
        private const string MsgMandDataMissed = "Es fehlen Pflichtdaten.";
        private const string InitalLanesFile = "InitialLanes.Xml";
        private readonly List<Car> _cars = new List<Car>();
        private readonly CarsService _carsService;
        private readonly List<Driver> _drivers = new List<Driver>();
        private readonly DriversService _driversService;
        private readonly GridLaneInitHelper _gridLaneHelper;
        private readonly IInitLanesView _initLanesView;
        private readonly SerializerService<List<InitialLane>> _serializerService;
        private List<InitialLane> _initialLanes = new List<InitialLane>();
        private List<InitialLane> _initialLanesToSave = new List<InitialLane>();

        public InitLanesPresenter(IInitLanesView initLanesView, DriversService driversService, CarsService carsService)
            : base(initLanesView)
        {
            _initLanesView = initLanesView;
            _driversService = driversService;
            _carsService = carsService;
            GridHandler = new GridHandler(_initLanesView.GrdLanes);
            _gridLaneHelper = new GridLaneInitHelper(_initLanesView.GrdLanes, driversService, carsService);
            _serializerService = new SerializerService<List<InitialLane>>(ServiceHelper.ConfigPath, InitalLanesFile);

            _initLanesView.GrdLanes.CellValueChanged += GrdLanesCellValueChanged;
            _initLanesView.GrdLanes.CurrentCellDirtyStateChanged += GrdLanesCurrentCellDirtyStateChanged;
        }

        private void GrdLanesCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (_initLanesView.GrdLanes.IsCurrentCellDirty)
                _initLanesView.GrdLanes.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void GrdLanesCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == _initLanesView.GrdLanes.Columns[_gridLaneHelper.ColumnCar.Name].Index && e.RowIndex >= 0)
            {
                InitialLane initialLane = _gridLaneHelper.GetInitialLane(e.RowIndex);
                _initLanesView.GrdLanes[_gridLaneHelper.ColumnCarPicture.Name, e.RowIndex].Value = initialLane.Car.Image;
            }
        }

        public List<InitialLane> InitialLanes
        {
            get
            {
                ObtainInitialLanes();
                return _initialLanes;
            }
        }

        protected override string DefaultXmlFileName
        {
            get
            {
                const string fileName = "View_InitialLanes.xml";
                return ServiceHelper.ConfigViewPath + fileName;
            }
        }

        public void FillView()
        {
            SetDriverDataSource();
            SetCarDataSource();
            FillGrid();
        }

        public bool Validate()
        {
            bool ret = false;
            ObtainInitialLanes();
            if (_initialLanes.Count == 0)
                ShowMessage(MsgNoLanes);
            else if (AreMandantoryFieldsMissing())
                ShowMessage(MsgMandDataMissed);
            else
                ret = true;
            return ret;
        }

        public void HandleCellValueChanged(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == _gridLaneHelper.ColumnDriver.Index || e.ColumnIndex == _gridLaneHelper.ColumnCar.Index))
                _gridLaneHelper.UpdateDependentValues(e.RowIndex);
        }

        public void SaveData()
        {
            ObtainInitialLanesToSave();
            _serializerService.Save(_initialLanesToSave);
        }

        public void UpdateAllDependentValues()
        {
            _gridLaneHelper.UpdateAllDependentValues();
        }

        public void RandomizeLanes()
        {
            _gridLaneHelper.RandomizeLanes();
        }

        public void RotateDownLanes()
        {
            _gridLaneHelper.RotateDownLanes();
        }

        public void RotateUpLanes()
        {
            _gridLaneHelper.RotateUpLanes();
        }

        public void AdjustCultureStrings()
        {
            _initLanesView.BtnRefresh.Text = LanguageManager.GetString("InitLanesFormBtnRefresh");
            _initLanesView.BtnRotateUp.Text = LanguageManager.GetString("InitLanesFormBtnRotateUp");
            _initLanesView.BtnRotateDown.Text = LanguageManager.GetString("InitLanesFormBtnRotateDown");
            _initLanesView.BtnRandomize.Text = LanguageManager.GetString("InitLanesFormBtnRandomize");
            _initLanesView.BtnOk.Text = LanguageManager.GetString("InitLanesFormBtnOk");
            _initLanesView.BtnCancel.Text = LanguageManager.GetString("InitLanesFormBtnCancel");
            _initLanesView.GridColumnId.HeaderText = LanguageManager.GetString("InitLanesFormColumnId");
            _initLanesView.GridColumnDriver.HeaderText = LanguageManager.GetString("InitLanesFormColumnDriver");
            _initLanesView.GridColumnCar.HeaderText = LanguageManager.GetString("InitLanesFormColumnCar");
            _initLanesView.ToolStripMenuItemLargerFont.Text = LanguageManager.GetString("ToolStripMenuItemLargerFont");
            _initLanesView.ToolStripMenuItemSmallerFont.Text = LanguageManager.GetString("ToolStripMenuItemSmallerFont");
            _initLanesView.ToolStripMenuItemLargerHeaderFont.Text = LanguageManager.GetString("ToolStripMenuItemLargerHeaderFont");
            _initLanesView.ToolStripMenuItemSmallerHeaderFont.Text = LanguageManager.GetString("ToolStripMenuItemSmallerHeaderFont");
            _initLanesView.ToolStripMenuItemSaveSettings.Text = LanguageManager.GetString("ToolStripMenuItemSaveSettings");
            _initLanesView.ToolStripMenuItemLoadSettings.Text = LanguageManager.GetString("ToolStripMenuItemLoadSettings");
        }
        
        private void ObtainInitialLanes()
        {
            _initialLanes = new List<InitialLane>();
            foreach (DataGridViewRow row in _initLanesView.GrdLanes.Rows)
            {
                if (_gridLaneHelper.IsLaneValid(row.Index))
                    _initialLanes.Add(_gridLaneHelper.GetInitialLane(row.Index));
            }
        }

        private void ObtainInitialLanesToSave()
        {
            _initialLanesToSave = new List<InitialLane>();
            foreach (DataGridViewRow row in _initLanesView.GrdLanes.Rows)
                _initialLanesToSave.Add(_gridLaneHelper.GetInitialLane(row.Index));
        }

        private void ShowMessage(string msg)
        {
            var largeOkMessageBox = new LargeOkMessageBox();
            largeOkMessageBox.ShowDialog(msg);
        }

        private bool AreMandantoryFieldsMissing()
        {
            bool missing = false;
            foreach (InitialLane initalLane in _initialLanes)
            {
                if (initalLane.Car == null || initalLane.Driver == null)
                {
                    missing = true;
                    break;
                }
            }
            return missing;
        }

        private void SetDriverDataSource()
        {
            _drivers.Add(new Driver());

            _driversService.Drivers.Sort(CompareDrivers);
            List<Driver> activatedDrivers = _driversService.Drivers.FindAll(driver => driver.Activated);
            _drivers.AddRange(activatedDrivers);

            _gridLaneHelper.ColumnDriver.DataSource = _drivers;
            _gridLaneHelper.ColumnDriver.DisplayMember = "Name";
            _gridLaneHelper.ColumnDriver.ValueMember = "Name";
        }

        private static int CompareDrivers(Driver driver1, Driver driver2)
        {
            return String.CompareOrdinal(driver1.Name, driver2.Name);
        }

        private void SetCarDataSource()
        {
            _cars.Add(new Car());
            _carsService.Cars.Sort(CompareCars);
            _cars.AddRange(_carsService.Cars);

            _gridLaneHelper.ColumnCar.DataSource = _cars;
            _gridLaneHelper.ColumnCar.DisplayMember = "Name";
            _gridLaneHelper.ColumnCar.ValueMember = "Name";
        }

        private static int CompareCars(Car car1, Car car2)
        {
            return String.CompareOrdinal(car1.Name, car2.Name);
        }

        private void FillGrid()
        {
            _initLanesView.GrdLanes.Rows.Clear();
            FillGridWithIDs();
            UpdateGridWithLaneData();
            SizeGrid();
        }

        public void CheckToShowGridColumnGhostcar()
        {
            _initLanesView.GridColumnGhostcar.Visible = false;      
        }

        private void FillGridWithIDs()
        {
            foreach (LaneId laneId in Enum.GetValues(typeof (LaneId)))
            {
                _initLanesView.GrdLanes.Rows.Add();
                int rowIndex = _initLanesView.GrdLanes.Rows.GetLastRow(DataGridViewElementStates.None);
                _initLanesView.GrdLanes.Rows[rowIndex].Tag = laneId;
                _initLanesView.GrdLanes[_gridLaneHelper.ColumnId.Name, rowIndex].Value = ((int) laneId + 1).ToString();
            }
        }

        private void UpdateGridWithLaneData()
        {
            foreach (InitialLane initialLane in _serializerService.Object)
                UpdateGridWithInitialLane(initialLane);
        }

        private void UpdateGridWithInitialLane(InitialLane initialLane)
        {
            try
            {
                int? rowIndex = FindRowOfLane(initialLane);
                if (rowIndex != null)
                {
                    using (var initalLaneModel = new InitalLaneModel(initialLane))
                    {
                        _initLanesView.GrdLanes[_gridLaneHelper.ColumnDriver.Name, (int) rowIndex].Value =
                            initalLaneModel.DriverName;
                        _initLanesView.GrdLanes[_gridLaneHelper.ColumnCar.Name, (int)rowIndex].Value =
                            initalLaneModel.CarName;
                        _initLanesView.GrdLanes[_gridLaneHelper.ColumnCarPicture.Name, (int)rowIndex].Value =
                            initalLaneModel.CarPicture;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private int? FindRowOfLane(InitialLane initialLane)
        {
            int? foundRowIndex = null;
            foreach (DataGridViewRow row in _initLanesView.GrdLanes.Rows)
            {
                if (row.Tag is LaneId && (LaneId) row.Tag == initialLane.Id)
                {
                    foundRowIndex = row.Index;
                    break;
                }
            }
            return foundRowIndex;
        }

        public void CheckToSetEmptyItem()
        {
            if (_initLanesView.GrdLanes.SelectedCells.Count == 1)
            {
                int columnIndex = _initLanesView.GrdLanes.SelectedCells[0].ColumnIndex;
                if (columnIndex == _initLanesView.GridColumnDriver.Index || columnIndex == _initLanesView.GridColumnCar.Index)
                {
                    DataGridViewComboBoxCell cell = _initLanesView.GrdLanes.SelectedCells[0] as DataGridViewComboBoxCell;
                    if (cell != null)
                        cell.Value = string.Empty;
                }
            }
        }

    }
}