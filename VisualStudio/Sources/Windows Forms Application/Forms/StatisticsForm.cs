using System;
using System.Windows.Forms;
using Elreg.BusinessObjects.Options;
using Elreg.Log;
using Elreg.RaceStatisticsService;
using Elreg.WindowsFormsPresenter;
using Elreg.WindowsFormsView;
using Form = Elreg.WinFormsPresentationFramework.Forms.Form;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class StatisticsForm : WinFormsPresentationFramework.Forms.Form, IStatisticsView
    {
        private readonly StatisticsPresenter _statisticsPresenter;
        private bool _dataFilled;

        public StatisticsForm(StatisticLogger statisticLogger, RaceSettings raceSettings)
        {
            InitializeComponent();
            _statisticsPresenter = new StatisticsPresenter(this, statisticLogger, raceSettings);
        }

        #region IStatisticsView Members

        public DataGridView GrdStatistics
        {
            get { return _grdStatistics; }
        }

        public ComboBox CbxEventNames
        {
            get { return cbxEventNames; }
        }

        public ComboBox CbxTrackNames
        {
            get { return cbxTrackName; }
        }

        public ComboBox CbxRaceTypes
        {
            get { return cbxRaceTypes; }
        }

        public ComboBox CbxGroupBy
        {
            get { return cbxGroupBy; }
        }

        public ComboBox CbxSortBy
        {
            get { return cbxSortBy; }
        }

        public DataGridViewColumn ColumnOfDriver
        {
            get { return ColumnDriver; }
        }

        public DataGridViewColumn ColumnOfCar
        {
            get { return ColumnCar; }
        }

        public DataGridViewColumn ColumnOfCarName
        {
            get { return ColumnCarName; }
        }

        #endregion

        private void GrdLanesDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void ToolStripMenuItemLargerFontClick(object sender, EventArgs e)
        {
            try
            {
                _statisticsPresenter.IncreaseCellFont();
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
                _statisticsPresenter.DecreaseCellFont();
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
                _statisticsPresenter.SaveGridSettings();
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
                _statisticsPresenter.LoadGridSettingsChooseSource();
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
                _statisticsPresenter.IncreaseHeaderCellFont();
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
                _statisticsPresenter.DecreaseHeaderCellFont();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void StatisticsFormLoad(object sender, EventArgs e)
        {
            try
            {
                _statisticsPresenter.FillStaticData();
                _statisticsPresenter.CalcAndFillStatisticResult();
                _statisticsPresenter.LoadGridSettings();
                _statisticsPresenter.CalcFirstColumnAndHeaders();
                _dataFilled = true;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_dataFilled)
                    _statisticsPresenter.CalcAndFillStatisticResult();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ToolStripMenuItemcopyToClipboardClick(object sender, EventArgs e)
        {
            try
            {
                _statisticsPresenter.CopyTableToClipboard();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

    }
}