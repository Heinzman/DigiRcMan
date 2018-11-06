using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.DomainModels;
using Elreg.Log;
using Elreg.ResourcesService;
using Elreg.WindowsFormsView;
using Elreg.WinFormsPresentationFramework;
using Elreg.WinFormsPresentationFramework.DataTransferObjects;
using Elreg.WinFormsPresentationFramework.Forms;

namespace Elreg.WindowsFormsPresenter
{
    public class RaceResultsPresenter : GridPresenter
    {
        private readonly RaceResultsModel _raceResultsModel;
        private readonly IRaceResultsView _raceResultsView;
        private List<GridResultDto> _gridResultDtos;
        private TimeSpan? _bestRaceTimeNet;
        private string MessageCouldNotLoad { get; set; }
        private string MessageReallyDelete { get; set; }
        private string MessageWasSaved { get; set; }

        public RaceResultsPresenter(IRaceResultsView raceResultsView, RaceResultsModel raceResultsModel)
            : base(raceResultsView)
        {
            try
            {
                _raceResultsView = raceResultsView;
                _raceResultsModel = raceResultsModel;
                GridHandler = new GridHandler(GrdLanes);
                _raceResultsModel.ResultsChanged += RaceResultsModelResultsChanged;
                LanguageManager.LanguageChanged += LanguageManagerLanguageChanged;
                AdjustCultureStrings();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public bool GridResultFilled { get; private set; }

        public IRaceResult RaceResult
        {
            get { return _raceResultsModel.RaceResult; }
            set { _raceResultsModel.RaceResult = value; }
        }

        public bool CanBeUsedForChampionship
        {
            get { return _raceResultsModel.CanBeUsedForChampionship; }
        }

        public void LoadAndShow(string raceResultsXmlFile)
        {
            try
            {
                _raceResultsModel.DeserializeRaceResults(raceResultsXmlFile);
                _raceResultsView.InvokeShowAndFocus();
                FillData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
                var largeOkMessageBox = new LargeOkMessageBox();
                var text = MessageCouldNotLoad.Replace(LanguageManager.ReplaceString1, raceResultsXmlFile);
                largeOkMessageBox.ShowDialog(text);
            }
        }

        public void FillData()
        {
            try
            {
                CreateGridResultDtosFromModel();
                FillGrdLanes();
                FilterColumns();
                SetCaption();
                SetButtons();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void UpdateLaneAfterChanges(int columnIndex, int rowIndex)
        {
            try
            {
                var laneId = (LaneId)GrdLanes.Rows[rowIndex].Tag;
                int changedValue;

                if (int.TryParse(GrdLanes[columnIndex, rowIndex].Value.ToString(), out changedValue))
                {
                    if (columnIndex == GrdLanes[Columns.ColumnPosition.ToString(), 0].ColumnIndex)
                        _raceResultsModel.ChangePositionOfLane(laneId, changedValue);
                    else if (columnIndex == GrdLanes[Columns.ColumnPoints.ToString(), 0].ColumnIndex)
                        _raceResultsModel.ChangePointsOfLane(laneId, changedValue);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void SaveData()
        {
            try
            {
                _raceResultsModel.SaveData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public bool ConfirmDeleting()
        {
            bool ret = false;
            try
            {
                LargeMessageBoxHandler largeMessageBoxHandler = new LargeMessageBoxHandler();
                DialogResult dialogResult = largeMessageBoxHandler.ShowDialog(MessageReallyDelete);
                ret = dialogResult == DialogResult.Yes;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
            return ret;
        }

        public void InformSaved()
        {
            try
            {
                var largeOkMessageBox = new LargeOkMessageBox();
                largeOkMessageBox.ShowDialog(MessageWasSaved);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void DeleteRaceResult()
        {
            try
            {
                _raceResultsModel.DeleteRaceResult();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void CreateRaceResult()
        {
            try
            {
                _raceResultsModel.CreateRaceResult();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void CopyTableToClipboard()
        {
            try
            {
                SetColumnVisible(Columns.ColumnCar, false);
                SetColumnVisible(Columns.ColumnCarName, true);
                DataGridViewColumn column = GrdLanes.Columns[Columns.ColumnCarName.ToString()];
                if (column != null)
                    column.DisplayIndex = 2;
                GrdLanes.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                GrdLanes.SelectAll();
                DataObject dataObject = GrdLanes.GetClipboardContent();
                if (dataObject != null)
                    Clipboard.SetDataObject(dataObject);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
            finally
            {
                SetColumnVisible(Columns.ColumnCar, true);
                SetColumnVisible(Columns.ColumnCarName, false);
            }
        }

        protected override string DefaultXmlFileName
        {
            get
            {
                const string fileName = "RaceResults.xml";
                return ServiceHelper.ConfigViewPath + fileName;
            }
        }

        private void LanguageManagerLanguageChanged(object sender, EventArgs e)
        {
            AdjustCultureStrings();
        }

        private void CreateGridResultDtosFromModel()
        {
            _gridResultDtos = new List<GridResultDto>();
            GetBestRaceTimeNet();
            foreach (RaceResultLane raceResultLane in _raceResultsModel.RaceResult.RaceResultLanes)
            {
                var gridResultDto = new GridResultDto
                                        {
                                            LaneId = raceResultLane.Id,
                                            Position = Format(raceResultLane.Position),
                                            Driver = raceResultLane.Driver.Name,
                                            Car = GetCarPicture(raceResultLane),
                                            CarName = raceResultLane.Car.Name,
                                            Points = Format(raceResultLane.Points),
                                            Lap = Format(raceResultLane.Laps),
                                            BestLapTime = Format(raceResultLane.BestLapTime),
                                            Penalties = Format(raceResultLane.Penalties),
                                            RaceTimeNet = FormatRaceTimeNet(raceResultLane.RaceTimeNet)
                                        };
                _gridResultDtos.Add(gridResultDto);
            }
        }

        private void GetBestRaceTimeNet()
        {
            RaceResultLane raceResultLane = _raceResultsModel.RaceResult.RaceResultLanes.Find(r => r.Position == 1);
            if (raceResultLane != null) 
                _bestRaceTimeNet = raceResultLane.RaceTimeNet;
            else 
                _bestRaceTimeNet = null;
        }

        private string FormatRaceTimeNet(TimeSpan raceTimeNet)
        {
            string formattedRaceTimeNet = Format(raceTimeNet);
            if (_bestRaceTimeNet != null)
            {
                if (raceTimeNet > _bestRaceTimeNet)
                {
                    TimeSpan deltaRaceTime = raceTimeNet - _bestRaceTimeNet.Value;
                    formattedRaceTimeNet = "+" + Format(deltaRaceTime);
                }
            }
            return formattedRaceTimeNet;
        }

        private void RaceResultsModelResultsChanged(object sender, EventArgs e)
        {
            try
            {
                FillData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void FilterColumns()
        {
            bool isColumnPointsVisible = true;
            bool isColumnLapCountVisible = true;
            bool isColumnRaceTimeNetVisible = true;

            if (_raceResultsModel.IsTraining || _raceResultsModel.IsQualification)
            {
                isColumnPointsVisible = false;
                isColumnRaceTimeNetVisible = false;
            }
            else if (_raceResultsModel.IsRace)
                isColumnLapCountVisible = false;

            if (_raceResultsView != null && GrdLanes != null)
            {
                SetColumnVisible(Columns.ColumnPoints, isColumnPointsVisible);
                SetColumnVisible(Columns.ColumnLapCount, isColumnLapCountVisible);
                SetColumnVisible(Columns.ColumnRaceTimeNet, isColumnRaceTimeNetVisible);
            }
            SetColumnVisible(Columns.ColumnCarName, false);
        }

        private void SetColumnVisible(Columns columnsEnum, bool isVisible)
        {
            DataGridViewColumn column = GrdLanes.Columns[columnsEnum.ToString()];
            if (column != null)
                GrdLanes.Invoke((MethodInvoker)(() => column.Visible = isVisible));
        }

        private void FillGrdLanes()
        {
            GridResultFilled = false;
            _gridResultDtos.Sort((g1, g2) => String.CompareOrdinal(g1.Position, g2.Position));
            GrdLanes.Invoke((MethodInvoker)(() => GrdLanes.Rows.Clear()));
            
            foreach (GridResultDto gridResultDto in _gridResultDtos)
            {
                GridResultDto dto = gridResultDto;
                int rowIndex = _raceResultsView.GetIndexOfAddedRowInGrdLanes();
                GrdLanes.Invoke((MethodInvoker)(() => GrdLanes.Rows[rowIndex].Tag = dto.LaneId));
                SetGrdLanesColumnValue(Columns.ColumnPosition, rowIndex, dto.Position);
                SetGrdLanesColumnValue(Columns.ColumnDriver, rowIndex, dto.Driver);
                SetGrdLanesColumnValue(Columns.ColumnCar, rowIndex, dto.Car);
                SetGrdLanesColumnValue(Columns.ColumnCarName, rowIndex, dto.CarName);
                SetGrdLanesColumnValue(Columns.ColumnLapCount, rowIndex, dto.Lap);
                SetGrdLanesColumnValue(Columns.ColumnBestLapTime, rowIndex, dto.BestLapTime);
                SetGrdLanesColumnValue(Columns.ColumnPenalties, rowIndex, dto.Penalties);
                SetGrdLanesColumnValue(Columns.ColumnPoints, rowIndex, dto.Points);
                SetGrdLanesColumnValue(Columns.ColumnRaceTimeNet, rowIndex, dto.RaceTimeNet);
            }
            SizeGrid();
            GridResultFilled = true;
        }

        private void SetGrdLanesColumnValue(Columns column, int rowIndex, object value)
        {
            GrdLanes.Invoke((MethodInvoker)(() => GrdLanes[column.ToString(), rowIndex].Value = value));
        }

        private DataGridView GrdLanes
        {
            get { return _raceResultsView.GrdLanes; }
        }

        private void SetCaption()
        {
            string caption;
            if (_raceResultsModel.IsTraining)
                caption = "Training Results ";
            else if (_raceResultsModel.IsQualification)
                caption = "Qualification Results ";
            else
                caption = "Race Results ";
            _raceResultsView.Invoke((MethodInvoker)(() => _raceResultsView.Text = caption + _raceResultsModel.RaceResult.Name));
        }

        private void SetButtons()
        {
            _raceResultsView.BtnDeleteVisible = true;
            _raceResultsView.BtnSaveVisible = true;
        }

        private void AdjustCultureStrings()
        {
            MessageCouldNotLoad = LanguageManager.GetString("RaceResultsMessageCouldNotLoad");
            MessageReallyDelete = LanguageManager.GetString("RaceResultsMessageReallyDelete");
            MessageWasSaved = LanguageManager.GetString("RaceResultsMessageWasSaved");
            _raceResultsView.ToolStripMenuItemLargerFontText = LanguageManager.GetString("ToolStripMenuItemLargerFont");
            _raceResultsView.ToolStripMenuItemSmallerFontText = LanguageManager.GetString("ToolStripMenuItemSmallerFont");
            _raceResultsView.ToolStripMenuItemLargerHeaderFontText = LanguageManager.GetString("ToolStripMenuItemLargerHeaderFont");
            _raceResultsView.ToolStripMenuItemSmallerHeaderFontText = LanguageManager.GetString("ToolStripMenuItemSmallerHeaderFont");
            _raceResultsView.ToolStripMenuItemSaveSettingsText = LanguageManager.GetString("ToolStripMenuItemSaveSettings");
            _raceResultsView.ToolStripMenuItemLoadSettingsText = LanguageManager.GetString("ToolStripMenuItemLoadSettings");
            _raceResultsView.GridColumnPositionHeaderText = LanguageManager.GetString("RaceResultsFormColumnPosition");
            _raceResultsView.GridColumnDriverHeaderText = LanguageManager.GetString("RaceResultsFormColumnDriver");
            _raceResultsView.GridColumnPointsHeaderText = LanguageManager.GetString("RaceResultsFormColumnPoints");
            _raceResultsView.GridColumnCarHeaderText = LanguageManager.GetString("RaceResultsFormColumnCar");
            _raceResultsView.GridColumnLapCountHeaderText = LanguageManager.GetString("RaceResultsFormColumnLapCount");
            _raceResultsView.GridColumnBestLapTimeHeaderText = LanguageManager.GetString("RaceResultsFormColumnBestLapTime");
            _raceResultsView.GridColumnPenaltiesHeaderText = LanguageManager.GetString("RaceResultsFormColumnPenalties");
            _raceResultsView.GridColumnRaceTimeNetHeaderText = LanguageManager.GetString("RaceResultsFormColumnRaceTimeNet");
            _raceResultsView.BtnClose.Text = LanguageManager.GetString("RaceResultsFormBtnClose");
            _raceResultsView.BtnDelete.Text = LanguageManager.GetString("RaceResultsFormBtnDelete");
            _raceResultsView.BtnSave.Text = LanguageManager.GetString("RaceResultsFormBtnSave");
            _raceResultsView.Caption = LanguageManager.GetString("RaceResultsFormCaption");
        }

        #region Nested type: Columns

        private enum Columns
        {
            ColumnPosition,
            ColumnDriver,
            ColumnCar,
            ColumnCarName,
            ColumnPoints,
            ColumnLapCount,
            ColumnBestLapTime,
            ColumnPenalties,
            ColumnRaceTimeNet
        }

        #endregion
    }
}