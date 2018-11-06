using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elreg.Log;
using Elreg.RaceConsolidationService;
using Form = Elreg.WinFormsPresentationFramework.Forms.Form;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class RaceLogListForm : WinFormsPresentationFramework.Forms.Form
    {
        private readonly List<KeyValuePair<string, List<LinearRaceData>>> _raceDataDict;

        public RaceLogListForm(List<KeyValuePair<string, List<LinearRaceData>>> raceDataDict)
        {
            _raceDataDict = raceDataDict;
            InitializeComponent();
        }

        public List<LinearRaceData> SelectedRaceDataList { get; private set; }

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

        private void RaceLogListFormLoad(object sender, EventArgs e)
        {
            try
            {
                listBox1.DataSource = _raceDataDict;
                listBox1.DisplayMember = "Key";
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            try
            {
                DetermineSelectedItemAndClose();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void DetermineSelectedItemAndClose()
        {
            DetermineSelectedItem();
            if (SelectedRaceDataList != null)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void DetermineSelectedItem()
        {
            if (listBox1.SelectedItem is KeyValuePair<string, List<LinearRaceData>>)
                SelectedRaceDataList = ((KeyValuePair<string, List<LinearRaceData>>) listBox1.SelectedItem).Value;
        }

        private void ListBox1DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DetermineSelectedItemAndClose();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }
    }
}
