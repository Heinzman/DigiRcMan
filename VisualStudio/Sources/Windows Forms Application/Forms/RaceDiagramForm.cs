using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.RaceConsolidationService;
using Form = Elreg.WinFormsPresentationFramework.Forms.Form;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class RaceDiagramForm : WinFormsPresentationFramework.Forms.Form
    {
        private bool _isTableFilled;
        private bool _isGraphFilled;
        private RaceDataConsolidator _raceDataConsolidator;

        public RaceDiagramForm(string fileName)
        {
            InitializeComponent();
            ctlRaceLogGraph1.Visible = false;
            ctlRaceLogTable1.Visible = false; 
            InitRaceDataConsolidator(fileName);
        }

        private void InitRaceDataConsolidator(string fileName)
        {
            _raceDataConsolidator = new RaceDataConsolidator(fileName);
            AssignRaceDataConsolidator();
        }

        private void AssignRaceDataConsolidator()
        {
            ctlRaceLogTable1.RaceDataConsolidator = _raceDataConsolidator;
            ctlRaceLogGraph1.RaceDataConsolidator = _raceDataConsolidator;
        }

        private void BtnCloseClick(object sender, System.EventArgs e)
        {
            Close();
        }

        private void RaceDiagramFormLoad(object sender, System.EventArgs e)
        {
            bool isOk = true;
            _raceDataConsolidator.CreateRaceDataList();
            if (_raceDataConsolidator.RaceDataList == null)
                isOk = ShowOpenFileDialog();

            if (isOk)
                ShowRaceLogGraph();
        }

        private void ShowRaceLogGraph()
        {
            ctlRaceLogGraph1.Visible = true;
            ctlRaceLogGraph1.BringToFront();
            if (!_isGraphFilled)
                ctlRaceLogGraph1.FillChart();
            _isGraphFilled = true;
        }

        private void OptCheckedChanged(object sender, System.EventArgs e)
        {
            FillTableOrGraph();
        }

        private void FillTableOrGraph()
        {
            if (optTable.Checked)
            {
                ctlRaceLogTable1.Visible = true;
                ctlRaceLogTable1.BringToFront();
                if (!_isTableFilled)
                    ctlRaceLogTable1.FillTable();
                _isTableFilled = true;
            }
            else
                ShowRaceLogGraph();
        }

        private void BtnOpenFileClick(object sender, System.EventArgs e)
        {
            if (ShowOpenFileDialog())
            {
                AssignRaceDataConsolidator();
                FillTableOrGraph();
            }
        }

        private bool ShowOpenFileDialog()
        {
            bool isOk = false;
            OpenFileDialog openFileDialog = new OpenFileDialog
                                                {
                                                    FileName = "",
                                                    Filter = @"Race Log File|RaceLog*.txt|All Files|*.*",
                                                    InitialDirectory = ServiceHelper.LogsPath
                                                };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _isTableFilled = false;
                _isGraphFilled = false;
                InitRaceDataConsolidator(openFileDialog.FileName);
                _raceDataConsolidator.CreateRaceDataList();
                if (_raceDataConsolidator.RaceDataDict.Count > 1)
                {
                    RaceLogListForm raceLogListForm = new RaceLogListForm(_raceDataConsolidator.RaceDataDict);
                    if (raceLogListForm.ShowDialog(this) == DialogResult.OK)
                    {
                        _raceDataConsolidator.RaceDataList = raceLogListForm.SelectedRaceDataList;
                        isOk = true;
                    }
                }
                else if (_raceDataConsolidator.RaceDataDict.Count == 1)
                    isOk = true;
            }
            return isOk;
        }
    }
}
