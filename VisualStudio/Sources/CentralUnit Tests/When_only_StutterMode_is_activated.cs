using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Races;
using Elreg.CentralUnitService.Settings;
using Elreg.UnitTests.MockObjects;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Elreg.UnitTests.CentralUnitTests
{
    [TestFixture]
    public class When_only_StutterMode_is_activated : CentralUnitBaseTest
    {
        protected override void InitCentralUnitOptionsService()
        {
            _centralUnitOptionsService.Options = new Options
                                                     {
                                                         IsCentralUnitActivated = true,
                                                         TurboOptions = new TurboSettings {IsActivated = false},
                                                         StutterOptions = new StutterSettings {IsActivated = true, PercentFuelForStuttering = 10},
                                                         DelayOptions = new DelaySettings {IsActivated = false}
                                                     };
        }

        [Test]
        public void In_RaceStatus_initialized_And_all_Fuel_levels_Then_DelayMode_should_be_None()
        {
            while (Lane1.CurrentFuelLevelInLitres > 0)
            {
                Lane1.CurrentFuelLevelInLitres -= 1;
                Assert.AreEqual(ArduinoDelayMode.DelayNone, MockArduinoWriter.GetDelayModeOf(LaneId.Lane1));
            }
        }

        [Test]
        public void In_RaceStatus_started_And_FuelLevel_is_greaterThan_PercentFuelForStutterMin_Then_DelayMode_should_be_None()
        {
            StartCompetition(Race.TypeEnum.Race);
            while (Lane1.CurrentFuelLevelInLitres > 0)
            {
                Lane1.CurrentFuelLevelInLitres -= 1;
                WaitMilliSeconds(50);
                if (Lane1.CurrentFuelLevelInLitres >
                    Lane1.TankMaximumInLitres / 100 * _centralUnitOptionsService.Options.StutterOptions.PercentFuelForStuttering)
                {
                    Assert.AreEqual(ArduinoDelayMode.DelayNone, MockArduinoWriter.GetDelayModeOf(LaneId.Lane1));
                }
            }
        }

        [Test]
        public void In_RaceStatus_started_And_FuelLevel_is_lessThan_PercentFuelForStutterMin_Then_DelayMode_should_be_StutterMin()
        {
            StartCompetition(Race.TypeEnum.Race);
            Lane1.CurrentFuelLevelInLitres =
                Lane1.TankMaximumInLitres / 100 * _centralUnitOptionsService.Options.StutterOptions.PercentFuelForStuttering - 1;
            WaitMilliSeconds(50);
            Assert.AreEqual(ArduinoDelayMode.StutterMin, MockArduinoWriter.GetDelayModeOf(LaneId.Lane1));
        }

        [Test]
        public void In_RaceStatus_started_And_FuelLevel_is_lessThan_PercentFuelForStutterMedium_Then_DelayMode_should_be_StutterMedium()
        {
            StartCompetition(Race.TypeEnum.Race);
            int percentForStutterMedium = _centralUnitOptionsService.Options.StutterOptions.PercentFuelForStuttering * 2 / 3;
            Lane1.CurrentFuelLevelInLitres = Lane1.TankMaximumInLitres / 100 * percentForStutterMedium - 1;
            WaitMilliSeconds(50);
            Assert.AreEqual(ArduinoDelayMode.StutterMedium, MockArduinoWriter.GetDelayModeOf(LaneId.Lane1));
        }

        [Test]
        public void In_RaceStatus_started_And_FuelLevel_is_lessThan_PercentFuelForStutterMax_Then_DelayMode_should_be_StutterMax()
        {
            StartCompetition(Race.TypeEnum.Race);
            int percentForStutterMax = _centralUnitOptionsService.Options.StutterOptions.PercentFuelForStuttering / 3;
            Lane1.CurrentFuelLevelInLitres = Lane1.TankMaximumInLitres / 100 * percentForStutterMax - 1;
            WaitMilliSeconds(50);
            Assert.AreEqual(ArduinoDelayMode.StutterMax, MockArduinoWriter.GetDelayModeOf(LaneId.Lane1));
        }

        [Test]
        public void In_RaceStatus_started_And_FuelLevel_is_Zero_Then_DelayMode_should_be_StutterMax()
        {
            StartCompetition(Race.TypeEnum.Race);
            Lane1.CurrentFuelLevelInLitres = 0;
            WaitMilliSeconds(50);
            Assert.AreEqual(ArduinoDelayMode.StutterMax, MockArduinoWriter.GetDelayModeOf(LaneId.Lane1));
        }

        [Test]
        public void In_RaceStatus_started_And_FuelLevel_is_lessThan_Zero_Then_DelayMode_should_be_StutterMax()
        {
            StartCompetition(Race.TypeEnum.Race);
            Lane1.CurrentFuelLevelInLitres = -10;
            WaitMilliSeconds(50);
            Assert.AreEqual(ArduinoDelayMode.StutterMax, MockArduinoWriter.GetDelayModeOf(LaneId.Lane1));
        }

        [Test]
        public void In_RaceStatus_stopped_And_all_Fuel_levels_Then_DelayMode_should_be_None()
        {
            StartCompetition(Race.TypeEnum.Race);
            MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, 12, new List<uint> { 12 });

            RaceModel.StopRace();
            while (Lane1.CurrentFuelLevelInLitres < 100)
            {
                Lane1.CurrentFuelLevelInLitres += 1;
                Assert.AreEqual(ArduinoDelayMode.DelayNone, MockArduinoWriter.GetDelayModeOf(LaneId.Lane1));
            }
        }

        public MockArduinoWriter MockArduinoWriter
        {
            get { return (MockArduinoWriter) _arduinoWriter; }
        }
    }
}
