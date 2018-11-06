using System;
using System.Windows.Forms;
using Elreg.BusinessObjects.Interfaces;
using Elreg.DomainModels;
using Elreg.Log;
using Elreg.RaceControlService;
using Elreg.WindowsFormsPresenter;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class RaceResultsForm : WinFormsPresentationFramework.Forms.Form, IRaceResultsView
    {
        private readonly RaceResultsPresenter _raceResultsPresenter;
        private readonly RaceKeyController _raceKeyController;
        private bool _ok;

        public RaceResultsForm(RaceKeyController raceKeyController, RaceResultsModel raceResultsModel)
        {
            InitializeComponent();
            TopMost = true;
            _raceResultsPresenter = new RaceResultsPresenter(this, raceResultsModel);
            _raceKeyController = raceKeyController;
            KeyDown += RaceResultsFormKeyDown;
        }

        #region IRaceResultsView Members

        public Button BtnClose
        {
            get { return btnClose; }
        }

        public bool Ok
        {
            get { return _ok && _raceResultsPresenter.CanBeUsedForChampionship; }
        }

        public DataGridView GrdLanes
        {
            get { return grdLanes; }
        }

        public void CreateRaceResult()
        {
            _raceResultsPresenter.CreateRaceResult();
        }

        public void LoadAndShow(string raceResultsXmlFile)
        {
            _raceResultsPresenter.LoadAndShow(raceResultsXmlFile);
        }

        public IRaceResult RaceResult
        {
            get { return _raceResultsPresenter.RaceResult; }
            set { _raceResultsPresenter.RaceResult = value; }
        }

        public string Caption
        {
            set { Text = value; }
        }

        public Button BtnSave
        {
            get { return btnSave; }
        }

        public Button BtnDelete
        {
            get { return btnDelete; }
        }

        public bool BtnDeleteVisible
        {
            set
            {
                MethodInvoker uiDelegate = delegate { btnDelete.Visible = value; };
                UpdateUi(uiDelegate);
            }
        }

        public bool BtnSaveVisible
        {
            set
            {
                MethodInvoker uiDelegate = delegate { btnSave.Visible = value; };
                UpdateUi(uiDelegate);
            }
        }

        public string ToolStripMenuItemLargerFontText
        {
            set
            {
                MethodInvoker uiDelegate = delegate { toolStripMenuItemLargerFont.Text = value; };
                UpdateUi(uiDelegate);
            }
        }

        public string ToolStripMenuItemSmallerFontText
        {
            set
            {
                MethodInvoker uiDelegate = delegate { toolStripMenuItemSmallerFont.Text = value; };
                UpdateUi(uiDelegate);
            }
        }

        public string ToolStripMenuItemLargerHeaderFontText
        {
            set
            {
                MethodInvoker uiDelegate = delegate { toolStripMenuItemLargerHeaderFont.Text = value; };
                UpdateUi(uiDelegate);
            }
        }

        public string ToolStripMenuItemSmallerHeaderFontText
        {
            set
            {
                MethodInvoker uiDelegate = delegate { toolStripMenuItemSmallerHeaderFont.Text = value; };
                UpdateUi(uiDelegate);
            }
        }

        public string ToolStripMenuItemSaveSettingsText
        {
            set
            {
                MethodInvoker uiDelegate = delegate { toolStripMenuItemSaveSettings.Text = value; };
                UpdateUi(uiDelegate);
            }
        }

        public string ToolStripMenuItemLoadSettingsText
        {
            set
            {
                MethodInvoker uiDelegate = delegate { toolStripMenuItemLoadSettings.Text = value; };
                UpdateUi(uiDelegate);
            }
        }

        public string GridColumnPositionHeaderText
        {
            set
            {
                MethodInvoker uiDelegate = delegate { ColumnPosition.HeaderText = value; };
                UpdateUi(uiDelegate);
            }
        }

        public string GridColumnDriverHeaderText
        {
            set
            {
                MethodInvoker uiDelegate = delegate { ColumnDriver.HeaderText = value; };
                UpdateUi(uiDelegate);
            }
        }

        public string GridColumnPointsHeaderText
        {
            set
            {
                MethodInvoker uiDelegate = delegate { ColumnPoints.HeaderText = value; };
                UpdateUi(uiDelegate);
            }
        }

        public string GridColumnCarHeaderText
        {
            set
            {
                MethodInvoker uiDelegate = delegate { ColumnCar.HeaderText = value; };
                UpdateUi(uiDelegate);
            }
        }

        public string GridColumnLapCountHeaderText
        {
            set
            {
                MethodInvoker uiDelegate = delegate { ColumnLapCount.HeaderText = value; };
                UpdateUi(uiDelegate);
            }
        }

        public string GridColumnBestLapTimeHeaderText
        {
            set
            {
                MethodInvoker uiDelegate = delegate { ColumnBestLapTime.HeaderText = value; };
                UpdateUi(uiDelegate);
            }
        }

        public string GridColumnPenaltiesHeaderText
        {
            set
            {
                MethodInvoker uiDelegate = delegate { ColumnPenalties.HeaderText = value; };
                UpdateUi(uiDelegate);
            }
        }

        public string GridColumnRaceTimeNetHeaderText
        {
            set
            {
                MethodInvoker uiDelegate = delegate { ColumnRaceTimeNet.HeaderText = value; };
                UpdateUi(uiDelegate);
            }
        }

        public int GetIndexOfAddedRowInGrdLanes()
        {
            MethodInvoker uiDelegate = () => grdLanes.Rows.Add();
            UpdateUi(uiDelegate);
            int rowIndex = grdLanes.Rows.GetLastRow(DataGridViewElementStates.None);
            return rowIndex;
        }

        #endregion

        private void RaceResultsFormKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                _raceKeyController.HandleKey(e);
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
                _ok = true;
                SaveSettings();
                Hide();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnDeleteClick(object sender, EventArgs e)
        {
            try
            {
                if (_raceResultsPresenter.ConfirmDeleting())
                {
                    _ok = false;
                    Hide();
                    _raceResultsPresenter.DeleteRaceResult();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            try
            {
                _raceResultsPresenter.SaveData();
                _raceResultsPresenter.InformSaved();
                _raceResultsPresenter.FillData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceResultsFormLoad(object sender, EventArgs e)
        {
            try
            {
                _raceResultsPresenter.LoadGridSettings();
                _raceResultsPresenter.FillData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void GrdLanesDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void GrdLanesSizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (WindowState != FormWindowState.Minimized && _raceResultsPresenter != null)
                    _raceResultsPresenter.SizeGrid();
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
                _raceResultsPresenter.IncreaseCellFont();
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
                _raceResultsPresenter.DecreaseCellFont();
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
                _raceResultsPresenter.SaveGridSettings();
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
                _raceResultsPresenter.LoadGridSettingsChooseSource();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void GrdLanesCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_raceResultsPresenter != null && _raceResultsPresenter.GridResultFilled && e.ColumnIndex >= 0 && e.RowIndex >= 0)
                    _raceResultsPresenter.UpdateLaneAfterChanges(e.ColumnIndex, e.RowIndex);
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
                _raceResultsPresenter.HandleGridKey(e);
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

        private void SizeGrid()
        {
            if (WindowState != FormWindowState.Minimized && _raceResultsPresenter != null)
                _raceResultsPresenter.SizeGrid();
        }

        private void ToolStripMenuItemLargerHeaderFontClick(object sender, EventArgs e)
        {
            try
            {
                _raceResultsPresenter.IncreaseHeaderCellFont();
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
                _raceResultsPresenter.DecreaseHeaderCellFont();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CopyTableToClipboardToolStripMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                _raceResultsPresenter.CopyTableToClipboard();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }
    }
}