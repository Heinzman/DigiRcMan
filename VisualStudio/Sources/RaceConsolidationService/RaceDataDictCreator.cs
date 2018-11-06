using System.Collections.Generic;
using Elreg.BusinessObjects;

namespace Elreg.RaceConsolidationService
{
    public class RaceDataDictCreator
    {
        private readonly List<LinearRaceData> _linearRaceDataList;
        bool _isLapAdded;
        bool _shouldAdd;
        string _startTime = string.Empty;
        List<LinearRaceData> _tempLinearRaceDataList;

        public List<KeyValuePair<string, List<LinearRaceData>>> RaceDataDict { get; private set; }

        public RaceDataDictCreator(List<LinearRaceData> linearRaceDataList)
        {
            _linearRaceDataList = linearRaceDataList;
            RaceDataDict = new List<KeyValuePair<string, List<LinearRaceData>>>();
        }

        public void DoWork()
        {
            foreach (LinearRaceData linearRaceData in _linearRaceDataList)
            {
                if (linearRaceData.RaceEvent == RaceEvent.RaceStarted || 
                    linearRaceData.RaceEvent == RaceEvent.RaceStopped ||
                    linearRaceData.RaceEvent == RaceEvent.RaceFinished)
                {
                    CheckToAddRaceDataToDictionary();
                }

                if (linearRaceData.RaceEvent == RaceEvent.RaceStarted)
                {
                    _startTime = string.Format("{0:yyyy-MM-dd HH:mm:ss.fff}", linearRaceData.TimeStamp);
                    _tempLinearRaceDataList = new List<LinearRaceData>();
                    _shouldAdd = true;
                }
                else if (!string.IsNullOrEmpty(linearRaceData.Laps))
                    _isLapAdded = true;

                if (_shouldAdd)
                    _tempLinearRaceDataList.Add(linearRaceData);

            }
            CheckToAddRaceDataToDictionary();
        }

        private void CheckToAddRaceDataToDictionary()
        {
            if (_tempLinearRaceDataList != null && _isLapAdded && !string.IsNullOrEmpty(_startTime))
            {
                RaceDataDict.Add(new KeyValuePair<string, List<LinearRaceData>>(_startTime, _tempLinearRaceDataList));
                _tempLinearRaceDataList = null;
                _isLapAdded = false;
                _shouldAdd = false;
            }
        }
    }
}
