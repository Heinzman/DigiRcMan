using System;
using System.Collections.Generic;
using System.IO;
using Heinzman.BusinessObjects;
using Heinzman.BusinessObjects.Championships;
using Heinzman.RaceOptionsService;

namespace Heinzman.DomainModels.Championships
{
    public class ChampionshipFactory
    {
        private readonly bool _newChampionship;
        private Championship _championship;
        private List<string> _championshipFileList;
        private string _latestChampionshipFile;
        private SerializerService<Championship> _serializerService;

        public ChampionshipFactory(bool newChampionship)
        {
            _newChampionship = newChampionship;
        }

        public Championship Championship
        {
            get { return _championship; }
        }

        public SerializerService<Championship> SerializerService
        {
            get { return _serializerService; }
        }

        private string XmlChampionshipFileName
        {
            get { return _championship.Name + ".xml"; }
        }

        public void DetermineOrCreate()
        {
            if (_newChampionship)
                CreateNewChampionship();
            else
                LoadLatestSavedChampionship();
        }

        private void LoadLatestSavedChampionship()
        {
            try
            {
                DetermineChampionshipFileList();
                DetermineLatestChampionshipFile();
                DeserializeChampionship();
            }
            catch (Exception)
            {
                CreateNewChampionship();
            }
        }

        private void CreateNewChampionship()
        {
            _championship = new Championship();
            _serializerService = new SerializerService<Championship>(ServiceHelper.ChampionshipsPath,
                                                                     XmlChampionshipFileName);
        }

        private void DetermineChampionshipFileList()
        {
            string[] files = Directory.GetFiles(ServiceHelper.ChampionshipsPath, "*.xml");
            _championshipFileList = new List<string>(files);
        }

        private void DetermineLatestChampionshipFile()
        {
            _championshipFileList.Sort();
            string latestChampionshipFileWithPath = _championshipFileList[_championshipFileList.Count - 1];
            _latestChampionshipFile = Path.GetFileName(latestChampionshipFileWithPath);
        }

        private void DeserializeChampionship()
        {
            _serializerService = new SerializerService<Championship>(ServiceHelper.ChampionshipsPath,
                                                                     _latestChampionshipFile);
            _championship = _serializerService.Object;
        }
    }
}