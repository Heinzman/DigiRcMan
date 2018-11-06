using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Elreg.BusinessObjects.Lanes;
using Elreg.Log;
using Elreg.RaceOptionsService;
using Elreg.WindowsFormsPresenter.InitUpdateLanes;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class InitLanesForm : WinFormsPresentationFramework.Forms.Form, IInitLanesView
    {
        private readonly InitLanesPresenter _initLanesPresenter;
        private bool _ok;

        public InitLanesForm(DriversService driversService, CarsService carsService)
        {
            try
            {
                InitializeComponent();

                ColumnCarPicture.DefaultCellStyle.NullValue = null;
                _initLanesPresenter = new InitLanesPresenter(this, driversService, carsService);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        #region IInitLanesView Members

        public List<InitialLane> InitialLanes
        {
            get { return _initLanesPresenter.InitialLanes; }
        }

        public bool Ok
        {
            get { return _ok; }
        }

        public Button BtnRefresh
        {
            get { return btnRefresh; }
        }

        public Button BtnRotateUp
        {
            get { return btnRotateUp; }
        }

        public Button BtnRotateDown
        {
            get { return btnRotateDown; }
        }

        public Button BtnRandomize
        {
            get { return btnRandomize; }
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

        public DataGridViewColumn GridColumnGhostcar
        {
            get { return ColumnGhostcar; }
        }

        public DataGridViewColumn GridColumnDriver
        {
            get { return ColumnDriver; }
        }

        public DataGridViewColumn GridColumnCar
        {
            get { return ColumnCar; }
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

        public DataGridView GrdLanes
        {
            get { return grdLanes; }
        }

        #endregion

        private void BtnOkClick(object sender, EventArgs e)
        {
            try
            {
                if (_initLanesPresenter.Validate())
                {
                    _initLanesPresenter.SaveData();
                    _ok = true;
                    CheckIfSettingsChangedAndClose();
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
                CheckIfSettingsChangedAndClose();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CheckIfSettingsChangedAndClose()
        {
            CheckIfSettingsChanged();
            Close();
        }

        private void CheckIfSettingsChanged()
        {
            _initLanesPresenter.CheckIfSettingsChanged();
        }

        private void InitLanesFormLoad(object sender, EventArgs e)
        {
            try
            {
                _initLanesPresenter.AdjustCultureStrings();
                _initLanesPresenter.FillView();
                _initLanesPresenter.LoadGridSettings();
                _initLanesPresenter.CheckToShowGridColumnGhostcar();
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
                if (WindowState != FormWindowState.Minimized && _initLanesPresenter != null)
                    _initLanesPresenter.SizeGrid();
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
                _initLanesPresenter.IncreaseCellFont();
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
                _initLanesPresenter.DecreaseCellFont();
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
                _initLanesPresenter.SaveGridSettings();
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
                _initLanesPresenter.LoadGridSettingsChooseSource();
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
                if (_initLanesPresenter != null)
                    _initLanesPresenter.HandleCellValueChanged(e);
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
                _initLanesPresenter.UpdateAllDependentValues();
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
                _initLanesPresenter.SizeGrid();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnRandomizeClick(object sender, EventArgs e)
        {
            try
            {
                _initLanesPresenter.RandomizeLanes();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnRotateDownClick(object sender, EventArgs e)
        {
            try
            {
                _initLanesPresenter.RotateDownLanes();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnRotateUpClick(object sender, EventArgs e)
        {
            try
            {
                _initLanesPresenter.RotateUpLanes();
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
                _initLanesPresenter.IncreaseHeaderCellFont();
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
                _initLanesPresenter.DecreaseHeaderCellFont();
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
                if (e.KeyData == Keys.Space || e.KeyData == Keys.Delete)
                    _initLanesPresenter.CheckToSetEmptyItem();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void GrdLanesCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == ColumnGhostcar.Index && e.RowIndex == -1)
                {
                    Image image = Properties.Resources.Ghost;
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    Rectangle rectangle = new Rectangle(e.CellBounds.X + 5, e.CellBounds.Y + 5, e.CellBounds.Width - 10, e.CellBounds.Height - 10);
                    e.Graphics.DrawImage(image, rectangle);
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

    }
}