using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elreg.BusinessObjects.Lanes;
using Elreg.Log;
using Elreg.RaceOptionsService;
using Elreg.WindowsFormsPresenter.InitUpdateLanes;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class UpdateLanesForm : WinFormsPresentationFramework.Forms.Form, IUpdateLanesView
    {
        private readonly UpdateLanesPresenter _updateLanesPresenter;
        private bool _ok;

        public UpdateLanesForm(List<Lane> lanes, DriversService driversService, CarsService carsService)
        {
            InitializeComponent();
            _updateLanesPresenter = new UpdateLanesPresenter(lanes, this, driversService, carsService);
        }

        #region IUpdateLanesView Members

        public bool Ok
        {
            get { return _ok; }
        }

        public Button BtnRefresh
        {
            get { return btnRefresh; }
        }

        public Button BtnOk
        {
            get { return btnOk; }
        }

        public Button BtnCancel
        {
            get { return btnCancel; }
        }

        public DataGridViewColumn GridColumnId
        {
            get { return ColumnID; }
        }

        public DataGridViewColumn GridColumnDriver
        {
            get { return ColumnDriver; }
        }

        public DataGridViewColumn GridColumnCar
        {
            get { return ColumnCar; }
        }

        public DataGridViewColumn GridColumnLapCount
        {
            get { return ColumnLapCount; }
        }

        public DataGridViewColumn GridColumnStatus
        {
            get { return ColumnStatus; }
        }

        public DataGridViewColumn GridColumnOverallPenalties
        {
            get { return ColumnOverallPenalties; }
        }

        public List<ChangedLane> ChangedLanes
        {
            get { return _updateLanesPresenter.ChangedLanes; }
        }

        public DataGridView GrdLanes
        {
            get { return grdLanes; }
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

        #endregion

        private void BtnOkClick(object sender, EventArgs e)
        {
            try
            {
                if (_updateLanesPresenter.Validate())
                {
                    _ok = true;
                    Close();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnCancelClick(object sender, EventArgs e)
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

        private void UpdateLanesFormLoad(object sender, EventArgs e)
        {
            try
            {
                _updateLanesPresenter.FillView();
                _updateLanesPresenter.LoadGridSettings();
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
                if (WindowState != FormWindowState.Minimized && _updateLanesPresenter != null)
                    _updateLanesPresenter.SizeGrid();
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
                _updateLanesPresenter.IncreaseCellFont();
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
                _updateLanesPresenter.DecreaseCellFont();
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
                _updateLanesPresenter.SaveGridSettings();
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
                _updateLanesPresenter.LoadGridSettingsChooseSource();
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
                if (_updateLanesPresenter != null)
                    _updateLanesPresenter.HandleCellValueChanged(e);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnRefreshClick(object sender, EventArgs e)
        {
            try
            {
                _updateLanesPresenter.UpdateAllDependentValues();
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
                if (_updateLanesPresenter != null)
                    _updateLanesPresenter.SizeGrid();
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
                _updateLanesPresenter.IncreaseHeaderCellFont();
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
                _updateLanesPresenter.DecreaseHeaderCellFont();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }
    }
}