using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.Races;
using Elreg.CentralUnitService.Settings;
using Elreg.DomainModels;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.CentralUnitTests.TurboModeActivated
{
    public abstract class TurboModeBaseTest : CentralUnitBaseTest
    {
        private const uint MaxSpeed = 12;

        protected override void InitCentralUnitOptionsService()
        {
            _centralUnitOptionsService.Options = new Options
            {
                IsCentralUnitActivated = true,
                TurboOptions =
                {
                    IsActivated = true,
                    MaxLevelWithoutTurbo = (uint)ControllerLevel.L14,
                    LevelOfTurbo = ControllerLevel.L15
                }
            };
        }

        protected void Test_FuelConsumptionService_should_get_LitresForTurbo_For(Options.FuelConsumptionOfSlowerCars fuelConsumptionOfSlowerCars, Lane lane)
        {
            FuelConsumptionPerSpeed fuelConsumptionPerSpeed;
            var actualFuel = GetFuelConsumptionOf(fuelConsumptionOfSlowerCars, lane, out fuelConsumptionPerSpeed);
            float expectedFuel = fuelConsumptionPerSpeed.LitresForTurboSpeed / fuelConsumptionPerSpeed.FuelCalcDivider;
            Assert.AreEqual(expectedFuel, actualFuel);
        }

        protected float GetFuelConsumptionOf(Options.FuelConsumptionOfSlowerCars fuelConsumptionOfSlowerCars, Lane lane,
                                           out FuelConsumptionPerSpeed fuelConsumptionPerSpeed)
        {
            _centralUnitOptionsService.Options.TurboOptions.FuelConsumptionOfSlowerCars = fuelConsumptionOfSlowerCars;
            fuelConsumptionPerSpeed = new FuelConsumptionPerSpeed();
            FuelConsumption fuelConsumption = InitFuelConsumption(fuelConsumptionPerSpeed);

            StartCompetition(CompetitionType);
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            MockRaceDataProvider.RaiseAddLapForLane(Lane3.Id); 
            Lane1.Lap = 0;
            Lane2.Lap = 0;
            Lane3.Lap = 0;
            lane.Lap = 0;
            MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(lane.Id, MaxSpeed, new List<uint> { MaxSpeed });

            float actualFuel = fuelConsumption.GetFuelConsumptionPer(MaxSpeed, lane, CompetitionType);
            return actualFuel;
        }

        protected abstract Race.TypeEnum CompetitionType { get; }

    }
}
