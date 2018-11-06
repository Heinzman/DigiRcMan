using System;
using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.DomainModels.RaceTimeTests
{
    [TestFixture]
    public class RaceTimeTest : BaseLapTest
    {
        private delegate void CreateInitialLanesFunc();

        private CreateInitialLanesFunc _createInitialLanesFunc;

        private const double EpsilonFactor = 0.15f;

        [Test]
        public void WhenRaceWithoutPauseIs1SecThenLapTimeOfAllLanesShouldBe1Sec()
        {
            const int secs = 1;
            TestLapTimeWithoutPause(secs);
        }

        [Test]
        public void WhenRaceIs1SecAndPauseIs1SecThenLapTimeOfAllLanesShouldBe2Sec()
        {
            const int secs = 1;
            const int expectedRaceTime = secs * 2;

            TestLapTimeNetWithPause(expectedRaceTime, secs);
        }

        [Test]
        public void WhenRaceIs1SecAndPauseIs1SecThenLapTimeNetOfAllLanesShouldBe1Sec()
        {
            const int secs = 1;
            const int expectedRaceTime = secs;

            TestLapTimeNetWithPause(expectedRaceTime, secs);
        }

        [Test]
        public void WhenRaceWithoutPauseIs1SecThenRaceTimeNetOfAllLanesShouldBe1Sec()
        {
            const int secs = 1;
            TestLapTimeNetWithoutPause(secs);
        }

        [Test]
        [Category("LongRunning")]
        public void WhenRaceWithoutPauseIs671SecThenRaceTimeOfAllLanesShouldBe671Sec()
        {
            const int secs = 671;
            TestLapTimeWithoutPause(secs);
        }

        [Test]
        [Category("LongRunning")]
        public void WhenRaceWithoutPauseIs704SecThenRaceTimeNetOfAllLanesShouldBe704Sec()
        {
            const int secs = 704;
            TestLapTimeNetWithoutPause(secs);
        }

        private void TestRaceTimeWithPause(int expectedRaceTime, int secs)
        {
            AddLapsForAllLanesAndWait(secs);
            PauseForSecs(secs);
            AddLapsForAllLanes();
            AssertLapTimeOfAllLanes(secs);
        }

        private void PauseForSecs(int secs)
        {
            RaceModel.PauseRaceByKeyboard();
            WaitSeconds(secs);
            RaceModel.RestartRaceByKeyboardOrArduinoCheckCountDown();
        }

        private void TestLapTimeNetWithPause(int expectedRaceTime, int secs)
        {
            AddLapsForAllLanesAndWait(secs);
            PauseForSecs(secs);
            AddLapsForAllLanes();
            AssertLapTimeNetOfAllLanes(expectedRaceTime);
        }

        private void AssertLapTimeNetOfAllLanes(int expectedRaceTime)
        {
            Assert.IsTrue(Math.Abs(Lane1.LapTimeNet.Value.TotalSeconds) < expectedRaceTime*(1 + EpsilonFactor));
            Assert.IsTrue(Math.Abs(Lane2.LapTimeNet.Value.TotalSeconds) < expectedRaceTime*(1 + EpsilonFactor));
            Assert.IsTrue(Math.Abs(Lane3.LapTimeNet.Value.TotalSeconds) < expectedRaceTime*(1 + EpsilonFactor));
            Assert.IsTrue(Math.Abs(Lane4.LapTimeNet.Value.TotalSeconds) < expectedRaceTime*(1 + EpsilonFactor));
            Assert.IsTrue(Math.Abs(Lane5.LapTimeNet.Value.TotalSeconds) < expectedRaceTime*(1 + EpsilonFactor));
            Assert.IsTrue(Math.Abs(Lane6.LapTimeNet.Value.TotalSeconds) < expectedRaceTime*(1 + EpsilonFactor));
        }

        private void TestLapTimeNetWithoutPause(int secs)
        {
            AddLapsForAllLanesAndWait(secs);
            AddLapsForAllLanes();
            AssertLapTimeNetOfAllLanes(secs);
        }

        private void TestLapTimeWithoutPause(int secs)
        {
            AddLapsForAllLanesAndWait(secs);
            AddLapsForAllLanes();
            AssertLapTimeOfAllLanes(secs);
        }

        private void AssertLapTimeOfAllLanes(int secs)
        {
            Assert.IsTrue(Math.Abs(Lane1.LapTime.Value.TotalSeconds) < secs*(1 + EpsilonFactor));
            Assert.IsTrue(Math.Abs(Lane2.LapTime.Value.TotalSeconds) < secs*(1 + EpsilonFactor));
            Assert.IsTrue(Math.Abs(Lane3.LapTime.Value.TotalSeconds) < secs*(1 + EpsilonFactor));
            Assert.IsTrue(Math.Abs(Lane4.LapTime.Value.TotalSeconds) < secs*(1 + EpsilonFactor));
            Assert.IsTrue(Math.Abs(Lane5.LapTime.Value.TotalSeconds) < secs*(1 + EpsilonFactor));
            Assert.IsTrue(Math.Abs(Lane6.LapTime.Value.TotalSeconds) < secs*(1 + EpsilonFactor));
        }

        private void AddLapsForAllLanesAndWait(int secs)
        {
            _createInitialLanesFunc = CreateInitialLanesWithCountOf6;
            StartRace();
            AddLapsForAllLanes();
            WaitSeconds(secs);
        }

        private void AddLapsForAllLanes()
        {
            AddLapFor(LaneId.Lane1);
            AddLapFor(LaneId.Lane2);
            AddLapFor(LaneId.Lane3);
            AddLapFor(LaneId.Lane4);
            AddLapFor(LaneId.Lane5);
            AddLapFor(LaneId.Lane6);
        }

        protected override void CreateInitialLanes()
        {
            _createInitialLanesFunc();
        }

        private void CreateInitialLanesWithCountOf6()
        {
            CreateInitialLanesWithCountOf(6);
        }

        private void CreateInitialLanesWithCountOf(int count)
        {
            const float tankMaximumInLitres = 100f;
            const float fuelconsumptionFactor = 1f;

            InitialLanes = new List<InitialLane>();

            for (int id = 0; id < count; id++)
            {
                Driver driver = CreateNewDriver(id);
                Car car = CreateNewCar(id);
                InitialLanes.Add(new InitialLane((LaneId)id, tankMaximumInLitres, fuelconsumptionFactor, driver, car));
            }
        }
    }
}
