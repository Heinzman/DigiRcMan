using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Elreg.Log;
using Elreg.RaceConsolidationService;

namespace Elreg.WindowsFormsApplication.UserControls
{
    public partial class CtlRaceLogGraph : UserControl
    {
        private DataTable _dataTable;
        public RaceDataConsolidator RaceDataConsolidator { private get; set; }
        
        public CtlRaceLogGraph()
        {
            InitializeComponent();
            InitializeChart();
        }

        public void FillChart()
        {
            _dataTable = RaceDataConsolidator.GetRaceDataForGraph(true);
            FillSeriesLegend();
            FillDataIntoGrid();
        }

        private void FillSeriesLegend()
        {
            chart1.Legends.Clear();
            chart1.Series.Clear();
            for (int i = 2; i < _dataTable.Columns.Count; i++)
            {
                DataColumn dataColumn = _dataTable.Columns[i];
                string driverName = dataColumn.ColumnName;
                Legend legend = new Legend(driverName)
                                    {
                                        Font = new Font(Font.FontFamily, 15),
                                        LegendStyle = LegendStyle.Row,
                                        Position = {Auto = false, Height = 5F, Width = 100F, X = 0F, Y = 0F}
                                    };
                chart1.Legends.Add(legend);

                Series series = new Series {ChartType = SeriesChartType.StepLine, Name = driverName};
                chart1.Series.Add(series);
            }
        }

        private void InitializeChart()
        {
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true; 
        }

        private void FillDataIntoGrid()
        {
            foreach (DataRow row in _dataTable.Rows)
            {
                for (int driverIndex = 0; driverIndex < DriverCount; driverIndex++)
                {
                    double value;
                    double.TryParse(row[driverIndex + 2].ToString(), out value);

                    chart1.Series[driverIndex].Points.AddY(value);
                }
            }
        }

        private int DriverCount
        {
            get { return _dataTable.Columns.Count - 2; }
        }

        private void BtnIncreaseXClick(object sender, EventArgs e)
        {
            try
            {
                if (chart1.Dock == DockStyle.Fill)
                {
                    chart1.Dock = DockStyle.None;
                    chart1.Height = splitContainer1.Panel1.Height;
                    chart1.Width = splitContainer1.Panel1.Width;
                    chart1.Location = new Point(0, 0);
                }
                chart1.Width += chart1.Width / 10;
                AdjustAutoScrollMinSize();
                chart1.Location = new Point(0, 0);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnDecreaseXClick(object sender, EventArgs e)
        {
            try
            {
                if (chart1.Dock == DockStyle.Fill)
                {
                    chart1.Dock = DockStyle.None;
                    chart1.Height = splitContainer1.Panel1.Height;
                    chart1.Width = splitContainer1.Panel1.Width;
                    chart1.Location = new Point(0, 0);
                }
                chart1.Width -= chart1.Width / 10;
                AdjustAutoScrollMinSize();
                chart1.Location = new Point(0, 0);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnIncreaseYClick(object sender, EventArgs e)
        {
            try
            {
                if (chart1.Dock == DockStyle.Fill)
                {
                    chart1.Dock = DockStyle.None;
                    chart1.Height = splitContainer1.Panel1.Height;
                    chart1.Width = splitContainer1.Panel1.Width;
                    chart1.Location = new Point(0, 0);
                }
                chart1.Height += chart1.Height / 10;
                AdjustAutoScrollMinSize();
                chart1.Location = new Point(0, 0);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnDecreaseYClick(object sender, EventArgs e)
        {
            try
            {
                if (chart1.Dock == DockStyle.Fill)
                {
                    chart1.Dock = DockStyle.None;
                    chart1.Height = splitContainer1.Panel1.Height;
                    chart1.Width = splitContainer1.Panel1.Width;
                    chart1.Location = new Point(0, 0);
                }
                chart1.Height -= chart1.Height / 10;
                AdjustAutoScrollMinSize();
                chart1.Location = new Point(0, 0);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AdjustAutoScrollMinSize()
        {
            splitContainer1.Panel1.AutoScrollMinSize = chart1.Size;
        }

        private void BtnAutoSizeClick(object sender, EventArgs e)
        {
            try
            {
                chart1.Dock = DockStyle.Fill;
                splitContainer1.Panel1.AutoScrollMinSize = new Size();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }
    }
}
