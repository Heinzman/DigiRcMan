using System.Collections.Generic;
using System.Data;

namespace Elreg.RaceConsolidationService
{
    public class RaceDataConsolidator
    {
        private readonly string _fileName;
        public List<KeyValuePair<string, List<LinearRaceData>>> RaceDataDict { get; private set; }
        public List<LinearRaceData> RaceDataList { get; set; }

        public RaceDataConsolidator(string fileName)
        {
            _fileName = fileName;
        }

        public int MaxLapsOfRace
        {
            get
            {
                int maxLaps = 0;
                CheckToCreateRaceDataList();

                if (RaceDataList != null)
                {
                    foreach (LinearRaceData linearRaceData in RaceDataList)
                    {
                        int lap;
                        if (int.TryParse(linearRaceData.Laps, out lap))
                        {
                            if (lap > maxLaps)
                                maxLaps = lap;
                        }
                    }
                }
                return maxLaps;
            }
        }

        public DataTable GetRaceTable(bool showDetails, bool showEmptyRows)
        {
            CheckToCreateRaceDataList();
            RaceDataTableCreator raceDataTableCreator = new RaceDataTableCreator(RaceDataList, showDetails, showEmptyRows);
            raceDataTableCreator.CreateForDiagram();

            return raceDataTableCreator.RaceDataTable;
        }

        public DataTable GetRaceDataForGraph(bool showEmptySpaces)
        {
            DataTable dataTable = null;
            CheckToCreateRaceDataList();

            if (RaceDataList != null)
            {
                RaceDataTableCreator raceDataTableCreator = new RaceDataTableCreator(RaceDataList, showEmptySpaces);
                raceDataTableCreator.CreateForGraph();
                dataTable = raceDataTableCreator.RaceDataTable;
            }
            return dataTable;
        }

        private void CheckToCreateRaceDataList()
        {
            if (RaceDataList == null)
                CreateRaceDataList();
        }

        public void CreateRaceDataList()
        {
            RaceDataList = null;
            RaceDataCreator raceDataCreator = new RaceDataCreator(_fileName);
            raceDataCreator.DoWork();

            LinearRaceDataCreator linearRaceDataModifier = new LinearRaceDataCreator(raceDataCreator.RaceDataList);
            linearRaceDataModifier.DoWork();

            RaceDataDictCreator raceDataDictCreator = new RaceDataDictCreator(linearRaceDataModifier.LinearRaceDataList);
            raceDataDictCreator.DoWork();

            RaceDataDict = raceDataDictCreator.RaceDataDict;
            if (raceDataDictCreator.RaceDataDict.Count > 0)
                RaceDataList = RaceDataDict[raceDataDictCreator.RaceDataDict.Count - 1].Value;
        }
    }
}
