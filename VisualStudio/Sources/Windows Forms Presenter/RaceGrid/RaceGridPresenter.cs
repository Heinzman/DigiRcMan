using System;
using System.Drawing;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Races;
using Elreg.DomainModels.RaceModel;
using Elreg.Log;
using Elreg.ResourcesService;
using Elreg.WindowsFormsPresenter.RaceControl;
using Elreg.WindowsFormsPresenter.RaceGrid.LapTime;
using Elreg.WindowsFormsView;
using Elreg.WinFormsPresentationFramework;
using Elreg.WinFormsPresentationFramework.DataTransferObjects;

namespace Elreg.WindowsFormsPresenter.RaceGrid
{
    public class RaceGridPresenter : RacePresenter, IRaceGridPresenter
    {
        #region Columns enum

        public enum Columns
        {
            ColumnId,
            ColumnDriver,
            ColumnCarFuelLevel,
            ColumnLapCount,
            ColumnCar,
            ColumnRockets,
            ColumnPosition,
            ColumnBestLapTime,
            ColumnLapTime,
            ColumnLapTimeBestLapTime,
            ColumnFuelConsumption,
            ColumnFuelConsumptionWithAverage,
            ColumnStatus,
            ColumnPenalties,
            ColumnEngineDamage,
            ColumnCurrentSpeed
        }

        #endregion

        private readonly GridPresenterForComp _gridPresenterForComp;
        private readonly RaceGridLaneDto[] _previousRaceGridLaneDto = new RaceGridLaneDto[6];
        private readonly Lane[] _previousLanes = new Lane[6];
        private readonly RaceGridRaceDto _raceGridRaceDto = new RaceGridRaceDto();
        private readonly IRaceGridView _raceGridView;
        private readonly ISimpleView _raceControlView;
        private readonly System.Timers.Timer _racingTimeTimer = new System.Timers.Timer();
        private readonly LapTimeHandler _lapTimeHandler;
        private string _lastRacingTime;
        private readonly ResourceProxy _resourceProxy = new ResourceProxy();
        private readonly PositionsCalculator _positionsCalculator;
        private static readonly object Locker = new object();

        public RaceGridPresenter(IRaceGridView raceGridView, RaceModel raceModel, ISimpleView raceControlView)
            : base(raceModel)
        {
            try
            {
                _raceGridView = raceGridView;
                _raceControlView = raceControlView;
                _gridPresenterForComp = new GridPresenterForComp(raceGridView);
                InitRacingTimeTimer();
                _raceGridView.GrdLanes.CellPainting += GrdLanesCellPainting;
                LanguageManager.LanguageChanged += LanguageManagerLanguageChanged;
                AdjustCultureStrings();
                _lapTimeHandler = new LapTimeHandler(RaceModel, _raceGridView, this);
                _positionsCalculator = new PositionsCalculator(raceModel, _raceGridView);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void HandleGridKey(KeyEventArgs e)
        {
            try
            {
                _gridPresenterForComp.HandleGridKey(e);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public override void FillView()
        {
            try
            {
                ClearPositions();
                _lapTimeHandler.Reset();
                CreateRaceGridRaceDtoFromModel();
                _raceGridView.GrdLanes.Rows.Clear();
                foreach (RaceGridLaneDto raceGridLaneDto in _raceGridRaceDto.Lanes)
                {
                    _raceGridView.GrdLanes.Rows.Add();
                    int rowIndex = _raceGridView.GrdLanes.Rows.GetLastRow(DataGridViewElementStates.None);
                    _raceGridView.GrdLanes.Rows[rowIndex].Tag = raceGridLaneDto;
                    _raceGridView.GrdLanes[Columns.ColumnId.ToString(), rowIndex].Value = raceGridLaneDto.ScxId;
                    _raceGridView.GrdLanes[Columns.ColumnDriver.ToString(), rowIndex].Value = raceGridLaneDto.Driver;
                    _raceGridView.GrdLanes[Columns.ColumnLapCount.ToString(), rowIndex].Value = raceGridLaneDto.Lap;
                    _raceGridView.GrdLanes[Columns.ColumnCar.ToString(), rowIndex].Value = raceGridLaneDto.Car;
                    _raceGridView.GrdLanes[Columns.ColumnPosition.ToString(), rowIndex].Value = raceGridLaneDto.Position;
                    _raceGridView.GrdLanes[Columns.ColumnBestLapTime.ToString(), rowIndex].Value = raceGridLaneDto.BestLapTime;
                    _raceGridView.GrdLanes[Columns.ColumnLapTimeBestLapTime.ToString(), rowIndex].Value = raceGridLaneDto.LapTimeBestLapTime;
                    _raceGridView.GrdLanes[Columns.ColumnLapTime.ToString(), rowIndex].Value = raceGridLaneDto.LapTime;
                    _raceGridView.GrdLanes[Columns.ColumnStatus.ToString(), rowIndex].Value = raceGridLaneDto.StatusImage;
                    _raceGridView.GrdLanes[Columns.ColumnPenalties.ToString(), rowIndex].Value = raceGridLaneDto.PenaltiesText;

                    SetBackgroundColorForSpecialColumnsOfRow(rowIndex);
                }
                SizeGrid();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void ClearPositions()
        {
            try
            {
                foreach (Label label in _raceGridView.PositionLabels)
                {
                    if (label != null)
                        _raceGridView.SetControlPropertyThreadSafe(label, "Text", string.Empty);
                }

                foreach (PictureBox positionPicture in _raceGridView.PositionPictures)
                {
                    if (positionPicture != null)
                        _raceGridView.SetControlPropertyThreadSafe(positionPicture, "Image", null);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void IncreaseCellFont()
        {
            try
            {
                _gridPresenterForComp.IncreaseCellFont();
                SizeGrid();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void DecreaseCellFont()
        {
            try
            {
                _gridPresenterForComp.DecreaseCellFont();
                SizeGrid();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void IncreaseHeaderCellFont()
        {
            try
            {
                _gridPresenterForComp.IncreaseHeaderCellFont();
                SizeGrid();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void DecreaseHeaderCellFont()
        {
            try
            {
                _gridPresenterForComp.DecreaseHeaderCellFont();
                SizeGrid();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void IncreaseStatusCellFont()
        {
            try
            {
                _gridPresenterForComp.IncreaseStatusCellFont();
                SizeGrid();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void DecreaseStatusCellFont()
        {
            try
            {
                _gridPresenterForComp.DecreaseStatusCellFont();
                SizeGrid();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void SizeGrid()
        {
            try
            {
                if (_raceGridView.WindowState != FormWindowState.Minimized)
                    _gridPresenterForComp.SizeGrid();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void SaveGridSettings()
        {
            try
            {
                _gridPresenterForComp.SaveGridSettings();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void LoadGridSettings()
        {
            try
            {
                _gridPresenterForComp.LoadGridSettings();
                _gridPresenterForComp.CheckOrUncheckColumnMenuItems();
                SizeGrid();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void LoadGridSettingsChooseSource()
        {
            try
            {
                _gridPresenterForComp.LoadGridSettingsChooseSource();
                _gridPresenterForComp.CheckOrUncheckColumnMenuItems();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public int GetRowIndexBy(LaneId laneId)
        {
            int rowIndex = -1;
            try
            {
                foreach (DataGridViewRow row in _raceGridView.GrdLanes.Rows)
                {
                    var raceGridLaneDto = row.Tag as RaceGridLaneDto;
                    if (raceGridLaneDto != null && raceGridLaneDto.LaneId == laneId)
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            } 
            return rowIndex;
        }

        public void InitializeGridColumns()
        {
            try
            {
                _raceGridView.GridColumnStatus.DefaultCellStyle.NullValue = null;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void CheckIfSettingsChanged()
        {
            try
            {
                _gridPresenterForComp.CheckIfSettingsChanged();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public Color DefaultBackgroundColor
        {
            get { return Color.FromArgb(210, 210, 210); }
        }

        public Color AlternatingBackgroundColor
        {
            get { return Color.FromArgb(190, 190, 190); }
        }

        public void ShowRaceControlForm()
        {
            try
            {
                FormHelper.HideForm(_raceGridView);
                FormHelper.ShowAndFocus(_raceControlView);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void DecreasePositionsCellFont()
        {
            try
            {
                _gridPresenterForComp.DecreasePositionsCellFont();
                SizeGrid();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void IncreasePositionsCellFont()
        {
            try
            {
                _gridPresenterForComp.IncreasePositionsCellFont();
                SizeGrid();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        protected override void UpdateRaceStatus()
        {
            _raceGridView.SetControlPropertyThreadSafe(_raceGridView.Labels[(int)RaceStatusLabels.Type], "Text", RaceModel.Race.Type.ToString());
            _raceGridView.SetControlPropertyThreadSafe(_raceGridView.Labels[(int)RaceStatusLabels.Status], "Text", RaceModel.Race.Status.ToString());
        }

        protected override void UpdateRace()
        {
            foreach (Lane lane in RaceModel.Race.Lanes)
                UpdateLane(lane);
        }

        protected override void UpdatePositions()
        {
            _positionsCalculator.UpdatePositions();
        }

        protected override void UpdateLane(Lane lane)
        {
            LaneId laneId = lane.Id;
            int rowIndex = GetRowIndexBy(laneId);
            if (rowIndex >= 0)
            {
                if (HasDataChangedOf(lane))
                {
                    RaceGridLaneDto raceGridLaneDto = CreateRaceGridLaneDtoFromModel(laneId);
                    RaceGridLaneDto previousRaceGridLaneDto = _previousRaceGridLaneDto[(int) laneId];

                    if (raceGridLaneDto != null)
                    {
                        if (previousRaceGridLaneDto == null || previousRaceGridLaneDto.LaneStatus != raceGridLaneDto.LaneStatus)
                            _raceGridView.GrdLanes[Columns.ColumnStatus.ToString(), rowIndex].Value = raceGridLaneDto.StatusImage;
                        if (lane.IsStartedOrInitializedOrFinished || lane.IsDisqualified)
                        {
                            if (previousRaceGridLaneDto == null || previousRaceGridLaneDto.Lap != raceGridLaneDto.Lap)
                                _raceGridView.GrdLanes[Columns.ColumnLapCount.ToString(), rowIndex].Value = raceGridLaneDto.Lap;
                            if (previousRaceGridLaneDto == null || previousRaceGridLaneDto.Position != raceGridLaneDto.Position || previousRaceGridLaneDto.Status != raceGridLaneDto.Status)
                                UpdatePositionsOfLanes();
                            if (previousRaceGridLaneDto == null || previousRaceGridLaneDto.BestLapTime != raceGridLaneDto.BestLapTime)
                                _raceGridView.GrdLanes[Columns.ColumnBestLapTime.ToString(), rowIndex].Value = raceGridLaneDto.BestLapTime;
                            if (previousRaceGridLaneDto == null || previousRaceGridLaneDto.LapTime != raceGridLaneDto.LapTime)
                                _raceGridView.GrdLanes[Columns.ColumnLapTime.ToString(), rowIndex].Value = raceGridLaneDto.LapTime;
                            if (previousRaceGridLaneDto == null || previousRaceGridLaneDto.LapTimeBestLapTime != raceGridLaneDto.LapTimeBestLapTime)
                                _raceGridView.GrdLanes[Columns.ColumnLapTimeBestLapTime.ToString(), rowIndex].Value = raceGridLaneDto.LapTimeBestLapTime;
                            if (previousRaceGridLaneDto == null || previousRaceGridLaneDto.PenaltiesCount != raceGridLaneDto.PenaltiesCount)
                            {
                                _raceGridView.GrdLanes[Columns.ColumnPenalties.ToString(), rowIndex].Value = raceGridLaneDto.PenaltiesText;
                                CalcPenaltiesBackColor(rowIndex, raceGridLaneDto);
                            }
                            if (previousRaceGridLaneDto == null || previousRaceGridLaneDto.CarName != raceGridLaneDto.CarName)
                                _raceGridView.GrdLanes[Columns.ColumnCar.ToString(), rowIndex].Value = raceGridLaneDto.Car;
                        }
                        _previousRaceGridLaneDto[(int) laneId] = raceGridLaneDto;
                    }
                }
            }
        }

        private bool HasDataChangedOf(Lane lane)
        {
            bool changed = true;
            lock (Locker)
            {
                int laneId = (int) lane.Id;
                Lane prevLane = _previousLanes[laneId];

                if (prevLane != null)
                {
                    changed = lane.Driver.Id != prevLane.Driver.Id ||
                              lane.Car.Id != prevLane.Car.Id ||
                              lane.Lap != prevLane.Lap ||
                              lane.Position != prevLane.Position ||
                              lane.Status != prevLane.Status ||
                              lane.PenaltyCount != prevLane.PenaltyCount;
                }
                _previousLanes[laneId] = Clone(lane);
            } 

            return changed;
        }

        private Lane Clone(Lane lane)
        {
            Lane clonedLane = new Lane
                                  {
                                      Driver = lane.Driver,
                                      Car = lane.Car,
                                      Position = lane.Position,
                                      Lap = lane.Lap,
                                      PenaltyCount = lane.PenaltyCount,
                                      Status = lane.Status
                                  };
            return clonedLane;
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

        private void GrdLanesCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //try
            //{

            //    if (e.RowIndex > -1 && e.ColumnIndex == _raceGridView.GridColumnDriver.Index)
            //    {
            //        //e.PaintBackground(e.ClipBounds, true);
            //        //e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom);
            //        //e.Graphics.RotateTransform(270);
            //        //e.Graphics.DrawString(e.FormattedValue.ToString(), e.CellStyle.Font, Brushes.Black, 0, 0);
            //        //e.Graphics.ResetTransform();
            //        //e.Handled = true;

            //        e.PaintBackground(e.ClipBounds, true);
            //        e.Graphics.DrawString(Convert.ToString(e.FormattedValue),
            //                              e.CellStyle.Font, Brushes.Black, e.CellBounds.X-10, e.CellBounds.Y+10,
            //                              StringFormat.GenericDefault);
            //        e.Handled = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ErrorLog.LogError(false, ex);
            //}
        }

        private void CalcPenaltiesBackColor(int rowIndex, RaceGridLaneDto raceGridLaneDto)
        {
            if (RaceModel.RaceSettings.AutoDisqualificationRaceActivated)
            {
                Color color;
                int disqualiAfterPenalties = RaceModel.RaceSettings.AutoDisqualificationRaceAfterPenalties;
                int penaltiesCount = raceGridLaneDto.PenaltiesCount;

                if (penaltiesCount >= disqualiAfterPenalties - 1 && penaltiesCount > 0)
                    color = Color.IndianRed;
                else if (penaltiesCount >= disqualiAfterPenalties - 2 && penaltiesCount > 0)
                    color = Color.PaleGoldenrod;
                else
                    color = GetBackgroundColorOf(rowIndex);

                DataGridViewCell cell = _raceGridView.GrdLanes[Columns.ColumnPenalties.ToString(), rowIndex];
                DataGridViewCellStyle cellStyle = cell.Style.Clone();
                cellStyle.BackColor = color;
                cell.Style = cellStyle;
            }

        }

        private void SetBackgroundColorForSpecialColumnsOfRow(int rowIndex)
        {
            Color color = GetBackgroundColorOf(rowIndex);

            foreach (DataGridViewColumn column in _raceGridView.GrdLanes.Columns)
                _raceGridView.GrdLanes[column.Index, rowIndex].Style.BackColor = color;
        }

        private Color GetBackgroundColorOf(int rowIndex)
        {
            Color color = AlternatingBackgroundColor;
            if (rowIndex%2 == 0)
                color = DefaultBackgroundColor;
            return color;
        }

        private RaceGridLaneDto CreateRaceGridLaneDtoFromModel(LaneId laneId)
        {
            RaceGridLaneDto raceGridLaneDto = null;

            if (RaceModel.Race != null)
            {
                Lane lane = RaceModel.Race.Lanes.Find(foundLane => foundLane.Id == laneId);
                raceGridLaneDto = ConvertLaneToRaceGridLaneDto(lane);
            }
            return raceGridLaneDto;
        }

        private void UpdatePositionsOfLanes()
        {
            foreach (Lane lane in RaceModel.Race.Lanes)
            {
                int rowIndex = GetRowIndexBy(lane.Id);
                if (rowIndex >= 0)
                {
                    RaceGridLaneDto raceGridLaneDto = CreateRaceGridLaneDtoFromModel(lane.Id);
                    if (raceGridLaneDto != null)
                        _raceGridView.GrdLanes[Columns.ColumnPosition.ToString(), rowIndex].Value = raceGridLaneDto.Position;
                }
            }
        }

        private void CreateRaceGridRaceDtoFromModel()
        {
            _raceGridRaceDto.Lanes.Clear();
            if (RaceModel.Race != null)
            {
                _raceGridRaceDto.RaceStatus = RaceModel.Race.Status.ToString();
                foreach (Lane lane in RaceModel.Race.Lanes)
                {
                    RaceGridLaneDto raceGridLaneDto = ConvertLaneToRaceGridLaneDto(lane);
                    _raceGridRaceDto.Lanes.Add(raceGridLaneDto);
                }
            }
            _raceGridRaceDto.Lanes.Sort((r1, r2) => String.CompareOrdinal(r1.Driver, r2.Driver));
        }

        private RaceGridLaneDto ConvertLaneToRaceGridLaneDto(Lane lane)
        {
            var raceGridLaneDto = new RaceGridLaneDto
                                      {
                                          LaneId = lane.Id,
                                          ScxId = ((int) lane.Id + 1).ToString(),
                                          Driver = lane.Driver.Name,
                                          Car = CalcCarImage(lane),
                                          CarName = lane.Car.Name,
                                          Position = CalcPosition(lane),
                                          Lap = CalcLaneString(lane),
                                          LapTime = GridPresenter.Format(lane.LapTimeNet),
                                          BestLapTime = GridPresenter.Format(lane.BestLapTime),
                                          LapTimeBestLapTime = GridPresenter.Format(lane.LapTimeNet) + "\n" + GridPresenter.Format(lane.BestLapTime),
                                          Color = CalcColor(lane),
                                          StatusImage = null,
                                          PenaltiesText = CalcPenalties(lane),
                                          PenaltiesCount = lane.PenaltyCount,
                                          Status = lane.Status
                                      };
            CalcLaneStatus(lane, raceGridLaneDto);
            return raceGridLaneDto;
        }

        private string CalcPenalties(Lane lane)
        {
            string penalties = string.Empty;
            if (lane.PenaltyCount > 0)
                penalties = lane.PenaltyCount.ToString();
            return penalties;
        }

        private string CalcPosition(Lane lane)
        {
            string position = string.Empty;
            if (lane.IsStartedOrInitializedOrFinished && (IsQualiAndBestLapTimeExistsOf(lane) || IsRaceOrTraining()))
                position = lane.Position.ToString();
            return position;
        }

        private bool IsQualiAndBestLapTimeExistsOf(Lane lane)
        {
            return RaceModel.Race.Type == Race.TypeEnum.Qualification && lane.BestLapTime.HasValue;
        }

        private bool IsRaceOrTraining()
        {
            return RaceModel.Race.Type != Race.TypeEnum.Qualification;
        }

        private static Image CalcCarImage(Lane lane)
        {
            if (lane == null || lane.Car == null || lane.Car.Image == null)
                return Resource1.White;
            else
                return lane.Car.Image;
        }

        private string CalcLaneString(Lane lane)
        {
            string lapString = string.Empty;
            int lap = RaceModel.GetLapNumberOf(lane);
            if (lap >= 0)
            {
                lapString = lap.ToString();
                if (lane.Lap == -1)
                    lapString += "+";
            }
            return lapString;
        }

        private Color CalcColor(Lane lane)
        {
            Color color = Color.White;

            switch (lane.Id)
            {
                case LaneId.Lane1:
                    color = Color.CornflowerBlue;
                    break;
                case LaneId.Lane2:
                    color = Color.Salmon;
                    break;
                case LaneId.Lane3:
                    color = Color.WhiteSmoke;
                    break;
                case LaneId.Lane4:
                    color = Color.LightSteelBlue;
                    break;
                case LaneId.Lane5:
                    color = Color.LightSalmon;
                    break;
                case LaneId.Lane6:
                    color = Color.LightGray;
                    break;
            }
            return color;
        }

        private void CalcLaneStatus(Lane lane, RaceGridLaneDto raceGridLaneDto)
        {
            raceGridLaneDto.StatusImage = null;
            raceGridLaneDto.LaneStatus = LaneStatus.Normal;

            if (lane.Status == Lane.LaneStatusEnum.Disqualified)
            {
                raceGridLaneDto.StatusImage = _resourceProxy.GetBitmap("Disqualified1");
                raceGridLaneDto.LaneStatus = LaneStatus.Disqualified;
            }
            else if (lane.Status == Lane.LaneStatusEnum.Finished)
            {
                raceGridLaneDto.StatusImage = _resourceProxy.GetBitmap("Finished");
                raceGridLaneDto.LaneStatus = LaneStatus.Finished;
            }
        }

        private void InitRacingTimeTimer()
        {
            _racingTimeTimer.Interval = 50;
            _racingTimeTimer.Elapsed += RacingTimeTimerElapsed;
            _racingTimeTimer.Start();
        }

        private void RacingTimeTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                UpdateRacingTime();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void UpdateRacingTime()
        {
            TimeSpan racingTimespan = RaceModel.GetNetTimeSpanFromStart();
            string racingTime = String.Format("{0:HH:mm:ss}", new DateTime(racingTimespan.Ticks));
            if (_lastRacingTime != racingTime)
            {
                _raceGridView.SetControlPropertyThreadSafe(_raceGridView.Labels[(int)RaceStatusLabels.RaceTime], "Text", racingTime);
                _lastRacingTime = racingTime;
            }
        }

        private void AdjustCultureStrings()
        {
            _raceGridView.BtnShowRaceControlForm.Text = LanguageManager.GetString("RaceGridFormBtnShowRaceControlForm");
            _raceGridView.GridColumnId.HeaderText = LanguageManager.GetString("RaceGridFormColumnId");
            _raceGridView.GridColumnDriver.HeaderText = LanguageManager.GetString("RaceGridFormColumnDriver");
            _raceGridView.GridColumnLapCount.HeaderText = LanguageManager.GetString("RaceGridFormColumnLapCount");
            _raceGridView.GridColumnCar.HeaderText = LanguageManager.GetString("RaceGridFormColumnCar");
            _raceGridView.GridColumnPosition.HeaderText = LanguageManager.GetString("RaceGridFormColumnPosition");
            _raceGridView.GridColumnBestLapTime.HeaderText = LanguageManager.GetString("RaceGridFormColumnBestLapTime");
            _raceGridView.GridColumnLapTime.HeaderText = LanguageManager.GetString("RaceGridFormColumnLapTime");
            _raceGridView.GridColumnLapTimeBestLapTime.HeaderText = LanguageManager.GetString("RaceGridFormColumnLapTimeBestLapTime");
            _raceGridView.GridColumnStatus.HeaderText = LanguageManager.GetString("RaceGridFormColumnStatus");
            _raceGridView.GridColumnPenalties.HeaderText = LanguageManager.GetString("RaceGridFormColumnPenalties");
            _raceGridView.ToolStripMenuItemLargerFont.Text = LanguageManager.GetString("ToolStripMenuItemLargerFont");
            _raceGridView.ToolStripMenuItemSmallerFont.Text = LanguageManager.GetString("ToolStripMenuItemSmallerFont");
            _raceGridView.ToolStripMenuItemLargerHeaderFont.Text = LanguageManager.GetString("ToolStripMenuItemLargerHeaderFont");
            _raceGridView.ToolStripMenuItemSmallerHeaderFont.Text = LanguageManager.GetString("ToolStripMenuItemSmallerHeaderFont");
            _raceGridView.ToolStripMenuItemSaveSettings.Text = LanguageManager.GetString("ToolStripMenuItemSaveSettings");
            _raceGridView.ToolStripMenuItemLoadSettings.Text = LanguageManager.GetString("ToolStripMenuItemLoadSettings");
            _raceGridView.ToolStripMenuItemColumns.Text = LanguageManager.GetString("ToolStripMenuItemColumns");
            _raceGridView.ToolStripMenuItemColumnId.Text = LanguageManager.GetString("ToolStripMenuItemColumnID");
            _raceGridView.ToolStripMenuItemColumnDriver.Text = LanguageManager.GetString("ToolStripMenuItemColumnDriver");
            _raceGridView.ToolStripMenuItemColumnCarPicture.Text = LanguageManager.GetString("ToolStripMenuItemColumnCarPicture");
            _raceGridView.ToolStripMenuItemColumnLaps.Text = LanguageManager.GetString("ToolStripMenuItemColumnLaps");
            _raceGridView.ToolStripMenuItemColumnPos.Text = LanguageManager.GetString("ToolStripMenuItemColumnPos");
            _raceGridView.ToolStripMenuItemColumnBestLapTime.Text = LanguageManager.GetString("ToolStripMenuItemColumnBestLapTime");
            _raceGridView.ToolStripMenuItemColumnLapTime.Text = LanguageManager.GetString("ToolStripMenuItemColumnLapTime");
            _raceGridView.ToolStripMenuItemColumnLapTimeBest.Text = LanguageManager.GetString("ToolStripMenuItemColumnLapTimeBest");
            _raceGridView.ToolStripMenuItemColumnStatus.Text = LanguageManager.GetString("ToolStripMenuItemColumnStatus");
            _raceGridView.ToolStripMenuItemColumnPenalties.Text = LanguageManager.GetString("ToolStripMenuItemColumnPenalties");
            _raceGridView.ToolStripMenuItemLargerStatusFont.Text = LanguageManager.GetString("ToolStripMenuItemLargerStatusFont");
            _raceGridView.ToolStripMenuItemSmallerStatusFont.Text = LanguageManager.GetString("ToolStripMenuItemSmallerStatusFont");
        }

        #region Nested type: RaceStatusLabels

        private enum RaceStatusLabels
        {
            Type = 0,
            Status = 1,
            RaceTime = 2
        }

        #endregion

    }
}