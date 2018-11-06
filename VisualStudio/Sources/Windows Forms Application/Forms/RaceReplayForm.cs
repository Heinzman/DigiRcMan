using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elreg.Controls.ProgressColumns;
using Elreg.DomainModels.RaceModel;
using Elreg.DomainModels.RaceReplay;
using Elreg.RaceOptionsService;
using Elreg.WindowsFormsPresenter.RaceReplay;
using Elreg.WindowsFormsView;
using Elreg.Log;
using Elreg.WinFormsPresentationFramework.DataTransferObjects;
using Form = Elreg.WinFormsPresentationFramework.Forms.Form;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class RaceReplayForm : Form, IRaceReplayView 
    {
        private readonly RaceReplayPresenter _raceGridPresenter;

        public RaceReplayForm(RaceModel raceModel, DriversService driversService, CarsService carsService)
        {
            try
            {
                InitializeComponent();

                RaceReplayRaceModel raceReplayRaceModel = new RaceReplayRaceModel(raceModel);
                _raceGridPresenter = new RaceReplayPresenter(this, raceReplayRaceModel, driversService, carsService);
                _raceGridPresenter.InitializeGridColumns();
                _raceGridPresenter.ClearPositions();
                FormBorderStyle = FormBorderStyle.Sizable;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public Label LblEventDescription
        {
            get { return lblEventDescription; }
        }

        public Label LblRaceTimeNet
        {
            get { return lblRaceTimeNet; }
        }

        public ProgressBar ProgressBar
        {
            get { return progressBar1; }
        }

        public CheckBox ChkPlayInSteps
        {
            get { return chkReplayByEvent; }
        }

        public Button BtnPlayOrPause
        {
            get { return btnPlayOrPause; }
        }

        public NumericUpDown UdSpeed
        {
            get { return udSpeed; }
        }

        public DataGridView GrdLanes
        {
            get { return grdLanes; }
        }

        public ToolStripMenuItem MenuItemColumns
        {
            get { return ColumnsMenuItem; }
        }

        public string RaceStatus
        {
            set { SetControlPropertyThreadSafe(this, "Text", value); }
        }

        public SplitContainer SplitContainerStatus
        {
            get { return splitContainer1; }
        }

        public SplitContainer SplitContainerPosition
        {
            get { return splitContainer2; }
        }

        public List<Label> Labels
        {
            get 
            {
                List<Label> labels = new List<Label> {lblRaceType, lblStatus, lblRaceTime};
                return labels; 
            }
        }

        public DataGridViewImageColumn GridColumnStatus
        {
            get { return ColumnStatus; }
        }

        public DataGridViewTextBoxColumn GridColumnDriver
        {
            get { return ColumnDriver; }
        }

        public DataGridViewColumn GridColumnId
        {
            get { return ColumnID; }
        }

        public DataGridViewColumn GridColumnLapCount
        {
            get { return ColumnLapCount; }
        }

        public DataGridViewColumn GridColumnPenalties
        {
            get { return ColumnPenalties; }
        }

        public DataGridViewColumn GridColumnCar
        {
            get { return ColumnCar; }
        }

        public DataGridViewColumn GridColumnRockets
        {
            get { return ColumnRockets; }
        }

        public DataGridViewColumn GridColumnPosition
        {
            get { return ColumnPosition; }
        }

        public DataGridViewColumn GridColumnBestLapTime
        {
            get { return ColumnBestLapTime; }
        }

        public DataGridViewColumn GridColumnLapTime
        {
            get { return ColumnLapTime; }
        }

        public DataGridViewColumn GridColumnLapTimeBestLapTime
        {
            get { return ColumnLapTimeBestLapTime; }
        }

        public ToolStripMenuItem ToolStripMenuItemLargerFont
        {
            get { return toolStripMenuItemLargerFont; }
        }

        public ToolStripMenuItem ToolStripMenuItemSmallerFont
        {
            get { return toolStripMenuItemSmallerFont; }
        }

        public ToolStripMenuItem ToolStripMenuItemLargerHeaderFont
        {
            get { return toolStripMenuItemLargerHeaderFont; }
        }

        public ToolStripMenuItem ToolStripMenuItemSmallerHeaderFont
        {
            get { return toolStripMenuItemSmallerHeaderFont; }
        }

        public ToolStripMenuItem ToolStripMenuItemSaveSettings
        {
            get { return toolStripMenuItemSaveSettings; }
        }

        public ToolStripMenuItem ToolStripMenuItemLoadSettings
        {
            get { return toolStripMenuItemLoadSettings; }
        }

        public ToolStripMenuItem ToolStripMenuItemColumns
        {
            get { return ColumnsMenuItem; }
        }

        public ToolStripMenuItem ToolStripMenuItemColumnId
        {
            get { return ColumnIDMenuItem; }
        }

        public ToolStripMenuItem ToolStripMenuItemColumnDriver
        {
            get { return DriverMenuItem; }
        }

        public ToolStripMenuItem ToolStripMenuItemColumnCarPicture
        {
            get { return CarPictureMenuItem; }
        }

        public ToolStripMenuItem ToolStripMenuItemColumnLaps
        {
            get { return LapsMenuItem; }
        }

        public ToolStripMenuItem ToolStripMenuItemColumnPos
        {
            get { return PosMenuItem; }
        }

        public ToolStripMenuItem ToolStripMenuItemColumnBestLapTime
        {
            get { return BestLapTimeMenuItem; }
        }

        public ToolStripMenuItem ToolStripMenuItemColumnLapTime
        {
            get { return LapTimeMenuItem; }
        }

        public ToolStripMenuItem ToolStripMenuItemColumnLapTimeBest
        {
            get { return LapTimeBestMenuItem; }
        }

        public ToolStripMenuItem ToolStripMenuItemColumnStatus
        {
            get { return StatusMenuItem; }
        }

        public ToolStripMenuItem ToolStripMenuItemColumnPenalties
        {
            get { return PenaltiesMenuItem; }
        }

        public ToolStripMenuItem ToolStripMenuItemLargerStatusFont
        {
            get { return toolStripMenuItemLargerStatusFont; }
        }

        public ToolStripMenuItem ToolStripMenuItemSmallerStatusFont
        {
            get { return toolStripMenuItemSmallerStatusFont; }
        }

        public PictureBox GetPicPositionOf(int position)
        {
            PictureBox pictureBox = null;
            switch (position)
            {
                case 1:
                    pictureBox = picPosition1;
                    break;
                case 2:
                    pictureBox = picPosition2;
                    break;
                case 3:
                    pictureBox = picPosition3;
                    break;
                case 4:
                    pictureBox = picPosition4;
                    break;
                case 5:
                    pictureBox = picPosition5;
                    break;
                case 6:
                    pictureBox = picPosition6;
                    break;
            }
            return pictureBox;
        }

        public Label GetLblPositionOf(int position)
        {
            Label label = null;
            switch (position)
            {
                case 1:
                    label = lblPosition1;
                    break;
                case 2:
                    label = lblPosition2;
                    break;
                case 3:
                    label = lblPosition3;
                    break;
                case 4:
                    label = lblPosition4;
                    break;
                case 5:
                    label = lblPosition5;
                    break;
                case 6:
                    label = lblPosition6;
                    break;
            }
            return label;
        }

        public List<Label> PositionLabels
        {
            get { return new List<Label> { lblPosition1, lblPosition2, lblPosition3, lblPosition4, lblPosition5, lblPosition6 }; }
        }

        public List<PictureBox> PositionPictures
        {
            get { return new List<PictureBox> { picPosition1, picPosition2, picPosition3, picPosition4, picPosition5, picPosition6 }; }
        }

        public Button BtnShowRaceControlForm
        {
            get { return btnShowRaceControlForm; }
        }

        public void FillView()
        {
            _raceGridPresenter.FillView();
        }

        protected override void LoadSettings()
        {
            // nothing to do
        }

        protected override void SaveSettings()
        {
            // nothing to do
        }

        private void SizeGrid()
        {
            if (WindowState != FormWindowState.Minimized && _raceGridPresenter != null)
                _raceGridPresenter.SizeGrid();
        }

        private void GrdLanesCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                RaceGridLaneDto raceGridLaneDto = grdLanes.Rows[e.RowIndex].DataBoundItem as RaceGridLaneDto;
                DataGridViewColumn columnId = grdLanes.Columns[ColumnID.Name];

                if (grdLanes != null &&
                    columnId != null &&
                    raceGridLaneDto != null && ColumnID != null &&
                    e.ColumnIndex != columnId.Index)
                {
                    DataGridViewCellStyle cellStyle = e.CellStyle.Clone();
                    cellStyle.BackColor = raceGridLaneDto.Color;
                    e.CellStyle = cellStyle;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void GrdLanesKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                _raceGridPresenter.HandleGridKey(e);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ToolStripMenuItemLargerFontClick(object sender, EventArgs e)
        {
            try
            {
                _raceGridPresenter.IncreaseCellFont();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ToolStripMenuItemSmallerFontClick(object sender, EventArgs e)
        {
            try
            {
                _raceGridPresenter.DecreaseCellFont();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ToolStripMenuItemSaveSettingsClick(object sender, EventArgs e)
        {
            try
            {
                _raceGridPresenter.SaveGridSettings();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceGridFormLoad(object sender, EventArgs e)
        {
            try
            {
                _raceGridPresenter.LoadGridSettings();
                _raceGridPresenter.ShowFirstRaceReplayData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void GrdLanesDataError(object sender, DataGridViewDataErrorEventArgs e)
        {}

        private void RaceGridFormKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                _raceGridPresenter.HandleKey(e);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ToolStripMenuItemLoadSettingsClick(object sender, EventArgs e)
        {
            try
            {
                _raceGridPresenter.LoadGridSettingsChooseSource();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ColumnMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
                if (toolStripMenuItem != null)
                {
                    string columnName = toolStripMenuItem.Tag.ToString();
                    DataGridViewColumn column = grdLanes.Columns[columnName];
                    if (column != null)
                    {
                        column.Visible = !toolStripMenuItem.Checked;
                        toolStripMenuItem.Checked = !toolStripMenuItem.Checked;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceGridFormFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _raceGridPresenter.CheckIfSettingsChanged();

                if (e.CloseReason != CloseReason.ApplicationExitCall)
                {
                    e.Cancel = true;
                    Visible = false;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void GrdLanesColumnHeadersHeightChanged(object sender, EventArgs e)
        {
            try
            {
                SizeGrid();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ToolStripMenuItemLargerHeaderFontClick(object sender, EventArgs e)
        {
            try
            {
                _raceGridPresenter.IncreaseHeaderCellFont();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ToolStripMenuItemSmallerHeaderFontClick(object sender, EventArgs e)
        {
            try
            {
                _raceGridPresenter.DecreaseHeaderCellFont();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ToolStripMenuItemLargerStatusFontClick(object sender, EventArgs e)
        {
            try
            {
                _raceGridPresenter.IncreaseStatusCellFont();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ToolStripMenuItemSmallerStatusFontClick(object sender, EventArgs e)
        {
            try
            {
                _raceGridPresenter.DecreaseStatusCellFont();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnMinimizeClick(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Minimized;
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
                Close();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnNormalizeClick(object sender, EventArgs e)
        {
            try
            {
                if (WindowState == FormWindowState.Maximized)
                {
                    WindowState = FormWindowState.Normal;
                    FormBorderStyle = FormBorderStyle.Sizable;
                }
                else
                {
                    WindowState = FormWindowState.Maximized;
                    FormBorderStyle = FormBorderStyle.None;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SplitContainer1SplitterMoved(object sender, SplitterEventArgs e)
        {
            try
            {
                if (Visible)
                    SizeGrid();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnShowRaceControlFormClick(object sender, EventArgs e)
        {
            try
            {
                _raceGridPresenter.ShowRaceControlForm();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ToolStripMenuItemPositionsfontLargerClick(object sender, EventArgs e)
        {
            try
            {
                _raceGridPresenter.IncreasePositionsCellFont();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ToolStripMenuItemPositionsfontSmallerClick(object sender, EventArgs e)
        {
            try
            {
                _raceGridPresenter.DecreasePositionsCellFont();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SplitContainer2SplitterMoved(object sender, SplitterEventArgs e)
        {
            try
            {
                _raceGridPresenter.SizeGrid();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceGridWithPositionFormSizeChanged(object sender, EventArgs e)
        {
            SizeGrid();
        }

        private void BtnNextStepClick(object sender, EventArgs e)
        {
            try
            {
                _raceGridPresenter.ShowNextRaceReplayData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnPreviousStepClick(object sender, EventArgs e)
        {
            try
            {
                _raceGridPresenter.ShowPreviousRaceReplayData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnLastStepClick(object sender, EventArgs e)
        {
            try
            {
                _raceGridPresenter.ShowLastRaceReplayData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnFirstStepClick(object sender, EventArgs e)
        {
            try
            {
                _raceGridPresenter.ShowFirstRaceReplayData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnLoadFileClick(object sender, EventArgs e)
        {
            try
            {
                _raceGridPresenter.LoadLogFile();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnPlayOrPauseClick(object sender, EventArgs e)
        {
            try
            {
                _raceGridPresenter.HandlePlayOrPause();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ProgressBar1Click(object sender, EventArgs e)
        {
            try
            {
                int position = PointToClient(MousePosition).X - progressBar1.Bounds.X;
                double ratio = (double)position / progressBar1.Bounds.Width;

                _raceGridPresenter.ChangeReplayPositionByProgressbar(ratio);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ChkReplayByEventCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                _raceGridPresenter.HandleChkReplayByEventCheckedChanged();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void UdSpeedValueChanged(object sender, EventArgs e)
        {
            try
            {
                _raceGridPresenter.HandleUdSpeedValueChanged();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

    }
}