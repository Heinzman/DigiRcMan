using Elreg.BusinessObjects;
using Elreg.GhostCarService.Replay;
using NUnit.Framework;

namespace Elreg.UnitTests.GhostCar
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_Second_ConstSpeedGhostCar_Is_Back_To_Recorded_Less_Than_MinSecs : GhostBaseTest
    {
        private const uint DefaultSpeedOfFirstGhost = 3;
        private const uint DefaultSpeedOfSecondGhost = 6;

        [Test]
        public void Second_GhostCar_should_reduce_speed_GhostcarAIsFirst()
        {
            InitGhostCarRace();
            const Ghost firstGhost = Ghost.GhostA;
            const Ghost secondGhost = Ghost.GhostB;
            LaneId laneIdOfFirstGhost = LaneIdOfGhostcarA;
            LaneId laneIdOfSecondGhost = LaneIdOfGhostcarB;

            Second_GhostCar_should_reduce_speed(laneIdOfSecondGhost, laneIdOfFirstGhost, firstGhost, secondGhost);
        }

        [Test]
        public void Second_GhostCar_should_reduce_speed_GhostcarBIsFirst()
        {
            InitGhostCarRace();
            const Ghost firstGhost = Ghost.GhostB;
            const Ghost secondGhost = Ghost.GhostA;
            LaneId laneIdOfFirstGhost = LaneIdOfGhostcarB;
            LaneId laneIdOfSecondGhost = LaneIdOfGhostcarA;

            Second_GhostCar_should_reduce_speed(laneIdOfSecondGhost, laneIdOfFirstGhost, firstGhost, secondGhost);
        }

        [Test]
        public void Second_GhostCar_should_have_defaultSpeed_after_next_lap_with_correct_distance_GhostcarAIsFirst()
        {
            InitGhostCarRace();
            const Ghost firstGhost = Ghost.GhostA;
            const Ghost secondGhost = Ghost.GhostB;
            LaneId laneIdOfFirstGhost = LaneIdOfGhostcarA;
            LaneId laneIdOfSecondGhost = LaneIdOfGhostcarB;
            Second_GhostCar_should_reduce_speed(laneIdOfSecondGhost, laneIdOfFirstGhost, firstGhost, secondGhost);
            Second_GhostCar_should_have_defaultSpeed_after_next_lap_with_correct_distance(secondGhost, laneIdOfSecondGhost, laneIdOfFirstGhost);
        }

        [Test]
        public void Second_GhostCar_should_have_defaultSpeed_after_next_lap_with_correct_distance_GhostcarBIsFirst()
        {
            InitGhostCarRace();
            const Ghost firstGhost = Ghost.GhostB;
            const Ghost secondGhost = Ghost.GhostA;
            LaneId laneIdOfFirstGhost = LaneIdOfGhostcarB;
            LaneId laneIdOfSecondGhost = LaneIdOfGhostcarA;
            Second_GhostCar_should_reduce_speed(laneIdOfSecondGhost, laneIdOfFirstGhost, firstGhost, secondGhost);
            Second_GhostCar_should_have_defaultSpeed_after_next_lap_with_correct_distance(secondGhost, laneIdOfSecondGhost, laneIdOfFirstGhost);
        }

        private void Second_GhostCar_should_have_defaultSpeed_after_next_lap_with_correct_distance(Ghost secondGhost, LaneId laneIdOfSecondGhost,
                                                                                                   LaneId laneIdOfFirstGhost)
        {
            MockGhostCarSerialPortParser.AddLapFor(laneIdOfFirstGhost);
            WaitMoreThanMinDistanceInSecs();
            MockGhostCarSerialPortParser.AddLapFor(laneIdOfSecondGhost);
            WaitSomeGhostMilliSeconds();
            Assert.IsTrue(GetArduinoValueMappedAsSpeedOf(secondGhost) == DefaultSpeedOfSecondGhost);
        }

        private void Second_GhostCar_should_reduce_speed(LaneId laneIdOfSecondGhost, LaneId laneIdOfFirstGhost, Ghost firstGhost, Ghost secondGhost)
        {
            SetGhostCarOptionsToRecorded(firstGhost, DefaultSpeedOfFirstGhost);
            SetGhostCarOptionsToConstSpeed(secondGhost, DefaultSpeedOfSecondGhost);
            RaceModel.StartRaceCheckCountDown();
            MockGhostCarSerialPortParser.AddLapFor(laneIdOfSecondGhost);

            WaitSomeGhostMilliSeconds();
            Assert.IsTrue(GetArduinoValueMappedAsSpeedOf(secondGhost) == DefaultSpeedOfSecondGhost);

            MockGhostCarSerialPortParser.AddLapFor(laneIdOfFirstGhost);
            MockGhostCarSerialPortParser.AddLapFor(laneIdOfFirstGhost);
            WaitLessThanMinDistanceInSecs();
            MockGhostCarSerialPortParser.AddLapFor(laneIdOfSecondGhost);

            WaitSomeGhostMilliSeconds();
            const uint expectedSpeedOfSecondGhost = DefaultSpeedOfSecondGhost - 1;
            Assert.AreEqual(expectedSpeedOfSecondGhost, GetArduinoValueMappedAsSpeedOf(secondGhost));
        }

        private void SetGhostCarOptionsToConstSpeed(Ghost ghost, uint defaultSpeed)
        {
            ReplayOptions replayOptions = GhostcarsService.GetReplayOptionsBy(ghost);
            replayOptions.DefaultSpeed = defaultSpeed;
            replayOptions.IsLaneChangeActivated = false;
            replayOptions.IsRecordedLapActivated = false;
            replayOptions.IsLaneChangeSupressed = false;
            replayOptions.LaneChangeFrequency = GhostCarLaneChangeFrequency.Often;
        }

        protected override void InitGhostcarsService()
        {
            base.InitGhostcarsService();
            ActivateDistanceHandler();
        }

    }
}
