using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.Races;
using Elreg.DomainModels;
using Elreg.Log;
using Elreg.RaceStatisticsService;
using Elreg.WindowsFormsView;
using Elreg.WinFormsPresentationFramework;
using Elreg.WinFormsPresentationFramework.DataTransferObjects;

namespace Elreg.WindowsFormsPresenter
{
    public class StatisticsPresenter : GridPresenter
    {
        private readonly IStatisticsView _statisticsView;
        private readonly RaceSettings _raceSettings;
        private readonly StatisticsModel _statisticsModel;

        public StatisticsPresenter(IStatisticsView statisticsView, StatisticLogger statisticLogger, RaceSettings raceSettings)
            : base(statisticsView)
        {
            try
            {
                _statisticsView = statisticsView;
                _raceSettings = raceSettings;
                _statisticsModel = new StatisticsModel(statisticLogger);
                GridHandler = new GridHandler(GrdStatistics);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void CalcAndFillStatisticResult()
        {
            try
            {
                GrdStatistics.DataSource = null;
                _statisticsModel.CalcStatisticRecords(StatisticsFilterDto);
                GrdStatistics.AutoGenerateColumns = false;
                GrdStatistics.DataSource = _statisticsModel.StatisticRecordDtos;
                CalcFirstColumnAndHeaders();
                GrdStatistics.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void CalcFirstColumnAndHeaders()
        {
            try
            {
                if (StatisticsFilterDto.GroupBy == StatisticsGroupByEnum.Car)
                {
                    _statisticsView.GrdStatistics.Columns[_statisticsView.ColumnOfCar.Index].DisplayIndex = 0;
                    _statisticsView.ColumnOfCar.HeaderText = @"Car";
                    _statisticsView.ColumnOfDriver.HeaderText = @"Best Driver";
                }
                else
                {
                    _statisticsView.GrdStatistics.Columns[_statisticsView.ColumnOfDriver.Index].DisplayIndex = 0;
                    _statisticsView.ColumnOfCar.HeaderText = @"Best Car";
                    _statisticsView.ColumnOfDriver.HeaderText = @"Driver";
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void FillStaticData()
        {
            try
            {
                FillComboBoxes();
                SetDefaultValues();
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
                SetColumnVisible(_statisticsView.ColumnOfCar, false);
                SetColumnVisible(_statisticsView.ColumnOfCarName, true);
                _statisticsView.ColumnOfCarName.DisplayIndex = 2;
                GrdStatistics.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                GrdStatistics.SelectAll();
                DataObject dataObject = GrdStatistics.GetClipboardContent();
                if (dataObject != null)
                    Clipboard.SetDataObject(dataObject);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
            finally
            {
                SetColumnVisible(_statisticsView.ColumnOfCar, true);
                SetColumnVisible(_statisticsView.ColumnOfCarName, false);
            }
        }

        private void SetColumnVisible(DataGridViewColumn column, bool isVisible)
        {
            if (column != null)
                GrdStatistics.Invoke((MethodInvoker)(() => column.Visible = isVisible));
        }

        protected override string DefaultXmlFileName
        {
            get
            {
                const string fileName = "StatisticsView.xml";
                return ServiceHelper.ConfigViewPath + fileName;
            }
        }

        private void SetDefaultValues()
        {
            _statisticsView.CbxRaceTypes.SelectedValue = Race.TypeEnum.Race.ToString();
            _statisticsView.CbxTrackNames.SelectedValue = _raceSettings.TrackName;
            _statisticsView.CbxEventNames.SelectedValue = _raceSettings.EventName;
        }

        private DataGridView GrdStatistics
        {
            get { return _statisticsView.GrdStatistics; }
        }

        private void FillComboBoxes()
        {
            FillComboBox(_statisticsView.CbxEventNames, _statisticsModel.EventNames, true, true);
            FillComboBox(_statisticsView.CbxTrackNames, _statisticsModel.TrackNames);
            FillComboBox(_statisticsView.CbxRaceTypes, _statisticsModel.RaceTypes, false);
            FillComboBox(_statisticsView.CbxGroupBy, _statisticsModel.GroupBys);
            FillComboBox(_statisticsView.CbxSortBy, _statisticsModel.SortBys);
        }

        private void FillComboBox<T>(ComboBox comboBox, IEnumerable<KeyValuePair<T, string>> keyValuePairs)
        {
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
            comboBox.DataSource = keyValuePairs;
        }

        private void FillComboBox(ComboBox comboBox, List<string> orgList, bool sort = true, bool reverse = false)
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>> {new KeyValuePair<string, string>(null, "All")};
            if (sort)
                orgList.Sort();
            if (reverse)
                orgList.Reverse();
            foreach (string element in orgList)
                list.Add(new KeyValuePair<string, string>(element, element));
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
            comboBox.DataSource = list;
        }

        private StatisticsFilterDto StatisticsFilterDto
        {
            get
            {
                StatisticsFilterDto statisticsFilterDto = new StatisticsFilterDto();
                var value = _statisticsView.CbxEventNames.SelectedItem;
                if (value is KeyValuePair<string, string>)
                    statisticsFilterDto.EventNameKey = ((KeyValuePair<string, string>) value).Key;
                value = _statisticsView.CbxTrackNames.SelectedItem;
                if (value is KeyValuePair<string, string>)
                    statisticsFilterDto.TrackNameKey = ((KeyValuePair<string, string>)value).Key;
                value = _statisticsView.CbxRaceTypes.SelectedItem;
                if (value is KeyValuePair<string, string>)
                    statisticsFilterDto.RaceTypeKey = ((KeyValuePair<string, string>)value).Key;
                value = _statisticsView.CbxGroupBy.SelectedItem;
                if (value is KeyValuePair<StatisticsGroupByEnum, string>)
                    statisticsFilterDto.GroupBy = ((KeyValuePair<StatisticsGroupByEnum, string>)value).Key;
                value = _statisticsView.CbxSortBy.SelectedItem;
                if (value is KeyValuePair<StatisticsSortByEnum, string>)
                    statisticsFilterDto.SortBy = ((KeyValuePair<StatisticsSortByEnum, string>)value).Key;
                return statisticsFilterDto;
            }
        }
    }
}
