using Elreg.BusinessObjects;

namespace Elreg.CentralUnitService.Settings
{
    public class TurboSettings
    {
        public bool IsActivated { get; set; }

        public ControllerLevel? LevelOfTurbo { get; set; }

        public uint MaxLevelWithoutTurbo { get; set; }

        public int MillisecsPressedSinglePeriodForTurbo { get; set; }

        public int NumberOfClicksForTurbo { get; set; }

        public Options.FuelConsumptionOfSlowerCars FuelConsumptionOfSlowerCars { get; set; }

        public float FactorFuelComsumptionOfSlowerCarsABitLess { get; set; }

        public float FactorFuelComsumptionOfSlowerCarsLess { get; set; }

        public float FactorFuelComsumptionOfSlowerCarsMuchLess { get; set; }

        public TurboSettings()
        {
            IsActivated = false;
            MaxLevelWithoutTurbo = (uint)ControllerLevel.L12;
            LevelOfTurbo = ControllerLevel.L15;
            MillisecsPressedSinglePeriodForTurbo = 300;
            NumberOfClicksForTurbo = 2;
            FactorFuelComsumptionOfSlowerCarsABitLess = 0.5f;
            FactorFuelComsumptionOfSlowerCarsLess = 1f;
            FactorFuelComsumptionOfSlowerCarsMuchLess = 2f;
            FuelConsumptionOfSlowerCars = Options.FuelConsumptionOfSlowerCars.Less;
        }



    }
}
