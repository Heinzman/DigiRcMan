using Elreg.BusinessObjects.Races;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.PitInDetectionTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_ButtonIsPressed_While_RestartCountDown : PitInDetectionTest
    {
        [Test]
        public void PitIn_Must_Not_Be_Detected_After_CountDown()
        {
            RaceSettings.StartCountDownRaceActivated = false;
            RaceSettings.RestartCountDownRaceActivated = true;
            InitAndStartRace();
            Assert.AreEqual(Race.StatusEnum.Started, RaceModel.Race.Status);
            RaceModel.PauseRaceByKeyboard();
            RaceModel.RestartRaceByKeyboardOrArduinoCheckCountDown();
            Assert.AreEqual(Race.StatusEnum.RestartCountDown, RaceModel.Race.Status);
            Assert.IsFalse(Lane1.IsInPitstop);
            MockControllerDataSupplier.SetCarControllersActionFor(Lane1.Id, 0, true);
            WaitSecondsForCountDownFinished();
            Assert.AreEqual(Race.StatusEnum.Restarted, RaceModel.Race.Status);
            WaitSecondsForPitstopInDetection();
            Assert.IsFalse(Lane1.IsInPitstop);
        }
    }
    // ReSharper restore InconsistentNaming

}
