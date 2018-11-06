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
    public class When_DelayAndStutterMode_is_deactivated : CentralUnitBaseTest
    {
        protected override void InitCentralUnitOptionsService()
        {
            _centralUnitOptionsService.Options = new Options
                                                     {
                                                         IsCentralUnitActivated = true,
                                                         TurboOptions = new TurboSettings {IsActivated = false},
                                                         StutterOptions = new StutterSettings {IsActivated = false},
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
        public void In_RaceStatus_started_And_all_Fuel_levels_Then_DelayMode_should_be_None()
        {
            StartCompetition(Race.TypeEnum.Race);
            while (Lane1.CurrentFuelLevelInLitres > 0)
            {
                MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, 12, new List<uint> {12});
                Assert.AreEqual(ArduinoDelayMode.DelayNone, MockArduinoWriter.GetDelayModeOf(LaneId.Lane1));
            }
        }

        [Test]
        public void In_RaceStatus_stopped_And_all_Fuel_levels_Then_DelayMode_should_be_None()
        {
            In_RaceStatus_started_And_all_Fuel_levels_Then_DelayMode_should_be_None();
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
