using System;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Championships;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Races;
using Elreg.RaceOptionsService;
using System.IO;

namespace Elreg.DomainModels
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

        public IRaceResult CreateRaceResult()
        {
            IRaceResult raceResult = new RaceResult();
            raceResult.Create(_raceModel.Race.Lanes, _raceModel.Race.Type);
            RaceResult = raceResult;
            CreateSerializerService();
            CalcPointsOfAllLanes();
            SaveData();
            return raceResult;
        }

        public bool CanBeUsedForChampionship
        {
            get { return IsRace; }
        }

        public void SaveData()
        {
            var raceResult = RaceResult as RaceResult;
            if (raceResult != null)
                _serializerService.Save(raceResult);
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
                            raceResultLane.Points = _raceModel.RaceSettings.PointsForPosition1;
                            break;
                        case 2:
                            raceResultLane.Points = _raceModel.RaceSettings.PointsForPosition2;
                            break;
                        case 3:
                            raceResultLane.Points = _raceModel.RaceSettings.PointsForPosition3;
                            break;
                        case 4:
                            raceResultLane.Points = _raceModel.RaceSettings.PointsForPosition4;
                            break;
                        case 5:
                            raceResultLane.Points = _raceModel.RaceSettings.PointsForPosition5;
                            break;
                        case 6:
                            raceResultLane.Points = _raceModel.RaceSettings.PointsForPosition6;
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
