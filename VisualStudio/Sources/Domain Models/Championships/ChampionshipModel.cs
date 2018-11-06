using System;
using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Championships;
using Elreg.BusinessObjects.Lanes;
using Elreg.RaceOptionsService;

namespace Elreg.DomainModels.Championships
{
    public class ChampionshipModel
    {
        private ChampionshipLane _existingChampionshipLane;
        private RaceResult _raceResultToAdd;
        private SerializerService<Championship> _serializerService;

        public List<ChampionshipLane> ChampionshipLanes
        {
            get { return Championship.ChampionshipLanes; }
        }

        public Championship Championship { get; set; }

        public bool NewChampionship { private get; set; }

        public event EventHandler ChampionshipChanged;

        public void Add(RaceResult raceResult)
        {
            _raceResultToAdd = raceResult;
            DetermineOrCreateChampionship();
            Championship.RaceResults.Add(_raceResultToAdd);
            AddPointsToChampionship();
            CalcPositionsOfLanes();
            SaveData();
        }

        public void ChangePointsOfDriver(Driver driver, int points)
        {
            ChampionshipLane championshipLane = ChampionshipLanes.Find(championshipLane2 => championshipLane2.Driver.Id == driver.Id);
            championshipLane.Points = points;
            CalcPositionsOfLanes();
            RaiseEventChampionshipChanged();
        }

        public void DeserializeChampionship(string championshipXmlFile)
        {
            _serializerService = new SerializerService<Championship>(ServiceHelper.ChampionshipsPath,
                                                                     championshipXmlFile);
            Championship = _serializerService.Object;
        }

        private void DetermineOrCreateChampionship()
        {
            var championshipFactory = new ChampionshipFactory(NewChampionship);
            championshipFactory.DetermineOrCreate();
            Championship = championshipFactory.Championship;
            _serializerService = championshipFactory.SerializerService;
        }

        private void RaiseEventChampionshipChanged()
        {
            if (ChampionshipChanged != null)
                ChampionshipChanged(this, null);
        }

        private void AddPointsToChampionship()
        {
            foreach (RaceResultLane raceResultLane in _raceResultToAdd.RaceResultLanes)
            {
                if (ExistsDriverInChampionship(raceResultLane))
                    AddPointsOf(raceResultLane);
                else
                    AddDriverAndPointsOf(raceResultLane);
            }
        }

        private bool ExistsDriverInChampionship(RaceResultLane raceResultLane)
        {
            GetLaneOfChampionshipWithSameDriver(raceResultLane);
            return _existingChampionshipLane != null;
        }

        private void GetLaneOfChampionshipWithSameDriver(RaceResultLane raceResultLane)
        {
            _existingChampionshipLane = null;
            foreach (ChampionshipLane championshipLane in Championship.ChampionshipLanes)
            {
                if (championshipLane.Driver.Id == raceResultLane.Driver.Id)
                    _existingChampionshipLane = championshipLane;
            }
        }

        private void AddPointsOf(RaceResultLane raceResultLane)
        {
            _existingChampionshipLane.Points += raceResultLane.Points;
        }

        private void AddDriverAndPointsOf(RaceResultLane raceResultLane)
        {
            var newChampionshipLane = new ChampionshipLane
                                          {
                                              Driver = raceResultLane.Driver,
                                              Points = raceResultLane.Points
                                          };
            Championship.ChampionshipLanes.Add(newChampionshipLane);
        }

        private void CalcPositionsOfLanes()
        {
            ChampionshipLanes.Sort((l1, l2) => l2.Points.CompareTo(l1.Points));

            ChampionshipLane previousChampionshipLane = null;
            int position = 1;
            foreach (ChampionshipLane championshipLane in ChampionshipLanes)
            {
                if (previousChampionshipLane == null || previousChampionshipLane.Points == championshipLane.Points)
                    championshipLane.Position = position;
                else
                    championshipLane.Position = ++position;
                previousChampionshipLane = championshipLane;
            }
        }

        public void SaveData()
        {
            _serializerService.Save(Championship);
        }
    }
}