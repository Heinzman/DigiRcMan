using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.LoggingData;
using Elreg.BusinessObjects.Races;
using Elreg.DomainModels.Logs;
using Elreg.DomainModels.RaceReplay;
using Elreg.Log;
using Elreg.RaceOptionsService;
using Elreg.ResourcesService;
using Elreg.WindowsFormsPresenter.RaceControl;
using Elreg.WindowsFormsPresenter.RaceGrid;
using Elreg.WindowsFormsPresenter.RaceGrid.LapTime;
using Elreg.WindowsFormsView;
using Elreg.WinFormsPresentationFramework;
using Elreg.WinFormsPresentationFramework.DataTransferObjects;
using Timer = System.Timers.Timer;

namespace Elreg.WindowsFormsPresenter.RaceReplay
{
    public class RaceReplayPresenter : RacePresenter, IRaceGridPresenter, IRaceReplayPresenter
    {
        private readonly DriversService _driversService;
        private readonly CarsService _carsService;
        private readonly GridPresenterForComp _gridPresenterForComp;
        private readonly RaceGridRaceDto _raceGridRaceDto = new RaceGridRaceDto();
        private readonly ISimpleView _raceControlView;
        private readonly Timer _racingTimeTimer = new Timer();
        private readonly LapTimeHandler _lapTimeHandler;
        private string _lastRacingTime;
        private readonly ResourceProxy _resourceProxy = new ResourceProxy();
        private readonly PositionsCalculator _positionsCalculator;
        private RaceReplayModel _raceReplayModel;
        private int _indexRaceReplayData = -1;
        private IReplayHandler _replayHandler;
        private bool _isPaused = true;

        #region Columns enum

        private enum Columns
        {
            ColumnId,
            ColumnDriver,
            ColumnLapCount,
            ColumnCar,
            ColumnPosition,
            ColumnBestLapTime,
            ColumnLapTime,
            ColumnLapTimeBestLapTime,
            ColumnStatus,
            ColumnPenalties
        }

        #endregion

        public RaceReplayPresenter(IRaceReplayView raceGridView, IRaceModel raceModel, DriversService driversService, CarsService carsService)
            : base(raceModel)
        {
            _driversService = driversService;
            _carsService = carsService;
            try
            {
                RaceGridView = raceGridView;
                _raceControlView = null;
                _gridPresenterForComp = new GridPresenterForComp(raceGridView);
                InitRacingTimeTimer();
                LanguageManager.LanguageChanged += LanguageManagerLanguageChanged;
                AdjustCultureStrings();
                _lapTimeHandler = new LapTimeHandler(RaceModel, RaceGridView, this, false);
                _positionsCalculator = new PositionsCalculator(raceModel, RaceGridView);

                _raceReplayModel = new RaceReplayModel(LoggerModel.Inst.RaceReplayLogFileName);
                _raceReplayModel.ParseFile();

                _replayHandler = new ReplayByEventHandler(this);
                SetReplaySpeed();
                InitProgressbar();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public IRaceReplayView RaceGridView { get; private set; }

        private void InitProgressbar()
        {
            RaceGridView.ProgressBar.Maximum = _raceReplayModel.RaceReplayDataList.Count-1;
            RaceGridView.ProgressBar.Minimum = 0;
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
                RaceGridView.GrdLanes.Rows.Clear();
                foreach (RaceGridLaneDto raceGridLaneDto in _raceGridRaceDto.Lanes)
                {
                    RaceGridView.GrdLanes.Rows.Add();
                    int rowIndex = RaceGridView.GrdLanes.Rows.GetLastRow(DataGridViewElementStates.None);
                    RaceGridView.GrdLanes.Rows[rowIndex].Tag = raceGridLaneDto;
                    RaceGridView.GrdLanes[Columns.ColumnId.ToString(), rowIndex].Value = raceGridLaneDto.ScxId;
                    RaceGridView.GrdLanes[Columns.ColumnDriver.ToString(), rowIndex].Value = raceGridLaneDto.Driver;
                    RaceGridView.GrdLanes[Columns.ColumnLapCount.ToString(), rowIndex].Value = raceGridLaneDto.Lap;
                    RaceGridView.GrdLanes[Columns.ColumnCar.ToString(), rowIndex].Value = raceGridLaneDto.Car;
                    RaceGridView.GrdLanes[Columns.ColumnPosition.ToString(), rowIndex].Value = raceGridLaneDto.Position;
                    RaceGridView.GrdLanes[Columns.ColumnBestLapTime.ToString(), rowIndex].Value = raceGridLaneDto.BestLapTime;
                    RaceGridView.GrdLanes[Columns.ColumnLapTimeBestLapTime.ToString(), rowIndex].Value = raceGridLaneDto.LapTimeBestLapTime;
                    RaceGridView.GrdLanes[Columns.ColumnLapTime.ToString(), rowIndex].Value = raceGridLaneDto.LapTime;
                    RaceGridView.GrdLanes[Columns.ColumnStatus.ToString(), rowIndex].Value = raceGridLaneDto.StatusImage;
                    RaceGridView.GrdLanes[Columns.ColumnPenalties.ToString(), rowIndex].Value = raceGridLaneDto.PenaltiesText;

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
                foreach (Label label in RaceGridView.PositionLabels)
                {
                    if (label != null)
                        RaceGridView.SetControlPropertyThreadSafe(label, "Text", string.Empty);
                }

                foreach (PictureBox positionPicture in RaceGridView.PositionPictures)
                {
                    if (positionPicture != null)
                        RaceGridView.SetControlPropertyThreadSafe(positionPicture, "Image", null);
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
                if (RaceGridView.WindowState != FormWindowState.Minimized)
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
                foreach (DataGridViewRow row in RaceGridView.GrdLanes.Rows)
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
                RaceGridView.GridColumnStatus.DefaultCellStyle.NullValue = null;
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

        public int IndexRaceReplayData
        {
            get { return _indexRaceReplayData; }
        }

        public RaceReplayModel RaceReplayModel
        {
            get { return _raceReplayModel; }
        }

        public void ShowRaceControlForm()
        {
            try
            {
                FormHelper.HideForm(RaceGridView);
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
            try
            {
                RaceGridView.SetControlPropertyThreadSafe(RaceGridView.Labels[(int)RaceStatusLabels.Type], "Text", RaceModel.Race.Type.ToString());
                RaceGridView.SetControlPropertyThreadSafe(RaceGridView.Labels[(int)RaceStatusLabels.Status], "Text", RaceModel.Race.Status.ToString());
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        protected override void UpdateRace()
        {
            foreach (Lane lane in RaceModel.Race.Lanes)
                UpdateLane(lane);
        }

        protected override void UpdatePositions()
        {
            try
            {
                _positionsCalculator.UpdatePositions();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        protected override void UpdateLane(Lane lane)
        {
            try
            {
                LaneId laneId = lane.Id;
                int rowIndex = GetRowIndexBy(laneId);
                if (rowIndex >= 0)
                {
                    if (true)
                    {
                        RaceGridLaneDto raceGridLaneDto = CreateRaceGridLaneDtoFromModel(laneId);

                        if (raceGridLaneDto != null)
                        {
                            RaceGridView.GrdLanes[Columns.ColumnStatus.ToString(), rowIndex].Value = raceGridLaneDto.StatusImage;
                            if (lane.IsStartedOrInitializedOrFinished || lane.IsDisqualified)
                            {
                                RaceGridView.GrdLanes[Columns.ColumnLapCount.ToString(), rowIndex].Value = raceGridLaneDto.Lap;
                                UpdatePositionsOfLanes();
                                RaceGridView.GrdLanes[Columns.ColumnBestLapTime.ToString(), rowIndex].Value = raceGridLaneDto.BestLapTime;
                                RaceGridView.GrdLanes[Columns.ColumnLapTime.ToString(), rowIndex].Value = raceGridLaneDto.LapTime;
                                RaceGridView.GrdLanes[Columns.ColumnLapTimeBestLapTime.ToString(), rowIndex].Value = raceGridLaneDto.LapTimeBestLapTime;
                                RaceGridView.GrdLanes[Columns.ColumnPenalties.ToString(), rowIndex].Value = raceGridLaneDto.PenaltiesText;
                                CalcPenaltiesBackColor(rowIndex, raceGridLaneDto);
                                RaceGridView.GrdLanes[Columns.ColumnCar.ToString(), rowIndex].Value = raceGridLaneDto.Car;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
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

        private void CalcPenaltiesBackColor(int rowIndex, RaceGridLaneDto raceGridLaneDto)
        {
            if (RaceModel.RaceSettings.AutoDisqualificationRaceActivated)
            {
                Color color;
                int disqualiAfterPenalties = RaceModel.RaceSettings.AutoDisqualificationRaceAfterPenalties;
                int penaltiesCount = raceGridLaneDto.PenaltiesCount;

                if (penaltiesCount >= disqualiAfterPenalties - 1)
                    color = Color.IndianRed;
                else if (penaltiesCount >= disqualiAfterPenalties - 2)
                    color = Color.PaleGoldenrod;
                else
                    color = GetBackgroundColorOf(rowIndex);

                DataGridViewCell cell = RaceGridView.GrdLanes[Columns.ColumnPenalties.ToString(), rowIndex];
                DataGridViewCellStyle cellStyle = cell.Style.Clone();
                cellStyle.BackColor = color;
                cell.Style = cellStyle;
            }

        }

        private void SetBackgroundColorForSpecialColumnsOfRow(int rowIndex)
        {
            Color color = GetBackgroundColorOf(rowIndex);

            foreach (DataGridViewColumn column in RaceGridView.GrdLanes.Columns)
                RaceGridView.GrdLanes[column.Index, rowIndex].Style.BackColor = color;
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
                        RaceGridView.GrdLanes[Columns.ColumnPosition.ToString(), rowIndex].Value = raceGridLaneDto.Position;
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

        private void RacingTimeTimerElapsed(object sender, ElapsedEventArgs e)
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
            try
            {
                TimeSpan racingTimespan = RaceModel.GetNetTimeSpanFromStart();
                string racingTime = String.Format("{0:HH:mm:ss}", new DateTime(racingTimespan.Ticks));
                if (_lastRacingTime != racingTime)
                {
                    RaceGridView.SetControlPropertyThreadSafe(RaceGridView.Labels[(int)RaceStatusLabels.RaceTime], "Text", racingTime);
                    _lastRacingTime = racingTime;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AdjustCultureStrings()
        {
            RaceGridView.BtnShowRaceControlForm.Text = LanguageManager.GetString("RaceGridFormBtnShowRaceControlForm");
            RaceGridView.GridColumnId.HeaderText = LanguageManager.GetString("RaceGridFormColumnId");
            RaceGridView.GridColumnDriver.HeaderText = LanguageManager.GetString("RaceGridFormColumnDriver");
            RaceGridView.GridColumnLapCount.HeaderText = LanguageManager.GetString("RaceGridFormColumnLapCount");
            RaceGridView.GridColumnCar.HeaderText = LanguageManager.GetString("RaceGridFormColumnCar");
            RaceGridView.GridColumnPosition.HeaderText = LanguageManager.GetString("RaceGridFormColumnPosition");
            RaceGridView.GridColumnBestLapTime.HeaderText = LanguageManager.GetString("RaceGridFormColumnBestLapTime");
            RaceGridView.GridColumnLapTime.HeaderText = LanguageManager.GetString("RaceGridFormColumnLapTime");
            RaceGridView.GridColumnLapTimeBestLapTime.HeaderText = LanguageManager.GetString("RaceGridFormColumnLapTimeBestLapTime");
            RaceGridView.GridColumnStatus.HeaderText = LanguageManager.GetString("RaceGridFormColumnStatus");
            RaceGridView.GridColumnPenalties.HeaderText = LanguageManager.GetString("RaceGridFormColumnPenalties");
            RaceGridView.ToolStripMenuItemLargerFont.Text = LanguageManager.GetString("ToolStripMenuItemLargerFont");
            RaceGridView.ToolStripMenuItemSmallerFont.Text = LanguageManager.GetString("ToolStripMenuItemSmallerFont");
            RaceGridView.ToolStripMenuItemLargerHeaderFont.Text = LanguageManager.GetString("ToolStripMenuItemLargerHeaderFont");
            RaceGridView.ToolStripMenuItemSmallerHeaderFont.Text = LanguageManager.GetString("ToolStripMenuItemSmallerHeaderFont");
            RaceGridView.ToolStripMenuItemSaveSettings.Text = LanguageManager.GetString("ToolStripMenuItemSaveSettings");
            RaceGridView.ToolStripMenuItemLoadSettings.Text = LanguageManager.GetString("ToolStripMenuItemLoadSettings");
            RaceGridView.ToolStripMenuItemColumns.Text = LanguageManager.GetString("ToolStripMenuItemColumns");
            RaceGridView.ToolStripMenuItemColumnId.Text = LanguageManager.GetString("ToolStripMenuItemColumnID");
            RaceGridView.ToolStripMenuItemColumnDriver.Text = LanguageManager.GetString("ToolStripMenuItemColumnDriver");
            RaceGridView.ToolStripMenuItemColumnCarPicture.Text = LanguageManager.GetString("ToolStripMenuItemColumnCarPicture");
            RaceGridView.ToolStripMenuItemColumnLaps.Text = LanguageManager.GetString("ToolStripMenuItemColumnLaps");
            RaceGridView.ToolStripMenuItemColumnPos.Text = LanguageManager.GetString("ToolStripMenuItemColumnPos");
            RaceGridView.ToolStripMenuItemColumnBestLapTime.Text = LanguageManager.GetString("ToolStripMenuItemColumnBestLapTime");
            RaceGridView.ToolStripMenuItemColumnLapTime.Text = LanguageManager.GetString("ToolStripMenuItemColumnLapTime");
            RaceGridView.ToolStripMenuItemColumnLapTimeBest.Text = LanguageManager.GetString("ToolStripMenuItemColumnLapTimeBest");
            RaceGridView.ToolStripMenuItemColumnStatus.Text = LanguageManager.GetString("ToolStripMenuItemColumnStatus");
            RaceGridView.ToolStripMenuItemColumnPenalties.Text = LanguageManager.GetString("ToolStripMenuItemColumnPenalties");
            RaceGridView.ToolStripMenuItemLargerStatusFont.Text = LanguageManager.GetString("ToolStripMenuItemLargerStatusFont");
            RaceGridView.ToolStripMenuItemSmallerStatusFont.Text = LanguageManager.GetString("ToolStripMenuItemSmallerStatusFont");
        }

        #region Nested type: RaceStatusLabels

        private enum RaceStatusLabels
        {
            Type = 0,
            Status = 1,
            RaceTime = 2
        }

        #endregion

        public void ShowNextRaceReplayData()
        {
            try
            {
                if (_raceReplayModel.RaceReplayDataList != null)
                {
                    if (_raceReplayModel.RaceReplayDataList.Count > IndexRaceReplayData + 1)
                        _indexRaceReplayData = IndexRaceReplayData + 1;
                    UpdateRaceGridViewWithRaceReplayData();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void ShowPreviousRaceReplayData()
        {
            try
            {
                if (_raceReplayModel.RaceReplayDataList != null && _raceReplayModel.RaceReplayDataList.Count > 0)
                {
                    if (IndexRaceReplayData > 0)
                        _indexRaceReplayData = IndexRaceReplayData - 1;
                    UpdateRaceGridViewWithRaceReplayData();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void ShowFirstRaceReplayData()
        {
            try
            {
                if (_raceReplayModel.RaceReplayDataList != null && _raceReplayModel.RaceReplayDataList.Count > 0)
                {
                    _indexRaceReplayData = 0;
                    UpdateRaceGridViewWithRaceReplayData();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void ShowLastRaceReplayData()
        {
            try
            {
                if (_raceReplayModel.RaceReplayDataList != null && _raceReplayModel.RaceReplayDataList.Count > 0)
                {
                    _indexRaceReplayData = _raceReplayModel.RaceReplayDataList.Count-1;
                    UpdateRaceGridViewWithRaceReplayData();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void UpdateRaceGridViewWithRaceReplayData()
        {
            RaceReplayData raceReplayData = _raceReplayModel.RaceReplayDataList[IndexRaceReplayData];
            RaceReplayRaceModel raceReplayRaceModel = RaceModel as RaceReplayRaceModel;

            if (raceReplayData != null && raceReplayRaceModel != null)
            {
                raceReplayRaceModel.RaceReplayData = raceReplayData;
                CompleteRaceReplayData(raceReplayData, raceReplayRaceModel);
                UpdateReplayDescriptions(raceReplayData);
                FillView();
                UpdateRace();
                UpdatePositions();
                UpdateRacingTime();
                UpdateRaceStatus();
                UpdateLapTimeHandler(raceReplayData);
            }
        }

        private void UpdateReplayDescriptions(RaceReplayData raceReplayData)
        {
            try
            {
                RaceGridView.LblEventDescription.Text = raceReplayData.EventDescription;

                string racingTime = String.Format("{0:mm:ss.f}", new DateTime(raceReplayData.Race.RacingTime.NetTimeSpanFromStart.Ticks));
                RaceGridView.LblRaceTimeNet.Text = racingTime;

                RaceGridView.ProgressBar.Value = IndexRaceReplayData;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void UpdateLapTimeHandler(RaceReplayData raceReplayData)
        {
            try
            {
                _lapTimeHandler.ResetBackgroundColors();

                if (raceReplayData.LaneIdOfEvent.HasValue)
                {
                    switch (raceReplayData.RaceEvent)
                    {
                        case RaceEvent.InvalidLapDueMinLapTime:
                            _lapTimeHandler.LapNotAddedDueMinSeconds(raceReplayData.LaneIdOfEvent.Value);
                            break;
                        case RaceEvent.LapAdded:
                            _lapTimeHandler.LapAdded(raceReplayData.LaneIdOfEvent.Value);
                            break;
                        case RaceEvent.LaneFinished:
                            _lapTimeHandler.Finished(raceReplayData.LaneIdOfEvent.Value);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CompleteRaceReplayData(RaceReplayData raceReplayData, RaceReplayRaceModel raceReplayRaceModel)
        {
            try
            {
                if (raceReplayData.Race == null)
                {
                    raceReplayData.Race = new Race();
                    raceReplayData.EventDescription = "Error, sorry :-(";
                }
                else
                {
                    if (RaceModel.StatusHandler.IsRacePaused)
                        raceReplayData.Race.Type = RaceModel.Race.Type;
                    else
                        raceReplayData.Race.Type = Race.TypeEnum.Race;
                    raceReplayData.Race.RaceSettings = raceReplayRaceModel.RaceSettings;

                    foreach (Lane lane in raceReplayData.Race.Lanes)
                    {
                        Driver driver = _driversService.Drivers.Find(o => o.Id == lane.Driver.Id);
                        if (driver != null)
                            lane.Driver = driver;

                        Car car = _carsService.Cars.Find(o => o.Id == lane.Car.Id);
                        if (car != null)
                            lane.Car = car;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
                raceReplayData.EventDescription = "Error, sorry :-(";
            }
        }

        public void LoadLogFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
                                                {
                                                    FileName = "",
                                                    Filter = @"Race Replay File|RaceReplayLog*.txt|All Files|*.*",
                                                    InitialDirectory = ServiceHelper.LogsPath
                                                };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _raceReplayModel = new RaceReplayModel(openFileDialog.FileName);
                _raceReplayModel.ParseFile();
                InitProgressbar();
                ShowFirstRaceReplayData();
            }
        }

        public void HandlePlayOrPause()
        {
            if (_isPaused)
                Play();
            else
                Pause();
        }

        private void Play()
        {
            _replayHandler.Play();
            _isPaused = false;
            RaceGridView.BtnPlayOrPause.Text = "||";
        }

        public void Pause()
        {
            _replayHandler.Pause();
            _isPaused = true;
            RaceGridView.BtnPlayOrPause.Text = ">";
        }

        public void ChangeReplayPositionByProgressbar(double ratio)
        {
            if (_raceReplayModel.RaceReplayDataList != null && _raceReplayModel.RaceReplayDataList.Count > 0)
            {
                int position = (int)(_raceReplayModel.RaceReplayDataList.Count * ratio);
                if (position < _raceReplayModel.RaceReplayDataList.Count && position >= 0)
                {
                    _indexRaceReplayData = position;
                    UpdateRaceGridViewWithRaceReplayData();
                }
            }
        }

        public void HandleChkReplayByEventCheckedChanged()
        {
            Pause();

            bool shouldReplayByEvent = RaceGridView.ChkPlayInSteps.Checked;
            if (shouldReplayByEvent)
                _replayHandler = new ReplayByEventHandler(this);
            else
                _replayHandler = new ReplayByTimelineHandler(this);
            SetReplaySpeed();
        }

        public void HandleKey(KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyData == (Keys.G | Keys.Control))
                ShowFirstRaceReplayData();
            else if (keyEventArgs.KeyData == (Keys.H | Keys.Control))
                ShowPreviousRaceReplayData();
            else if (keyEventArgs.KeyData == (Keys.J | Keys.Control))
                HandlePlayOrPause();
            else if (keyEventArgs.KeyData == (Keys.K | Keys.Control))
                ShowNextRaceReplayData();
            else if (keyEventArgs.KeyData == (Keys.L | Keys.Control))
                ShowLastRaceReplayData();
        }

        public void HandleUdSpeedValueChanged()
        {
            SetReplaySpeed();
        }

        private void SetReplaySpeed()
        {
            _replayHandler.ReplaySpeed = (uint) RaceGridView.UdSpeed.Value;
        }
    }
}