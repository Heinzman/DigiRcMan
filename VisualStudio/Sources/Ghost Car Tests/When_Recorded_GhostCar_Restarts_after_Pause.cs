using Elreg.BusinessObjects;
using Elreg.GhostCarService.Replay;
using NUnit.Framework;

namespace Elreg.UnitTests.GhostCar
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_Recorded_GhostCar_Restarts_after_Pause : GhostBaseTest
    {
        private const uint DefaultSpeed = 3;

        [SetUp]
        public void Initialize()
        {
            InitGhostCarRace();
            StartRaceWithRecordedLap();
            PauseAndRestartRace();
        }

        [Test]
        public void Ghostcar_should_have_default_Speed()
        {
            Assert.AreEqual(DefaultSpeed, CurrentControllerValueA);
        }

        private void StartRaceWithRecordedLap()
        {
            ReplayOptions replayOptions = GhostcarsService.GetReplayOptionsBy(Ghost.GhostA);
            replayOptions.DefaultSpeed = 3;
            replayOptions.IsLaneChangeActivated = true;
            replayOptions.IsRecordedLapActivated = true;
            replayOptions.IsLaneChangeSupressed = false;
            replayOptions.LaneChangeFrequency = GhostCarLaneChangeFrequency.Often;
            replayOptions.RecordedLapData = LoadRecordedLapDataFromFile();
            RaceModel.StartRaceCheckCountDown();
        }

    }
}
