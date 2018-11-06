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
    public class When_only_DelayMode_is_activated : CentralUnitBaseTest
    {
        protected override void InitCentralUnitOptionsService()
        {
            _centralUnitOptionsService.Options = new Options
                                                     {
                                                         IsCentralUnitActivated = true,
                                                         TurboOptions = new TurboSettings {IsActivated = false},
                                                         StutterOptions = new StutterSettings { IsActivated = false, PercentFuelForStuttering = 10 },
                                                         DelayOptions = new DelaySettings {IsActivated = true, PercentFuelForZeroDelay = 20}
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
        public void In_RaceStatus_started_And_FuelLevel_is_lessThan_PercentFuelForZeroDelay_Then_DelayMode_should_be_None()
        {
            StartCompetition(Race.TypeEnum.Race);
            while (Lane1.CurrentFuelLevelInLitres > 0)
            {
                Lane1.CurrentFuelLevelInLitres -= 1;
                WaitMilliSeconds(50);
                if (Lane1.CurrentFuelLevelInLitres <
                    Lane1.TankMaximumInLitres / 100 * _centralUnitOptionsService.Options.DelayOptions.PercentFuelForZeroDelay)
                {
                    Assert.AreEqual(ArduinoDelayMode.DelayNone, MockArduinoWriter.GetDelayModeOf(LaneId.Lane1));
                }
            }
        }

        [Test]
        public void In_RaceStatus_started_And_FuelLevel_is_full_Then_DelayMode_should_be_DelayMax()
        {
            StartCompetition(Race.TypeEnum.Race);
            WaitMilliSeconds(50);
            Assert.AreEqual(ArduinoDelayMode.DelayMax, MockArduinoWriter.GetDelayModeOf(LaneId.Lane1));
        }

        [Test]
        public void In_RaceStatus_started_And_FuelLevel_isgreaterThan_PercentFuelForZeroDelay_Then_DelayMode_should_be_Delay1()
        {
            StartCompetition(Race.TypeEnum.Race);
            Lane1.CurrentFuelLevelInLitres =
               Lane1.TankMaximumInLitres / 100 * _centralUnitOptionsService.Options.DelayOptions.PercentFuelForZeroDelay + 1;
            WaitMilliSeconds(50);
            Assert.AreEqual(ArduinoDelayMode.Delay1, MockArduinoWriter.GetDelayModeOf(LaneId.Lane1));
        }

        [Test]
        public void In_RaceStatus_stopped_And_FuelLevel_is_greaterThan_PercentFuelForZeroDelay_Then_DelayMode_must_not_be_None()
        {
            StartCompetition(Race.TypeEnum.Race);
            MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, 12, new List<uint> { 12 });

            RaceModel.StopRace();
            while (Lane1.CurrentFuelLevelInLitres > 0)
            {
                Lane1.CurrentFuelLevelInLitres -= 1;
                WaitMilliSeconds(50);
                if (Lane1.CurrentFuelLevelInLitres >
                    Lane1.TankMaximumInLitres / 100 * _centralUnitOptionsService.Options.DelayOptions.PercentFuelForZeroDelay)
                {
                    Assert.AreNotEqual(ArduinoDelayMode.DelayNone, MockArduinoWriter.GetDelayModeOf(LaneId.Lane1));
                }
            }
        }

        public MockArduinoWriter MockArduinoWriter
        {
            get { return (MockArduinoWriter) _arduinoWriter; }
        }
    }
}
