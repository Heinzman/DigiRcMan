using Elreg.BusinessObjects.Races;
using Elreg.CentralUnitService.Settings;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.CentralUnitTests.TurboModeActivated.InQualification
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
        public void SlowerCarsHaveTurboConsumption_ABitLess_Then_ForLastCar_FuelConsumptionService_should_get_LitresForTurbo()
        {
            Test_FuelConsumptionService_should_get_LitresForTurbo_For(Options.FuelConsumptionOfSlowerCars.ABitLess, Lane3);
        }

        protected override Race.TypeEnum CompetitionType
        {
            get { return Race.TypeEnum.Qualification; }
        }
    }
}
