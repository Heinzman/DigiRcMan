using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;
using Elreg.Log;
using Elreg.RaceOptionsService;
using Elreg.ResourcesService;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsPresenter.InitUpdateLanes
{
    public class UpdateLanesPresenter : GridPresenter
    {
        private const string MsgNoLanes = "Es sind keine Fahrer ausgewählt.";
        private const string MsgMandDataMissed = "Es fehlen Pflichtdaten.";
        private readonly List<Car> _cars = new List<Car>();
        private readonly CarsService _carsService;
        private readonly List<Lane> _currentLanes = new List<Lane>();
        private readonly List<Driver> _drivers = new List<Driver>();
        private readonly DriversService _driversService;
        private readonly GridLaneUpdateHelper _gridLaneHelper;
        private readonly IUpdateLanesView _updateLanesView;
        private List<ChangedLane> _changedLanes = new List<ChangedLane>();

        public UpdateLanesPresenter(List<Lane> currentLanes, IUpdateLanesView updateLanesView,
                                    DriversService driversService, CarsService carsService) : base(updateLanesView)
        {
            _currentLanes = currentLanes;
            _updateLanesView = updateLanesView;
            _driversService = driversService;
            _carsService = carsService;
            GridHandler = new GridHandler(_updateLanesView.GrdLanes);
            _gridLaneHelper = new GridLaneUpdateHelper(_updateLanesView.GrdLanes, driversService, carsService);
            AdjustCultureStrings();
            LanguageManager.LanguageChanged += LanguageManagerLanguageChanged;
        }

        private void LanguageManagerLanguageChanged(object sender, EventArgs e)
        {
            try
            {
                AdjustCultureStrings();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public List<ChangedLane> ChangedLanes
        {
            get
            {
                ObtainChangedLanes();
                return _changedLanes;
            }
        }

        protected override string DefaultXmlFileName
        {
            get
            {
                const string fileName = "View_UpdateLanes.xml";
                return ServiceHelper.ConfigViewPath + fileName;
            }
        }

        public void FillView()
        {
            CloneCurrentLanes();
            SetDriverDataSource();
            SetCarDataSource();
            SetStatusDataSource();
            FillGrid();
        }

        public bool Validate()
        {
            bool ret = false;
            ObtainChangedLanes();
            if (_changedLanes.Count == 0)
                ShowMessage(MsgNoLanes);
            else if (AreMandantoryFieldsMissing())
                ShowMessage(MsgMandDataMissed);
            else
                ret = true;
            return ret;
        }

        public void UpdateAllDependentValues()
        {
            _gridLaneHelper.UpdateAllDependentValues();
        }

        public void HandleCellValueChanged(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == _gridLaneHelper.ColumnDriver.Index || e.ColumnIndex == _gridLaneHelper.ColumnCar.Index))
                _gridLaneHelper.UpdateDependentValues(e.RowIndex);
        }

        private void CloneCurrentLanes()
        {
            foreach (Lane currentLane in _currentLanes)
            {
                var changedLane = new ChangedLane(currentLane);
                _changedLanes.Add(changedLane);
            }
        }

        private void ObtainChangedLanes()
        {
            _changedLanes = new List<ChangedLane>();
            foreach (DataGridViewRow row in _updateLanesView.GrdLanes.Rows)
            {
                if (_gridLaneHelper.IsLaneValid(row.Index))
                    _changedLanes.Add(_gridLaneHelper.GetChangedLane(row.Index));
            }
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, @"Validierungsfehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private bool AreMandantoryFieldsMissing()
        {
            bool missing = false;
            foreach (ChangedLane changedLane in _changedLanes)
            {
                if (changedLane.Car == null || changedLane.Driver == null)
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
            List<Driver> activatedDrivers = _driversService.Drivers.FindAll(driver => driver.Activated);
            _drivers.AddRange(activatedDrivers);

            _gridLaneHelper.ColumnDriver.DataSource = _drivers;
            _gridLaneHelper.ColumnDriver.DisplayMember = "Name";
            _gridLaneHelper.ColumnDriver.ValueMember = "Name";
        }

        private void SetCarDataSource()
        {
            _cars.Add(new Car());
            _cars.AddRange(_carsService.Cars);

            _gridLaneHelper.ColumnCar.DataSource = _cars;
            _gridLaneHelper.ColumnCar.DisplayMember = "Name";
            _gridLaneHelper.ColumnCar.ValueMember = "Name";
        }

        private void SetStatusDataSource()
        {
            var statusList = new List<KeyValuePair<string, Lane.LaneStatusEnum>>
                                 {
                                     new KeyValuePair<string, Lane.LaneStatusEnum>("Started", Lane.LaneStatusEnum.Started),
                                     new KeyValuePair<string, Lane.LaneStatusEnum>("Finished", Lane.LaneStatusEnum.Finished),
                                     new KeyValuePair<string, Lane.LaneStatusEnum>("Disqualified", Lane.LaneStatusEnum.Disqualified)
                                 };
            _gridLaneHelper.ColumnStatus.DataSource = statusList;
            _gridLaneHelper.ColumnStatus.DisplayMember = "Key";
            _gridLaneHelper.ColumnStatus.ValueMember = "Value";
        }

        private void FillGrid()
        {
            _updateLanesView.GrdLanes.Rows.Clear();
            UpdateGridWithLaneData();
            SortGrid();
            SizeGrid();
        }

        private void UpdateGridWithLaneData()
        {
            foreach (ChangedLane changedLane in _changedLanes)
            {
                _updateLanesView.GrdLanes.Rows.Add();
                int rowIndex = _updateLanesView.GrdLanes.Rows.GetLastRow(DataGridViewElementStates.None);
                int laneId = (int) changedLane.Id + 1;
                _updateLanesView.GrdLanes.Rows[rowIndex].Tag = changedLane.Id;
                _updateLanesView.GrdLanes[_gridLaneHelper.ColumnId.Name, rowIndex].Value = laneId.ToString();
                _updateLanesView.GrdLanes[_gridLaneHelper.ColumnDriver.Name, rowIndex].Value = changedLane.Driver.Name;
                _updateLanesView.GrdLanes[_gridLaneHelper.ColumnCar.Name, rowIndex].Value = changedLane.Car.Name;
                _updateLanesView.GrdLanes[_gridLaneHelper.ColumnLapCount.Name, rowIndex].Value = changedLane.Lap;
                _updateLanesView.GrdLanes[_gridLaneHelper.ColumnStatus.Name, rowIndex].Value = changedLane.Status;
                _updateLanesView.GrdLanes[_gridLaneHelper.ColumnOverallPenalties.Name, rowIndex].Value = changedLane.PenaltyCount;
                _updateLanesView.GrdLanes[_gridLaneHelper.ColumnOverallPenalties.Name, rowIndex].Value = changedLane.PenaltyCount;
            }
        }

        private void SortGrid()
        {
            _updateLanesView.GrdLanes.Sort(_gridLaneHelper.ColumnDriver, ListSortDirection.Ascending);
        }

        private void AdjustCultureStrings()
        {
            _updateLanesView.Text = LanguageManager.GetString("UpdateLanesFormCaption");
            _updateLanesView.BtnRefresh.Text = LanguageManager.GetString("UpdateLanesFormBtnRefresh");
            _updateLanesView.BtnOk.Text = LanguageManager.GetString("UpdateLanesFormBtnOk");
            _updateLanesView.BtnCancel.Text = LanguageManager.GetString("UpdateLanesFormBtnCancel");
            _updateLanesView.GridColumnId.HeaderText = LanguageManager.GetString("UpdateLanesFormColumnId");
            _updateLanesView.GridColumnDriver.HeaderText = LanguageManager.GetString("UpdateLanesFormColumnDriver");
            _updateLanesView.GridColumnCar.HeaderText = LanguageManager.GetString("UpdateLanesFormColumnCar");
            _updateLanesView.GridColumnLapCount.HeaderText = LanguageManager.GetString("UpdateLanesFormColumnLapCount");
            _updateLanesView.GridColumnStatus.HeaderText = LanguageManager.GetString("UpdateLanesFormColumnStatus");
            _updateLanesView.GridColumnOverallPenalties.HeaderText = LanguageManager.GetString("UpdateLanesFormColumnOverallPenalties");
            _updateLanesView.ToolStripMenuItemLargerFont.Text = LanguageManager.GetString("ToolStripMenuItemLargerFont");
            _updateLanesView.ToolStripMenuItemSmallerFont.Text = LanguageManager.GetString("ToolStripMenuItemSmallerFont");
            _updateLanesView.ToolStripMenuItemLargerHeaderFont.Text = LanguageManager.GetString("ToolStripMenuItemLargerHeaderFont");
            _updateLanesView.ToolStripMenuItemSmallerHeaderFont.Text = LanguageManager.GetString("ToolStripMenuItemSmallerHeaderFont");
            _updateLanesView.ToolStripMenuItemSaveSettings.Text = LanguageManager.GetString("ToolStripMenuItemSaveSettings");
            _updateLanesView.ToolStripMenuItemLoadSettings.Text = LanguageManager.GetString("ToolStripMenuItemLoadSettings");
        }
    }
}