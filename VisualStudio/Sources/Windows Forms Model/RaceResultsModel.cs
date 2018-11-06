using System;
using Heinzman.BusinessObjects;
using Heinzman.BusinessObjects.Championships;
using Heinzman.BusinessObjects.Interfaces;
using Heinzman.BusinessObjects.Lanes;
using Heinzman.BusinessObjects.Races;
using Heinzman.RaceOptionsService;
using System.IO;

namespace Heinzman.DomainModels
{
    public class RaceResultsModel
    {
        private readonly RaceModel.RaceModel _raceModel;
        private IRaceResult _raceResult;
        private SerializerService<RaceResult> _serializerService;
        public event EventHandler ResultsChanged;

        public RaceResultsModel(RaceModel.RaceModel raceModel)
        {
            _raceModel = raceModel;
        }

        public IRaceResult RaceResult
        {
            get
            {
                if (_raceResult == null)
                    return new RaceResultNullValue();
                else
                    return _raceResult;
            }
            set { _raceResult = value; }
        }

        public void ChangePositionOfLane(LaneId laneId, int position)
        {
            RaceResultLane currentLane = GetLaneById(laneId);
            currentLane.Position = position;
            CalcPointsOfAllLanes();
            RaiseEventResultsChanged();
        }

        public void ChangePointsOfLane(LaneId laneId, int points)
        {
            RaceResultLane currentLane = GetLaneById(laneId);
            currentLane.Points = points;
            RaiseEventResultsChanged();
        }

        public bool IsTraining
        {
            get { return RaceResult.RaceType == Race.TypeEnum.Training; }
        }

        public bool IsQualification
        {
            get { return RaceResult.RaceType == Race.TypeEnum.Qualification; }
        }

        public bool IsRace
        {
            get { return RaceResult.RaceType == Race.TypeEnum.Race; }
        }

        public void CreateRaceResult()
        {
            RaceResult raceResult = new RaceResult();
            raceResult.Create(_raceModel.Race.Lanes, _raceModel.Race.Type);
            RaceResult = raceResult;
            CreateSerializerService();
            CalcPointsOfAllLanes();
            SaveData();
        }

        public bool CanBeUsedForChampionship
        {
            get { return IsRace; }
        }

        public void SaveData()
        {
            if (RaceResult is RaceResult)
                _serializerService.Save((RaceResult)RaceResult);
        }

        public void DeleteRaceResult()
        {
            string fileWithPath = Path.Combine(ServiceHelper.RaceResultsPath, XmlRaceResultFileName);
            File.Delete(fileWithPath);
        }

        public void DeserializeRaceResults(string raceResultsXmlFile)
        {
            _serializerService = new SerializerService<RaceResult>(ServiceHelper.RaceResultsPath, raceResultsXmlFile);
            RaceResult = _serializerService.Object;
        }

        private void CalcPointsOfAllLanes()
        {
            foreach (RaceResultLane raceResultLane in RaceResult.RaceResultLanes)
            {
                if (raceResultLane.IsDisqualified)
                    raceResultLane.Points = 0;
                else
                    switch (raceResultLane.Position)
                    {
                        case 1:
                            raceResultLane.Points = 12;
                            break;
                        case 2:
                            raceResultLane.Points = 9;
                            break;
                        case 3:
                            raceResultLane.Points = 7;
                            break;
                        case 4:
                            raceResultLane.Points = 5;
                            break;
                        case 5:
                            raceResultLane.Points = 3;
                            break;
                        case 6:
                            raceResultLane.Points = 1;
                            break;
                    }
            }
        }

        private void CreateSerializerService()
        {
            _serializerService = new SerializerService<RaceResult>(ServiceHelper.RaceResultsPath, XmlRaceResultFileName);
        }

        private void RaiseEventResultsChanged()
        {
            if (ResultsChanged != null)
                ResultsChanged(this, null);
        }

        private string XmlRaceResultFileName
        {
            get 
            { 
                string fileName = RaceResult.Name + ".xml";
                if (RaceResult.RaceType != Race.TypeEnum.Race)
                    fileName = "_" + fileName;
                return fileName;
            }
        }

        private RaceResultLane GetLaneById(LaneId laneId)
        {
            return RaceResult.RaceResultLanes.Find(lane => lane.Id == laneId);
        }

    }
}
