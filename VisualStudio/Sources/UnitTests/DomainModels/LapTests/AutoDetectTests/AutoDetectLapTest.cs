using System.Collections.Generic;
using Elreg.BusinessObjects.Races;
using Elreg.DomainModels;
using Elreg.UnitTests.MockObjects;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests.AutoDetectTests
{
    [TestFixture]
    public class AutoDetectLapTest : BaseAutoDetectLapTest
    {
        [Test]
        public void TestAutoDetectedLapByDefaultAutoDetectLapSpeedSum()
        {
            ForceNormalAutoDetectedLapFor(Race.TypeEnum.Race); 
            Assert.IsTrue(Lane1.Lap == 1);
        }

        [Test]
        public void TestCalcSpeedSumAvgAfter5LapsShouldBe70()
        {
            const int defaultSpeedSum = 0;
            InitAndStartRaceAndAddZerothLap(defaultSpeedSum);
            Add5LapsAndAddSpeedSumAvg70();

            const int expected = 70;
            int? actual = RaceModel.SpeedSumAvgCalculator.SpeedSumAvg;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestAfter2RacesWith2LapsSpeedSumAvgShouldBeNull()
        {
            const int defaultSpeedSum = 0;
            InitAndStartRaceAndAddZerothLap(defaultSpeedSum);
            Add2LapsAndAddSpeedSumAvg();
            RaceModel.StopRace();
            StartRace();
            Add2LapsAndAddSpeedSumAvg();

            Assert.IsNull(RaceModel.SpeedSumAvgCalculator.SpeedSumAvg);
        }

        [Test]
        public void TestAfterRaceWith5LapsSpeedSumAvgShouldBe70()
        {
            const int defaultSpeedSum = 0;
            InitAndStartRaceAndAddZerothLap(defaultSpeedSum);
            Add5LapsAndAddSpeedSumAvg70();
            RaceModel.StopRace();

            const int expected = 70;
            int? actual = RaceModel.SpeedSumAvgCalculator.SpeedSumAvg;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestAutoDetectedLapAfter2LapsWithoutDefaultSpeedSumShouldNotCount()
        {
            const int defaultSpeedSum = 0;
            InitAndStartRaceAndAddZerothLap(defaultSpeedSum);
            Add2LapsAndAddSpeedSumAvg();

            Assert.IsTrue(Lane1.Lap == 2);
            AutoDetectLap();
            Assert.IsTrue(Lane1.Lap == 2);
        }

        [Test]
        public void TestAutoDetectedLapAfter5LapsWithoutDefaultSpeedSum()
        {
            const int defaultSpeedSum = 0;
            InitAndStartRaceAndAddZerothLap(defaultSpeedSum);
            Add5LapsAndAddSpeedSumAvg70();

            Assert.IsTrue(Lane1.Lap == 5);
            AutoDetectLap();
            Assert.IsTrue(Lane1.Lap == 6);
        }

        [Test]
        public void TestAutoDetectedLapAfter5LapsWithoutDefaultSpeedSumExactlyAtSpeedSumAvg70()
        {
            const int defaultSpeedSum = 0;
            InitAndStartRaceAndAddZerothLap(defaultSpeedSum);
            Add5LapsAndAddSpeedSumAvg70();

            Assert.IsTrue(Lane1.Lap == 5);
            for (uint i = 0; i < 70; i++)
                MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, 1, new List<uint> { 1 });
            Assert.IsTrue(Lane1.Lap == 6);
        }

        [Test]
        public void Test2AutoDetectedLapsThenPauseThenNormalLapShouldBeDetected()
        {
            StartTraceLogging();
            InitAndStartRaceAndAddZerothLap(70);
            AutoDetectLap();
            WaitSecondsForValidLap();
            AutoDetectLap();
            WaitSecondsForValidLap();
            RaceModel.PauseRaceByKeyboard();
            WaitSomeMilliSeconds();
            RaceModel.RestartRaceByKeyboardOrArduinoCheckCountDown();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            StopTraceLogging();
            Assert.AreEqual(3, Lane1.Lap);
        }

        [Test]
        public void Test2AutoDetectedLapsThenPauseThenNormalLapShouldNotBeDetecteddueMinSecs()
        {
            StartTraceLogging();
            InitAndStartRaceAndAddZerothLap(70);
            AutoDetectLap();
            WaitSecondsForValidLap();
            AutoDetectLap();
            RaceModel.PauseRaceByKeyboard();
            WaitSomeMilliSeconds();
            RaceModel.RestartRaceByKeyboardOrArduinoCheckCountDown();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            StopTraceLogging();
            Assert.AreEqual(2, Lane1.Lap);
        }

        private void Add2LapsAndAddSpeedSumAvg()
        {
            AddLapAndAddSpeedSumTenTimesOf(7);
            AddLapAndAddSpeedSumTenTimesOf(8);
        }

        private void InitAndStartRaceAndAddZerothLap(int defaultSpeedSum)
        {
            RaceSettings.AutoDetectLapSpeedFactor = 1;
            RaceSettings.StartCountDownRaceActivated = false;
            RaceSettings.RestartCountDownRaceActivated = false;
            RaceModel.SpeedSumAvgCalculator = new SpeedSumAvgCalculator();
            RaceModel.LapTimeAvgCalculator = new MockLapTimeAvgCalculator();
            StartRace();
            AutoDetectLapSpeedSum = defaultSpeedSum;
            AddRegularLapAndWaitValidSeconds();
        }

        private void AddLapAndAddSpeedSumTenTimesOf(uint speedSum)
        {
            for (int i = 0; i < 10; i++)
                MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, speedSum, new List<uint> { speedSum });
            AddRegularLapAndWaitValidSeconds();
        }

        private void Add5LapsAndAddSpeedSumAvg70()
        {
            AddLapAndAddSpeedSumTenTimesOf(9);
            AddLapAndAddSpeedSumTenTimesOf(8);
            AddLapAndAddSpeedSumTenTimesOf(7);
            AddLapAndAddSpeedSumTenTimesOf(6);
            AddLapAndAddSpeedSumTenTimesOf(1); 
        }

    }
}
