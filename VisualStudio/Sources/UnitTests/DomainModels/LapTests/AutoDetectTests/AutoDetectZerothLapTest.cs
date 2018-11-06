using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Races;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests.AutoDetectTests
{
    [TestFixture]
    public class AutoDetectZerothLapTest : BaseAutoDetectLapTest
    {
        [Test]
        public void TestSpeedSumShouldBeNullAfterStart()
        {
            InitAndStartCompetition(Race.TypeEnum.Race);

            int? actual = RaceModel.SpeedSumAvgCalculator.SpeedSumAvgOfZerothLap;
            Assert.AreEqual(null, actual);
        }

        [Test]
        public void TestSpeedSumShouldBeNullAfterFirstCar()
        {
            InitAndStartCompetition(Race.TypeEnum.Race);

            AddLapAndAddSpeedSumTenTimesOf(LaneId.Lane1, 1);

            int? actual = RaceModel.SpeedSumAvgCalculator.SpeedSumAvgOfZerothLap;
            Assert.AreEqual(null, actual);
        }

        [Test]
        public void TestSpeedSumShouldBe10AfterSecondCar()
        {
            InitAndStartCompetition(Race.TypeEnum.Race);

            AddLapAndAddSpeedSumTenTimesOf(LaneId.Lane1, 1);
            AddLapAndAddSpeedSumTenTimesOf(LaneId.Lane2, 1);

            int? actual = RaceModel.SpeedSumAvgCalculator.SpeedSumAvgOfZerothLap;
            const int expected = 10;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestThirdCarShouldBeAutoDetectedAfterSpeedsumOf15()
        {
            ForceZerothAutoDetectedLapForLane3For(Race.TypeEnum.Race);
            Assert.AreEqual(0, Lane3.Lap);
        }

        [Test]
        public void TestRegularLapImmediatlyAfterAutoDetectedZerothLapShouldNotBeValid()
        {
            InitAndStartCompetition(Race.TypeEnum.Race);
            AddLapAndAddSpeedSumTenTimesOf(LaneId.Lane1, 1);
            AddLapAndAddSpeedSumTenTimesOf(LaneId.Lane2, 1);
            AddSpeedSumTenTimesOf(LaneId.Lane3, 2);

            Assert.AreEqual(0, Lane3.Lap);
            MockRaceDataProvider.RaiseAddLapForLane(LaneId.Lane3);
            Assert.AreEqual(0, Lane3.Lap);
        }

        [Test]
        public void TestWaitMinSecsThenAutoDetectedZerothLapThenRegularLapShouldNotBeValid()
        {
            InitAndStartCompetition(Race.TypeEnum.Race);
            WaitSecondsForValidLap();
            AddLapAndAddSpeedSumTenTimesOf(LaneId.Lane1, 1);
            AddLapAndAddSpeedSumTenTimesOf(LaneId.Lane2, 1);
            AddSpeedSumTenTimesOf(LaneId.Lane3, 2);
            Assert.AreEqual(0, Lane3.Lap);
            MockRaceDataProvider.RaiseAddLapForLane(LaneId.Lane3);
            Assert.AreEqual(0, Lane3.Lap);
        }

        [Test]
        public void TestAutoDetectedZerothLapThenConsumeHalfSpeedSumAvgButNotWaitMinSecsRegularLapShouldNotBeValid()
        {
            AutoDetectLapSpeedSum = 100;
            InitAndStartCompetition(Race.TypeEnum.Race);
            AddLapAndAddSpeedSumTenTimesOf(LaneId.Lane1, 1);
            AddLapAndAddSpeedSumTenTimesOf(LaneId.Lane2, 1);
            AddSpeedSumTenTimesOf(LaneId.Lane3, 2);
            Assert.AreEqual(0, Lane3.Lap);
            AddSpeedSumTenTimesOf(LaneId.Lane3, 6);
            MockRaceDataProvider.RaiseAddLapForLane(LaneId.Lane3);
            Assert.AreEqual(0, Lane3.Lap);
        }

        [Test]
        public void TestAutoDetectedZerothLapThenConsumeHalfSpeedSumAvgThenWaitMinSecsRegularLapShouldBeValid()
        {
            AutoDetectLapSpeedSum = 100;
            InitAndStartCompetition(Race.TypeEnum.Race);
            AddLapAndAddSpeedSumTenTimesOf(LaneId.Lane1, 1);
            AddLapAndAddSpeedSumTenTimesOf(LaneId.Lane2, 1);
            AddSpeedSumTenTimesOf(LaneId.Lane3, 2);
            Assert.AreEqual(0, Lane3.Lap);
            AddSpeedSumTenTimesOf(LaneId.Lane3, 6);
            WaitSecondsForValidLap();
            MockRaceDataProvider.RaiseAddLapForLane(LaneId.Lane3);
            Assert.AreEqual(1, Lane3.Lap);
        }

        [Test]
        public void TestWithInitalSpeedSumAvgEqualsZeroStartAutoDetectedZerothLapThenWaitMinSecsRegularLapShouldBeValid()
        {
            InitAndStartCompetition(Race.TypeEnum.Race);
            AddLapAndAddSpeedSumTenTimesOf(LaneId.Lane1, 1);
            AddLapAndAddSpeedSumTenTimesOf(LaneId.Lane2, 1);
            AddSpeedSumTenTimesOf(LaneId.Lane3, 2);
            Assert.AreEqual(0, Lane3.Lap);
            WaitSecondsForValidLap();
            MockRaceDataProvider.RaiseAddLapForLane(LaneId.Lane3);
            Assert.AreEqual(1, Lane3.Lap);
        }

    }
}
