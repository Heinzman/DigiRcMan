using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Elreg.BusinessObjects;

namespace Elreg.RaceConsolidationService
{
    public class RaceDataTableCreator
    {
        private readonly List<LinearRaceData> _linearRaceDataList;
        private readonly bool _showDetails;
        private readonly bool _showEmptyRows;
        private readonly List<string> _driverNames = new List<string>();
        private readonly Dictionary<string, int> _driverColumnIndexes = new Dictionary<string, int>();
        private readonly List<DataColumn> _dataColumns = new List<DataColumn>();

        public DataTable RaceDataTable { get; private set; }

        public RaceDataTableCreator(List<LinearRaceData> linearRaceDataList, bool showDetails, bool showEmptyRows)
        {
            _linearRaceDataList = linearRaceDataList;
            _showDetails = showDetails;
            _showEmptyRows = showEmptyRows;
            RaceDataTable = new DataTable();
        }

        public RaceDataTableCreator(List<LinearRaceData> linearRaceDataList, bool showEmptyRows)
            : this(linearRaceDataList, false, showEmptyRows)
        {
        }

        public void CreateForDiagram()
        {
            try
            {
                _linearRaceDataList.Reverse();
                DetermineDriverNames();
                CreateDataColumns();
                CreateDataRowsforDiagram();
            }
            finally
            {
                _linearRaceDataList.Reverse();
            }
        }

        public void CreateForGraph()
        {
            DetermineDriverNames();
            CreateDataColumns();
            CreateDataRowsForGraph();
        }

        private void CreateDataColumns()
        {
            AddColumn("Time (sec)", typeof(int));
            AddColumn("Race Event", typeof (string));
           
            int index = 2;            
            foreach (string driverName in _driverNames)
            {
                _driverColumnIndexes.Add(driverName, index);
                AddColumn(driverName, typeof(string));
                if (_showDetails)
                {
                    AddColumn(driverName + " Details", typeof(string));
                    index += 2;
                }
                else
                    index += 1;
            }
        }

        private void AddColumn(string headerText, Type type)
        {
            DataColumn dataColumn = new DataColumn(headerText, type);
            RaceDataTable.Columns.Add(dataColumn);
            _dataColumns.Add(dataColumn);
        }

        private void CreateDataRowsforDiagram()
        {
            StringBuilder detailsBuilder = new StringBuilder();

            foreach (LinearRaceData linearRaceData in _linearRaceDataList)
            {
                if (_showEmptyRows ||
                    (!_showDetails && HasValues(linearRaceData) ||
                     _showDetails && linearRaceData.RaceEvent != RaceEvent.Undefined))
                {
                    DataRow dataRow = RaceDataTable.Rows.Add();

                    dataRow[_dataColumns[0]] = linearRaceData.Second;
                    if (string.IsNullOrEmpty(linearRaceData.Driver))
                        dataRow[_dataColumns[1]] = linearRaceData.Event;

                    foreach (string driverName in _driverNames)
                    {
                        int index;
                        if (_driverColumnIndexes.TryGetValue(driverName, out index) && linearRaceData.Driver == driverName)
                        {
                            if (linearRaceData.RaceEvent == RaceEvent.LapAdded || linearRaceData.RaceEvent == RaceEvent.LaneFinished)
                            {
                                dataRow[_dataColumns[index]] = linearRaceData.Laps;
                            }
                            detailsBuilder.Clear();
                            detailsBuilder.Append(linearRaceData.Event);
                            detailsBuilder.Append(" ");
                            if (linearRaceData.LapTime.TotalSeconds > 0)
                            {
                                detailsBuilder.Append("Time:");
                                detailsBuilder.Append(string.Format("{0:mm:ss.ff}", DateTime.Today + linearRaceData.LapTime));
                                detailsBuilder.Append(" ");
                            }
                            detailsBuilder.Append("Pos:");
                            detailsBuilder.Append(linearRaceData.Position);
                            detailsBuilder.Append(" ");
                            detailsBuilder.Append("Fuel:");
                            detailsBuilder.Append(linearRaceData.Fuel);
                            detailsBuilder.Append(" ");
                            detailsBuilder.Append("Penalty:");
                            detailsBuilder.Append(linearRaceData.Penalties);
                            detailsBuilder.Append(" ");
                            if (_showDetails)
                                dataRow[_dataColumns[index + 1]] = detailsBuilder.ToString().Trim();
                            break;
                        }
                    }
                }
            }
        }

        private void CreateDataRowsForGraph()
        {
            DataRow previousDataRow = null;

            foreach (LinearRaceData linearRaceData in _linearRaceDataList)
            {
                if (_showEmptyRows || HasValues(linearRaceData))
                {
                    DataRow dataRow = RaceDataTable.Rows.Add();

                    if (previousDataRow != null)
                    {
                        foreach (var dataColumn in _dataColumns)
                            dataRow[dataColumn] = previousDataRow[dataColumn];
                    }

                    dataRow[_dataColumns[0]] = linearRaceData.Second;
                    foreach (string driverName in _driverNames)
                    {
                        int index;
                        if (_driverColumnIndexes.TryGetValue(driverName, out index) && linearRaceData.Driver == driverName)
                        {
                            if (linearRaceData.RaceEvent == RaceEvent.LapAdded || linearRaceData.RaceEvent == RaceEvent.LaneFinished)
                            {
                                dataRow[_dataColumns[index]] = linearRaceData.Laps;
                            }
                        }
                    }
                    previousDataRow = dataRow;
                }
            }
        }

        private bool HasValues(LinearRaceData linearRaceData)
        {
            return linearRaceData.RaceEvent == RaceEvent.LapAdded || linearRaceData.RaceEvent == RaceEvent.RaceFinished ||
                   linearRaceData.RaceEvent == RaceEvent.RaceStarted || linearRaceData.RaceEvent == RaceEvent.RaceStopped ||
                   linearRaceData.RaceEvent == RaceEvent.LaneFinished;
        }

        private void DetermineDriverNames()
        {
            foreach (LinearRaceData linearRaceData in _linearRaceDataList)
            {
                string driver = linearRaceData.Driver;
                if (!string.IsNullOrEmpty(driver))
                {
                    if (!_driverNames.Exists(d => d == driver))
                        _driverNames.Add(driver);
                }
            }
            _driverNames.Sort();
        }
    }
}
