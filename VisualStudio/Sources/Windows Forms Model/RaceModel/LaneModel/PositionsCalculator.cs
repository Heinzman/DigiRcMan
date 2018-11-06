using Heinzman.BusinessObjects.Lanes;

namespace Heinzman.DomainModels.RaceModel.LaneModel
{
    public class PositionsCalculator
    {
        private readonly RaceModel _raceModel;

        public PositionsCalculator(RaceModel raceModel)
        {
            _raceModel = raceModel;
        }

        public void DoWork()
        {
            _raceModel.Race.OrderByPosition();

            int position = 1;
            foreach (Lane lane in _raceModel.Race.Lanes)
                lane.Position = position++;            
        }

    }
}
