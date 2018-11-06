using System.Collections.Generic;
using System.IO;
using Heinzman.BusinessObjects;

namespace Heinzman.DomainModels
{
    public class RaceResultsListModel
    {
        private List<string> _raceResultsFileList;

        public List<string> RaceResultsFileList
        {
            get { return _raceResultsFileList; }
        }

        public void DetermineRaceResultsFileList()
        {
            string[] filesWithPath = Directory.GetFiles(ServiceHelper.RaceResultsPath, "*.xml");
            _raceResultsFileList = new List<string>();
            foreach (string fileWithPath in filesWithPath)
            {
                string file = Path.GetFileName(fileWithPath);
                _raceResultsFileList.Add(file);
            }
            SortRaceResultsFileList();
        }

        private void SortRaceResultsFileList()
        {
            _raceResultsFileList.Sort((s1, s2) => s2.CompareTo(s1));
        }
    }
}
