using System.Collections.Generic;
using System.IO;
using Heinzman.BusinessObjects;

namespace Heinzman.DomainModels.Championships
{
    public class ChampionshipListModel
    {
        private List<string> _championshipFileList;

        public List<string> ChampionshipFileList
        {
            get { return _championshipFileList; }
        }

        public void DetermineChampionshipFileList()
        {
            string[] filesWithPath = Directory.GetFiles(ServiceHelper.ChampionshipsPath, "*.xml");
            _championshipFileList = new List<string>();
            foreach (string fileWithPath in filesWithPath)
            {
                string file = Path.GetFileName(fileWithPath);
                _championshipFileList.Add(file);
            }
            SortChampionshipFileList();
        }

        private void SortChampionshipFileList()
        {
            _championshipFileList.Sort(delegate(string s1, string s2) { return s2.CompareTo(s1); });
        }
    }
}