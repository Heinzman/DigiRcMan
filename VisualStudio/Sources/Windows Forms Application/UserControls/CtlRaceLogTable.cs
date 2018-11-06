using System;
using System.Data;
using System.Windows.Forms;
using Elreg.Log;
using Elreg.RaceConsolidationService;
using Elreg.WindowsFormsPresenter;

namespace Elreg.WindowsFormsApplication.UserControls
{
    public partial class CtlRaceLogTable : UserControl
    {
        private readonly GridHandler _gridHandler;
        public RaceDataConsolidator RaceDataConsolidator { get; set; }

        public CtlRaceLogTable()
        {
            InitializeComponent();
            _gridHandler = new GridHandler(dataGridView1);
        }

        private void ToolStripMenuItemLargerFontClick(object sender, EventArgs e)
        {
            try
            {
                _gridHandler.IncreaseDataGridFont();
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
                _gridHandler.DecreaseDataGridFont();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ChkCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FillTable();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void FillTable()
        {
            try
            {
                if (RaceDataConsolidator != null)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    bool showDetails = chkShowDetails.Checked;
                    bool showEmptyRows = chkShowEmptyRows.Checked;
                    DataTable dataTable = RaceDataConsolidator.GetRaceTable(showDetails, showEmptyRows);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns[0].Frozen = true;
                    SetSortModes();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void SetSortModes()
        {
            for (int index = 0; index < dataGridView1.Columns.Count; index++)
            {
                var column = dataGridView1.Columns[index];
                if (index == 0)
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                else
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

    }
}
