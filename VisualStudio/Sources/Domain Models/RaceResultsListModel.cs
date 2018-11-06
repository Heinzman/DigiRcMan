using System.Collections.Generic;
using System.IO;
using Elreg.BusinessObjects;

namespace Elreg.DomainModels
{
    public class RaceResultsListModel
    {
        public List<string> RaceResultsFileList { get; private set; }

        public void DetermineRaceResultsFileList()
        {
            string[] filesWithPath = Directory.GetFiles(ServiceHelper.RaceResultsPath, "*.xml");
            RaceResultsFileList = new List<string>();
            foreach (string fileWithPath in filesWithPath)
            {
                string file = Path.GetFileName(fileWithPath);
                RaceResultsFileList.Add(file);
            }
            SortRaceResultsFileList();
        }

        private void SortRaceResultsFileList()
        {
            RaceResultsFileList.Sort((s1, s2) => System.String.CompareOrdinal(s2, s1));
        }
    }
}
