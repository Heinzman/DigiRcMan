using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elreg.BusinessObjects.Championships;
using Elreg.BusinessObjects.Lanes;
using Elreg.DomainModels.Championships;
using Elreg.ResourcesService;
using Elreg.WindowsFormsView;
using Elreg.BusinessObjects;
using Elreg.Log;
using Elreg.WinFormsPresentationFramework.DataTransferObjects;
using Elreg.WinFormsPresentationFramework.Forms;

namespace Elreg.WindowsFormsPresenter
{
    public class ChampionshipPresenter : GridPresenter
    {
        private readonly IChampionshipView _championshipView;

        private List<GridChampionshipDto> _gridChampionshipDtos;

        private readonly ChampionshipModel _championshipModel = new ChampionshipModel();

        private bool _gridChampionshipFilled;

        private string MessageCouldNotLoad { get; set; }

        private enum Columns
        {
            ColumnPosition,
            ColumnDriver,
            ColumnPoints
        }

        public ChampionshipPresenter(IChampionshipView championshipView)
            : base(championshipView)
        {
            try
            {
                _championshipView = championshipView;
                GridHandler = new GridHandler(_championshipView.GrdLanes);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void LoadAndShow(string championshipXmlFile)
        {
            try
            {
                _championshipModel.DeserializeChampionship(championshipXmlFile);
                _championshipView.InvokeShowAndFocus();
                FillData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
                LargeOkMessageBox largeOkMessageBox = new LargeOkMessageBox();
                var text = MessageCouldNotLoad.Replace(LanguageManager.ReplaceString1, championshipXmlFile);
                largeOkMessageBox.ShowDialog(text);
            }
        }

        public void Add(RaceResult raceResult)
        {
            try
            {
                _championshipModel.Add(raceResult);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void FillData()
        {
            try
            {
                _gridChampionshipFilled = false;
                CreateGridChampionshipDtosFromModel();
                _gridChampionshipDtos.Sort((g1, g2) => String.CompareOrdinal(g1.Position, g2.Position));
                FillGridWithValues();
                SetCaption();
                SizeGrid();
                _gridChampionshipFilled = true;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void UpdateLaneAfterChanges(int columnIndex, int rowIndex)
        {
            try
            {
                ChampionshipLane championshipLane = (ChampionshipLane)_championshipView.GrdLanes.Rows[rowIndex].Tag;
                int changedValue;

                if (int.TryParse(_championshipView.GrdLanes[columnIndex, rowIndex].Value.ToString(), out changedValue))
                {
                    if (columnIndex == _championshipView.GrdLanes[Columns.ColumnPoints.ToString(), 0].ColumnIndex)
                        _championshipModel.ChangePointsOfDriver(championshipLane.Driver, changedValue);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public bool GridResultFilled
        {
            get { return _gridChampionshipFilled; }
            set { _gridChampionshipFilled = value; }
        }

        public bool NewChampionship
        {
            set { _championshipModel.NewChampionship = value; }
        }

        public void SaveData()
        {
            try
            {
                _championshipModel.SaveData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void AdjustCultureStrings()
        {
            try
            {
                MessageCouldNotLoad = LanguageManager.GetString("RaceResultsMessageCouldNotLoad");
                _championshipView.BtnSave.Text = LanguageManager.GetString("ChampionshipFormBtnSave");
                _championshipView.BtnClose.Text = LanguageManager.GetString("ChampionshipFormBtnClose");
                _championshipView.GridColumnPosition.HeaderText = LanguageManager.GetString("ChampionshipFormColumnPosition");
                _championshipView.GridColumnDriver.HeaderText = LanguageManager.GetString("ChampionshipFormColumnDriver");
                _championshipView.GridColumnPoints.HeaderText = LanguageManager.GetString("ChampionshipFormColumnPoints");
                _championshipView.ToolStripMenuItemLargerFont.Text = LanguageManager.GetString("ToolStripMenuItemLargerFont");
                _championshipView.ToolStripMenuItemSmallerFont.Text = LanguageManager.GetString("ToolStripMenuItemSmallerFont");
                _championshipView.ToolStripMenuItemLargerHeaderFont.Text = LanguageManager.GetString("ToolStripMenuItemLargerHeaderFont");
                _championshipView.ToolStripMenuItemSmallerHeaderFont.Text = LanguageManager.GetString("ToolStripMenuItemSmallerHeaderFont");
                _championshipView.ToolStripMenuItemSaveSettings.Text = LanguageManager.GetString("ToolStripMenuItemSaveSettings");
                _championshipView.ToolStripMenuItemLoadSettings.Text = LanguageManager.GetString("ToolStripMenuItemLoadSettings");
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void CopyTableToClipboard()
        {
            try
            {
                _championshipView.GrdLanes.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                _championshipView.GrdLanes.SelectAll();
                DataObject dataObject = _championshipView.GrdLanes.GetClipboardContent();
                if (dataObject != null)
                    Clipboard.SetDataObject(dataObject);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        protected override string DefaultXmlFileName
        {
            get
            {
                const string fileName = "Championship.xml";
                return ServiceHelper.ConfigViewPath + fileName;
            }
        }

        private void CreateGridChampionshipDtosFromModel()
        {
            _gridChampionshipDtos = new List<GridChampionshipDto>();

            foreach (ChampionshipLane championshipLane in _championshipModel.ChampionshipLanes)
            {
                GridChampionshipDto gridChampionshipDto = new GridChampionshipDto
                                                              {
                                                                  ChampionshipLane = championshipLane,
                                                                  Position = Format(championshipLane.Position),
                                                                  Driver = championshipLane.Driver.Name,
                                                                  Points = Format(championshipLane.Points)
                                                              };
                _gridChampionshipDtos.Add(gridChampionshipDto);
            }
        }

        private void FillGridWithValues()
        {
            _championshipView.GrdLanes.Rows.Clear();
            foreach (GridChampionshipDto gridChampionshipDto in _gridChampionshipDtos)
            {
                _championshipView.GrdLanes.Rows.Add();
                int rowIndex = _championshipView.GrdLanes.Rows.GetLastRow(System.Windows.Forms.DataGridViewElementStates.None);
                _championshipView.GrdLanes.Rows[rowIndex].Tag = gridChampionshipDto.ChampionshipLane;
                _championshipView.GrdLanes[Columns.ColumnPosition.ToString(), rowIndex].Value = gridChampionshipDto.Position;
                _championshipView.GrdLanes[Columns.ColumnDriver.ToString(), rowIndex].Value = gridChampionshipDto.Driver;
                _championshipView.GrdLanes[Columns.ColumnPoints.ToString(), rowIndex].Value = gridChampionshipDto.Points;
            }
        }

        private void SetCaption()
        {
            _championshipView.Caption = _championshipModel.Championship.Name;
        }
    }
}
