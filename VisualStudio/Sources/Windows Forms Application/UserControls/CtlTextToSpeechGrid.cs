using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elreg.ComputerSpeech;
using Elreg.Log;
using Elreg.WinFormsPresentationFramework.DataTransferObjects;

namespace Elreg.WindowsFormsApplication.UserControls
{
    public partial class CtlTextToSpeechGrid : UserControl
    {
        private bool _wereAllCountDownRowsChecked;
        private BindingSource _bindingSourceCountDown;
        private List<TextToSpeechCreationRow> _dataList;

        public CtlTextToSpeechGrid()
        {
            InitializeComponent();
        }

        public List<TextToSpeechCreationRow> DataList
        {
            set
            {
                _dataList = value;
                _bindingSourceCountDown = new BindingSource { DataSource = _dataList };
                grdTextToSpeach.AutoGenerateColumns = false;
                grdTextToSpeach.DataSource = _bindingSourceCountDown;
            }
        }

        private void GrdTextToSpeachCellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == ColumnIsToCreate.Index && e.RowIndex == -1)
                {
                    if (_wereAllCountDownRowsChecked)
                        UnCheckAllCountDownRows();
                    else
                        CheckAllCountDownRows();
                    _wereAllCountDownRowsChecked = !_wereAllCountDownRowsChecked;
                    grdTextToSpeach.Refresh();
                    grdTextToSpeach.CurrentCell = null;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void UnCheckAllCountDownRows()
        {
            SetCountDownRowsCheckedTo(false);
        }

        private void CheckAllCountDownRows()
        {
            SetCountDownRowsCheckedTo(true);
        }

        private void SetCountDownRowsCheckedTo(bool isChecked)
        {
            foreach (TextToSpeechCreationRow textToSpeechCreationRow in _dataList)
                textToSpeechCreationRow.IsToCreate = isChecked;
        }

        private void GrdTextToSpeachCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == ColumnSpeak.Index && e.RowIndex >= 0)
                {
                    string textToSpeak = grdTextToSpeach[ColumnTextToSpeak.Index, e.RowIndex].Value.ToString();
                    var speaker = new Speaker(textToSpeak);
                    speaker.Speak();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

    }
}
