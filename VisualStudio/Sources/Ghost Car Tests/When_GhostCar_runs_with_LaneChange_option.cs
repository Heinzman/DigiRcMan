using Elreg.BusinessObjects;
using Elreg.GhostCarService.Replay;
using NUnit.Framework;

namespace Elreg.UnitTests.GhostCar
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_GhostCar_runs_with_LaneChange_option : GhostBaseTest
    {
        [SetUp]
        public void Initialize()
        {
            InitGhostCarRace();
            StartRaceWithRecordedLap();
        }

        private void StartRaceWithRecordedLap()
        {
            ReplayOptions replayOptions = GhostcarsService.GetReplayOptionsBy(Ghost.GhostA);
            replayOptions.DefaultSpeed = 3;
            replayOptions.IsLaneChangeActivated = true;
            replayOptions.IsRecordedLapActivated = false;
            replayOptions.IsLaneChangeSupressed = false;
            replayOptions.LaneChangeFrequency = GhostCarLaneChangeFrequency.Often;
            RaceModel.StartRaceCheckCountDown();
        }

        [Test]
        public void LaneChange_must_not_happen_Before_ZerothLap()
        {
            int laneChangeCount = GetLaneChangeCount();
            Assert.IsTrue(laneChangeCount == 0);
        }

        [Test]
        public void LaneChange_should_happen_After_ZerothLap()
        {
            MockGhostCarSerialPortParser.AddLapFor(LaneIdOfGhostcarA);
            int laneChangeCount = GetLaneChangeCount();
            Assert.IsTrue(laneChangeCount > 0);
        }

        [Test]
        public void LaneChange_must_not_happen_After_Pause()
        {
            PauseAndRestartRace();
            int laneChangeCount = GetLaneChangeCount();
            Assert.IsTrue(laneChangeCount == 0);
        }

        private int GetLaneChangeCount()
        {
            int laneChangeCount = 0;
            for (int i = 0; i < 1000; i++)
            {
                WaitMilliSeconds(2);
                if (IsButtonPressedOfGhostA)
                    laneChangeCount++;
            }
            return laneChangeCount;
        }
    }
}
