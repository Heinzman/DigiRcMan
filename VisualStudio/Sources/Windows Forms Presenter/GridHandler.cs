using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.Exceptions;
using Elreg.Log;
using Elreg.Serialization;
using Elreg.WinFormsPresentationFramework.SerializationObjects;

namespace Elreg.WindowsFormsPresenter
{
    public class GridHandler
    {
        private const int MinVirtRows = 3;
        private readonly DataGridView _dataGridView;
        private readonly RaceStatusDescription _raceStatusDescription;
        private readonly RacePositionDescription _racePositionDescription;
        private RaceGridSettings _raceGridSettings = new RaceGridSettings();
        private string _xmlFileName;
        private bool _settingsLoaded;

        public GridHandler(DataGridView dataGridView)
        {
            _dataGridView = dataGridView;
            _dataGridView.ColumnWidthChanged += DataGridViewColumnWidthChanged;
        }

        public GridHandler(DataGridView dataGridView, RaceStatusDescription raceStatusDescription, 
                           RacePositionDescription racePositionDescription) : this(dataGridView)
        {
            _raceStatusDescription = raceStatusDescription;
            _racePositionDescription = racePositionDescription;
        }

        public RaceGridSettings RaceGridSettings
        {
            get { return _raceGridSettings; }
        }

        private string XmlFileName
        {
            get { return _xmlFileName; }
            set { _xmlFileName = value.Replace("\\\\", "\\"); }
        }

        public void HandleKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Alt)
                IncreaseCellFont();
            else if (e.KeyCode == Keys.Y && e.Alt)
                DecreaseCellFont();
            else if (e.KeyCode == Keys.J && e.Alt)
                IncreaseStatusCellFont();
            else if (e.KeyCode == Keys.M && e.Alt)
                DecreaseStatusCellFont();
        }

        public void IncreaseCellFont()
        {
            ChangeCellFontSize(1);
        }

        public void DecreaseCellFont()
        {
            ChangeCellFontSize(-1);
        }

        public void IncreaseDataGridFont()
        {
            ChangeDataGridFontSize(1);
        }

        public void DecreaseDataGridFont()
        {
            ChangeDataGridFontSize(-1);
        }

        public void IncreaseHeaderCellFont()
        {
            ChangeHeaderCellFontSize(1);
        }

        public void DecreaseHeaderCellFont()
        {
            ChangeHeaderCellFontSize(-1);
        }

        public void IncreaseStatusCellFont()
        {
            ChangeStatusCellFontSize(1);
        }

        public void DecreaseStatusCellFont()
        {
            ChangeStatusCellFontSize(-1);
        }

        public void IncreasePositionsCellFont()
        {
            ChanceFontSizeOfPositionLabels(1);
        }

        public void DecreasePositionsCellFont()
        {
            ChanceFontSizeOfPositionLabels(-1);
        }

        private void ChanceFontSizeOfPositionLabels(int valueToAdd)
        {
            if (_racePositionDescription != null)
            {
                _racePositionDescription.FontSize += valueToAdd;
                SettingsChanged = true;
            }
        }

        public void SizeGrid()
        {
            SizeGridRows();
        }

        public bool SaveGridSettings(string xmlFileName, out string newXmlFileName)
        {
            bool ret = false;
            newXmlFileName = xmlFileName;
            try
            {
                XmlFileName = xmlFileName;
                CreateRaceGridSettings();
                if (IsDestFileChosen())
                {
                    ObjectXmlSerializer<RaceGridSettings>.Save(_raceGridSettings, XmlFileName);
                    SettingsChanged = false;
                    newXmlFileName = XmlFileName;
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    @"Unable to save raceGridSettings object!" + Environment.NewLine + Environment.NewLine + ex.Message,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ret;
        }

        public bool LoadGridSettingsChooseSource(string xmlFileName, out string newXmlFileName)
        {
            bool ret = false;
            newXmlFileName = string.Empty;
            XmlFileName = xmlFileName;
            if (IsSourceFileChosen())
            {
                LoadGridSettings(XmlFileName);
                SettingsChanged = false;
                newXmlFileName = XmlFileName;
                ret = true;
            }
            return ret;
        }

        public void LoadGridSettings(string xmlFileName)
        {
            try
            {
                _raceGridSettings = ObjectXmlSerializer<RaceGridSettings>.Load(xmlFileName);
                AssignColumnsFromRaceGridSettings();
                AssignHeaderHeightFromRaceGridSettings();
                AssignHeaderFontFromRaceGridSettings();
                AssignRaceStatusFromRaceGridSettings();
                AssignRacePositionsFromRaceGridSettings();
                _settingsLoaded = true;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public bool SettingsChanged { set; get; }

        private void DataGridViewColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (_settingsLoaded)
                    SettingsChanged = true;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private bool IsDestFileChosen()
        {
            bool ret = false;
            var saveFileDialog = new SaveFileDialog {Filter = @"xml files (*.xml)|*.xml", FilterIndex = 1};

            string fileNameWithoutPath = Path.GetFileName(XmlFileName); 
            string directory = Path.GetDirectoryName(XmlFileName);

            saveFileDialog.InitialDirectory = directory;
            saveFileDialog.FileName = fileNameWithoutPath;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlFileName = saveFileDialog.FileName;
                ret = true;
            }
            return ret;
        }

        private bool IsSourceFileChosen()
        {
            bool ret = false;
            var openFileDialog = new OpenFileDialog {Filter = @"xml files (*.xml)|*.xml", FilterIndex = 1};

            string fileNameWithoutPath = Path.GetFileName(XmlFileName);
            string directory = Path.GetDirectoryName(XmlFileName);

            openFileDialog.InitialDirectory = directory;
            openFileDialog.FileName = fileNameWithoutPath;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlFileName = openFileDialog.FileName;
                ret = true;
            }
            return ret;
        }

        private void SizeGridRows()
        {
            if (Rows.Count > 0)
            {
                int virtRowsToDisplay = Rows.Count;
                if (virtRowsToDisplay < MinVirtRows)
                    virtRowsToDisplay = MinVirtRows;
                int rowHeight = (GridHeight - ColumnHeadersHeight) / virtRowsToDisplay;
                foreach (DataGridViewRow row in Rows)
                    SetRowHeight(row, rowHeight);
            }
        }

        private DataGridViewRowCollection Rows
        {
            get
            {
                object rows = GetGridProperty("Rows");
                DataGridViewRowCollection collection = rows as DataGridViewRowCollection;
                if (collection == null)
                    throw new LcException("GetGridProperty(\"Rows\") returned null");
                return collection;
            }
        }

        private int GridHeight
        {
            get { return GetGridIntProperty("Height"); }
        }

        private int ColumnHeadersHeight
        {
            get { return GetGridIntProperty("ColumnHeadersHeight"); }
        }

        private int GetGridIntProperty(string property)
        {
            object obj = GetGridProperty(property);
            int intValue;
            if (!int.TryParse(obj.ToString(), out intValue))
                throw new LcException("GetGridProperty(" + property + ") returned null");
            return intValue;
        }

        private object GetGridProperty(string property)
        {
            return _dataGridView.GetType().InvokeMember(property, BindingFlags.GetProperty, null, _dataGridView, null);
        }

        private void SetRowHeight(DataGridViewRow row, int rowHeight)
        {
            if (_dataGridView.InvokeRequired)
                _dataGridView.Invoke((MethodInvoker) (() => row.Height = rowHeight));
            else
                row.Height = rowHeight;
        }

        private void ChangeCellFontSize(int valueToAdd)
        {
            if (FirstSelectedCell != null)
            {
                int colIndex = FirstSelectedCell.ColumnIndex;
                DataGridViewColumn column = GetGridColumn(colIndex);
                if (column != null)
                {
                    DataGridViewCellStyle cellStyle = column.DefaultCellStyle.Clone();
                    Font currentFont = cellStyle.Font;
                    if (currentFont == null)
                        currentFont = _dataGridView.DefaultCellStyle.Font;
                    if (currentFont != null)
                    {
                        var newFont = new Font(currentFont.FontFamily.Name, currentFont.Size + valueToAdd, currentFont.Style);
                        cellStyle.Font = newFont;
                        foreach (DataGridViewRow row in Rows)
                        {
                            Color backcolor = row.Cells[colIndex].Style.BackColor;
                            DataGridViewCellStyle rowCellStyle = cellStyle.Clone();
                            rowCellStyle.BackColor = backcolor;
                            row.Cells[colIndex].Style = rowCellStyle;
                        }
                        SetDefaultCellStyle(column, cellStyle);
                    }
                    SettingsChanged = true;
                }
            }
        }

        private void ChangeDataGridFontSize(int valueToAdd)
        {
            DataGridViewCellStyle cellStyle = _dataGridView.DefaultCellStyle.Clone();
            Font currentFont = cellStyle.Font;
            if (currentFont != null)
            {
                var newFont = new Font(currentFont.FontFamily.Name, currentFont.Size + valueToAdd, currentFont.Style);
                cellStyle.Font = newFont;
                _dataGridView.DefaultCellStyle = cellStyle;
            }
            SettingsChanged = true;
        }

        private DataGridViewColumn GetGridColumn(string colName)
        {
            DataGridViewColumn column;
            object columns = GetGridProperty("Columns");
            DataGridViewColumnCollection collection = columns as DataGridViewColumnCollection;
            if (collection == null)
                throw new LcException("GetGridProperty(\"Columns\") returned null");
            else
                column = collection[colName];
            return column;
        }

        private DataGridViewColumn GetGridColumn(int colIndex)
        {
            DataGridViewColumn column;
            object columns = GetGridProperty("Columns");
            DataGridViewColumnCollection collection = columns as DataGridViewColumnCollection;
            if (collection == null)
                throw new LcException("GetGridProperty(\"Columns\") returned null");
            else
                column = collection[colIndex];
            return column;
        }

        private DataGridViewColumnCollection Columns
        {
            get
            {
                object obj = GetGridProperty("Columns");
                DataGridViewColumnCollection collection = obj as DataGridViewColumnCollection;
                if (collection == null)
                    throw new LcException("GetGridProperty(\"Columns\") returned null");
                return collection;
            }
        }

        private DataGridViewCell FirstSelectedCell
        {
            get
            {
                DataGridViewCell firstSelectedCell = null;
                object selectedCells = GetGridProperty("SelectedCells");
                DataGridViewSelectedCellCollection collection = selectedCells as DataGridViewSelectedCellCollection;
                if (collection == null)
                    throw new LcException("GetGridProperty(\"SelectedCells\") returned null");
                else if (collection.Count > 0)
                    firstSelectedCell = collection[0];
                return firstSelectedCell;
            }
        }

        private DataGridViewCellStyle ColumnHeadersDefaultCellStyle
        {
            get
            {
                object obj = GetGridProperty("ColumnHeadersDefaultCellStyle");
                DataGridViewCellStyle cellStyle = obj as DataGridViewCellStyle;
                if (cellStyle == null)
                    throw new LcException("GetGridProperty(\"ColumnHeadersDefaultCellStyle\") returned null");
                return cellStyle;
            }
        }

        private void SetDefaultCellStyle(DataGridViewColumn column, DataGridViewCellStyle cellStyle)
        {
            if (_dataGridView.InvokeRequired)
                _dataGridView.Invoke((MethodInvoker)(() => column.DefaultCellStyle = cellStyle));
            else
                column.DefaultCellStyle = cellStyle;
        }

        private void ChangeHeaderCellFontSize(int valueToAdd)
        {
            DataGridViewCellStyle cellStyle = ColumnHeadersDefaultCellStyle.Clone();
            Font currentFont = cellStyle.Font;
            if (currentFont != null)
            {
                var newFont = new Font(currentFont.FontFamily.Name, currentFont.Size + valueToAdd, currentFont.Style);
                cellStyle.Font = newFont;
                SetColumnHeadersDefaultCellStyle(cellStyle);
                SettingsChanged = true;
            }
        }

        private void SetColumnHeadersDefaultCellStyle(DataGridViewCellStyle cellStyle)
        {
            if (_dataGridView.InvokeRequired)
                _dataGridView.Invoke((MethodInvoker)(() => _dataGridView.ColumnHeadersDefaultCellStyle = cellStyle));
            else
                _dataGridView.ColumnHeadersDefaultCellStyle = cellStyle;
        }

        private void ChangeStatusCellFontSize(int valueToAdd)
        {
            if (_raceStatusDescription != null)
            {
                _raceStatusDescription.RaceStatusFontSize += valueToAdd;
                SettingsChanged = true;
            }
        }

        private void CreateRaceGridSettings()
        {
            _raceGridSettings = new RaceGridSettings { HeaderHeight = ColumnHeadersHeight };
            if (ColumnHeadersDefaultCellStyle.Font != null)
                _raceGridSettings.HeaderFontSize = ColumnHeadersDefaultCellStyle.Font.Size;
            CreateRaceGridSettingsOfRaceStatusDescription();
            CreateRaceGridSettingsOfPosition();

            foreach (DataGridViewColumn column in Columns)
            {
                var gridColumnProperties = new GridColumnProperties
                                               {
                                                   Name = column.Name,
                                                   Position = column.DisplayIndex,
                                                   Width = column.Width
                                               };
                if (column.DefaultCellStyle.Font != null)
                    gridColumnProperties.FontSize = column.DefaultCellStyle.Font.Size;
                gridColumnProperties.Visible = column.Visible;
                _raceGridSettings.GridColumnPropertiesList.Add(gridColumnProperties);
            }
        }

        private void CreateRaceGridSettingsOfPosition()
        {
            if (_racePositionDescription != null)
            {
                _raceGridSettings.PositionFontSize = _racePositionDescription.FontSize;
                _raceGridSettings.PositionsHeight = _racePositionDescription.PositionsHeight;
            }
        }

        private void CreateRaceGridSettingsOfRaceStatusDescription()
        {
            if (_raceStatusDescription != null)
            {
                _raceGridSettings.RaceStatusHeight = _raceStatusDescription.RaceStatusHeight;
                _raceGridSettings.RaceStatusFontSize = _raceStatusDescription.RaceStatusFontSize;
            }
        }

        private void AssignColumnsFromRaceGridSettings()
        {
            foreach (GridColumnProperties gridColumnProperties in _raceGridSettings.GridColumnPropertiesList)
            {
                DataGridViewColumn column = GetGridColumn(gridColumnProperties.Name);
                if (column != null && column.Visible)
                    SetColumnProperties(gridColumnProperties, column);
            }
        }

        private void SetColumnProperties(GridColumnProperties gridColumnProperties, DataGridViewColumn column)
        {
            Font font = null;
            if (column.DefaultCellStyle.Font != null)
                font = new Font(column.DefaultCellStyle.Font.FontFamily, gridColumnProperties.FontSize);

            if (_dataGridView.InvokeRequired)
            {
                _dataGridView.Invoke((MethodInvoker) (() => column.Width = gridColumnProperties.Width));
                _dataGridView.Invoke((MethodInvoker) (() => column.Visible = gridColumnProperties.Visible));
                _dataGridView.Invoke((MethodInvoker) (() => column.DisplayIndex = gridColumnProperties.Position));
                if (font != null)
                    _dataGridView.Invoke((MethodInvoker) (() => column.DefaultCellStyle.Font = font));
            }
            else
            {
                column.Width = gridColumnProperties.Width;
                column.Visible = gridColumnProperties.Visible;
                column.DisplayIndex = gridColumnProperties.Position;
                if (font != null)
                    column.DefaultCellStyle.Font = font;                
            }
        }

        private void AssignHeaderHeightFromRaceGridSettings()
        {
            if (_dataGridView.InvokeRequired)
                _dataGridView.Invoke((MethodInvoker)(() => _dataGridView.ColumnHeadersHeight = _raceGridSettings.HeaderHeight));
            else
                _dataGridView.ColumnHeadersHeight = _raceGridSettings.HeaderHeight;
        }

        private void AssignHeaderFontFromRaceGridSettings()
        {
            if (ColumnHeadersDefaultCellStyle.Font != null)
            {
                var font = new Font(ColumnHeadersDefaultCellStyle.Font.FontFamily, _raceGridSettings.HeaderFontSize);
                if (_dataGridView.InvokeRequired)
                    _dataGridView.Invoke((MethodInvoker)(() => _dataGridView.ColumnHeadersDefaultCellStyle.Font = font));
                else
                    _dataGridView.ColumnHeadersDefaultCellStyle.Font = font;
            }
        }

        private void AssignRaceStatusFromRaceGridSettings()
        {
            if (_raceStatusDescription != null)
            {
                _raceStatusDescription.RaceStatusHeight = _raceGridSettings.RaceStatusHeight;
                _raceStatusDescription.RaceStatusFontSize = _raceGridSettings.RaceStatusFontSize;
            }
        }

        private void AssignRacePositionsFromRaceGridSettings()
        {
            if (_racePositionDescription != null)
            {
                _racePositionDescription.FontSize = _raceGridSettings.PositionFontSize;
                _racePositionDescription.PositionsHeight = _raceGridSettings.PositionsHeight;
            }
        }
    }
}