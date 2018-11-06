using Elreg.BusinessObjects.Races;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.PitInDetectionTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_ButtonIsPressed_For_MinSecs_After_RestartCountDown : PitInDetectionTest
    {
        [Test]
        public void PitIn_Should_Be_Detected()
        {
            StartTraceLogging();
            RaceSettings.RestartCountDownRaceActivated = true;
            InitAndStartRace();
            Assert.AreEqual(Race.StatusEnum.Started, RaceModel.Race.Status);
            RaceModel.PauseRaceByKeyboard();
            RaceModel.RestartRaceByKeyboardOrArduinoCheckCountDown();
            Assert.AreEqual(Race.StatusEnum.RestartCountDown, RaceModel.Race.Status);
            Assert.IsFalse(Lane1.IsInPitstop);
            WaitSecondsForCountDownFinished();
            Assert.AreEqual(Race.StatusEnum.Restarted, RaceModel.Race.Status);
            MockControllerDataSupplier.SetCarControllersActionFor(Lane1.Id, 0, true);
            WaitSecondsForPitstopInDetection();
            StopTraceLogging();
            Assert.IsTrue(Lane1.IsInPitstop);
        }
    }
    // ReSharper restore InconsistentNaming

}
