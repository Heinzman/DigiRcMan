using System;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.Races;
using Elreg.CentralUnitService.Settings;
using Elreg.HelperClasses;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.CentralUnitTests.TurboModeActivated.InRace
{
    [TestFixture]
    public class When_Speed_Is_Max_And : TurboModeBaseTest
    {
        [Test]
        public void SlowerCarsHaveTurboConsumption_Same_Then_ForFirstCar_FuelConsumptionService_should_get_LitresForTurbo()
        {
            Test_FuelConsumptionService_should_get_LitresForTurbo_For(Options.FuelConsumptionOfSlowerCars.Equal, Lane1);
        }

        [Test]
        public void SlowerCarsHaveTurboConsumption_ABitLess_Then_ForFirstCar_FuelConsumptionService_should_get_LitresForTurbo()
        {
            Test_FuelConsumptionService_should_get_LitresForTurbo_For(Options.FuelConsumptionOfSlowerCars.ABitLess, Lane1);
        }

        [Test]
        public void SlowerCarsHaveTurboConsumption_Less_Then_ForFirstCar_FuelConsumptionService_should_get_LitresForTurbo()
        {
            Test_FuelConsumptionService_should_get_LitresForTurbo_For(Options.FuelConsumptionOfSlowerCars.Less, Lane1);
        }

        [Test]
        public void SlowerCarsHaveTurboConsumption_MuchLess_Then_ForFirstCar_FuelConsumptionService_should_get_LitresForTurbo()
        {
            Test_FuelConsumptionService_should_get_LitresForTurbo_For(Options.FuelConsumptionOfSlowerCars.MuchLess, Lane1);
        }

        [Test]
        public void SlowerCarsHaveTurboConsumption_Same_Then_ForLastCar_FuelConsumptionService_should_get_LitresForTurbo()
        {
            Test_FuelConsumptionService_should_get_LitresForTurbo_For(Options.FuelConsumptionOfSlowerCars.Equal, Lane3);
        }

        [Test]
        public void SlowerCarsHaveTurboConsumption_ABitLess_Then_ForLastCar_FuelConsumptionService_should_get_ABitLessThanLitresForTurbo()
        {
            FuelConsumptionPerSpeed fuelConsumptionPerSpeed;
            var actualFuel = GetFuelConsumptionOf(Options.FuelConsumptionOfSlowerCars.ABitLess, Lane3, out fuelConsumptionPerSpeed);
            const int expectedPos = 3;
            Assert.AreEqual(expectedPos, Lane3.Position);
            float factor = _centralUnitOptionsService.Options.TurboOptions.FactorFuelComsumptionOfSlowerCarsABitLess;
            float expectedFuel = (fuelConsumptionPerSpeed.LitresForTurboSpeed - (expectedPos - 1)*factor) / fuelConsumptionPerSpeed.FuelCalcDivider;

            expectedFuel = (fuelConsumptionPerSpeed.LitresForTurboSpeed -
                           ((fuelConsumptionPerSpeed.LitresForTurboSpeed - fuelConsumptionPerSpeed.LitresForSpeed12)/5*
                            factor * (expectedPos - 1))) / fuelConsumptionPerSpeed.FuelCalcDivider;

            Assert.IsTrue(Math.Abs(expectedFuel - actualFuel) < SystemHelper.Epsilon);
        }

        protected override Race.TypeEnum CompetitionType
        {
            get { return Race.TypeEnum.Race; }
        }

    }
}
