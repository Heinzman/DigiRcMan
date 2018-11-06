using Heinzman.BusinessObjects.Lanes;
using Heinzman.BusinessObjects.Options;

namespace Heinzman.DomainModels.RaceModel.LaneModel
{
    public class FuelConsumptionCalculator
    {
        private readonly Lane _lane;
        private readonly RaceSettings _raceSettings;
        private float _calcedLitresToConsume;

        public FuelConsumptionCalculator(Lane lane, RaceSettings raceSettings)
        {
            _lane = lane;
            _raceSettings = raceSettings;
        }

        public void CalcAndConsume(float litres)
        {
            CalcCurrentLitresToConsume(litres);
            _lane.ConsumeFuelInLitres(_calcedLitresToConsume);
        }

        public float CalcCurrentLitresToConsume(float litres)
        {
            float calcedLitresByConsumptionFactor = litres * _lane.FuelConsumptionFactor * FuelConsumptionFactorViaSetting;
            CalcLitresToConsume(calcedLitresByConsumptionFactor);
            return _calcedLitresToConsume;
        }

        private float FuelConsumptionFactorViaSetting
        {
            get { return _raceSettings.FuelConsumptionCircaPerLap / _raceSettings.FuelConsumptionDefaultPerLap; }
        }

        private void CalcLitresToConsume(float litres)
        {
            if (IsTankEmptyAndNegativeFuelLevelIsNotAllowed(litres))
                _calcedLitresToConsume = _lane.CurrentFuelLevelInLitres;
            else
                _calcedLitresToConsume = litres;
        }

        private bool IsTankEmptyAndNegativeFuelLevelIsNotAllowed(float calcedLitresByConsumptionFactor)
        {
            return _raceSettings.NegativeFuelLevelEnabled == false && calcedLitresByConsumptionFactor > _lane.CurrentFuelLevelInLitres;
        }


    }
}
