using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.Races;
using Elreg.CentralUnitService.Settings;
using Elreg.DomainModels;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.CentralUnitTests.TurboModeDeactivated
{
    [TestFixture]
    public class When_Speed_Is_Max : CentralUnitBaseTest
    {
        private const uint MaxSpeed = 12;

        protected override void InitCentralUnitOptionsService()
        {
            _centralUnitOptionsService.Options = new Options
            {
                IsCentralUnitActivated = true,
                TurboOptions =
                {
                    IsActivated = false,
                    MaxLevelWithoutTurbo = (uint)ControllerLevel.L14,
                    LevelOfTurbo = ControllerLevel.L15
                }
            };
        }

        [Test]
        public void FuelConsumptionService_should_get_LitresForSpeed12()
        {
            FuelConsumptionPerSpeed fuelConsumptionPerSpeed = new FuelConsumptionPerSpeed();
            FuelConsumption fuelConsumption = InitFuelConsumption(fuelConsumptionPerSpeed);

            StartRace();
            MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, MaxSpeed, new List<uint> { MaxSpeed });

            float actualFuel = fuelConsumption.GetFuelConsumptionPer(MaxSpeed, Lane1, Race.TypeEnum.Race);
            float expectedFuel = fuelConsumptionPerSpeed.LitresForSpeed12 / fuelConsumptionPerSpeed.FuelCalcDivider;
            Assert.AreEqual(expectedFuel, actualFuel);
        }

    }
}
