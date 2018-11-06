using System;
using System.Windows.Forms;
using Elreg.BusinessObjects.Championships;
using Elreg.Controls;
using Elreg.Log;
using Elreg.RaceControlService;
using Elreg.ResourcesService;
using Elreg.WindowsFormsPresenter;
using Elreg.WindowsFormsView;
using Form = Elreg.WinFormsPresentationFramework.Forms.Form;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class ChampionshipForm : WinFormsPresentationFramework.Forms.Form, IChampionshipView
    {
        private readonly RaceKeyController _raceKeyController;
        private readonly ChampionshipPresenter _championshipPresenter;

        public ChampionshipForm(RaceKeyController raceKeyController)
        {
            InitializeComponent();
            _championshipPresenter = new ChampionshipPresenter(this);
            _raceKeyController = raceKeyController;
            KeyDown += ChampionshipFormKeyDown;
            LanguageManager.LanguageChanged += LanguageManagerLanguageChanged;
        }

        private void LanguageManagerLanguageChanged(object sender, EventArgs e)
        {
            try
            {
                _championshipPresenter.AdjustCultureStrings();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        #region IChampionshipView Members

        public PrettyGrid GrdLanes
        {
            get { return grdLanes; }
        }

        public void LoadAndShow(string championshipXmlFile)
        {
            _championshipPresenter.LoadAndShow(championshipXmlFile);
        }

        public string Caption
        {
            set { Text = value; }
        }

        public Button BtnSave
        {
            get { return btnSave; }
        }

        public Button BtnClose
        {
            get { return btnClose; }
        }

        public DataGridViewColumn GridColumnPosition
        {
            get { return ColumnPosition; }
        }

        public DataGridViewColumn GridColumnDriver
        {
            get { return ColumnDriver; }
        }

        public DataGridViewColumn GridColumnPoints
        {
            get { return ColumnPoints; }
        }

        public void AddToLatest(RaceResult raceResult)
        {
            _championshipPresenter.NewChampionship = false;
            _championshipPresenter.Add(raceResult);
        }

        public void AddToNew(RaceResult raceResult)
        {
            _championshipPresenter.NewChampionship = true;
            _championshipPresenter.Add(raceResult);
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

        private void ChampionshipFormKeyDown(object sender, KeyEventArgs e)
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

        private void BtnSaveClick(object sender, EventArgs e)
        {
            try
            {
                _championshipPresenter.SaveData();
                Close();
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

        private void ChampionshipFormLoad(object sender, EventArgs e)
        {
            try
            {
                _championshipPresenter.AdjustCultureStrings();
                _championshipPresenter.FillData();
                _championshipPresenter.LoadGridSettings();
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
                if (WindowState != FormWindowState.Minimized && _championshipPresenter != null)
                    _championshipPresenter.SizeGrid();
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
                _championshipPresenter.IncreaseCellFont();
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
                _championshipPresenter.DecreaseCellFont();
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
                _championshipPresenter.SaveGridSettings();
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
                _championshipPresenter.LoadGridSettingsChooseSource();
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
                if (_championshipPresenter != null && _championshipPresenter.GridResultFilled && e.ColumnIndex >= 0 &&
            e.RowIndex >= 0)
                    _championshipPresenter.UpdateLaneAfterChanges(e.ColumnIndex, e.RowIndex);
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
                _championshipPresenter.HandleGridKey(e);
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
            if (WindowState != FormWindowState.Minimized && _championshipPresenter != null)
                _championshipPresenter.SizeGrid();
        }

        private void ToolStripMenuItemLargerHeaderFontClick(object sender, EventArgs e)
        {
            try
            {
                _championshipPresenter.IncreaseHeaderCellFont();
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
                _championshipPresenter.DecreaseHeaderCellFont();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ToolStripMenuItemCopyToClipboardClick(object sender, EventArgs e)
        {
            try
            {
                _championshipPresenter.CopyTableToClipboard();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

    }
}