using System;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.Races;
using Elreg.CentralUnitService.Settings;
using Elreg.DomainModels;
using Elreg.HelperClasses;
using Elreg.RaceOptionsService;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.FuelConsumptionTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    // ReSharper disable PossibleInvalidOperationException
    public class When_Speed12_Is_Handled : BaseLapTest
    {
        private FuelConsumption _fuelConsumption;
        private Options _centralUnitOption; 

        [SetUp]
        public void StartUp()
        {
            _centralUnitOption = new Options {IsCentralUnitActivated = true, TurboOptions = {IsActivated = true}};
            _fuelConsumption = new FuelConsumption(new FuelConsumptionService()) { Options = _centralUnitOption };
        }

        [Test]
        public void And_TurboOption_is_Off_Then_Calced_Lites_Should_Be_LitresForSpeed12()
        {
            _centralUnitOption.TurboOptions.IsActivated = false;
            Lane lane = new Lane {Position = 1, Lap = 1};
            float litres = _fuelConsumption.GetFuelConsumptionPer(12, lane, Race.TypeEnum.Race);
            float expectedLitres = FuelConsumptionPerSpeed.LitresForSpeed12 / FuelConsumptionPerSpeed.FuelCalcDivider;
            Assert.AreEqual(expectedLitres, litres);
        }

        [Test]
        public void And_TurboOption_is_On_And_First_Position_Then_Calced_Lites_Should_Be_LitresForTurboSpeed()
        {
            Lane lane = new Lane { Position = 1, Lap = 1 };
            float litres = _fuelConsumption.GetFuelConsumptionPer(12, lane, Race.TypeEnum.Race);
            float expectedLitres = FuelConsumptionPerSpeed.LitresForTurboSpeed / FuelConsumptionPerSpeed.FuelCalcDivider;
            Assert.AreEqual(expectedLitres, litres);
        }

        [Test]
        public void And_TurboOption_is_On_And_Position_is_6_And_ConsumptionOpt_Less_Is_1_Then_Calced_Lites_Should_Be_LitresForSpeed12()
        {
            _centralUnitOption.TurboOptions.FuelConsumptionOfSlowerCars = Options.FuelConsumptionOfSlowerCars.Less;
            _centralUnitOption.TurboOptions.FactorFuelComsumptionOfSlowerCarsLess = 1;
            Lane lane = new Lane { Position = 6, Lap = 1 };
            float litres = _fuelConsumption.GetFuelConsumptionPer(12, lane, Race.TypeEnum.Race);
            float expectedLitres = FuelConsumptionPerSpeed.LitresForSpeed12 / FuelConsumptionPerSpeed.FuelCalcDivider;
            Assert.AreEqual(expectedLitres, litres);
        }

        [Test]
        public void And_TurboOption_is_On_And_Position_is_6_And_ConsumptionOpt_MuchLess_Is_2_Then_Calced_Lites_Should_Be_LitresForSpeed12()
        {
            _centralUnitOption.TurboOptions.FuelConsumptionOfSlowerCars = Options.FuelConsumptionOfSlowerCars.MuchLess;
            _centralUnitOption.TurboOptions.FactorFuelComsumptionOfSlowerCarsLess = 2;
            Lane lane = new Lane { Position = 6, Lap = 1 };
            float litres = _fuelConsumption.GetFuelConsumptionPer(12, lane, Race.TypeEnum.Race);
            float expectedLitres = FuelConsumptionPerSpeed.LitresForSpeed12 / FuelConsumptionPerSpeed.FuelCalcDivider;
            Assert.AreEqual(expectedLitres, litres);
        }

        [Test]
        public void And_TurboOption_is_On_And_Position_is_6_And_ConsumptionOpt_ABitLess_Is_05_Then_Calced_Lites_Should_Be_GreaterThanLitresForSpeed12()
        {
            _centralUnitOption.TurboOptions.FuelConsumptionOfSlowerCars = Options.FuelConsumptionOfSlowerCars.ABitLess;
            _centralUnitOption.TurboOptions.FactorFuelComsumptionOfSlowerCarsLess = 0.5f;
            Lane lane = new Lane { Position = 6, Lap = 1 };
            float litres = _fuelConsumption.GetFuelConsumptionPer(12, lane, Race.TypeEnum.Race);

            Assert.IsTrue(Math.Abs(litres - FuelConsumptionPerSpeed.LitresForSpeed12 / FuelConsumptionPerSpeed.FuelCalcDivider) > SystemHelper.Epsilon);
            Assert.IsTrue(Math.Abs(litres - FuelConsumptionPerSpeed.LitresForTurboSpeed / FuelConsumptionPerSpeed.FuelCalcDivider) > SystemHelper.Epsilon);
        }

        private FuelConsumptionPerSpeed FuelConsumptionPerSpeed
        {
            get { return _fuelConsumption.FuelConsumptionPerSpeed; }
        }
    }
}
