using Elreg.BusinessObjects;
using NUnit.Framework;

namespace Elreg.UnitTests.GhostCar
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_Second_RecordedGhostCar_Is_Back_Less_Than_MinSecs : GhostBaseTest
    {
        private const uint DefaultSpeed = 3;

        [Test]
        public void Second_GhostCar_should_switch_to_Default_Speed_GhostcarAIsFirst()
        {
            InitGhostCarRace();
            const Ghost firstGhost = Ghost.GhostA;
            const Ghost secondGhost = Ghost.GhostB;
            LaneId laneIdOfFirstGhost = LaneIdOfGhostcarA;
            LaneId laneIdOfSecondGhost = LaneIdOfGhostcarB;

            Second_GhostCar_should_switch_to_Default_Speed(laneIdOfSecondGhost, laneIdOfFirstGhost, firstGhost, secondGhost);
        }

        [Test]
        public void Second_GhostCar_should_switch_to_Default_Speed_GhostcarBIsFirst()
        {
            InitGhostCarRace();
            const Ghost firstGhost = Ghost.GhostB;
            const Ghost secondGhost = Ghost.GhostA;
            LaneId laneIdOfFirstGhost = LaneIdOfGhostcarB;
            LaneId laneIdOfSecondGhost = LaneIdOfGhostcarA;

            Second_GhostCar_should_switch_to_Default_Speed(laneIdOfSecondGhost, laneIdOfFirstGhost, firstGhost, secondGhost);
        }

        [Test]
        public void Second_GhostCar_should_switch_to_RecordedLap_after_next_lap_with_correct_distance_GhostcarAIsFirst()
        {
            InitGhostCarRace();
            const Ghost firstGhost = Ghost.GhostA;
            const Ghost secondGhost = Ghost.GhostB;
            LaneId laneIdOfFirstGhost = LaneIdOfGhostcarA;
            LaneId laneIdOfSecondGhost = LaneIdOfGhostcarB;

            Second_GhostCar_should_switch_to_RecordedLap_after_next_lap_with_correct_distance(firstGhost, secondGhost, laneIdOfSecondGhost, laneIdOfFirstGhost);
        }

        [Test]
        public void Second_GhostCar_should_switch_to_RecordedLap_after_next_lap_with_correct_distance_GhostcarBIsFirst()
        {
            InitGhostCarRace();
            const Ghost firstGhost = Ghost.GhostB;
            const Ghost secondGhost = Ghost.GhostA;
            LaneId laneIdOfFirstGhost = LaneIdOfGhostcarB;
            LaneId laneIdOfSecondGhost = LaneIdOfGhostcarA;

            Second_GhostCar_should_switch_to_RecordedLap_after_next_lap_with_correct_distance(firstGhost, secondGhost, laneIdOfSecondGhost, laneIdOfFirstGhost);
        }

        private void Second_GhostCar_should_switch_to_Default_Speed(LaneId laneIdOfSecondGhost, LaneId laneIdOfFirstGhost, Ghost firstGhost, Ghost secondGhost)
        {
            SetGhostCarOptionsToRecorded(firstGhost, DefaultSpeed);
            SetGhostCarOptionsToRecorded(secondGhost, DefaultSpeed);
            RaceModel.StartRaceCheckCountDown();
            MockGhostCarSerialPortParser.AddLapFor(laneIdOfSecondGhost);

            WaitSomeGhostMilliSeconds();
            Assert.IsTrue(GetArduinoValueMappedAsSpeedOf(secondGhost) > DefaultSpeed);

            MockGhostCarSerialPortParser.AddLapFor(laneIdOfFirstGhost);
            MockGhostCarSerialPortParser.AddLapFor(laneIdOfFirstGhost);
            WaitLessThanMinDistanceInSecs();
            MockGhostCarSerialPortParser.AddLapFor(laneIdOfSecondGhost);

            WaitSomeGhostMilliSeconds();
            Assert.AreEqual(DefaultSpeed, GetArduinoValueMappedAsSpeedOf(secondGhost));
        }

        private void Second_GhostCar_should_switch_to_RecordedLap_after_next_lap_with_correct_distance(Ghost firstGhost, Ghost secondGhost,
                                                                                                      LaneId laneIdOfSecondGhost, LaneId laneIdOfFirstGhost)
        {
            Second_GhostCar_should_switch_to_Default_Speed(laneIdOfSecondGhost, laneIdOfFirstGhost, firstGhost, secondGhost);
            MockGhostCarSerialPortParser.AddLapFor(laneIdOfFirstGhost);
            WaitMoreThanMinDistanceInSecs();
            MockGhostCarSerialPortParser.AddLapFor(laneIdOfSecondGhost);

            WaitSomeGhostMilliSeconds();
            Assert.IsTrue(GetArduinoValueMappedAsSpeedOf(secondGhost) > DefaultSpeed);
        }

        protected override void InitGhostcarsService()
        {
            base.InitGhostcarsService();
            ActivateDistanceHandler();
        }

    }
}
