using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;
using Elreg.DomainModels;
using Elreg.UnitTests.MockObjects;
using NUnit.Framework;

namespace Elreg.UnitTests.GhostCar
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_RaceParticipation_And_AutoDetectionFirstLap_Is_Activated : GhostBaseTest
    {
        [SetUp]
        public void Initialize()
        {
            InitGhostCarRace();
            InitAutoDetection();
            RaceModel.StartRaceCheckCountDown();
        }

        private void InitAutoDetection()
        {
            RaceSettings.AutoDetectLapSpeedFactor = 1;
            RaceSettings.StartCountDownRaceActivated = false;
            RaceSettings.RestartCountDownRaceActivated = false;
            RaceModel.SpeedSumAvgCalculator = new SpeedSumAvgCalculator();
            RaceModel.LapTimeAvgCalculator = new MockLapTimeAvgCalculator();
            AutoDetectLapSpeedSum = 20;
        }

        protected override void InitInitialLanes()
        {
            InitialLanes = new List<InitialLane>();
            Driver driver1 = new Driver { Name = "Driver1", Id = 1 };
            Driver ghostCar1 = GhostcarsService.Ghostcars[0];
            Driver driver3 = new Driver { Name = "Driver3", Id = 3 };
            Car car1 = new Car { Name = "Car1", Id = 1 };
            Car car2 = new Car { Name = "Car2", Id = 2 };
            Car car3 = new Car { Name = "Car3", Id = 3 };
            const float tankMaximumInLitres = 100f;
            const float fuelconsumptionFactor = 1f;
            InitialLanes.Add(new InitialLane(LaneId.Lane1, tankMaximumInLitres, fuelconsumptionFactor, driver1, car1));
            InitialLanes.Add(new InitialLane(LaneIdOfGhostcarA, tankMaximumInLitres, fuelconsumptionFactor, ghostCar1, car2));
            InitialLanes.Add(new InitialLane(LaneId.Lane3, tankMaximumInLitres, fuelconsumptionFactor, driver3, car3));
        }

        [Test]
        public void FirstLap_of_Ghostcar_must_not_be_detected()
        {
            AddLapAndAddSpeedSumTenTimesOf(LaneId.Lane1, 1);
            AddLapAndAddSpeedSumTenTimesOf(LaneId.Lane3, 1);
            Lane lane = RaceModel.RaceHandler.GetLaneById(LaneIdOfGhostcarA);
            AddSpeedSumTenTimesOf(LaneIdOfGhostcarA, 2);
            Assert.AreEqual(-1, lane.Lap);
        }

        [Test]
        public void Ghostcar_must_not_be_counted_as_speedsum()
        {
            AddLapAndAddSpeedSumTenTimesOf(LaneId.Lane1, 1);
            AddLapAndAddSpeedSumTenTimesOf(LaneIdOfGhostcarA, 1);
            AddSpeedSumTenTimesOf(LaneId.Lane3, 2);
            Assert.AreEqual(-1, Lane3.Lap);
        }

        private void AddLapAndAddSpeedSumTenTimesOf(LaneId laneId, uint speedSum)
        {
            AddSpeedSumTenTimesOf(laneId, speedSum);
            MockRaceDataProvider.RaiseAddLapForLane(laneId);
        }

        private void AddSpeedSumTenTimesOf(LaneId laneId, uint speedSum)
        {
            for (int i = 0; i < 10; i++)
                MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(laneId, speedSum, new List<uint> {speedSum});
        }

        protected override void InitGhostcarsService()
        {
            base.InitGhostcarsService();
            GhostcarsService.GhostcarsOptions.RaceParticipation = true;
        }
    }
}
